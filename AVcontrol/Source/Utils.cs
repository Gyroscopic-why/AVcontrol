using System;
using System.Linq;
using System.Collections.Generic;


namespace AVcontrol
{
    static public class Utils
    {
        static public string Reverse(this string initial)
        {
            if (string.IsNullOrEmpty(initial)) return initial;

            char[] charArray = initial.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static public T[] Reverse<T>(this T[] array)
        {
            if (array == null) return null;
            var result = new T[array.Length];
            Array.Copy(array, result, array.Length);
            Array.Reverse(result);
            return result;
        }

        static public List<T> Reverse<T>(this List<T> list)
        {
            if (list == null) return null;
            var result = new List<T>(list);

            result.Reverse();
            return result;
        }
        static public IList<T> Reverse<T>(this IList<T> collection)
        {
            if (collection == null) return null;

            var result = new T[collection.Count];
            for (var i = 0; i < collection.Count; i++)
            {
                result[i] = collection[collection.Count - 1 - i];
            }
            return result.ToList();
        }

        static public IEnumerable<T> Reverse<T>(this IEnumerable<T> collection)
        {
            if (collection == null) yield break;

            var stack = new Stack<T>();
            foreach (var item in collection)
                stack.Push(item);

            foreach (var item in stack)
                yield return item;
        }
        static public IEnumerable<T> FastReverse<T>(this IList<T> collection)
        {
            for (var i = collection.Count - 1; i >= 0; i--)
            {
                yield return collection[i];
            }
        }



        static public string Interval(string input, Int32 startId, Int32 endId)
        {
            if (startId < endId) return input.Substring(startId, endId - startId);
            else return input.Substring(endId, startId - endId).Reverse();
        }
        static public T[] Interval<T>(T[] array, Int32 startId, Int32 endId)
        {
            if (array == null) throw new ArgumentNullException("array", "Array cannot be null");
            var length = array.Length;

            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > length) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return array.ToList().GetRange(startId, endId - startId).ToArray();
            else
            {
                List<T> list = array.ToList().GetRange(endId, startId - endId);
                return Utils.Reverse(list.ToArray());
            }
        }
        static public List<T> Interval<T>(List<T> list, Int32 startId, Int32 endId)
        {
            if (list == null) throw new ArgumentNullException("list", "List cannot be null");
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException("startId", "StartIndex is out of bounds");
            if (endId < 0 || endId > count) throw new ArgumentOutOfRangeException("endId", "EndIndex is out of bounds");

            if (startId < endId) return list.GetRange(startId, endId - startId);
            else
            {
                list = list.GetRange(endId, startId - endId);
                return Utils.Reverse(list);
            }
        }


        static public bool IsPrime(Int32 number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            Int32 boundary = (Int32)Math.Floor(Math.Sqrt(number));
            for (Int32 i = 3; i <= boundary; i += 2) if (number % i == 0) return false;
            return true;
        }
    }
}