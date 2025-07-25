using System;
using System.Linq;
using System.Collections.Generic;


namespace AVcontrol
{
    public class Intervals
    {
        static public string SubString(string input, Int32 startId, Int32 endId)
        {
            if (startId < endId) return input.Substring(startId, endId - startId);
            else return (string)input.Substring(endId, startId - endId).Reverse();
        }



        static public Byte[] SubArray(Byte[] array, Int32 startId, Int32 endId)
        {
            if (array == null) throw new ArgumentNullException("array", "Array cannot be null");
            var length = array.Length;
            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > length) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return array.ToList().GetRange(startId, endId - startId).ToArray();
            else
            {
                List<Byte> list = array.ToList().GetRange(endId, startId - endId);
                list.Reverse();
                return list.ToArray();
            }
        }
        static public SByte[] SubArray(SByte[] array, Int32 startId, Int32 endId)
        {
            if (array == null) throw new ArgumentNullException("array", "Array cannot be null");
            var length = array.Length;
            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > length) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return array.ToList().GetRange(startId, endId - startId).ToArray();
            else
            {
                List<SByte> list = array.ToList().GetRange(endId, startId - endId);
                list.Reverse();
                return list.ToArray();
            }
        }
        static public List<Byte> SubList(List<Byte> list, Int32 startId, Int32 endId)
        {
            if (list == null) throw new ArgumentNullException("list", "List cannot be null");
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > count) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return list.GetRange(startId, endId - startId);
            else { list = list.GetRange(endId, startId - endId); list.Reverse(); return list; }
        }
        static public List<SByte> SubList(List<SByte> list, Int32 startId, Int32 endId)
        {
            if (list == null) throw new ArgumentNullException("list", "List cannot be null");
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > count) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return list.GetRange(startId, endId - startId);
            else { list = list.GetRange(endId, startId - endId); list.Reverse(); return list; }
        }



        static public Int16[] SubArray(Int16[] array, Int32 startId, Int32 endId)
        {
            if (array == null) throw new ArgumentNullException("array", "Array cannot be null");
            var length = array.Length;
            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > length) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return array.ToList().GetRange(startId, endId - startId).ToArray();
            else
            {
                List<Int16> list = array.ToList().GetRange(endId, startId - endId);
                list.Reverse();
                return list.ToArray();
            }
        }
        static public UInt16[] SubArray(UInt16[] array, Int32 startId, Int32 endId)
        {
            if (array == null) throw new ArgumentNullException("array", "Array cannot be null");
            var length = array.Length;
            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > length) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return array.ToList().GetRange(startId, endId - startId).ToArray();
            else
            {
                List<UInt16> list = array.ToList().GetRange(endId, startId - endId);
                list.Reverse();
                return list.ToArray();
            }
        }
        static public List<UInt16> SubList(List<UInt16> list, Int32 startId, Int32 endId)
        {
            if (list == null) throw new ArgumentNullException("list", "List cannot be null");
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > count) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return list.GetRange(startId, endId - startId);
            else { list = list.GetRange(endId, startId - endId); list.Reverse(); return list; }
        }
        static public List<Int16> SubList(List<Int16> list, Int32 startId, Int32 endId)
        {
            if (list == null) throw new ArgumentNullException("list", "List cannot be null");
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > count) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return list.GetRange(startId, endId - startId);
            else { list = list.GetRange(endId, startId - endId); list.Reverse(); return list; }
        }



        static public Int32[] SubArray(Int32[] array, Int32 startId, Int32 endId)
        {
            if (array == null) throw new ArgumentNullException("array", "Array cannot be null");
            var length = array.Length;
            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > length) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return array.ToList().GetRange(startId, endId - startId).ToArray();
            else
            {
                List<Int32> list = array.ToList().GetRange(endId, startId - endId);
                list.Reverse();
                return list.ToArray();
            }
        }
        static public UInt32[] SubArray(UInt32[] array, Int32 startId, Int32 endId)
        {
            if (array == null) throw new ArgumentNullException("array", "Array cannot be null");
            var length = array.Length;
            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > length) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return array.ToList().GetRange(startId, endId - startId).ToArray();
            else
            {
                List<UInt32> list = array.ToList().GetRange(endId, startId - endId);
                list.Reverse();
                return list.ToArray();
            }
        }
        static public List<UInt32> SubList(List<UInt32> list, Int32 startId, Int32 endId)
        {
            if (list == null) throw new ArgumentNullException("list", "List cannot be null");
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > count) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return list.GetRange(startId, endId - startId);
            else { list = list.GetRange(endId, startId - endId); list.Reverse(); return list; }
        }
        static public List<Int32> SubList(List<Int32> list, Int32 startId, Int32 endId)
        {
            if (list == null) throw new ArgumentNullException("list", "List cannot be null");
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > count) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return list.GetRange(startId, endId - startId);
            else { list = list.GetRange(endId, startId - endId); list.Reverse(); return list; }
        }



        static public Int64[] SubArray(Int64[] array, Int32 startId, Int32 endId)
        {
            if (array == null) throw new ArgumentNullException("array", "Array cannot be null");
            var length = array.Length;
            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > length) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return array.ToList().GetRange(startId, endId - startId).ToArray();
            else
            {
                List<Int64> list = array.ToList().GetRange(endId, startId - endId);
                list.Reverse();
                return list.ToArray();
            }
        }
        static public UInt64[] SubArray(UInt64[] array, Int32 startId, Int32 endId)
        {
            if (array == null) throw new ArgumentNullException("array", "Array cannot be null");
            var length = array.Length;
            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > length) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return array.ToList().GetRange(startId, endId - startId).ToArray();
            else
            {
                List<UInt64> list = array.ToList().GetRange(endId, startId - endId);
                list.Reverse();
                return list.ToArray();
            }
        }
        static public List<UInt64> SubList(List<UInt64> list, Int32 startId, Int32 endId)
        {
            if (list == null) throw new ArgumentNullException("list", "List cannot be null");
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > count) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return list.GetRange(startId, endId - startId);
            else { list = list.GetRange(endId, startId - endId); list.Reverse(); return list; }
        }
        static public List<Int64> SubList(List<Int64> list, Int32 startId, Int32 endId)
        {
            if (list == null) throw new ArgumentNullException("list", "List cannot be null");
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > count) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return list.GetRange(startId, endId - startId);
            else { list = list.GetRange(endId, startId - endId); list.Reverse(); return list; }
        }



        static public Char[] SubArray(Char[] array, Int32 startId, Int32 endId)
        {
            if (array == null) throw new ArgumentNullException("array", "Array cannot be null");
            var length = array.Length;
            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > length) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return array.ToList().GetRange(startId, endId - startId).ToArray();
            else
            {
                List<Char> list = array.ToList().GetRange(endId, startId - endId);
                list.Reverse();
                return list.ToArray();
            }
        }
        static public List<Char> SubList(List<Char> list, Int32 startId, Int32 endId)
        {
            if (list == null) throw new ArgumentNullException("list", "List cannot be null");
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > count) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return list.GetRange(startId, endId - startId);
            else { list = list.GetRange(endId, startId - endId); list.Reverse(); return list; }
        }
        static public string[] SubArray(string[] array, Int32 startId, Int32 endId)
        {
            if (array == null) throw new ArgumentNullException("array", "Array cannot be null");
            var length = array.Length;
            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId   < 0 || endId   > length) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return array.ToList().GetRange(startId, endId - startId).ToArray();
            else 
            { 
                List<string> list = array.ToList().GetRange(endId, startId - endId);
                list.Reverse();
                return list.ToArray();
            }
        }
        static public List<string> SubList(List<string> list, Int32 startId, Int32 endId)
        {
            if (list == null) throw new ArgumentNullException("list", "List cannot be null");
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId   < 0 || endId   > count) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return list.GetRange(startId, endId - startId);
            else { list = list.GetRange(endId, startId - endId); list.Reverse(); return list; }
        }
    }
}