using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static public string Fast_2_8_10_16_AsString(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if      (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16)
                throw new ArgumentOutOfRangeException(nameof(oldBase), "Bases must be 2, 8, 10 or 16");
            else if (newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException(nameof(newBase), "Bases must be 2, 8, 10 or 16");

            return Unsafe_2_8_10_16_AsString(oldValue, oldBase, newBase);
        }
        static public string Fast_2_8_10_16_AsString(string oldValue, Int32 oldBase, Int32 newBase, Int32 minOutputLength)
        {
            if      (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16)
                throw new ArgumentOutOfRangeException(nameof(oldBase), "Bases must be 2, 8, 10 or 16");
            else if (newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException(nameof(newBase), "Bases must be 2, 8, 10 or 16");

            return Unsafe_2_8_10_16_AsString(oldValue, oldBase, newBase, minOutputLength);
        }
        static public T[] Fast_2_8_10_16_AsArray<T>(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if      (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16)
                throw new ArgumentOutOfRangeException(nameof(oldBase), "Bases must be 2, 8, 10 or 16");
            else if (newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException(nameof(newBase), "Bases must be 2, 8, 10 or 16");

            return Unsafe_2_8_10_16_AsArray<T>(oldValue, oldBase, newBase);
        }
        static public T[] Fast_2_8_10_16_AsArray<T>(string oldValue, Int32 oldBase, Int32 newBase, Int32 minOutputLength)
        {
            if      (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16)
                throw new ArgumentOutOfRangeException(nameof(oldBase), "Bases must be 2, 8, 10 or 16");
            else if (newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException(nameof(newBase), "Bases must be 2, 8, 10 or 16");

            return Unsafe_2_8_10_16_AsArray<T>(oldValue, oldBase, newBase, minOutputLength);
        }
        static public List<T> Fast_2_8_10_16_AsList<T>(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if      (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16)
                throw new ArgumentOutOfRangeException(nameof(oldBase), "Bases must be 2, 8, 10 or 16");
            else if (newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException(nameof(newBase), "Bases must be 2, 8, 10 or 16");

            return Unsafe_2_8_10_16_AsList<T>(oldValue, oldBase, newBase);
        }
        static public List<T> Fast_2_8_10_16_AsList<T>(string oldValue, Int32 oldBase, Int32 newBase, Int32 minOutputLength)
        {
            if      (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16)
                throw new ArgumentOutOfRangeException(nameof(oldBase), "Bases must be 2, 8, 10 or 16");
            else if (newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException(nameof(newBase), "Bases must be 2, 8, 10 or 16");

            return Unsafe_2_8_10_16_AsList<T>(oldValue, oldBase, newBase, minOutputLength);
        }



        static private string Unsafe_2_8_10_16_AsString(string oldValue, Int32 oldBase, Int32 newBase)
            => Convert.ToString(Convert.ToInt64(oldValue, oldBase), newBase).ToUpper();
        static private string Unsafe_2_8_10_16_AsString(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
            => Unsafe_2_8_10_16_AsString(oldValue, oldBase, newBase).PadLeft(outputLength, '0');
        static private T[] Unsafe_2_8_10_16_AsArray<T>(string oldValue, Int32 oldBase, Int32 newBase)
            => [.. Unsafe_2_8_10_16_AsList<T>(oldValue, oldBase, newBase)];
        static private T[] Unsafe_2_8_10_16_AsArray<T>(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
            => [.. Unsafe_2_8_10_16_AsList<T>(oldValue, oldBase, newBase, outputLength)];
        static private List<T> Unsafe_2_8_10_16_AsList<T>(string oldValue, Int32 oldBase, Int32 newBase)
        {
            Int64 decimalValue = Convert.ToInt64(oldValue, oldBase);
            string newValue = Convert.ToString(decimalValue, newBase).ToUpper();

            return [.. oldValue.Select(c => 
                (T)Convert.ChangeType
                (
                    Convert.ToInt32(c.ToString(), newBase),
                    typeof(T)
                )
            )];
        }
        static private List<T> Unsafe_2_8_10_16_AsList<T>(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            List<T> result = Unsafe_2_8_10_16_AsList<T>(oldValue, oldBase, newBase);

            while (result.Count < outputLength) result.Insert(0, (T)(Convert.ChangeType(0, typeof(T))));
            return result;
        }
    }
}