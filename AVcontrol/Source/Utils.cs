using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;



namespace AVcontrol
{
    static public class Utils
    {
        static public T Reverse<T>(T initial) where T : struct, IConvertible
        {
            if (typeof(T).IsPrimitive && typeof(T) != typeof(bool) && typeof(T) != typeof(char))
            {
                Int64 value = Convert.ToInt64(initial, CultureInfo.InvariantCulture);
                bool  isNegative = value < 0;

                Int64 absValue = Math.Abs(value);

                long reversed = 0;
                while (absValue > 0)
                {
                    reversed  = reversed * 10 + absValue % 10;
                    absValue /= 10;
                }

                reversed = isNegative ? -reversed : reversed;

                return (T)Convert.ChangeType(reversed, typeof(T));
            }

            throw new NotSupportedException($"Unsupported type: {typeof(T)}");
        }

        static public string Reverse(this string initial)
        {
            if (string.IsNullOrEmpty(initial)) return initial;

            char[] charArray = initial.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static public T[]      Reverse<T>(this T[] array)
        {
            var result = new T[array.Length];

            Array.Copy(array, result, array.Length);
            Array.Reverse(result);

            return result;
        }
        static public List<T>  Reverse<T>(this List<T> list)
        {
            var result = new List<T>(list);

            result.Reverse();
            return result;
        }
        static public IList<T> Reverse<T>(this IList<T> collection)
        {
            var result = new T[collection.Count];

            for (var i = 0; i < collection.Count; i++)
                result[i] = collection[collection.Count - 1 - i];
            
            return [.. result];
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
                yield return collection[i];
        }



        static public string  Interval(string input, Int32 startId, Int32 endId)
        {
            if (startId < endId) return input[startId..endId];
            else return input[endId..startId].Reverse();
        }
        static public T[]     Interval<T>(T[] array, Int32 startId, Int32 endId)
        {
            var length = array.Length;

            if (startId < 0 || startId > length) throw new ArgumentOutOfRangeException(nameof(startId), "StartIndex is out of bounds");
            if (endId < 0 || endId > length) throw new ArgumentOutOfRangeException(nameof(endId), "EndIndex is out of bounds");

            if (startId < endId) return [.. array.ToList().GetRange(startId, endId - startId)];
            else
            {
                List<T> list = array.ToList().GetRange(endId, startId - endId);
                return Reverse(list.ToArray());
            }
        }
        static public List<T> Interval<T>(List<T> list, Int32 startId, Int32 endId)
        {
            var count = list.Count;
            if (startId < 0 || startId > count) throw new ArgumentOutOfRangeException(nameof(startId), "StartIndex is out of bounds");
            if (endId < 0 || endId > count) throw new ArgumentOutOfRangeException(nameof(endId), "EndIndex is out of bounds");

            if (startId < endId) return list.GetRange(startId, endId - startId);
            else
            {
                list = list.GetRange(endId, startId - endId);
                return Reverse(list);
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



        static public T XOR<T>(T initial, T key) where T : unmanaged
        {
            Byte[] initialBytes = ToBinary.LittleEndian(initial);
            Byte[] keyBytes     = ToBinary.LittleEndian(key);
            Byte[] resultBytes  = XOR(initialBytes, keyBytes);
            return FromBinary.LittleEndian<T>(resultBytes);
        }
        static public Byte[] XOR(Byte[] initial, Byte[] key)
        {
            ArgumentNullException.ThrowIfNull(initial);
            ArgumentNullException.ThrowIfNull(key);

            if (key.Length == 0) throw new ArgumentException("Key cannot be empty", nameof(key));

            Byte[] result = new Byte[initial.Length];
            for (var i = 0; i < initial.Length; i++)
                result[i] = (Byte)(initial[i] ^ key[i % key.Length]);

            return result;
        }
        static public List<Byte> XOR(List<Byte> initial, List<Byte> key)
        {
            ArgumentNullException.ThrowIfNull(initial);
            ArgumentNullException.ThrowIfNull(key);

            if (key.Count == 0) throw new ArgumentException("Key cannot be empty", nameof(key));

            var result = new List<Byte>(initial.Count);
            for (var i = 0; i < initial.Count; i++)
                result.Add((Byte)(initial[i] ^ key[i % key.Count]));

            return result;
        }
    }
}