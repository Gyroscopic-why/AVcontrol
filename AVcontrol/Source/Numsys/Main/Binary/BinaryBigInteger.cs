using System;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static public List<T> CustomAsBinaryBigInteger<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase, customDigits.Count)) return oldValue;

            BigInteger decimalValue = ToDecimalFromCustomBigInteger(oldValue, customDigits, oldBase);

            if (decimalValue == 0) return [customDigits[0]];
            else return FromDecimalToCustomBigInteger(decimalValue, customDigits, newBase);
        }
        static public List<T> CustomAsBinaryBigInteger<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits, Int32 outputLength)
        {
            List<T> result = CustomAsBinaryBigInteger(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, customDigits[0]);
            return result;
        }

        static public List<T> ToCustomAsBinaryBigInteger<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits)
        {
            Utils.TypeArgumentCheck<T>();

            if (!BaseArgumentCheck(oldBase, newBase, 36, customDigits.Count))
                return [.. oldValue.Select(b => (T)(object)customDigits[Convert.ToInt32(b)]!)];

            BigInteger decimalValue = ToDecimalBigInteger(oldValue, oldBase);

            if (decimalValue == 0) return [customDigits[0]];
            else return FromDecimalToCustomBigInteger(decimalValue, customDigits, newBase);
        }
        static public List<T> ToCustomAsBinaryBigInteger<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits, Int32 outputLength)
        {
            Utils.TypeArgumentCheck<T>();

            List<T> result = ToCustomAsBinaryBigInteger(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, customDigits[0]);
            return result;
        }

        static public List<T> FromCustomAsBinaryBigInteger<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits)
        {
            Utils.TypeArgumentCheck<T>();

            if (!BaseArgumentCheck(oldBase, newBase, customDigits.Count, 36))
                return [.. oldValue.Select(c => (T)Convert.ChangeType(customDigits.IndexOf(c), typeof(T)))];

            BigInteger decimalValue = ToDecimalFromCustomBigInteger(oldValue, customDigits, oldBase);

            if (decimalValue == 0) return [(T)Convert.ChangeType(0, typeof(T))];
            else return FromDecimalToCustomBigInteger(decimalValue, customDigits, newBase);
        }
        static public List<T> FromCustomAsBinaryBigInteger<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits, Int32 outputLength)
        {
            Utils.TypeArgumentCheck<T>();

            List<T> result = FromCustomAsBinaryBigInteger(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, (T)Convert.ChangeType(0, typeof(T)));
            return result;
        }
    }
}