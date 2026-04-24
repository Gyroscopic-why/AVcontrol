using System;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static public Int64 ToDecimal(string oldValue, Int32 oldBase)
        {
            Int64 decimalValue = 0;

            foreach (char c in oldValue)
            {
                Int32 digit = CharToDigit(c);
                if (digit >= oldBase) throw new ArgumentException($"Digit '{c}' is invalid for base {oldBase}.");

                decimalValue = decimalValue * oldBase + digit;
            }

            return decimalValue;
        }
        static public Int64 ToDecimal<T>(List<T> oldValue, Int32 oldBase)
        {
            Utils.TypeArgumentCheck<T>();

            Int64 decimalValue = 0;
            foreach (T digit in oldValue)
            {
                Int64 parsedDigit = Convert.ToInt64(digit);
                if (parsedDigit >= oldBase) throw new ArgumentException(
                    $"Digit '{parsedDigit}' is invalid for base {oldBase}.");

                decimalValue = decimalValue * oldBase + parsedDigit;
            }

            return decimalValue;
        }
        static public Int64 ToDecimalFromCustom(string oldValue, Int32 oldBase, string customDigits)
        {
            Int64 decimalValue = 0;

            foreach (char c in oldValue)
            {
                Int32 digit = CharToDigit(c, oldBase, customDigits);
                decimalValue = decimalValue * oldBase + digit;
            }

            return decimalValue;
        }
        static public Int64 ToDecimalFromCustom<T>(List<T> oldValue, Int32 oldBase, List<T> customDigits)
        {
            Utils.TypeArgumentCheck<T>();

            Int64 decimalValue = 0;
            foreach (T digit in oldValue)
                decimalValue = decimalValue * oldBase + customDigits.IndexOf(digit);

            return decimalValue;
        }



        static public string FromDecimal(Int64 decimalValue, Int32 newBase)
            => FromDecimalToCustom(decimalValue, newBase, gDigits);
        static public List<T> FromDecimal<T>(Int64 decimalValue, Int32 newBase)
        {
            Utils.TypeArgumentCheck<T>();

            List<T> result = [];
            Int64 current = decimalValue;

            while (current > 0)
            {
                result.Add((T)Convert.ChangeType(current % newBase, typeof(T)));
                current /= newBase;
            }

            return Utils.Reverse(result);
        }
        static public string FromDecimalToCustom(Int64 decimalValue, Int32 newBase, string customDigits)
        {
            string result = "";
            Int64 current = decimalValue;

            while (current > 0)
            {
                Int32 remainder = (Int32)(current % newBase);
                result += customDigits[remainder];
                current /= newBase;
            }

            return Utils.Reverse(result);
        }
        static public List<T> FromDecimalToCustom<T>(Int64 decimalValue, Int32 newBase, List<T> customDigits)
        {
            Utils.TypeArgumentCheck<T>();

            List<T> result = [];
            Int64 current = decimalValue;

            while (current > 0)
            {
                Int32 remainder = (Int32)(current % newBase);
                result.Add(customDigits[remainder]);
                current /= newBase;
            }

            return Utils.Reverse(result);
        }
    }
}