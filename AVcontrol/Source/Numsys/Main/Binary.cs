using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static public List<T> CustomAsBinary<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return oldValue;

            Int64 decimalValue = ToDecimalFromCustom(oldValue, oldBase, customDigits);

            if (decimalValue == 0) return [customDigits[0]];
            else return FromDecimalToCustom(decimalValue, newBase, customDigits);
        }
        static public List<T> CustomAsBinary<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits, Int32 outputLength)
        {
            List<T> result = CustomAsBinary(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, customDigits[0]);
            return result;
        }
        
        static public List<T> ToCustomAsBinary<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits)
        {
            Utils.TypeArgumentCheck<T>();

            if (!BaseArgumentCheck(oldBase, newBase))
                return [.. oldValue.Select(b => (T)(object)customDigits[Convert.ToInt32(b)]!)];

            Int64 decimalValue = ToDecimal(oldValue, oldBase);

            if (decimalValue == 0) return [customDigits[0]];
            else return FromDecimalToCustom(decimalValue, newBase, customDigits);
        }
        static public List<T> ToCustomAsBinary<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits, Int32 outputLength)
        {
            Utils.TypeArgumentCheck<T>();

            List<T> result = ToCustomAsBinary(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, customDigits[0]);
            return result;
        }
        
        static public List<T> FromCustomAsBinary<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits)
        {
            Utils.TypeArgumentCheck<T>();

            if (!BaseArgumentCheck(oldBase, newBase)) return [.. oldValue.Select(c => (T)(object)customDigits.IndexOf(c))];

            Int64 decimalValue = ToDecimalFromCustom<T>(oldValue, oldBase, customDigits);

            if (decimalValue == 0) return [(T)(object)0];
            else return FromDecimal<T>(decimalValue, newBase);
        }
        static public List<T> FromCustomAsBinary<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits, Int32 outputLength)
        {
            Utils.TypeArgumentCheck<T>();

            List<T> result = FromCustomAsBinary(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, (T)(object)0);
            return result;
        }
    }
}