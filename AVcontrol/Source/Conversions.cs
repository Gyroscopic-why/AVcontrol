using System;
using System.Linq;
using System.Collections.Generic;

namespace AVcontrol
{
    public class Conversions
    {
        static public List<Int16> BigEndianBytesToInt16(List<Byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            if (bytes.Count % 2 != 0) throw new ArgumentException("Byte array length must be even", nameof(bytes));

            var result = new List<Int16>(bytes.Count / 2);

            for (Int32 curId = 0; curId < bytes.Count; curId += 2)
            {
                Int16 value = (Int16)((bytes[curId] << 8) | bytes[curId + 1]);
                result.Add(value);
            }

            return result;
        }
        static public List<Int16> AutoBEBytesToInt16(List<Byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));

            var result = new List<Int16>((bytes.Count + 1) / 2);

            for (Int32 curId = 0; curId < bytes.Count; curId += 2)
            {
                Byte high = bytes[curId];
                Byte low = (curId + 1 < bytes.Count) ? bytes[curId + 1] : (Byte)0;
                result.Add((Int16)((high << 8) | low));
            }

            return result;
        }

        static public List<Int16> LEBytesToInt16(List<Byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            if (bytes.Count % 2 != 0) throw new ArgumentException("Byte array length must be even", nameof(bytes));

            var result = new List<Int16>(bytes.Count / 2);

            for (Int32 curId = 0; curId < bytes.Count; curId += 2)
            {
                Int16 value = (Int16)(bytes[curId] | (bytes[curId + 1] << 8));
                result.Add(value);
            }

            return result;
        }
        static public List<Int16> AutoLEBytesToInt16(List<Byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));

            var result = new List<Int16>((bytes.Count + 1) / 2);

            for (Int32 curId = 0; curId < bytes.Count; curId += 2)
            {
                Byte low = bytes[curId];
                Byte high = (curId + 1 < bytes.Count) ? bytes[curId + 1] : (Byte)0;
                result.Add((Int16)(low | (high << 8)));
            }

            return result;
        }



        static public List<UInt16> BEBytesToUInt16(List<Byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            if (bytes.Count % 2 != 0) throw new ArgumentException("Byte array length must be even", nameof(bytes));

            var result = new List<UInt16>(bytes.Count / 2);

            for (Int32 curId = 0; curId < bytes.Count; curId += 2)
            {
                UInt16 value = (UInt16)((bytes[curId] << 8) | bytes[curId + 1]);
                result.Add(value);
            }

            return result;
        }
        static public List<UInt16> AutoBEBytesToUInt16(List<Byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));

            var result = new List<UInt16>((bytes.Count + 1) / 2);

            for (Int32 curId = 0; curId < bytes.Count; curId += 2)
            {
                Byte high = bytes[curId];
                Byte low = (curId + 1 < bytes.Count) ? bytes[curId + 1] : (Byte)0;
                result.Add((UInt16)((high << 8) | low));
            }

            return result;
        }

        static public List<UInt16> LEBytesToUInt16(List<Byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            if (bytes.Count % 2 != 0) throw new ArgumentException("Byte array length must be even", nameof(bytes));

            var result = new List<UInt16>(bytes.Count / 2);

            for (Int32 curId = 0; curId < bytes.Count; curId += 2)
            {
                UInt16 value = (UInt16)(bytes[curId] | (bytes[curId + 1] << 8));
                result.Add(value);
            }

            return result;
        }
        static public List<UInt16> AutoLEBytesToUInt16(List<Byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));

            var result = new List<UInt16>((bytes.Count + 1) / 2);

            for (Int32 curId = 0; curId < bytes.Count; curId += 2)
            {
                Byte low = bytes[curId];
                Byte high = (curId + 1 < bytes.Count) ? bytes[curId + 1] : (Byte)0;
                result.Add((UInt16)(low | (high << 8)));
            }

            return result;
        }



        //-------------------  Array and List conversion  ------------------------------------------------------//

        

        static public List<Byte> ToByteList(Byte[] array, Int32 startId, Int32 endId)
        {
            if (array == null) throw new ArgumentNullException("array", "Array cannot be null");
            var length = array.Length;
            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > length) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            return startId < endId ? 
                array.ToList().GetRange(startId, endId - startId) :
                array.ToList().GetRange(endId, startId - endId).AsEnumerable().Reverse().ToList();
        }
        static public List<SByte> ToSByteList(SByte[] array, Int32 startId, Int32 endId)
        {
            if (array == null) throw new ArgumentNullException("array", "Array cannot be null");
            var length = array.Length;
            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > length) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            return startId < endId ? 
                array.ToList().GetRange(startId, endId - startId) :
                array.ToList().GetRange(endId, startId - endId).AsEnumerable().Reverse().ToList();
        }
        static public Byte[] ToByteArray(List<Byte> list, Int32 startId, Int32 endId)
        {
            if (list == null) throw new ArgumentNullException("list", "List cannot be null");
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > count) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            return startId < endId ? 
                list.GetRange(startId, endId - startId).ToArray() :
                list.GetRange(endId, startId - endId).AsEnumerable().Reverse().ToArray();
        }
        static public SByte[] ToSByteArray(List<SByte> list, Int32 startId, Int32 endId)
        {
            if (list == null) throw new ArgumentNullException("list", "List cannot be null");
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > count) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            return startId < endId ?
                list.GetRange(startId, endId - startId).ToArray() :
                list.GetRange(endId, startId - endId).AsEnumerable().Reverse().ToArray();
        }



        static public List<Int16> ToInt16List(Int16[] array, Int32 startId, Int32 endId)
        {
            if (array == null) throw new ArgumentNullException("array", "Array cannot be null");
            var length = array.Length;
            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > length) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            return startId < endId ?
                array.ToList().GetRange(startId, endId - startId) :
                array.ToList().GetRange(endId, startId - endId).AsEnumerable().Reverse().ToList();
        }
        static public List<UInt16> ToUInt16List(UInt16[] array, Int32 startId, Int32 endId)
        {
            if (array == null) throw new ArgumentNullException("array", "Array cannot be null");
            var length = array.Length;
            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > length) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            return startId < endId ?
                array.ToList().GetRange(startId, endId - startId) :
                array.ToList().GetRange(endId, startId - endId).AsEnumerable().Reverse().ToList();
        }
        static public Int16[] ToInt16Array(List<Int16> list, Int32 startId, Int32 endId)
        {
            if (list == null) throw new ArgumentNullException("list", "List cannot be null");
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > count) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            return startId < endId ?
                list.GetRange(startId, endId - startId).ToArray() :
                list.GetRange(endId, startId - endId).AsEnumerable().Reverse().ToArray();
        }
        static public UInt16[] ToUInt16Array(List<UInt16> list, Int32 startId, Int32 endId)
        {
            if (list == null) throw new ArgumentNullException("list", "List cannot be null");
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > count) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            return startId < endId ?
                list.GetRange(startId, endId - startId).ToArray() :
                list.GetRange(endId, startId - endId).AsEnumerable().Reverse().ToArray();
        }



        static public List<Int32> ToInt32List(Int32[] array, Int32 startId, Int32 endId)
        {
            if (array == null) throw new ArgumentNullException("array", "Array cannot be null");
            var length = array.Length;
            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > length) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            return startId < endId ?
                array.ToList().GetRange(startId, endId - startId) :
                array.ToList().GetRange(endId, startId - endId).AsEnumerable().Reverse().ToList();
        }
        static public List<UInt32> ToUInt32List(UInt32[] array, Int32 startId, Int32 endId)
        {
            if (array == null) throw new ArgumentNullException("array", "Array cannot be null");
            var length = array.Length;
            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > length) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            return startId < endId ?
                array.ToList().GetRange(startId, endId - startId) :
                array.ToList().GetRange(endId, startId - endId).AsEnumerable().Reverse().ToList();
        }
        static public Int32[] ToInt32Array(List<Int32> list, Int32 startId, Int32 endId)
        {
            if (list == null) throw new ArgumentNullException("list", "List cannot be null");
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > count) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            return startId < endId ?
                list.GetRange(startId, endId - startId).ToArray() :
                list.GetRange(endId, startId - endId).AsEnumerable().Reverse().ToArray();
        }
        static public UInt32[] ToUInt32Array(List<UInt32> list, Int32 startId, Int32 endId)
        {
            if (list == null) throw new ArgumentNullException("list", "List cannot be null");
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > count) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            return startId < endId ?
                list.GetRange(startId, endId - startId).ToArray() :
                list.GetRange(endId, startId - endId).AsEnumerable().Reverse().ToArray();
        }



        static public List<Int64> ToInt64List(Int64[] array, Int32 startId, Int32 endId)
        {
            if (array == null) throw new ArgumentNullException("array", "Array cannot be null");
            var length = array.Length;
            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > length) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            return startId < endId ?
                array.ToList().GetRange(startId, endId - startId) :
                array.ToList().GetRange(endId, startId - endId).AsEnumerable().Reverse().ToList();
        }
        static public List<UInt64> ToUInt64List(UInt64[] array, Int32 startId, Int32 endId)
        {
            if (array == null) throw new ArgumentNullException("array", "Array cannot be null");
            var length = array.Length;
            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > length) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            return startId < endId ?
                array.ToList().GetRange(startId, endId - startId) :
                array.ToList().GetRange(endId, startId - endId).AsEnumerable().Reverse().ToList();
        }
        static public Int64[] ToInt64Array(List<Int64> list, Int32 startId, Int32 endId)
        {
            if (list == null) throw new ArgumentNullException("list", "List cannot be null");
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > count) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            return startId < endId ?
                list.GetRange(startId, endId - startId).ToArray() :
                list.GetRange(endId, startId - endId).AsEnumerable().Reverse().ToArray();
        }
        static public UInt64[] ToUInt64Array(List<UInt64> list, Int32 startId, Int32 endId)
        {
            if (list == null) throw new ArgumentNullException("list", "List cannot be null");
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > count) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            return startId < endId ?
                list.GetRange(startId, endId - startId).ToArray() :
                list.GetRange(endId, startId - endId).AsEnumerable().Reverse().ToArray();
        }



        static public List<char> ToStringList(char[] array, Int32 startId, Int32 endId)
        {
            if (array == null) throw new ArgumentNullException("array", "Array cannot be null");
            var length = array.Length;
            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > length) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            return startId < endId ?
                array.ToList().GetRange(startId, endId - startId) :
                array.ToList().GetRange(endId, startId - endId).AsEnumerable().Reverse().ToList();
        }
        static public char[] ToStringArray(List<char> list, Int32 startId, Int32 endId)
        {
            if (list == null) throw new ArgumentNullException("list", "List cannot be null");
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > count) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            return startId < endId ?
                list.GetRange(startId, endId - startId).ToArray() :
                list.GetRange(endId, startId - endId).AsEnumerable().Reverse().ToArray();
        }
        static public List<string> ToStringList(string[] array, Int32 startId, Int32 endId)
        {
            if (array == null) throw new ArgumentNullException("array", "Array cannot be null");
            var length = array.Length;
            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId   < 0 || endId   > length) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            return startId < endId ?
                array.ToList().GetRange(startId, endId - startId) :
                array.ToList().GetRange(endId, startId - endId).AsEnumerable().Reverse().ToList();
        }
        static public string[] ToStringArray(List<string> list, Int32 startId, Int32 endId)
        {
            if (list == null) throw new ArgumentNullException("list", "List cannot be null");
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId   < 0 || endId   > count) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            return startId < endId ?
                list.GetRange(startId, endId - startId).ToArray() :
                list.GetRange(endId, startId - endId).AsEnumerable().Reverse().ToArray();
        }
    }
}