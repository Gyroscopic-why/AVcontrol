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
        static public Int32[] Fast_2_8_10_16_AsArray(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if      (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16)
                throw new ArgumentOutOfRangeException(nameof(oldBase), "Bases must be 2, 8, 10 or 16");
            else if (newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException(nameof(newBase), "Bases must be 2, 8, 10 or 16");

            return Unsafe_2_8_10_16_AsArray(oldValue, oldBase, newBase);
        }
        static public Int32[] Fast_2_8_10_16_AsArray(string oldValue, Int32 oldBase, Int32 newBase, Int32 minOutputLength)
        {
            if      (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16)
                throw new ArgumentOutOfRangeException(nameof(oldBase), "Bases must be 2, 8, 10 or 16");
            else if (newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException(nameof(newBase), "Bases must be 2, 8, 10 or 16");

            return Unsafe_2_8_10_16_AsArray(oldValue, oldBase, newBase, minOutputLength);
        }
        static public List<Int32> Fast_2_8_10_16_AsList(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if      (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16)
                throw new ArgumentOutOfRangeException(nameof(oldBase), "Bases must be 2, 8, 10 or 16");
            else if (newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException(nameof(newBase), "Bases must be 2, 8, 10 or 16");

            return Unsafe_2_8_10_16_AsList(oldValue, oldBase, newBase);
        }
        static public List<Int32> Fast_2_8_10_16_AsList(string oldValue, Int32 oldBase, Int32 newBase, Int32 minOutputLength)
        {
            if      (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16)
                throw new ArgumentOutOfRangeException(nameof(oldBase), "Bases must be 2, 8, 10 or 16");
            else if (newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException(nameof(newBase), "Bases must be 2, 8, 10 or 16");

            return Unsafe_2_8_10_16_AsList(oldValue, oldBase, newBase, minOutputLength);
        }



        static private string Unsafe_2_8_10_16_AsString(string oldValue, Int32 oldBase, Int32 newBase)
            => Convert.ToString(Convert.ToInt64(oldValue, oldBase), newBase).ToUpper();
        static private string Unsafe_2_8_10_16_AsString(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
            => Unsafe_2_8_10_16_AsString(oldValue, oldBase, newBase).PadLeft(outputLength, '0');
        static private Int32[] Unsafe_2_8_10_16_AsArray(string oldValue, Int32 oldBase, Int32 newBase)
            => [.. Unsafe_2_8_10_16_AsList(oldValue, oldBase, newBase)];
        static private Int32[] Unsafe_2_8_10_16_AsArray(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
            => [.. Unsafe_2_8_10_16_AsList(oldValue, oldBase, newBase, outputLength)];
        static private List<Int32> Unsafe_2_8_10_16_AsList(string oldValue, Int32 oldBase, Int32 newBase)
        {
            Int64 decimalValue = Convert.ToInt64(oldValue, oldBase);
            string newValue = Convert.ToString(decimalValue, newBase).ToUpper();

            return [.. oldValue.Select(c => Convert.ToInt32(c.ToString(), newBase))];
        }
        static private List<Int32> Unsafe_2_8_10_16_AsList(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            List<Int32> result = Unsafe_2_8_10_16_AsList(oldValue, oldBase, newBase);

            while (result.Count < outputLength) result.Insert(0, 0);
            return result;
        }
    }
}