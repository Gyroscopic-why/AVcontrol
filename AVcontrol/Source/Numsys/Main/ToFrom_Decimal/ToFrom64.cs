using System;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static public UInt64 ToDecimal64(string oldValue, Int32 oldBase)
        {
            UInt64 decimalValue = 0, oldBaseConv = (UInt64)oldBase;

            foreach (char c in oldValue)
            {
                UInt64 digit = CharToDigit64(c);
                if (digit >= oldBaseConv) throw new ArgumentException($"Digit '{c}' is invalid for base {oldBase}.");

                decimalValue = decimalValue * oldBaseConv + digit;
            }

            return decimalValue;
        }
        static public UInt64 ToDecimal64<T>(List<T> oldValue, Int32 oldBase)
        {
            Utils.TypeArgumentCheck<T>();

            UInt64 decimalValue = 0, oldBaseConv = (UInt64)oldBase;
            foreach (T digit in oldValue)
            {
                UInt64 parsedDigit = (UInt64)Convert.ToInt64(digit);
                if (parsedDigit >= oldBaseConv)
                    throw new ArgumentException
                    (
                        $"Digit '{parsedDigit}' is invalid for base {oldBase}."
                    );

                decimalValue = decimalValue * oldBaseConv + parsedDigit;
            }

            return decimalValue;
        }
        static public UInt64 ToDecimalFromCustom64(string oldValue, Int32 oldBase, string customDigits)
        {
            UInt64 decimalValue = 0, oldBaseConv = (UInt64)oldBase;

            foreach (char c in oldValue)
            {
                UInt64 digit = CharToDigit64(c, oldBase, customDigits);
                decimalValue = decimalValue * oldBaseConv + digit;
            }

            return decimalValue;
        }
        static public UInt64 ToDecimalFromCustom64<T>(List<T> oldValue, Int32 oldBase, List<T> customDigits)
        {
            Utils.TypeArgumentCheck<T>();

            UInt64 decimalValue = 0, oldBaseConv = (UInt64)oldBase;
            foreach (T digit in oldValue)
                decimalValue = decimalValue * oldBaseConv + (UInt64)customDigits.IndexOf(digit);

            return decimalValue;
        }



        static public string  FromDecimal64(UInt64 decimalValue, Int32 newBase)
            => FromDecimalToCustom64(decimalValue, newBase, gDigits);
        static public List<T> FromDecimal64<T>(UInt64 decimalValue, Int32 newBase)
        {
            Utils.TypeArgumentCheck<T>();

            List<T> result = [];
            UInt64 current = decimalValue, newBaseConv = (UInt64)newBase;

            while (current > 0)
            {
                result.Add((T)Convert.ChangeType(current % newBaseConv, typeof(T)));
                current /= newBaseConv;
            }

            return Utils.Reverse(result);
        }
        static public string  FromDecimalToCustom64(UInt64 decimalValue, Int32 newBase, string customDigits)
        {
            string result = "";
            UInt64 current = decimalValue, newBaseConv = (UInt64)newBase;

            while (current > 0)
            {
                Int32 remainder = (Int32)(current % newBaseConv);
                result += customDigits[remainder];
                current /= newBaseConv;
            }
            
            return Utils.Reverse(result);
        }
        static public List<T> FromDecimalToCustom64<T>(UInt64 decimalValue, Int32 newBase, List<T> customDigits)
        {
            Utils.TypeArgumentCheck<T>();

            List<T> result = [];
            UInt64 current = decimalValue, newBaseConv = (UInt64)newBase;

            while (current > 0)
            {
                Int32 remainder = (Int32)(current % newBaseConv);
                result.Add(customDigits[remainder]);
                current /= newBaseConv;
            }

            return Utils.Reverse(result);
        }
    }
}