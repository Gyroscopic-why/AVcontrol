using System;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static public UInt256 ToDecimal256(string oldValue, Int32 oldBase)
        {
            UInt256 decimalValue = 0, oldBaseConv = (UInt256)oldBase;

            foreach (char c in oldValue)
            {
                UInt256 digit = CharToDigit256(c);
                if (digit >= oldBaseConv) throw new ArgumentException($"Digit '{c}' is invalid for base {oldBase}.");

                decimalValue = decimalValue * oldBaseConv + digit;
            }

            return decimalValue;
        }
        static public UInt256 ToDecimal256<T>(List<T> oldValue, Int32 oldBase)
        {
            Utils.TypeArgumentCheck<T>();

            UInt256 decimalValue = 0, oldBaseConv = (UInt256)oldBase;
            foreach (T digit in oldValue)
            {
                UInt256 parsedDigit = (UInt256)Convert.ToInt64(digit);
                if (parsedDigit >= oldBaseConv)
                    throw new ArgumentException
                    (
                        $"Digit '{parsedDigit}' is invalid for base {oldBase}."
                    );

                decimalValue = decimalValue * oldBaseConv + parsedDigit;
            }

            return decimalValue;
        }
        static public UInt256 ToDecimalFromCustom256(string oldValue, Int32 oldBase, string customDigits)
        {
            UInt256 decimalValue = 0, oldBaseConv = (UInt256)oldBase;

            foreach (char c in oldValue)
            {
                UInt256 digit = CharToDigit256(c, oldBase, customDigits);
                decimalValue = decimalValue * oldBaseConv + digit;
            }

            return decimalValue;
        }
        static public UInt256 ToDecimalFromCustom256<T>(List<T> oldValue, Int32 oldBase, List<T> customDigits)
        {
            Utils.TypeArgumentCheck<T>();

            UInt256 decimalValue = 0, oldBaseConv = (UInt256)oldBase;
            foreach (T digit in oldValue)
                decimalValue = decimalValue * oldBaseConv + (UInt256)customDigits.IndexOf(digit);

            return decimalValue;
        }



        static public string  FromDecimal256(UInt256 decimalValue, Int32 newBase)
            => FromDecimalToCustom256(decimalValue, newBase, gDigits);
        static public List<T> FromDecimal256<T>(UInt256 decimalValue, Int32 newBase)
        {
            Utils.TypeArgumentCheck<T>();

            List<T> result = [];
            UInt256 current = decimalValue, newBaseConv = (UInt256)newBase;

            while (current > 0)
            {
                result.Add((T)Convert.ChangeType(current % newBaseConv, typeof(T)));
                current /= newBaseConv;
            }

            return Utils.Reverse(result);
        }
        static public string  FromDecimalToCustom256(UInt256 decimalValue, Int32 newBase, string customDigits)
        {
            string result = "";
            UInt256 current = decimalValue, newBaseConv = (UInt256)newBase;

            while (current > 0)
            {
                Int32 remainder = (Int32)(current % newBaseConv);
                result += customDigits[remainder];
                current /= newBaseConv;
            }

            return Utils.Reverse(result);
        }
        static public List<T> FromDecimalToCustom256<T>(UInt256 decimalValue, Int32 newBase, List<T> customDigits)
        {
            Utils.TypeArgumentCheck<T>();

            List<T> result = [];
            UInt256 current = decimalValue, newBaseConv = (UInt256)newBase;

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