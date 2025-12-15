using System;
using System.Threading;
using System.Diagnostics;



namespace AVcontrol
{
    public class SecureRandom : IDisposable
    {
        private readonly UInt32[] _state = new UInt32[16];
        private readonly Byte[]  _buffer;
        private Int32  _bufferPos;
        private bool   _disposed = false;

        private UInt64 _bytesGenerated = 0;
        private readonly UInt64 RESEED_INTERVAL = 1024 * 1024;  //  Reseed every 1MB (default)

        /// <summary>
        /// For rng reseeding interval in bytes generated. Minimum is 128 bytes. 
        /// If the minimum wi=ont be tolerated, it will be force set to 128 bytes.
        /// </summary>
        /// <param name="reseedAfterBytesGenerated"></param> min value = 128 bytes
        public SecureRandom(UInt64 reseedAfterBytesGenerated = 1024 * 1024) : this(GenerateTrueHardwareSeed()) 
        {
            if (reseedAfterBytesGenerated < 128) reseedAfterBytesGenerated = 128;
            RESEED_INTERVAL = reseedAfterBytesGenerated; 
        }
        public SecureRandom(Byte[] seed)
        {
            if (seed == null || seed.Length != 32) throw new ArgumentException("Seed must be 32 bytes", nameof(seed));

            InitializeState(seed);
            _buffer = new Byte[64];
            _bufferPos = 64;  //  Force generate first block
        }

        private void InitializeState(Byte[] seed)
        {
            UInt32[] result = new UInt32[16];

            //  ChaCha20 constants
            result[0] = 0x61707865;
            result[1] = 0x3320646e;
            result[2] = 0x79622d32;
            result[3] = 0x6b206574;

            //  Convert to 256 bit
            for (var i = 0; i < 8; i++) result[4 + i] = BitConverter.ToUInt32(seed, i * 4);

            //  Counter and nonce
            result[12] = 0;
            result[13] = 0;
            result[14] = BitConverter.ToUInt32(seed, 16);
            result[15] = BitConverter.ToUInt32(seed, 20);

            Array.Copy(result, _state, 16);
        }



        public  void Reseed()
        {
            Byte[] newSeed = new Byte[32];

            for (var i = 0; i < newSeed.Length; i += 8)
            {
                UInt64 random = NextULongInternal();
                Byte[] bytes = BitConverter.GetBytes(random);

                Int32 bytesToCopy = Math.Min(8, newSeed.Length - i);
                Buffer.BlockCopy(bytes, 0, newSeed, i, bytesToCopy);
            }

            AddExtraEntropy(newSeed);
            InitializeState(newSeed);

            _bufferPos = 64;  //  Reset buffer position to force new block generation
            _bytesGenerated = 0;

            Array.Clear(newSeed, 0, newSeed.Length);  //  Clear sensitive data
        }
        private void GenerateBlock()
        {
            UInt32[] workingState = new UInt32[16];
            Array.Copy(_state, workingState, 16);

            //  40 (20x2) rounds of ChaCha20
            for (var i = 0; i < 20; i++)
            {
                QuarterRound(ref workingState[0], ref workingState[4], ref workingState[8], ref workingState[12]);
                QuarterRound(ref workingState[1], ref workingState[5], ref workingState[9], ref workingState[13]);
                QuarterRound(ref workingState[2], ref workingState[6], ref workingState[10], ref workingState[14]);
                QuarterRound(ref workingState[3], ref workingState[7], ref workingState[11], ref workingState[15]);

                QuarterRound(ref workingState[0], ref workingState[5], ref workingState[10], ref workingState[15]);
                QuarterRound(ref workingState[1], ref workingState[6], ref workingState[11], ref workingState[12]);
                QuarterRound(ref workingState[2], ref workingState[7], ref workingState[8], ref workingState[13]);
                QuarterRound(ref workingState[3], ref workingState[4], ref workingState[9], ref workingState[14]);
            }

            for (var i = 0; i < 16; i++) workingState[i] += _state[i];

            for (var i = 0; i < 16; i++)
            {
                Byte[] word = BitConverter.GetBytes(workingState[i]);
                Array.Copy(word, 0, _buffer, i * 4, 4);
            }

            _state[12]++;
            if (_state[12] == 0) _state[13]++;

            _bufferPos = 0;
            _bytesGenerated += 64;

            //  Auto reseed
            if (_bytesGenerated >= RESEED_INTERVAL)
            {
                Reseed();
                GenerateBlock();
            }

            Array.Clear(workingState, 0, workingState.Length);
        }
        private static void AddExtraEntropy(Byte[] seed)
        {
            //  Hardware entropy
            Int64 extraEntropy = Stopwatch.GetTimestamp() ^ Environment.TickCount;
            extraEntropy ^= GC.GetTotalMemory(false) ^ Environment.ProcessId;

            Byte[] extraBytes = BitConverter.GetBytes(extraEntropy);
            for (var i = 0; i < extraBytes.Length && i < seed.Length; i++) seed[i] ^= extraBytes[i];

            for (var i = 0; i < 10; i++)
            {
                Thread.Sleep(0);

                Int64 timing = Stopwatch.GetTimestamp();
                Byte[] timingBytes = BitConverter.GetBytes(timing);
                Int32  index = i % (seed.Length - timingBytes.Length);

                for (var j = 0; j < timingBytes.Length && (index + j) < seed.Length; j++)
                    seed[index + j] ^= timingBytes[j];
            }
        }



