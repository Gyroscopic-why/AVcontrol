using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static public string AsString256(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return oldValue;

            UInt256 decimalValue = ToDecimal256(oldValue, oldBase);

            if (decimalValue == 0) return "0";
            else return FromDecimal256(decimalValue, newBase);
        }
        static public string AsString256(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
            => AsString256(oldValue, oldBase, newBase).PadLeft(outputLength, '0');


        static public T[] AsArray256<T>(string oldValue, Int32 oldBase, Int32 newBase)
            => [.. AsList256<T>(oldValue, oldBase, newBase)];
        static public T[] AsArray256<T>(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
            => [.. AsList256<T>(oldValue, oldBase, newBase, outputLength)];


        static public List<T> AsList256<T>(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (!BaseArgumentCheck(oldBase, newBase))
                return [.. oldValue.Select(c => (T)Convert.ChangeType(gDigits.IndexOf(c), typeof(T)))];

            UInt256 decimalValue = ToDecimal256(oldValue, oldBase);

            if (decimalValue == 0) return [(T)Convert.ChangeType(0, typeof(T))];
            else return [.. FromDecimal256<T>(decimalValue, newBase)];
        }
        static public List<T> AsList256<T>(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            List<T> result = AsList256<T>(oldValue, oldBase, newBase);

            while (result.Count < outputLength) result.Insert(0, (T)Convert.ChangeType(0, typeof(T)));
            return result;
        }
    }
}