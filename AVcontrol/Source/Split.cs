using System;
using System.Collections.Generic;



namespace AVcontrol
{
    public class Split
    {
        static private void BaseArgumentCheck(Int32 numbase)
        {
            if (numbase < 2 || numbase > 36)
                throw new ArgumentOutOfRangeException
                (
                    nameof(numbase),
                    "the number base must be between 2 and 36."
                );
        }



        static public List<Byte>   LittleEndianByteList  <T>(T initial, Int32 numbase)
        {
            Int64 value = Convert.ToInt64(initial);

            BaseArgumentCheck(numbase);
            if (value < numbase) return [(Byte)value];

            Int32 digitCount = (Int32)(Math.Log(value, numbase) + 1);
            var result = new List<Byte>(digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((Byte)(value / (Int64)Math.Pow(numbase, i) % numbase));

            return result;
        }
        static public List<SByte>  LittleEndianSByteList <T>(T initial, Int32 numbase)
        {
            Int64 value = Convert.ToInt64(initial);

            BaseArgumentCheck(numbase);
            if (value < numbase) return [(SByte)value];

            Int32 digitCount = (Int32)(Math.Log(value, numbase) + 1);
            var result = new List<SByte>(digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((SByte)(value / (Int64)Math.Pow(numbase, i) % numbase));

            return result;
        }

        static public List<UInt16> LittleEndianUInt16List<T>(T initial, Int32 numbase)
        {
            Int64 value = Convert.ToInt64(initial);

            BaseArgumentCheck(numbase);
            if (value < numbase) return [(UInt16)value];

            Int32 digitCount = (Int32)(Math.Log(value, numbase) + 1);
            var result = new List<UInt16>(digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((UInt16)(value / (Int64)Math.Pow(numbase, i) % numbase));

            return result;
        }
        static public List<Int16>  LittleEndianInt16List <T>(T initial, Int32 numbase)
        {
            Int64 value = Convert.ToInt64(initial);

            BaseArgumentCheck(numbase);
            if (value < numbase) return [(Int16)value];
            
            Int32 digitCount = (Int32)(Math.Log(value, numbase) + 1);
            var result = new List<Int16>(digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((Int16)(value / (Int64)Math.Pow(numbase, i) % numbase));

            return result;
        }

        static public List<Int32>  LittleEndianInt32List <T>(T initial, Int32 numbase)
        {
            Int64 value = Convert.ToInt64(initial);

            BaseArgumentCheck(numbase);
            if (value < numbase) return [(Int32)value];

            Int32 digitCount = (Int32)(Math.Log(value, numbase) + 1);
            var result = new List<Int32>(digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((Int32)(value / (Int64)Math.Pow(numbase, i) % numbase));

            return result;
        }
        static public List<UInt32> LittleEndianUInt32List<T>(T initial, Int32 numbase)
        {
            Int64 value = Convert.ToInt64(initial);

            BaseArgumentCheck(numbase);
            if (value < numbase) return [(UInt32)value];

            Int32 digitCount = (Int32)(Math.Log(value, numbase) + 1);
            var result = new List<UInt32>(digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((UInt32)(value / (Int64)Math.Pow(numbase, i) % numbase));

            return result;
        }

        static public List<Int64>  LittleEndianInt64List <T>(T initial, Int32 numbase)
        {
            Int64 value = Convert.ToInt64(initial);

            BaseArgumentCheck(numbase);
            if (value < numbase) return [value];

            Int32 digitCount = (Int32)(Math.Log(value, numbase) + 1);
            var result = new List<Int64>(digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((Int64)(value / (Int64)Math.Pow(numbase, i) % numbase));

            return result;
        }
        static public List<UInt64> LittleEndianUInt64List<T>(T initial, Int32 numbase)
        {
            Int64 value = Convert.ToInt64(initial);

            BaseArgumentCheck(numbase);
            if (value < numbase) return [(UInt64)value];

            Int32 digitCount = (Int32)(Math.Log(value, numbase) + 1);
            var result = new List<UInt64>(digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((UInt64)(value / (Int64)Math.Pow(numbase, i) % numbase));

            return result;
        }



        static public List<Byte>   BigEndianByteList <T>(T initial, Int32 numbase)
            => Utils.Reverse(LittleEndianByteList (initial, numbase));
        static public List<SByte>  BigEndianSByteList<T>(T initial, Int32 numbase)
            => Utils.Reverse(LittleEndianSByteList(initial, numbase));

        static public List<Int16>  BigEndianInt16List <T>(T initial, Int32 numbase)
            => Utils.Reverse(LittleEndianInt16List(initial, numbase));
        static public List<UInt16> BigEndianUInt16List<T>(T initial, Int32 numbase)
            => Utils.Reverse(LittleEndianUInt16List(initial, numbase));

        static public List<Int32>  BigEndianInt32List <T>(T initial, Int32 numbase)
            => Utils.Reverse(LittleEndianInt32List(initial, numbase));
        static public List<UInt32> BigEndianUInt32List<T>(T initial, Int32 numbase)
            => Utils.Reverse(LittleEndianUInt32List(initial, numbase));

        static public List<Int64>  BigEndianInt64List <T>(T initial, Int32 numbase)
            => Utils.Reverse(LittleEndianInt64List(initial, numbase));
        static public List<UInt64> BigEndianUInt64List<T>(T initial, Int32 numbase)
            => Utils.Reverse(LittleEndianUInt64List(initial, numbase));
    }



    public class Combine
    {
        static private void BaseArgumentCheck(Int32 numbase)
        {
            if (numbase < 2 || numbase > 36)
                throw new ArgumentOutOfRangeException
                (
                    nameof(numbase),
                    "the number base must be between 2 and 36."
                );
        }



        static public Byte   LittleEndianByte  <T>(List<T> initial, Int32 numbase)
        {
            BaseArgumentCheck(numbase);

            Int128 result = 0;
            Int128 multiplier = 1;

            foreach (var digit in initial)
            {
                Byte parsedDigit = Convert.ToByte(digit);

                if (parsedDigit >= numbase)
                    throw new ArgumentException($"Digit {parsedDigit} is not valid for base {numbase}");

                result += parsedDigit * multiplier;
                multiplier *= numbase;
            }

            if (result > Byte.MaxValue)
                throw new ArgumentException($"Converted value {result} is too large to fit in a Byte");
            
            return (Byte)result;
        }
        static public SByte  LittleEndianSByte <T>(List<T> initial, Int32 numbase)
        {
            BaseArgumentCheck(numbase);

            Int128 result = 0;
            Int128 multiplier = 1;

            foreach (var digit in initial)
            {
                SByte parsedDigit = Convert.ToSByte(digit);

                if (parsedDigit >= numbase)
                    throw new ArgumentException($"Digit {parsedDigit} is not valid for base {numbase}");

                result += parsedDigit * multiplier;
                multiplier *= numbase;
            }

            if (result > SByte.MaxValue)
                throw new ArgumentException($"Converted value {result} is too large to fit in a SByte");
            if (result < SByte.MinValue)
                throw new ArgumentException($"Converted value {result} is too low to fit in a SByte");

            return (SByte)result;
        }

        static public Int16  LittleEndianInt16 <T>(List<T> initial, Int32 numbase)
        {
            BaseArgumentCheck(numbase);

            Int128 result = 0;
            Int128 multiplier = 1;

            foreach (var digit in initial)
            {
                Int16 parsedDigit = Convert.ToInt16(digit);

                if (parsedDigit >= numbase)
                    throw new ArgumentException($"Digit {parsedDigit} is not valid for base {numbase}");

                result     += parsedDigit * multiplier;
                multiplier *= numbase;
            }

            if (result > Int16.MaxValue)
                throw new ArgumentException($"Converted value {result} is too large to fit in a Int16");
            if (result < Int16.MinValue)
                throw new ArgumentException($"Converted value {result} is too low to fit in a Int16");

            return (Int16)result;
        }
        static public UInt16 LittleEndianUInt16<T>(List<T> initial, Int32 numbase)
        {
            BaseArgumentCheck(numbase);

            Int128 result = 0;
            Int128 multiplier = 1;

            foreach (var digit in initial)
            {
                UInt16 parsedDigit = Convert.ToUInt16(digit);

                if (parsedDigit >= numbase)
                    throw new ArgumentException($"Digit {parsedDigit} is not valid for base {numbase}");

                result     += parsedDigit * multiplier;
                multiplier *= numbase;
            }

            if (result > UInt16.MaxValue)
                throw new ArgumentException($"Converted value {result} is too large to fit in a UInt16");

            return (UInt16)result;
        }

        static public Int32  LittleEndianInt32 <T>(List<T> initial, Int32 numbase)
        {
            BaseArgumentCheck(numbase);

            Int128 result = 0;
            Int128 multiplier = 1;

            foreach (var digit in initial)
            {
                Int32 parsedDigit = Convert.ToInt32(digit);

                if (parsedDigit >= numbase)
                    throw new ArgumentException($"Digit {parsedDigit} is not valid for base {numbase}");

                result     += parsedDigit * multiplier;
                multiplier *= numbase;
            }

            if (result > Int32.MaxValue)
                throw new ArgumentException($"Converted value {result} is too large to fit in a Int32");
            if (result < Int32.MinValue)
                throw new ArgumentException($"Converted value {result} is too low to fit in a Int32");

            return (Int32)result;
        }
        static public UInt32 LittleEndianUInt32<T>(List<T> initial, Int32 numbase)
        {
            BaseArgumentCheck(numbase);

            Int128 result = 0;
            Int128 multiplier = 1;

            foreach (var digit in initial)
            {
                UInt32 parsedDigit = Convert.ToUInt32(digit);

                if (parsedDigit >= numbase)
                    throw new ArgumentException($"Digit {parsedDigit} is not valid for base {numbase}");

                result     += parsedDigit * multiplier;
                multiplier *= numbase;
            }

            if (result > UInt32.MaxValue)
                throw new ArgumentException($"Converted value {result} is too large to fit in a UInt32");

            return (UInt32)result;
        }

        static public Int64  LittleEndianInt64 <T>(List<T> initial, Int32 numbase)
        {
            BaseArgumentCheck(numbase);

            Int128 result = 0;
            Int128 multiplier = 1;

            foreach (var digit in initial)
            {
                Int64 parsedDigit = Convert.ToInt64(digit);

                if (parsedDigit >= numbase)
                    throw new ArgumentException($"Digit {parsedDigit} is not valid for base {numbase}");

                result     += parsedDigit * multiplier;
                multiplier *= numbase;
            }

            if (result > Int64.MaxValue)
                throw new ArgumentException($"Converted value {result} is too large to fit in a Int64");
            if (result < Int64.MinValue)
                throw new ArgumentException($"Converted value {result} is too low to fit in a Int64");

            return (Int64)result;
        }
        static public UInt64 LittleEndianUInt64<T>(List<T> initial, Int32 numbase)
        {
            BaseArgumentCheck(numbase);

            Int128 result = 0;
            Int128 multiplier = 1;

            foreach (var digit in initial)
            {
                UInt64 parsedDigit = Convert.ToUInt64(digit);

                if (parsedDigit >= (UInt64)numbase)
                    throw new ArgumentException($"Digit {parsedDigit} is not valid for base {numbase}");

                result     += parsedDigit * multiplier;
                multiplier *= numbase;
            }

            if (result > UInt64.MaxValue)
                throw new ArgumentException($"Converted value {result} is too large to fit in a UInt64");

            return (UInt64)result;
        }



        static public Byte   BigEndianByte  <T>(List<T> initial, Int32 numbase)
            => LittleEndianByte (Utils.Reverse(initial), numbase);
        static public SByte  BigEndianSByte <T>(List<T> initial, Int32 numbase)
            => LittleEndianSByte(Utils.Reverse(initial), numbase);

        static public Int16  BigEndianInt16 <T>(List<T> initial, Int32 numbase)
            => LittleEndianInt16 (Utils.Reverse(initial), numbase);
        static public UInt16 BigEndianUInt16<T>(List<T> initial, Int32 numbase)
            => LittleEndianUInt16(Utils.Reverse(initial), numbase);

        static public Int32  BigEndianInt32 <T>(List<T> initial, Int32 numbase)
            => LittleEndianInt32 (Utils.Reverse(initial), numbase);
        static public UInt32 BigEndianUInt32<T>(List<T> initial, Int32 numbase)
            => LittleEndianUInt32(Utils.Reverse(initial), numbase);

        static public Int64  BigEndianInt64 <T>(List<T> initial, Int32 numbase)
            => LittleEndianInt64 (Utils.Reverse(initial), numbase);
        static public UInt64 BigEndianUInt64<T>(List<T> initial, Int32 numbase)
            => LittleEndianUInt64(Utils.Reverse(initial), numbase);
    }
}