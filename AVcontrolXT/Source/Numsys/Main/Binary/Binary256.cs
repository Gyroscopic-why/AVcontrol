using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;



namespace AVcontrol.XT
{
    static public partial class Numsys
    {
        static public List<T> CustomAsBinary256<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits)
        {
            if (!AVcontrol.Numsys.BaseArgumentCheck(oldBase, newBase, customDigits.Count)) return oldValue;

            UInt256 decimalValue = ToDecimalFromCustom256(oldValue, customDigits, oldBase);

            if (decimalValue == 0) return [customDigits[0]];
            else return FromDecimalToCustom256(decimalValue, customDigits, newBase);
        }
        static public List<T> CustomAsBinary256<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits, Int32 outputLength)
        {
            List<T> result = CustomAsBinary256(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, customDigits[0]);
            return result;
        }

        static public List<T> ToCustomAsBinary256<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits)
        {
            Utils.TypeArgumentCheck<T>();

            if (!AVcontrol.Numsys.BaseArgumentCheck(oldBase, newBase, 36, customDigits.Count))
                return [.. oldValue.Select(b => (T)(object)customDigits[Convert.ToInt32(b)]!)];

            UInt256 decimalValue = ToDecimal256(oldValue, oldBase);

            if (decimalValue == 0) return [customDigits[0]];
            else return FromDecimalToCustom256(decimalValue, customDigits, newBase);
        }
        static public List<T> ToCustomAsBinary256<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits, Int32 outputLength)
        {
            Utils.TypeArgumentCheck<T>();

            List<T> result = ToCustomAsBinary256(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, customDigits[0]);
            return result;
        }

        static public List<T> FromCustomAsBinary256<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits)
        {
            Utils.TypeArgumentCheck<T>();

            if (!AVcontrol.Numsys.BaseArgumentCheck(oldBase, newBase, customDigits.Count, 36))
                return [.. oldValue.Select(c => (T)Convert.ChangeType(customDigits.IndexOf(c), typeof(T)))];

            UInt256 decimalValue = ToDecimalFromCustom256<T>(oldValue, customDigits, oldBase);

            if (decimalValue == 0) return [(T)Convert.ChangeType(0, typeof(T))];
            else return FromDecimal256<T>(decimalValue, newBase);
        }
        static public List<T> FromCustomAsBinary256<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits, Int32 outputLength)
        {
            Utils.TypeArgumentCheck<T>();

            List<T> result = FromCustomAsBinary256(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, (T)Convert.ChangeType(0, typeof(T)));
            return result;
        }
    }
}