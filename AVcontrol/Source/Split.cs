using System;
using System.Linq;
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



        static public List<Byte> LittleEndianByteList(Byte initial, Byte numbase)
            => LittleEndianByteList((Int16)initial, (Int16)numbase);
        static public List<Byte> LittleEndianByteList(Int16 initial, Int16 numbase)
        {
            BaseArgumentCheck(numbase);
            if (initial < numbase) return new List<Byte> { (Byte)initial };

            Int32 digitCount = (Int32)Math.Log(initial, numbase) + 1;
            var result = new List<Byte>(digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((Byte)(initial / (Int32)Math.Pow(numbase, i) % numbase));

            return result;
        }
        static public List<Byte> LittleEndianByteList(Int32 initial, Int32 numbase)
        {
            BaseArgumentCheck(numbase);
            if (initial < numbase) return new List<Byte> { (Byte)initial };

            Int32 digitCount = (Int32)Math.Log(initial, numbase) + 1;
            var result = new List<Byte>(digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((Byte)(initial / (Int32)Math.Pow(numbase, i) % numbase));

            return result;
        }
        static public List<Byte> LittleEndianByteList(Int64 initial, Int64 numbase)
        {
            BaseArgumentCheck((Int32)numbase);
            if (initial < numbase) return new List<Byte> { (Byte)initial };

            Int32 digitCount = (Int32)(Math.Log(initial, numbase) + 1);
            var result = new List<Byte>((Int32)digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((Byte)(initial / (Int64)Math.Pow(numbase, i) % numbase));
            return result;
        }


        static public List<Int16> LittleEndianInt16List(Byte initial, Byte numbase)
            => LittleEndianInt16List((Int16)initial, (Int16)numbase);
        static public List<Int16> LittleEndianInt16List(Int16 initial, Int16 numbase)
        {
            BaseArgumentCheck((Int32)numbase);
            if (initial < numbase) return new List<Int16> { (Int16)initial };

            Int32 digitCount = (Int32)(Math.Log(initial, numbase) + 1);
            var result = new List<Int16>((Int32)digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((Int16)(initial / (Int16)Math.Pow(numbase, i) % numbase));
            return result;
        }
        static public List<Int16> LittleEndianInt16List(Int32 initial, Int32 numbase)
        {
            BaseArgumentCheck((Int32)numbase);
            if (initial < numbase) return new List<Int16> { (Int16)initial };

            Int32 digitCount = (Int32)(Math.Log(initial, numbase) + 1);
            var result = new List<Int16>((Int32)digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((Int16)(initial / (Int32)Math.Pow(numbase, i) % numbase));
            return result;
        }
        static public List<Int16> LittleEndianInt16List(Int64 initial, Int64 numbase)
        {
            BaseArgumentCheck((Int32)numbase);
            if (initial < numbase) return new List<Int16> { (Int16)initial };

            Int32 digitCount = (Int32)(Math.Log(initial, numbase) + 1);
            var result = new List<Int16>((Int32)digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((Int16)(initial / (Int64)Math.Pow(numbase, i) % numbase));
            return result;
        }


        static public List<Int32> LittleEndianInt32List(Byte initial, Byte numbase)
            => LittleEndianInt32List((Int16)initial, (Int16)numbase);
        static public List<Int32> LittleEndianInt32List(Int16 initial, Int16 numbase)
        {
            BaseArgumentCheck((Int32)numbase);
            if (initial < numbase) return new List<Int32> { (Int32)initial };

            Int32 digitCount = (Int32)(Math.Log(initial, numbase) + 1);
            var result = new List<Int32>((Int32)digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((Int32)(initial / (Int16)Math.Pow(numbase, i) % numbase));
            return result;
        }
        static public List<Int32> LittleEndianInt32List(Int32 initial, Int32 numbase)
        {
            BaseArgumentCheck((Int32)numbase);
            if (initial < numbase) return new List<Int32> { (Int32)initial };

            Int32 digitCount = (Int32)(Math.Log(initial, numbase) + 1);
            var result = new List<Int32>((Int32)digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((Int32)(initial / (Int32)Math.Pow(numbase, i) % numbase));
            return result;
        }
        static public List<Int32> LittleEndianInt32List(Int64 initial, Int64 numbase)
        {
            BaseArgumentCheck((Int32)numbase);
            if (initial < numbase) return new List<Int32> { (Int32)initial };

            Int32 digitCount = (Int32)(Math.Log(initial, numbase) + 1);
            var result = new List<Int32>((Int32)digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((Int32)(initial / (Int64)Math.Pow(numbase, i) % numbase));
            return result;
        }


        static public List<Int64> LittleEndianInt64List(Byte initial, Byte numbase)
            => LittleEndianInt64List((Int16)initial, (Int16)numbase);
        static public List<Int64> LittleEndianInt64List(Int16 initial, Int16 numbase)
        {
            BaseArgumentCheck((Int32)numbase);
            if (initial < numbase) return new List<Int64> { (Int64)initial };

            Int32 digitCount = (Int32)(Math.Log(initial, numbase) + 1);
            var result = new List<Int64>((Int32)digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((Int64)(initial / (Int16)Math.Pow(numbase, i) % numbase));
            return result;
        }
        static public List<Int64> LittleEndianInt64List(Int32 initial, Int32 numbase)
        {
            BaseArgumentCheck((Int32)numbase);
            if (initial < numbase) return new List<Int64> { (Int64)initial };

            Int32 digitCount = (Int32)(Math.Log(initial, numbase) + 1);
            var result = new List<Int64>((Int32)digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((Int64)(initial / (Int32)Math.Pow(numbase, i) % numbase));
            return result;
        }
        static public List<Int64> LittleEndianInt64List(Int64 initial, Int64 numbase)
        {
            BaseArgumentCheck((Int32)numbase);
            if (initial < numbase) return new List<Int64> { (Int64)initial };

            Int32 digitCount = (Int32)(Math.Log(initial, numbase) + 1);
            var result = new List<Int64>((Int32)digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add((Int64)(initial / (Int64)Math.Pow(numbase, i) % numbase));
            return result;
        }





        static public List<Byte> BigEndianByteList(Byte initial, Byte numbase)
            => BigEndianByteList((Int16)initial, (Int16)numbase).ToArray().Reverse().ToList();
        static public List<Byte> BigEndianByteList(Int16 initial, Int16 numbase)
            => BigEndianByteList(initial, numbase).ToArray().Reverse().ToList();
        static public List<Byte> BigEndianByteList(Int32 initial, Int32 numbase)
            => BigEndianByteList(initial, numbase).ToArray().Reverse().ToList();
        static public List<Byte> BigEndianByteList(Int64 initial, Int64 numbase)
            => BigEndianByteList(initial, numbase).ToArray().Reverse().ToList();



        static public List<Int16> BigEndianInt16List(Byte initial, Byte numbase)
            => BigEndianInt16List((Int16)initial, (Int16)numbase).ToArray().Reverse().ToList();
        static public List<Int16> BigEndianInt16List(Int16 initial, Int16 numbase)
            => BigEndianInt16List(initial, numbase).ToArray().Reverse().ToList();
        static public List<Int16> BigEndianInt16List(Int32 initial, Int32 numbase)
            => BigEndianInt16List(initial, numbase).ToArray().Reverse().ToList();
        static public List<Int16> BigEndianInt16List(Int64 initial, Int64 numbase)
            => BigEndianInt16List(initial, numbase).ToArray().Reverse().ToList();



        static public List<Int32> BigEndianInt32List(Byte initial, Byte numbase)
            => BigEndianInt32List((Int16)initial, (Int16)numbase).ToArray().Reverse().ToList();
        static public List<Int32> BigEndianInt32List(Int16 initial, Int16 numbase)
            => BigEndianInt32List(initial, numbase).ToArray().Reverse().ToList();
        static public List<Int32> BigEndianInt32List(Int32 initial, Int32 numbase)
            => BigEndianInt32List(initial, numbase).ToArray().Reverse().ToList();
        static public List<Int32> BigEndianInt32List(Int64 initial, Int64 numbase)
            => BigEndianInt32List(initial, numbase).ToArray().Reverse().ToList();



        static public List<Int64> BigEndianInt64List(Byte initial, Byte numbase)
            => BigEndianInt64List((Int16)initial, (Int16)numbase).ToArray().Reverse().ToList();
        static public List<Int64> BigEndianInt64List(Int16 initial, Int16 numbase)
            => BigEndianInt64List(initial, numbase).ToArray().Reverse().ToList();
        static public List<Int64> BigEndianInt64List(Int32 initial, Int32 numbase)
            => BigEndianInt64List(initial, numbase).ToArray().Reverse().ToList();
        static public List<Int64> BigEndianInt64List(Int64 initial, Int64 numbase)
            => BigEndianInt64List(initial, numbase).ToArray().Reverse().ToList();
    }
}
