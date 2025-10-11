using System;


namespace AVcontrol
{
    public class FastRandom  // Xoshiro256++
    {
        private readonly UInt64[] _state = new UInt64[4];

        public FastRandom() : this((UInt64)Environment.TickCount) { }
        public FastRandom(UInt64 seed)
        {
            var init = new SplitMix64(seed);

            for (var i = 0; i < 4; i++) _state[i] = init.Next();
        }



        public Int32 Next() => (Int32)(NextULong() & 0x7FFFFFFF);
        public Int32 Next(Int32 maxValue)
        {
            if (maxValue <= 0) throw new ArgumentOutOfRangeException(nameof(maxValue));

            return (Int32)(NextULong() % (uint)maxValue);
        }
        public Int32 Next(Int32 minValue, Int32 maxValue)
        {
            if (minValue > maxValue) throw new ArgumentOutOfRangeException(nameof(minValue));

            Int64 range = (Int64)maxValue - minValue;
            if (range <= 0) return minValue;

            return (Int32)(NextULong() % (UInt64)range) + minValue;
        }
        public void NextBytes(byte[] buffer)
        {
            if (buffer == null) throw new ArgumentNullException(nameof(buffer));

            for (var i = 0; i < buffer.Length;)
            {
                UInt64 random = NextULong();

                for (var j = 0; j < 8 && i < buffer.Length; j++, i++)
                {
                    buffer[i] = (byte)(random & 0xFF);
                    random >>= 8;
                }
            }
        }
        public UInt64 NextULong()
        {
            UInt64 result = RotateLeft(_state[0] + _state[3], 23) + _state[0];
            UInt64 t = _state[1] << 17;

            _state[2] ^= _state[0];
            _state[3] ^= _state[1];
            _state[1] ^= _state[2];
            _state[0] ^= _state[3];

            _state[2] ^= t;
            _state[3] = RotateLeft(_state[3], 45);

            return result;
        }
        public double NextDouble() => (NextULong() >> 11) * (1.0 / (1UL << 53));

        private static UInt64 RotateLeft(UInt64 value, Int32 offset) => (value << offset) | (value >> (64 - offset));



        private class SplitMix64
        {
            private UInt64 _x;

            public SplitMix64(UInt64 seed) => _x = seed;

            public UInt64 Next()
            {
                UInt64 z = (_x += 0x9E3779B97F4A7C15);
                z = (z ^ (z >> 30)) * 0xBF58476D1CE4E5B9;
                z = (z ^ (z >> 27)) * 0x94D049BB133111EB;
                return z ^ (z >> 31);
            }
        }
    }
}