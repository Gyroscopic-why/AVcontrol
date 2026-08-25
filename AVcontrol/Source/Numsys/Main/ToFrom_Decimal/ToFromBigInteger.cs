using System;
using System.Numerics;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static public BigInteger ToDecimalBigInteger(string oldValue, Int32 oldBase)
        {
            BigInteger decimalValue = 0;
            UInt64 oldBaseConv = (UInt64)oldBase;

            foreach (char c in oldValue)
            {
                UInt64 digit = CharToDigit64(c);
                if (digit >= oldBaseConv) throw new ArgumentException($"Digit '{c}' is invalid for base {oldBase}.");

                decimalValue = decimalValue * oldBaseConv + digit;
            }

            return decimalValue;
        }
        static public BigInteger ToDecimalBigInteger<T>(List<T> oldValue, Int32 oldBase)
        {
            Utils.TypeArgumentCheck<T>();

            BigInteger decimalValue = 0;
            UInt64 oldBaseConv = (UInt64)oldBase;

            foreach (T digit in oldValue)
            {
                UInt64 parsedDigit = Convert.ToUInt64(digit);
                if (parsedDigit >= oldBaseConv)
                    throw new ArgumentException
                    (
                        $"Digit '{parsedDigit}' is invalid for base {oldBase}."
                    );

                decimalValue = decimalValue * oldBaseConv + parsedDigit;
            }

            return decimalValue;
        }
        static public BigInteger ToDecimalFromCustomBigInteger(string oldValue, string customDigits, Int32? oldBase = null)
        {
            BigInteger decimalValue = 0;
            Int32 safeOldBase = oldBase ?? customDigits.Length;
            UInt64 oldBaseConv = (UInt64)safeOldBase;

            foreach (char c in oldValue)
            {
                UInt64 digit = CharToDigit64(c, safeOldBase, customDigits);
                decimalValue = decimalValue * oldBaseConv + digit;
            }

            return decimalValue;
        }
        static public BigInteger ToDecimalFromCustomBigInteger<T>(List<T> oldValue, List<T> customDigits, Int32? oldBase = null)
        {
            Utils.TypeArgumentCheck<T>();

            BigInteger decimalValue = 0;
            UInt64 oldBaseConv = (UInt64)(oldBase ?? customDigits.Count);
            foreach (T digit in oldValue)
                decimalValue = decimalValue * oldBaseConv + (UInt64)customDigits.IndexOf(digit);

            return decimalValue;
        }



        static public string  FromDecimalBigInteger(BigInteger decimalValue, Int32 newBase)
            => FromDecimalToCustomBigInteger(decimalValue, gDigits[..newBase], newBase);
        static public List<T> FromDecimalBigInteger<T>(BigInteger decimalValue, Int32 newBase)
        {
            Utils.TypeArgumentCheck<T>();

            List<T> result = [];
            BigInteger current = decimalValue;
            UInt64 newBaseConv = (UInt64)newBase;

            while (current > 0)
            {
                result.Add((T)Convert.ChangeType((UInt64)(current % newBaseConv), typeof(T)));
                current /= newBaseConv;
            }

            return Utils.Reverse(result);
        }
        static public string  FromDecimalToCustomBigInteger(BigInteger decimalValue, string customDigits, Int32? newBase = null)
        {
            string result = "";
            BigInteger current = decimalValue;
            UInt64 newBaseConv = (UInt64)(newBase ?? customDigits.Length);

            while (current > 0)
            {
                Int32 remainder = (Int32)(current % newBaseConv);
                result += customDigits[remainder];
                current /= newBaseConv;
            }

            return Utils.Reverse(result);
        }
        static public List<T> FromDecimalToCustomBigInteger<T>(BigInteger decimalValue, List<T> customDigits, Int32? newBase = null)
        {
            Utils.TypeArgumentCheck<T>();

            List<T> result = [];
            BigInteger current = decimalValue;
            UInt64 newBaseConv = (UInt64)(newBase ?? customDigits.Count);

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