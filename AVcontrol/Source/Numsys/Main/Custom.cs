using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static public string CustomAsString(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return oldValue;

            Int64 decimalValue = ToDecimalFromCustom(oldValue, oldBase, customDigits);

            if (decimalValue == 0) return customDigits[0].ToString();
            else return FromDecimalToCustom(decimalValue, newBase, customDigits);
        }
        static public string CustomAsString(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
            => CustomAsString(oldValue, oldBase, newBase, customDigits).PadLeft(outputLength, customDigits[0]);

        static public string ToCustomAsString(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return (string)oldValue.Select(c => customDigits[gDigits.IndexOf(c)]);

            Int64 decimalValue = ToDecimal(oldValue, oldBase);

            if (decimalValue == 0) return customDigits[0].ToString();
            else return FromDecimalToCustom(decimalValue, newBase, customDigits);
        }
        static public string ToCustomAsString(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
            => ToCustomAsString(oldValue, oldBase, newBase, customDigits).PadLeft(outputLength, customDigits[0]);

        static public string FromCustomAsString(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return (string)oldValue.Select(c => gDigits[customDigits.IndexOf(c)]);

            Int64 decimalValue = ToDecimalFromCustom(oldValue, oldBase, customDigits);

            if (decimalValue == 0) return "0";
            else return FromDecimal(decimalValue, newBase);
        }
        static public string FromCustomAsString(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
            => FromCustomAsString(oldValue, oldBase, newBase, customDigits).PadLeft(outputLength, '0');



        static public Int32[] FromCustomAsArray(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
            => [.. FromCustomAsList(oldValue, oldBase, newBase, customDigits)];
        static public Int32[] FromCustomAsArray(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
            => [.. FromCustomAsList(oldValue, oldBase, newBase, customDigits, outputLength)];



        static public List<Int32> FromCustomAsList(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return [.. oldValue.Select(c => gDigits.IndexOf(c))];

            Int64 decimalValue = ToDecimalFromCustom(oldValue, oldBase, customDigits);

            if (decimalValue == 0) return [0];
            else return FromDecimal<Int32>(decimalValue, newBase);
        }
        static public List<Int32> FromCustomAsList(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
        {
            List<Int32> result = FromCustomAsList(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, 0);
            return result;
        }
    }
}