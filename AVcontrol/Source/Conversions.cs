using System;
using System.Collections.Generic;

namespace AVcontrol
{
    public class Conversions
    {
        static public List<Byte> ToByteList(List<SByte>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Byte>(initial.Count);
            foreach (var i in initial)
            {
                if (i < 0) throw new ArgumentOutOfRangeException(nameof(initial), "All SByte values must be non-negative to convert to Byte.");
                result.Add((Byte)i);
            }
            return result;
        }
        static public List<Byte> ToByteList(List<Int16>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Byte>(initial.Count);
            foreach (var i in initial)
            {
                if (i < 0 || i > 255) throw new ArgumentOutOfRangeException(nameof(initial), "All Int16 values must be in the range 0-255 to convert to Byte.");
                result.Add((Byte)i);
            }
            return result;
        }
        static public List<Byte> ToByteList(List<UInt16> initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Byte>(initial.Count);
            foreach (var i in initial)
            {
                if (i > 255) throw new ArgumentOutOfRangeException(nameof(initial), "All UInt16 values must be in the range 0-255 to convert to Byte.");
                result.Add((Byte)i);
            }
            return result;
        }
        static public List<Byte> ToByteList(List<Int32>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Byte>(initial.Count);
            foreach (var i in initial)
            {
                if (i < 0 || i > 255) throw new ArgumentOutOfRangeException(nameof(initial), "All Int32 values must be in the range 0-255 to convert to Byte.");
                result.Add((Byte)i);
            }
            return result;
        }
        static public List<Byte> ToByteList(List<UInt32> initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Byte>(initial.Count);
            foreach (var i in initial)
            {
                if (i > 255) throw new ArgumentOutOfRangeException(nameof(initial), "All UInt32 values must be in the range 0-255 to convert to Byte.");
                result.Add((Byte)i);
            }
            return result;
        }
        static public List<Byte> ToByteList(List<Int64>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Byte>(initial.Count);
            foreach (var i in initial)
            {
                if (i < 0 || i > 255) throw new ArgumentOutOfRangeException(nameof(initial), "All Int64 values must be in the range 0-255 to convert to Byte.");
                result.Add((Byte)i);
            }
            return result;
        }
        static public List<Byte> ToByteList(List<UInt64> initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Byte>(initial.Count);
            foreach (var i in initial)
            {
                if (i > 255) throw new ArgumentOutOfRangeException(nameof(initial), "All UInt64 values must be in the range 0-255 to convert to Byte.");
                result.Add((Byte)i);
            }
            return result;
        }


        static public List<SByte> ToSByteList(List<Byte>   initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<SByte>(initial.Count);
            foreach (var i in initial)
            {
                if (i > 127) throw new ArgumentOutOfRangeException(nameof(initial), "All Byte values must be in the range 0-127 to convert to SByte.");
                result.Add((SByte)i);
            }
            return result;
        }
        static public List<SByte> ToSByteList(List<Int16>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<SByte>(initial.Count);
            foreach (var i in initial)
            {
                if (i < -128 || i > 127) throw new ArgumentOutOfRangeException(nameof(initial), "All Int16 values must be in the range -128+127 to convert to SByte.");
                result.Add((SByte)i);
            }
            return result;
        }
        static public List<SByte> ToSByteList(List<UInt16> initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<SByte>(initial.Count);
            foreach (var i in initial)
            {
                if (i > 127) throw new ArgumentOutOfRangeException(nameof(initial), "All UInt16 values must be in the range 0-127 to convert to SByte.");
                result.Add((SByte)i);
            }
            return result;
        }
        static public List<SByte> ToSByteList(List<Int32>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<SByte>(initial.Count);
            foreach (var i in initial)
            {
                if (i < -128 || i > 127) throw new ArgumentOutOfRangeException(nameof(initial), "All Int32 values must be in the range -128+127 to convert to SByte.");
                result.Add((SByte)i);
            }
            return result;
        }
        static public List<SByte> ToSByteList(List<UInt32> initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<SByte>(initial.Count);
            foreach (var i in initial)
            {
                if (i > 127) throw new ArgumentOutOfRangeException(nameof(initial), "All UInt32 values must be in the range 0-127 to convert to SByte.");
                result.Add((SByte)i);
            }
            return result;
        }
        static public List<SByte> ToSByteList(List<Int64>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<SByte>(initial.Count);
            foreach (var i in initial)
            {
                if (i < -128 || i > 127) throw new ArgumentOutOfRangeException(nameof(initial), "All Int64 values must be in the range -128+127 to convert to SByte.");
                result.Add((SByte)i);
            }
            return result;
        }
        static public List<SByte> ToSByteList(List<UInt64> initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<SByte>(initial.Count);
            foreach (var i in initial)
            {
                if (i > 127) throw new ArgumentOutOfRangeException(nameof(initial), "All UInt64 values must be in the range 0-127 to convert to SByte.");
                result.Add((SByte)i);
            }
            return result;
        }





