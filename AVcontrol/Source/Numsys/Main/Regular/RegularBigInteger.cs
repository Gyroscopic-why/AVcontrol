using System;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static public string AsStringBigInteger(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return oldValue;

            BigInteger decimalValue = ToDecimalBigInteger(oldValue, oldBase);

            if (decimalValue == 0) return "0";
            else return FromDecimalBigInteger(decimalValue, newBase);
        }
        static public string AsStringBigInteger(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
            => AsStringBigInteger(oldValue, oldBase, newBase).PadLeft(outputLength, '0');


        static public T[] AsArrayBigInteger<T>(string oldValue, Int32 oldBase, Int32 newBase)
            => [.. AsListBigInteger<T>(oldValue, oldBase, newBase)];
        static public T[] AsArrayBigInteger<T>(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
            => [.. AsListBigInteger<T>(oldValue, oldBase, newBase, outputLength)];


        static public List<T> AsListBigInteger<T>(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (!BaseArgumentCheck(oldBase, newBase))
                return [.. oldValue.Select(c => (T)Convert.ChangeType(gDigits.IndexOf(c), typeof(T)))];

            BigInteger decimalValue = ToDecimalBigInteger(oldValue, oldBase);

            if (decimalValue == 0) return [(T)Convert.ChangeType(0, typeof(T))];
            else return [.. FromDecimalBigInteger<T>(decimalValue, newBase)];
        }
        static public List<T> AsListBigInteger<T>(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            List<T> result = AsListBigInteger<T>(oldValue, oldBase, newBase);

            while (result.Count < outputLength) result.Insert(0, (T)Convert.ChangeType(0, typeof(T)));
            return result;
        }
    }
}