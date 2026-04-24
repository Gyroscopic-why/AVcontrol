using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static public string AsString(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return oldValue;

            Int64 decimalValue = ToDecimal(oldValue, oldBase);

            if (decimalValue == 0) return "0";
            else return FromDecimal(decimalValue, newBase);
        }
        static public string AsString(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
            => AsString(oldValue, oldBase, newBase).PadLeft(outputLength, '0');


        static public Int32[] AsArray(string oldValue, Int32 oldBase, Int32 newBase)
            => [.. AsList(oldValue, oldBase, newBase)];
        static public Int32[] AsArray(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
            => [.. AsList(oldValue, oldBase, newBase, outputLength)];


        static public List<Int32> AsList(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return [.. oldValue.Select(c => gDigits.IndexOf(c))];

            Int64 decimalValue = ToDecimal(oldValue, oldBase);

            if (decimalValue == 0) return [0];
            else return [.. FromDecimal<Int32>(decimalValue, newBase)];
        }
        static public List<Int32> AsList(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            List<Int32> result = AsList(oldValue, oldBase, newBase);

            while (result.Count < outputLength) result.Insert(0, 0);
            return result;
        }
    }
}