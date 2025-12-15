using System;
using System.Collections.Generic;



namespace AVcontrol
{
    public class Conversions
    {
        static public List<Byte>   ToByteList   <T> (List<T> initial) where T : unmanaged
        {
            ArgumentNullException.ThrowIfNull(initial);

            var result = new List<Byte>(initial.Count);

            foreach (var i in initial)
                result.Add((Byte)Convert.ChangeType(i, typeof(Byte)));
            return result;
        }
        static public List<SByte>  ToSByteList  <T> (List<T> initial) where T : unmanaged
        {
            ArgumentNullException.ThrowIfNull(initial);
            var result = new List<SByte>(initial.Count);

            foreach (var i in initial)
                result.Add((SByte)Convert.ChangeType(i, typeof(SByte)));
            return result;
        }

        static public List<Int16>  ToInt16List  <T> (List<T> initial) where T : unmanaged
        {
            ArgumentNullException.ThrowIfNull(initial);
            var result = new List<Int16>(initial.Count);

            foreach (var i in initial)
                result.Add((Int16)Convert.ChangeType(i, typeof(Int16)));
            return result;
        }
        static public List<UInt16> ToUInt16List <T> (List<T> initial) where T : unmanaged
        {
            ArgumentNullException.ThrowIfNull(initial);
            var result = new List<UInt16>(initial.Count);

            foreach (var i in initial)
                result.Add((UInt16)Convert.ChangeType(i, typeof(UInt16)));
            return result;
        }

        static public List<Int32>  ToInt32List  <T> (List<T> initial) where T : unmanaged
        {
            ArgumentNullException.ThrowIfNull(initial);
            var result = new List<Int32>(initial.Count);

            foreach (var i in initial)
                result.Add((Int32)Convert.ChangeType(i, typeof(Int32)));
            return result;
        }
        static public List<UInt32> ToUInt32List <T> (List<T> initial) where T : unmanaged
        {
            ArgumentNullException.ThrowIfNull(initial);
            var result = new List<UInt32>(initial.Count);

            foreach (var i in initial)
                result.Add((UInt32)Convert.ChangeType(i, typeof(UInt32)));
            return result;
        }

        static public List<Int64>  ToInt64List  <T> (List<T> initial) where T : unmanaged
        {
            ArgumentNullException.ThrowIfNull(initial);
            var result = new List<Int64>(initial.Count);

            foreach (var i in initial)
                result.Add((Int64)Convert.ChangeType(i, typeof(Int64)));
            return result;
        }
        static public List<UInt64> ToUInt64List <T> (List<T> initial) where T : unmanaged
        {
            ArgumentNullException.ThrowIfNull(initial);
            var result = new List<UInt64>(initial.Count);

            foreach (var i in initial)
                result.Add((UInt64)Convert.ChangeType(i, typeof(UInt64)));
            return result;
        }
    }
}