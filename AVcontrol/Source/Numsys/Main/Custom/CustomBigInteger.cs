using System;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static public string CustomAsStringBigInteger(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase, customDigits.Length)) return oldValue;

            BigInteger decimalValue = ToDecimalFromCustomBigInteger(oldValue, customDigits, oldBase);

            if (decimalValue == 0) return customDigits[0].ToString();
            else return FromDecimalToCustomBigInteger(decimalValue, customDigits, newBase);
        }
        static public string CustomAsStringBigInteger(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
            => CustomAsStringBigInteger(oldValue, oldBase, newBase, customDigits).PadLeft(outputLength, customDigits[0]);

        static public string ToCustomAsStringBigInteger(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase, 36, customDigits.Length))
                return (string)oldValue.Select(c => customDigits[gDigits.IndexOf(c)]);

            BigInteger decimalValue = ToDecimalBigInteger(oldValue, oldBase);

            if (decimalValue == 0) return customDigits[0].ToString();
            else return FromDecimalToCustomBigInteger(decimalValue, customDigits, newBase);
        }
        static public string ToCustomAsStringBigInteger(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
            => ToCustomAsStringBigInteger(oldValue, oldBase, newBase, customDigits).PadLeft(outputLength, customDigits[0]);

        static public string FromCustomAsStringBigInteger(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase, customDigits.Length, 36))
                return (string)oldValue.Select(c => gDigits[customDigits.IndexOf(c)]);

            BigInteger decimalValue = ToDecimalFromCustomBigInteger(oldValue, customDigits, oldBase);

            if (decimalValue == 0) return "0";
            else return FromDecimalToCustomBigInteger(decimalValue, customDigits, newBase);
        }
        static public string FromCustomAsStringBigInteger(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
            => FromCustomAsStringBigInteger(oldValue, oldBase, newBase, customDigits).PadLeft(outputLength, '0');



        static public List<T> FromCustomAsListBigInteger<T>(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase, customDigits.Length, 26))
                return [.. oldValue.Select(c => (T)Convert.ChangeType(customDigits.IndexOf(c), typeof(T)))];

            BigInteger decimalValue = ToDecimalFromCustomBigInteger(oldValue, customDigits, oldBase);

            if (decimalValue == 0) return [(T)Convert.ChangeType(0, typeof(T))];
            else return FromDecimalBigInteger<T>(decimalValue, newBase);
        }
        static public List<T> FromCustomAsListBigInteger<T>(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
        {
            List<T> result = FromCustomAsListBigInteger<T>(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, (T)Convert.ChangeType(0, typeof(T)));
            return result;
        }
    }
}