using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static public Int32 LowBase(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (!BaseArgumentCheck(oldBase, newBase, 10)) return Convert.ToInt32(oldValue);

            Int64 decimalValue = ToDecimal(oldValue, oldBase);
            return Convert.ToInt32(FromDecimal(decimalValue, newBase));
        }

        static public Int32[] LowBaseArray(string oldValue, Int32 oldBase, Int32 newBase)
            => [.. LowBaseList(oldValue, oldBase, newBase)];
        static public Int32[] LowBaseArray(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
            => [.. LowBaseList(oldValue, oldBase, newBase, outputLength)];

        static public List<Int32> LowBaseList(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (!BaseArgumentCheck(oldBase, newBase, 10)) return [.. oldValue.Select(c => gDigits.IndexOf(c))];

            Int64 decimalValue = Convert.ToInt64(oldValue, oldBase);
            string newValue = Convert.ToString(decimalValue, newBase).ToUpper();

            List<Int32> result = [];
            foreach (char c in newValue) result.Add(Convert.ToInt32(c.ToString(), newBase));

            return result;
        }
        static public List<Int32> LowBaseList(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            List<Int32> result = LowBaseList(oldValue, oldBase, newBase);

            while (result.Count < outputLength) result.Insert(0, 0);
            return result;
        }
    }
}