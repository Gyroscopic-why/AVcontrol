using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static public List<T> CustomAsBinary64<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase, customDigits.Count)) return oldValue;

            UInt64 decimalValue = ToDecimalFromCustom64(oldValue, oldBase, customDigits);

            if (decimalValue == 0) return [customDigits[0]];
            else return FromDecimalToCustom64(decimalValue, newBase, customDigits);
        }
        static public List<T> CustomAsBinary64<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits, Int32 outputLength)
        {
            List<T> result = CustomAsBinary64(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, customDigits[0]);
            return result;
        }
        
        static public List<T> ToCustomAsBinary64<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits)
        {
            Utils.TypeArgumentCheck<T>();

            if (!BaseArgumentCheck(oldBase, newBase, 36, customDigits.Count))
                return [.. oldValue.Select(b => (T)(object)customDigits[Convert.ToInt32(b)]!)];

            UInt64 decimalValue = ToDecimal64(oldValue, oldBase);

            if (decimalValue == 0) return [customDigits[0]];
            else return FromDecimalToCustom64(decimalValue, newBase, customDigits);
        }
        static public List<T> ToCustomAsBinary64<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits, Int32 outputLength)
        {
            Utils.TypeArgumentCheck<T>();

            List<T> result = ToCustomAsBinary64(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, customDigits[0]);
            return result;
        }
        
        static public List<T> FromCustomAsBinary64<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits)
        {
            Utils.TypeArgumentCheck<T>();

            if (!BaseArgumentCheck(oldBase, newBase, customDigits.Count, 36))
                return [.. oldValue.Select(c => (T)Convert.ChangeType(customDigits.IndexOf(c), typeof(T)))];

            UInt64 decimalValue = ToDecimalFromCustom64<T>(oldValue, oldBase, customDigits);

            if (decimalValue == 0) return [(T)Convert.ChangeType(0, typeof(T))];
            else return FromDecimal64<T>(decimalValue, newBase);
        }
        static public List<T> FromCustomAsBinary64<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits, Int32 outputLength)
        {
            Utils.TypeArgumentCheck<T>();

            List<T> result = FromCustomAsBinary64(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, (T)Convert.ChangeType(0, typeof(T)));
            return result;
        }
    }
}