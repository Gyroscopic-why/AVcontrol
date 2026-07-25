using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static public string CustomAsString128(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase, customDigits.Length)) return oldValue;

            UInt128 decimalValue = ToDecimalFromCustom128(oldValue, oldBase, customDigits);

            if (decimalValue == 0) return customDigits[0].ToString();
            else return FromDecimalToCustom128(decimalValue, newBase, customDigits);
        }
        static public string CustomAsString128(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
            => CustomAsString128(oldValue, oldBase, newBase, customDigits).PadLeft(outputLength, customDigits[0]);

        static public string ToCustomAsString128(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase, 36, customDigits.Length))
                return (string)oldValue.Select(c => customDigits[gDigits.IndexOf(c)]);

            UInt128 decimalValue = ToDecimal128(oldValue, oldBase);

            if (decimalValue == 0) return customDigits[0].ToString();
            else return FromDecimalToCustom128(decimalValue, newBase, customDigits);
        }
        static public string ToCustomAsString128(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
            => ToCustomAsString128(oldValue, oldBase, newBase, customDigits).PadLeft(outputLength, customDigits[0]);

        static public string FromCustomAsString128(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase, customDigits.Length, 36))
                return (string)oldValue.Select(c => gDigits[customDigits.IndexOf(c)]);

            UInt128 decimalValue = ToDecimalFromCustom128(oldValue, oldBase, customDigits);

            if (decimalValue == 0) return "0";
            else return FromDecimal128(decimalValue, newBase);
        }
        static public string FromCustomAsString128(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
            => FromCustomAsString128(oldValue, oldBase, newBase, customDigits).PadLeft(outputLength, '0');



        static public T[] FromCustomAsArray128<T>(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
            => [.. FromCustomAsList128<T>(oldValue, oldBase, newBase, customDigits)];
        static public T[] FromCustomAsArray128<T>(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
            => [.. FromCustomAsList128<T>(oldValue, oldBase, newBase, customDigits, outputLength)];



        static public List<T> FromCustomAsList128<T>(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase, customDigits.Length, 26))
                return [.. oldValue.Select(c => (T)Convert.ChangeType(customDigits.IndexOf(c), typeof(T)))];

            UInt128 decimalValue = ToDecimalFromCustom128(oldValue, oldBase, customDigits);

            if (decimalValue == 0) return [(T)Convert.ChangeType(0, typeof(T))];
            else return FromDecimal128<T>(decimalValue, newBase);
        }
        static public List<T> FromCustomAsList128<T>(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
        {
            List<T> result = FromCustomAsList128<T>(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, (T)Convert.ChangeType(0, typeof(T)));
            return result;
        }
    }
}