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


        static private void TypeArgumentCheck<T>()
        {
            if (typeof(T) != typeof(Byte) &&
                typeof(T) != typeof(SByte) &&
                typeof(T) != typeof(Int16) &&
                typeof(T) != typeof(UInt16) &&
                typeof(T) != typeof(Int32) &&
                typeof(T) != typeof(UInt32) &&
                typeof(T) != typeof(Int64) &&
                typeof(T) != typeof(UInt64))
                throw new InvalidOperationException("Type T must be (S)Byte, (U)Int16, (U)Int32, or (U)Int64");
        }



        public T Next<T>()
        {
            TypeArgumentCheck<T>();
            return (T)Convert.ChangeType(NextULong() & 0x7FFFFFFF, typeof(T));
        }
        public T Next<T>(T positiveExclusiveMaxValue)
        {
            TypeArgumentCheck<T>();

            UInt64 parsedMaxValue = Convert.ToUInt64(positiveExclusiveMaxValue);
            if    (parsedMaxValue == 0) return (T)(object)0;

            ArgumentOutOfRangeException.ThrowIfNegative(parsedMaxValue);

            return (T)Convert.ChangeType(NextULong() % parsedMaxValue, typeof(T));
        }
        public T Next<T>(T positiveInclusiveMinValue, T positiveExclusiveMaxValue)
        {
            TypeArgumentCheck<T>();

            UInt64 parsedMaxValue = Convert.ToUInt64(positiveExclusiveMaxValue);
            UInt64 parsedMinValue = Convert.ToUInt64(positiveInclusiveMinValue);

            ArgumentOutOfRangeException.ThrowIfGreaterThan(parsedMinValue, parsedMaxValue);

            UInt64 range = parsedMaxValue - parsedMinValue;
            if (range <= 0) return (T)Convert.ChangeType(parsedMinValue, typeof(T));

            return (T)Convert.ChangeType((NextULong() % range) + parsedMinValue, typeof(T));
        }

        public Byte[] NextBytes(Int32 length)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(length);

            Byte[] buffer = new Byte[length];

            for (var i = 0; i < length;)
            {
                UInt64 random = NextULong();

                for (var j = 0; j < 8 && i < length; j++, i++)
                {
                    buffer[i] = (Byte)(random & 0xFF);
                    random >>= 8;
                }
            }
            return buffer;
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



        private class SplitMix64(UInt64 seed)
        {
            private UInt64 _seed = seed;

            public UInt64 Next()
            {
                UInt64 z = (_seed += 0x9E3779B97F4A7C15);
                z = (z ^ (z >> 30)) * 0xBF58476D1CE4E5B9;
                z = (z ^ (z >> 27)) * 0x94D049BB133111EB;
                return z ^ (z >> 31);
            }
        }
    }
}