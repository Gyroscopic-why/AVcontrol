using System;
using System.Globalization;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Utils
    {
        static public T Reverse<T>(T initial) where T : struct, IConvertible
        {
            if (typeof(T).IsPrimitive && typeof(T) != typeof(bool) && typeof(T) != typeof(char))
            {
                Int64 value = Convert.ToInt64(initial, CultureInfo.InvariantCulture);
                bool isNegative = value < 0;

                Int64 absValue = Math.Abs(value);

                Int64 reversed = 0;
                while (absValue > 0)
                {
                    reversed = reversed * 10 + absValue % 10;
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


        static public T[] Reverse<T>(this T[] array)
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


        static public T[]  Reverse<T>(this ReadOnlySpan<T> span)
        {
            T[] result = new T[span.Length];

            for (Int32 i = 0; i < span.Length; i++)
                result[i] = span[span.Length - 1 - i];

            return result;
        }
        static public void ReverseVoid<T>(this Span<T> span)
        {
            Int32 i = 0, j = span.Length - 1;
            while (i < j)
            {
                (span[j], span[i]) = (span[i], span[j]);
                i++;
                j--;
            }
        }
        static public void ReverseVoid<T>(this Memory<T> memory) => memory.Span.Reverse();
    }
}