        public Int32  SecureNext()
        {
            Reseed();
            Int32 result = NextInternal();
            Reseed();
            return result;
        }
        public Int32  SecureNext(Int32 maxValue)
        {
            Reseed();
            Int32 result = NextInternal(maxValue);
            Reseed();
            return result;
        }
        public Int32  SecureNext(Int32 minValue, Int32 maxValue)
        {
            Reseed();
            Int32 result = NextInternal(minValue, maxValue);
            Reseed();
            return result;
        }

        public UInt64 SecureNextULong()
        {
            Reseed();
            UInt64 result = NextULongInternal();
            Reseed();
            return result;
        }
        public double SecureNextDouble()
        {
            Reseed();
            double result = NextDoubleInternal();
            Reseed();
            return result;
        }
        public void   SecureNextBytes(Byte[] buffer)
        {
            Reseed();
            NextBytesInternal(buffer);
            Reseed();
        }



        public Int32  Next() => NextInternal();
        public Int32  Next(Int32 maxValue) => NextInternal(maxValue);
        public Int32  Next(Int32 minValue, Int32 maxValue) => NextInternal(minValue, maxValue);

        public UInt64 NextULong()  => NextULongInternal();
        public double NextDouble() => NextDoubleInternal();
        public void   NextBytes(Byte[] buffer) => NextBytesInternal(buffer);



        private Int32 NextInternal(Int32 maxValue)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(maxValue);

            return (Int32)(NextULongInternal() % (UInt32)maxValue);
        }
        private Int32 NextInternal(Int32 minValue, Int32 maxValue)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(minValue, maxValue);

            Int64 range = (Int64)maxValue - minValue;
            if (range <= 0) return minValue;

