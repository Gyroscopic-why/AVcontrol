using System;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Utils
    {
        static public string Interval(string input, Int32 startId, Int32 endId)
        {
            if (startId < endId) return input[startId..(endId - startId)];
            else return input[endId..(startId - endId)].Reverse();
        }
        static public T[] Interval<T>(T[] array, Int32 startId, Int32 endId)
        {
            var length = array.Length;

            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException(nameof(startId), "StartIndex is out of bounds");
            if (endId  < 0  || endId   > length) throw new ArgumentOutOfRangeException(nameof(endId),     "EndIndex is out of bounds");
            
            return startId < endId
                ? array[startId..(endId - startId)]
                : Reverse(array[endId..(startId - endId)]);
        }
        static public List<T> Interval<T>(List<T> list, Int32 startId, Int32 endId)
        {
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException(nameof(startId), "StartIndex is out of bounds");
            if (endId  < 0  || endId   > count) throw new ArgumentOutOfRangeException(nameof(endId),     "EndIndex is out of bounds");

            if (startId < endId) return list[startId..(endId - startId)];
            else return Reverse(list[endId..(startId - endId)]);
        }
    }
}