        static public List<Int16> ToInt16List(List<Byte>   initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Int16>(initial.Count);
            foreach (var i in initial) result.Add((Int16)i);
            return result;
        }
        static public List<Int16> ToInt16List(List<SByte>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Int16>(initial.Count);
            foreach (var i in initial)
            {
                if (i < -128) throw new ArgumentOutOfRangeException(nameof(initial), "All SByte values must be in the range -128+127 to convert to Int16.");
                result.Add((Int16)i);
            }
            return result;
        }
        static public List<Int16> ToInt16List(List<UInt16> initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Int16>(initial.Count);
            foreach (var i in initial)
            {
                if (i > 32767) throw new ArgumentOutOfRangeException(nameof(initial), "All UInt16 values must be in the range 0-32,767 to convert to Int16.");
                result.Add((Int16)i);
            }
            return result;
        }
        static public List<Int16> ToInt16List(List<Int32>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Int16>(initial.Count);
            foreach (var i in initial)
            {
                if (i < -32768 || i > 32767) throw new ArgumentOutOfRangeException(nameof(initial), "All Int32 values must be in the range -32,768+32,767 to convert to Int16.");
                result.Add((Int16)i);
            }
            return result;
        }
        static public List<Int16> ToInt16List(List<UInt32> initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Int16>(initial.Count);
            foreach (var i in initial)
            {
                if (i > 32767) throw new ArgumentOutOfRangeException(nameof(initial), "All UInt32 values must be in the range 0-32,767 to convert to Int16.");
                result.Add((Int16)i);
            }
            return result;
        }
        static public List<Int16> ToInt64List(List<Int64>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Int16>(initial.Count);
            foreach (var i in initial)
            {
                if (i < -32768 || i > 32767) throw new ArgumentOutOfRangeException(nameof(initial), "All Int64 values must be in the range -32,768+32,767 to convert to Int16.");
                result.Add((Int16)i);
            }
            return result;
        }
        static public List<Int16> ToInt16List(List<UInt64> initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Int16>(initial.Count);
            foreach (var i in initial)
            {
                if (i > 32767) throw new ArgumentOutOfRangeException(nameof(initial), "All UInt64 values must be in the range 0-32,767 to convert to Int16.");
                result.Add((Int16)i);
            }
            return result;
        }


        static public List<UInt16> ToUInt16List(List<Byte>   initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<UInt16>(initial.Count);
            foreach (var i in initial) result.Add((UInt16)i);
            return result;
        }
        static public List<UInt16> ToUInt16List(List<SByte>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<UInt16>(initial.Count);
            foreach (var i in initial)
            {
                if (i < 0) throw new ArgumentOutOfRangeException(nameof(initial), "All SByte values must be non-negative to convert to UInt16.");
                result.Add((UInt16)i);
            }
            return result;
        }
        static public List<UInt16> ToUInt16List(List<Int16>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<UInt16>(initial.Count);
            foreach (var i in initial)
            {
                if (i < 0) throw new ArgumentOutOfRangeException(nameof(initial), "All Int16 values must be non-negative to convert to UInt16.");
                result.Add((UInt16)i);
            }
            return result;
        }
        static public List<UInt16> ToUInt16List(List<Int32>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<UInt16>(initial.Count);
            foreach (var i in initial)
            {
                if (i < 0 || i > 65535) throw new ArgumentOutOfRangeException(nameof(initial), "All Int32 values must be in the range 0-65,535 to convert to UInt16.");
                result.Add((UInt16)i);
            }
            return result;
        }
        static public List<UInt16> ToUInt16List(List<UInt32> initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<UInt16>(initial.Count);
            foreach (var i in initial)
            {
                if (i > 65535) throw new ArgumentOutOfRangeException(nameof(initial), "All UInt32 values must be in the range 0-65,535 to convert to UInt16.");
                result.Add((UInt16)i);
            }
            return result;
        }
        static public List<UInt16> ToUInt16List(List<Int64>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<UInt16>(initial.Count);
            foreach (var i in initial)
            {
                if (i < 0 || i > 65535) throw new ArgumentOutOfRangeException(nameof(initial), "All Int64 values must be in the range 0-65,535 to convert to UInt16.");
                result.Add((UInt16)i);
            }
            return result;
        }
        static public List<UInt16> ToUInt16List(List<UInt64> initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<UInt16>(initial.Count);
            foreach (var i in initial)
            {
                if (i > 65535) throw new ArgumentOutOfRangeException(nameof(initial), "All UInt64 values must be in the range 0-65,535 to convert to UInt16.");
                result.Add((UInt16)i);
            }
            return result;
        }