            return (Int32)(NextULongInternal() % (UInt64)range) + minValue;
        }
        private Int32 NextInternal() => (Int32)(NextULongInternal() & 0x7FFFFFFF);

        private UInt64 NextULongInternal()
        {
            Byte[] bytes = new Byte[8];

            NextBytesInternal(bytes);
            return BitConverter.ToUInt64(bytes, 0);
        }
        private void   NextBytesInternal(Byte[] buffer)
        {
            ObjectDisposedException.ThrowIf(_disposed, nameof(SecureRandom));
            ArgumentNullException.ThrowIfNull(buffer);

            for (var i = 0; i < buffer.Length; i++)
            {
                if (_bufferPos >= 64) GenerateBlock();

                buffer[i] = _buffer[_bufferPos++];
            }
        }
        private double NextDoubleInternal() => (NextULongInternal() >> 11) * (1.0 / (1UL << 53));



        private static Byte[] GenerateTrueHardwareSeed()
        {
            Byte[] seed = new Byte[32];

            UInt64[] entropy = CollectHardwareEntropy();
            MixEntropy(entropy, seed);
            FinalMixWithTiming(seed);

            return seed;
        }
        private static UInt64[] CollectHardwareEntropy()
        {
            const bool forceFullCollection = true;
            UInt64[] entropy = new UInt64[8];

            Int64 ticks1 = DateTime.UtcNow.Ticks;
            Thread.Sleep(1);
            Int64 ticks2 = DateTime.UtcNow.Ticks;

            Int64 memory1 = GC.GetTotalMemory(!forceFullCollection);
            Thread.Sleep(1);
            Int64 memory2 = GC.GetTotalMemory(forceFullCollection);

            Int32 processId = Environment.ProcessId;
            Int32 threadId = Environment.CurrentManagedThreadId;

            Int64 timestamp = Stopwatch.GetTimestamp();
            Int32 tickCount = Environment.TickCount;

            entropy[0] = (UInt64)ticks1;
            entropy[1] = (UInt64)ticks2;
            entropy[2] = (UInt64)memory1;
            entropy[3] = (UInt64)memory2;
            entropy[4] = (UInt64)processId;
            entropy[5] = (UInt64)threadId;
            entropy[6] = (UInt64)timestamp;
            entropy[7] = (UInt64)tickCount;

            return entropy;
        }

        private static void MixEntropy(UInt64[] entropy, Byte[] output)
        {
            UInt64 mixer = 0;

            foreach (UInt64 value in entropy) 
                mixer = RotateLeft(mixer ^ value, 17) + 0x9E3779B97F4A7C15;

            for (var i = 0; i < 1000; i++)
            {
                mixer = RotateLeft(mixer * 0xBF58476D1CE4E5B9, 31);
                mixer ^= (UInt64)i;
            }

            var tempRng = new SimpleEntropyMixer(mixer);

            for (var i = 0; i < output.Length; i += 8)
            {
                UInt64 random = tempRng.NextULong();
                Byte[] bytes = BitConverter.GetBytes(random);

                Int32 bytesToCopy = Math.Min(8, output.Length - i);
                Buffer.BlockCopy(bytes, 0, output, i, bytesToCopy);
            }
        }
        private static void FinalMixWithTiming(Byte[] seed)
        {
            Byte[] temp = new Byte[seed.Length];
            Array.Copy(seed, temp, seed.Length);

            var timingMixer = new SimpleEntropyMixer((UInt64)Stopwatch.GetTimestamp());

            for (var round = 0; round < 100; round++)
            {
                Int64 start = Stopwatch.GetTimestamp();

                for (var i = 0; i < seed.Length; i++)
                {
                    seed[i] ^= (Byte)(timingMixer.NextULong() & 0xFF);
                    seed[i] = (Byte)((seed[i] << 3) | (seed[i] >> 5));
                }

                Int64 end = Stopwatch.GetTimestamp();
                timingMixer.AddEntropy((UInt64)(end - start));
                Thread.Sleep(0);
            }
        }



        private static UInt64 RotateLeft(UInt64 value, Int32 offset) => (value << offset) | (value >> (64 - offset));
        private static UInt32 RotateLeft(UInt32 value, Int32 offset) => (value << offset) | (value >> (32 - offset));



        private static void QuarterRound(ref UInt32 a, ref UInt32 b, ref UInt32 c, ref UInt32 d)
        {
            a += b; d = RotateLeft(d ^ a, 16);
            c += d; b = RotateLeft(b ^ c, 12);
            a += b; d = RotateLeft(d ^ a, 8);
            c += d; b = RotateLeft(b ^ c, 7);
        }



        public void Dispose()
        {
            if (!_disposed)
            {
                if (_state  != null) Array.Clear(_state,  0, _state.Length);
                if (_buffer != null) Array.Clear(_buffer, 0, _buffer.Length);

                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }



        private class SimpleEntropyMixer
        {
            private UInt64 _state;

            public SimpleEntropyMixer(UInt64 seed)
            {
                _state = seed;
                for (var i = 0; i < 100; i++) NextULong();
            }



            public void AddEntropy(UInt64 value)
            {
                _state ^= RotateLeft(value, 13);
                NextULong();
            }

            public UInt64 NextULong()
            {
                _state ^= _state >> 12;
                _state ^= _state << 25;
                _state ^= _state >> 27;
                return _state * 0x2545F4914F6CDD1D;
            }
        }
    }
}