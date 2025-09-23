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
                    "numbase",
                    "the number base must be between 2 and 36."
                );
        }



        static public List<Byte>  LittleEndianByteList <T>(T initial, Int32 numbase)
        {
            Int64 value = Convert.ToInt64(initial);

            BaseArgumentCheck(numbase);
            if (value < numbase) return new List<Byte> { (Byte)value };

            Int32 digitCount = (Int32)(Math.Log(value, numbase) + 1);
            var result = new List<Byte>(digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((Byte)(value / (Int64)Math.Pow(numbase, i) % numbase));

            return result;
        }
        static public List<Int16> LittleEndianInt16List<T>(T initial, Int32 numbase)
        {
            Int64 value = Convert.ToInt64(initial);

            BaseArgumentCheck(numbase);
            if (value < numbase) return new List<Int16> { (Int16)value };
            
            Int32 digitCount = (Int32)(Math.Log(value, numbase) + 1);
            var result = new List<Int16>(digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((Int16)(value / (Int64)Math.Pow(numbase, i) % numbase));

            return result;
        }
        static public List<Int32> LittleEndianInt32List<T>(T initial, Int32 numbase)
        {
            Int64 value = Convert.ToInt64(initial);

            BaseArgumentCheck(numbase);
            if (value < numbase) return new List<Int32> { (Int32)value };

            Int32 digitCount = (Int32)(Math.Log(value, numbase) + 1);
            var result = new List<Int32>(digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((Int32)(value / (Int64)Math.Pow(numbase, i) % numbase));

            return result;
        }
        static public List<Int64> LittleEndianInt64List<T>(T initial, Int32 numbase)
        {
            Int64 value = Convert.ToInt64(initial);

            BaseArgumentCheck(numbase);
            if (value < numbase) return new List<Int64> { value };

            Int32 digitCount = (Int32)(Math.Log(value, numbase) + 1);
            var result = new List<Int64>(digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((Int64)(value / (Int64)Math.Pow(numbase, i) % numbase));

            return result;
        }



        static public List<Byte> BigEndianByteList<T>(T initial, Int32 numbase)
            => Utils.Reverse(LittleEndianByteList(initial, numbase));
        static public List<Int16> BigEndianInt16List<T>(T initial, Int32 numbase)
            => Utils.Reverse(LittleEndianInt16List(initial, numbase));
        static public List<Int32> BigEndianInt32List<T>(T initial, Int32 numbase)
            => Utils.Reverse(LittleEndianInt32List(initial, numbase)); 
        static public List<Int64> BigEndianInt64List<T>(T initial, Int32 numbase)
            => Utils.Reverse(LittleEndianInt64List(initial, numbase));
    }
}