        static public List<Int32> ToInt32List(List<Byte>   initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Int32>(initial.Count);
            foreach (var i in initial) result.Add((Int32)i);
            return result;
        }
        static public List<Int32> ToInt32List(List<SByte>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Int32>(initial.Count);
            foreach (var i in initial) result.Add((Int32)i);
            return result;
        }
        static public List<Int32> ToInt32List(List<Int16>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Int32>(initial.Count);
            foreach (var i in initial) result.Add((Int32)i);
            return result;
        }
        static public List<Int32> ToInt32List(List<UInt16> initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Int32>(initial.Count);
            foreach (var i in initial) result.Add((Int32)i);
            return result;
        }
        static public List<Int32> ToInt32List(List<UInt32> initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Int32>(initial.Count);
            foreach (var i in initial)
            {
                if (i > Int32.MaxValue) throw new ArgumentOutOfRangeException(nameof(initial), "All UInt32 values must be in the range 0 to 2,147,483,647 to convert to Int32.");
                result.Add((Int32)i);
            }
            return result;
        }
        static public List<Int32> ToInt32List(List<Int64>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Int32>(initial.Count);
            foreach (var i in initial)
            {
                if (i < Int32.MinValue || i > Int32.MaxValue) throw new ArgumentOutOfRangeException(nameof(initial), "All Int64 values must be in the range -2,147,483,648 to 2,147,483,647 to convert to Int32.");
                result.Add((Int32)i);
            }
            return result;
        }
        static public List<Int32> ToInt32List(List<UInt64> initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Int32>(initial.Count);
            foreach (var i in initial)
            {
                if (i > Int32.MaxValue) throw new ArgumentOutOfRangeException(nameof(initial), "All UInt64 values must be in the range 0 to 2,147,483,647 to convert to Int32.");
                result.Add((Int32)i);
            }
            return result;
        }


        static public List<UInt32> ToUInt32List(List<Byte>   initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<UInt32>(initial.Count);
            foreach (var i in initial) result.Add((UInt32)i);
            return result;
        }
        static public List<UInt32> ToUInt32List(List<SByte>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<UInt32>(initial.Count);
            foreach (var i in initial)
            {
                if (i < 0) throw new ArgumentOutOfRangeException(nameof(initial), "All SByte values must be non-negative to convert to UInt32.");
                result.Add((UInt32)i);
            }
            return result;
        }
        static public List<UInt32> ToUInt32List(List<Int16>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<UInt32>(initial.Count);
            foreach (var i in initial)
            {
                if (i < 0) throw new ArgumentOutOfRangeException(nameof(initial), "All Int16 values must be non-negative to convert to UInt32.");
                result.Add((UInt32)i);
            }
            return result;
        }
        static public List<UInt32> ToUInt32List(List<UInt16> initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<UInt32>(initial.Count);
            foreach (var i in initial) result.Add((UInt32)i);
            return result;
        }
        static public List<UInt32> ToUInt32List(List<Int32>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<UInt32>(initial.Count);
            foreach (var i in initial)
            {
                if (i < 0) throw new ArgumentOutOfRangeException(nameof(initial), "All Int32 values must be non-negative to convert to UInt32.");
                result.Add((UInt32)i);
            }
            return result;
        }
        static public List<UInt32> ToUInt32List(List<Int64>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<UInt32>(initial.Count);
            foreach (var i in initial)
            {
                if (i < 0 || i > UInt32.MaxValue) throw new ArgumentOutOfRangeException(nameof(initial), "All Int64 values must be in the range 0 to 4,294,967,295 to convert to UInt32.");
                result.Add((UInt32)i);
            }
            return result;
        }
        static public List<UInt32> ToUInt32List(List<UInt64> initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<UInt32>(initial.Count);
            foreach (var i in initial)
            {
                if (i > UInt32.MaxValue) throw new ArgumentOutOfRangeException(nameof(initial), "All UInt64 values must be in the range 0 to 4,294,967,295 to convert to UInt32.");
                result.Add((UInt32)i);
            }
            return result;
        }





