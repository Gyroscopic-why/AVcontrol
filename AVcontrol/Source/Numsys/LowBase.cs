using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static public Int64 LowBase(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (!BaseArgumentCheck(oldBase, newBase, 10)) return Convert.ToInt64(oldValue);

            UInt64 decimalValue = ToDecimal64(oldValue, oldBase);
            return Convert.ToInt64(FromDecimal64(decimalValue, newBase));
        }

        static public T[] LowBaseArray<T>(string oldValue, Int32 oldBase, Int32 newBase)
            => [.. LowBaseList<T>(oldValue, oldBase, newBase)];
        static public T[] LowBaseArray<T>(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
            => [.. LowBaseList<T>(oldValue, oldBase, newBase, outputLength)];

        static public List<T> LowBaseList<T>(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (!BaseArgumentCheck(oldBase, newBase, 10))
                return [.. oldValue.Select(c => (T)Convert.ChangeType(gDigits.IndexOf(c), typeof(T)))];

            Int64 decimalValue = Convert.ToInt64(oldValue, oldBase);
            string    newValue = Convert.ToString(decimalValue, newBase).ToUpper();

            List<T> result = new (newValue.Length);
            foreach (char c in newValue)
                result.Add
                (   (T)Convert.ChangeType
                    (
                        Convert.ToInt64(c.ToString(), newBase),
                        typeof(T)
                )   );

            return result;
        }
        static public List<T> LowBaseList<T>(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            List<T> result  = LowBaseList<T>(oldValue, oldBase, newBase);

            while (result.Count < outputLength) result.Insert(0, (T)(Convert.ChangeType(0, typeof(T))));
            return result;
        }
    }
}