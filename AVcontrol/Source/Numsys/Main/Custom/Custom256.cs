using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static public string CustomAsString256(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase, customDigits.Length)) return oldValue;

            UInt256 decimalValue = ToDecimalFromCustom256(oldValue, customDigits, oldBase);

            if (decimalValue == 0) return customDigits[0].ToString();
            else return FromDecimalToCustom256(decimalValue, customDigits, newBase);
        }
        static public string CustomAsString256(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
            => CustomAsString256(oldValue, oldBase, newBase, customDigits).PadLeft(outputLength, customDigits[0]);

        static public string ToCustomAsString256(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase, 36, customDigits.Length))
                return (string)oldValue.Select(c => customDigits[gDigits.IndexOf(c)]);

            UInt256 decimalValue = ToDecimal256(oldValue, oldBase);

            if (decimalValue == 0) return customDigits[0].ToString();
            else return FromDecimalToCustom256(decimalValue, customDigits, newBase);
        }
        static public string ToCustomAsString256(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
            => ToCustomAsString256(oldValue, oldBase, newBase, customDigits).PadLeft(outputLength, customDigits[0]);

        static public string FromCustomAsString256(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase, customDigits.Length, 36))
                return (string)oldValue.Select(c => gDigits[customDigits.IndexOf(c)]);

            UInt256 decimalValue = ToDecimalFromCustom256(oldValue, customDigits, oldBase);

            if (decimalValue == 0) return "0";
            else return FromDecimal256(decimalValue, newBase);
        }
        static public string FromCustomAsString256(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
            => FromCustomAsString256(oldValue, oldBase, newBase, customDigits).PadLeft(outputLength, '0');



        static public T[] FromCustomAsArray256<T>(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
            => [.. FromCustomAsList256<T>(oldValue, oldBase, newBase, customDigits)];
        static public T[] FromCustomAsArray256<T>(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
            => [.. FromCustomAsList256<T>(oldValue, oldBase, newBase, customDigits, outputLength)];



        static public List<T> FromCustomAsList256<T>(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase, customDigits.Length, 26))
                return [.. oldValue.Select(c => (T)Convert.ChangeType(customDigits.IndexOf(c), typeof(T)))];

            UInt256 decimalValue = ToDecimalFromCustom256(oldValue, customDigits, oldBase);

            if (decimalValue == 0) return [(T)Convert.ChangeType(0, typeof(T))];
            else return FromDecimal256<T>(decimalValue, newBase);
        }
        static public List<T> FromCustomAsList256<T>(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
        {
            List<T> result = FromCustomAsList256<T>(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, (T)Convert.ChangeType(0, typeof(T)));
            return result;
        }
    }
}