        static public List<Int64> ToInt64List(List<Byte>   initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Int64>(initial.Count);
            foreach (var i in initial   ) result.Add((Int64)i);
            return result;
        }
        static public List<Int64> ToInt64List(List<SByte>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Int64>(initial.Count);
            foreach (var i in initial) result.Add((Int64)i);
            return result;
        }
        static public List<Int64> ToInt64List(List<Int16>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Int64>(initial.Count);
            foreach (var i in initial) result.Add((Int64)i);
            return result;
        }
        static public List<Int64> ToInt64List(List<UInt16> initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Int64>(initial.Count);
            foreach (var i in initial) result.Add((Int64)i);
            return result;
        }
        static public List<Int64> ToInt64List(List<Int32>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Int64>(initial.Count);
            foreach (var i in initial) result.Add((Int64)i);
            return result;
        }
        static public List<Int64> ToInt64List(List<UInt32> initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Int64>(initial.Count);
            foreach (var i in initial) result.Add((Int64)i);
            return result;
        }
        static public List<Int64> ToInt64List(List<UInt64> initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<Int64>(initial.Count);
            foreach (var i in initial)
            {
                if (i > Int64.MaxValue) throw new ArgumentOutOfRangeException(nameof(initial), "All UInt64 values must be in the range 0 to 9,223,372,036,854,775,807 to convert to Int64.");
                result.Add((Int64)i);
            }
            return result;
        }


        static public List<UInt64> ToUInt64List(List<Byte>   initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<UInt64>(initial.Count);
            foreach (var i in initial) result.Add((UInt64)i);
            return result;
        }
        static public List<UInt64> ToUInt64List(List<SByte>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<UInt64>(initial.Count);
            foreach (var i in initial)
            {
                if (i < 0) throw new ArgumentOutOfRangeException(nameof(initial), "All SByte values must be non-negative to convert to UInt64.");
                result.Add((UInt64)i);
            }
            return result;
        }
        static public List<UInt64> ToUInt64List(List<Int16>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<UInt64>(initial.Count);
            foreach (var i in initial)
            {
                if (i < 0) throw new ArgumentOutOfRangeException(nameof(initial), "All Int16 values must be non-negative to convert to UInt64.");
                result.Add((UInt64)i);
            }
            return result;
        }
        static public List<UInt64> ToUInt64List(List<UInt16> initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<UInt64>(initial.Count);
            foreach (var i in initial) result.Add((UInt64)i);
            return result;
        }
        static public List<UInt64> ToUInt64List(List<Int32>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<UInt64>(initial.Count);
            foreach (var i in initial)
            {
                if (i < 0) throw new ArgumentOutOfRangeException(nameof(initial), "All Int32 values must be non-negative to convert to UInt64.");
                result.Add((UInt64)i);
            }
            return result;
        }
        static public List<UInt64> ToUInt64List(List<UInt32> initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<UInt64>(initial.Count);
            foreach (var i in initial) result.Add((UInt64)i);
            return result;
        }
        static public List<UInt64> ToUInt64List(List<Int64>  initial)
        {
            if (initial == null) throw new ArgumentNullException(nameof(initial));
            var result = new List<UInt64>(initial.Count);
            foreach (var i in initial)
            {
                if (i < 0) throw new ArgumentOutOfRangeException(nameof(initial), "All Int64 values must be non-negative to convert to UInt64.");
                result.Add((UInt64)i);
            }
            return result;
        }
    }
}