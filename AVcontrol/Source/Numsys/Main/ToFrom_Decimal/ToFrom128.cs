using System;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static public UInt128 ToDecimal128(string oldValue, Int32 oldBase)
        {
            UInt128 decimalValue = 0, oldBaseConv = (UInt128)oldBase;

            foreach (char c in oldValue)
            {
                UInt128 digit = CharToDigit128(c);
                if (digit >= oldBaseConv) throw new ArgumentException($"Digit '{c}' is invalid for base {oldBase}.");

                decimalValue = decimalValue * oldBaseConv + digit;
            }

            return decimalValue;
        }
        static public UInt128 ToDecimal128<T>(List<T> oldValue, Int32 oldBase)
        {
            Utils.TypeArgumentCheck<T>();

            UInt128 decimalValue = 0, oldBaseConv = (UInt128)oldBase;
            foreach (T digit in oldValue)
            {
                UInt128 parsedDigit = (UInt128)Convert.ToInt64(digit);
                if (parsedDigit >= oldBaseConv)
                    throw new ArgumentException
                    (
                        $"Digit '{parsedDigit}' is invalid for base {oldBase}."
                    );

                decimalValue = decimalValue * oldBaseConv + parsedDigit;
            }

            return decimalValue;
        }
        static public UInt128 ToDecimalFromCustom128(string oldValue, Int32 oldBase, string customDigits)
        {
            UInt128 decimalValue = 0, oldBaseConv = (UInt128)oldBase;

            foreach (char c in oldValue)
            {
                UInt128 digit = CharToDigit128(c, oldBase, customDigits);
                decimalValue  = decimalValue * oldBaseConv + digit;
            }

            return decimalValue;
        }
        static public UInt128 ToDecimalFromCustom128<T>(List<T> oldValue, Int32 oldBase, List<T> customDigits)
        {
            Utils.TypeArgumentCheck<T>();

            UInt128 decimalValue = 0, oldBaseConv = (UInt128)oldBase;
            foreach (T digit in oldValue)
                decimalValue = decimalValue * oldBaseConv + (UInt128)customDigits.IndexOf(digit);

            return decimalValue;
        }



        static public string  FromDecimal128(UInt128 decimalValue, Int32 newBase)
            => FromDecimalToCustom128(decimalValue, newBase, gDigits);
        static public List<T> FromDecimal128<T>(UInt128 decimalValue, Int32 newBase)
        {
            Utils.TypeArgumentCheck<T>();

            List<T> result  = [];
            UInt128 current = decimalValue, newBaseConv = (UInt128)newBase;

            while (current > 0)
            {
                result.Add((T)Convert.ChangeType(current % newBaseConv, typeof(T)));
                current /= newBaseConv;
            }

            return Utils.Reverse(result);
        }
        static public string  FromDecimalToCustom128(UInt128 decimalValue, Int32 newBase, string customDigits)
        {
            string result = "";
            UInt128 current = decimalValue, newBaseConv = (UInt128)newBase;

            while (current > 0)
            {
                Int32 remainder = (Int32)(current % newBaseConv);
                result += customDigits[remainder];
                current /= newBaseConv;
            }

            return Utils.Reverse(result);
        }
        static public List<T> FromDecimalToCustom128<T>(UInt128 decimalValue, Int32 newBase, List<T> customDigits)
        {
            Utils.TypeArgumentCheck<T>();

            List<T> result = [];
            UInt128 current = decimalValue, newBaseConv = (UInt128)newBase;

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