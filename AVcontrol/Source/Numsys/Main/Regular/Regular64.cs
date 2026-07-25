using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static public string AsString64(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return oldValue;

            UInt64 decimalValue = ToDecimal64(oldValue, oldBase);

            if (decimalValue == 0) return "0";
            else return FromDecimal64(decimalValue, newBase);
        }
        static public string AsString64(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
            => AsString64(oldValue, oldBase, newBase).PadLeft(outputLength, '0');


        static public T[] AsArray64<T>(string oldValue, Int32 oldBase, Int32 newBase)
            => [.. AsList64<T>(oldValue, oldBase, newBase)];
        static public T[] AsArray64<T>(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
            => [.. AsList64<T>(oldValue, oldBase, newBase, outputLength)];


        static public List<T> AsList64<T>(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (!BaseArgumentCheck(oldBase, newBase))
                return [.. oldValue.Select(c => (T)Convert.ChangeType(gDigits.IndexOf(c), typeof(T)))];

            UInt64 decimalValue = ToDecimal64(oldValue, oldBase);

            if (decimalValue == 0) return [(T)Convert.ChangeType(0, typeof(T))];
            else return [.. FromDecimal64<T>(decimalValue, newBase)];
        }
        static public List<T> AsList64<T>(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            List<T> result = AsList64<T>(oldValue, oldBase, newBase);

            while (result.Count < outputLength) result.Insert(0, (T)Convert.ChangeType(0, typeof(T)));
            return result;
        }
    }
}