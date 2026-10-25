using System;
using System.Globalization;
using System.Collections.Generic;
using System.Runtime.InteropServices;



namespace AVcontrol
{
    static public partial class Utils
    {
        static public T Reverse<T>(T initial) where T : struct, IConvertible
        {
            Type t = typeof(T);
            if (!t.IsPrimitive
                || t == typeof(bool)   || t == typeof(Char)
                || t == typeof(IntPtr) || t == typeof(UIntPtr))
                throw new NotSupportedException($"Unsupported type: {t}");

            bool isSigned = t == typeof(SByte) || t == typeof(Int16)
                         || t == typeof(Int32) || t == typeof(Int64)
                         || t == typeof(float) || t == typeof(double);

            if (isSigned)
            {
                Int64 value = Convert.ToInt64(initial, CultureInfo.InvariantCulture);
                bool isNegative = value < 0;

                UInt64 absValue = isNegative ? unchecked((UInt64)(-value)) : (UInt64)value, reversed = 0;
                while (absValue > 0)
                {
                    reversed = reversed * 10 + absValue % 10;
                    absValue /= 10;
                }

                return (T)Convert.ChangeType
                    (
                        isNegative ? checked(-(Int64)reversed) : checked((Int64)reversed),
                        t, CultureInfo.InvariantCulture
                    );
            }
            else
            {
                UInt64 absValue = Convert.ToUInt64(initial, CultureInfo.InvariantCulture);

                UInt64 reversed = 0;
                while (absValue > 0)
                {
                    reversed  = reversed * 10 + absValue % 10;
                    absValue /= 10;
                }

                return (T)Convert.ChangeType(reversed, t, CultureInfo.InvariantCulture);
            }
        }
        static public string Reverse(this string initial)
        {
            if (string.IsNullOrEmpty(initial)) return initial;

            return string.Create
                (
                    initial.Length, initial, static (dst, src) =>
                    {
                        for (var i = 0; i < src.Length; i++)
                            dst[i] = src[src.Length - 1 - i];
                    }
                );
        }

        static public T[] Reverse<T>(this T[] array)
        {
            ArgumentNullException.ThrowIfNull(array);

            Int32 n = array.Length;
            T[] result = new T[n];

            for (Int32 i = 0, j = n - 1; i < n; i++, j--)
                result[i] = array[j];

            return result;
        }
        static public List<T> Reverse<T>(this List<T> list)
        {
            ArgumentNullException.ThrowIfNull(list);

            Int32 n = list.Count;
            List<T> result = new(n);
            CollectionsMarshal.SetCount(result, n);

            Span<T> dst = CollectionsMarshal.AsSpan(result);
            ReadOnlySpan<T> src = CollectionsMarshal.AsSpan(list);

            for (Int32 i = 0, j = n - 1; i < n; i++, j--)
                dst[i] = src[j];

            return result;
        }
        static public IList<T> Reverse<T>(this IList<T> collection)
        {
            ArgumentNullException.ThrowIfNull(collection);

            Int32 n = collection.Count;
            List<T> result = new(n);
            CollectionsMarshal.SetCount(result, n);

            Span<T> dst = CollectionsMarshal.AsSpan(result);

            for (Int32 i = 0, j = n - 1; i < n; i++, j--)
                dst[i] = collection[j];

            return result;
        }

        static public IEnumerable<T> Reverse<T>(this IEnumerable<T> collection)
        {
            if (collection == null) yield break;

            Int32 capacity = collection is ICollection<T> c ? c.Count : 0;
            var buffer = new List<T>(capacity);

            foreach (T item in collection) buffer.Add(item);
            for (Int32 i = buffer.Count - 1; i >= 0; i--) yield return buffer[i];
        }
        static public IEnumerable<T> FastReverse<T>(this IList<T> collection)
        {
            for (var i = collection.Count - 1; i >= 0; i--)
                yield return collection[i];
        }
        static public T[] Reverse<T>(this ReadOnlySpan<T> span)
        {
            Int32 n = span.Length;
            T[] result = new T[n];

            for (Int32 i = 0, j = n - 1; i < n; i++, j--)
                result[i] = span[j];

            return result;
        }

        static public void ReverseInPlace<T>(this Span<T> span)
        {
            Int32 i = 0, j = span.Length - 1;
            while (i < j)
            {
                (span[i], span[j]) = (span[j], span[i]);
                i++;
                j--;
            }
        }
        static public void ReverseInPlace<T>(this Memory<T> memory) => ReverseInPlace(memory.Span);
    }
}