using System;
using System.Linq;
using System.Collections.Generic;


namespace AVcontrol
{
    public class Numsys
    {
        private static Int32 CharToDigit(char c)
        {
            if (c >= '0' && c <= '9') return c - '0';
            else if (c >= 'A' && c <= 'Z') return c - 'A' + 10;
            else if (c >= 'a' && c <= 'z') return c - 'a' + 10;
            else throw new ArgumentException($"Invalid character: {c}");
        }
        private static Int32 CharToDigit(char c, string customDigits)
        {
            Int32 buffer = customDigits.IndexOf(c);
            if (buffer < 0) throw new ArgumentException($"Invalid character: {c} in custom digits.");

            return buffer;
        }



        static public T Auto<T> (string value, Int32 oldBase, Int32 newBase)
        {
            switch (typeof(T))
            {
                case Type t when t == typeof(string):      return (T)(object)AutoAsString(value, oldBase, newBase);
                case Type t when t == typeof(Int32[]):     return (T)(object)  AutoAsList(value, oldBase, newBase).ToArray();
                case Type t when t == typeof(List<Int32>): return (T)(object)  AutoAsList(value, oldBase, newBase);
                default: throw new ArgumentException("Unsupported return type.");
            }
        }
        static public T Auto<T> (string value, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            switch (typeof(T))
            {
                case Type t when t == typeof(string):      return (T)(object)AutoAsString(value, oldBase, newBase, outputLength);
                case Type t when t == typeof(Int32[]):     return (T)(object)  AutoAsList(value, oldBase, newBase, outputLength).ToArray();
                case Type t when t == typeof(List<Int32>): return (T)(object)  AutoAsList(value, oldBase, newBase, outputLength);
                default: throw new ArgumentException("Unsupported return type.");
            }
        }



        static public string    AutoAsString(string oldValue, Int32 oldBase, Int32 newBase)
        {
            return (oldBase == 2 || oldBase == 8 || oldBase == 10 || oldBase == 16)
                && (newBase == 2 || newBase == 8 || newBase == 10 || newBase == 16)
                ? Unsafe_2_8_10_16_AsString(oldValue, oldBase, newBase)
                : AsString(oldValue, oldBase, newBase);
        }
        static public string    AutoAsString(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            return (oldBase == 2 || oldBase == 8 || oldBase == 10 || oldBase == 16)
                && (newBase == 2 || newBase == 8 || newBase == 10 || newBase == 16)
                ? Unsafe_2_8_10_16_AsString(oldValue, oldBase, newBase, outputLength)
                : AsString(oldValue, oldBase, newBase, outputLength);
        }
        static public Int32[]    AutoAsArray(string oldValue, Int32 oldBase, Int32 newBase)
        {
            return (oldBase == 2 || oldBase == 8 || oldBase == 10 || oldBase == 16)
                && (newBase == 2 || newBase == 8 || newBase == 10 || newBase == 16)
                ? Unsafe_2_8_10_16_AsArray(oldValue, oldBase, newBase)
                : AsList(oldValue, oldBase, newBase).ToArray();
        }
        static public Int32[]    AutoAsArray(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            return (oldBase == 2 || oldBase == 8 || oldBase == 10 || oldBase == 16)
                && (newBase == 2 || newBase == 8 || newBase == 10 || newBase == 16)
                ? Unsafe_2_8_10_16_AsArray(oldValue, oldBase, newBase, outputLength)
                : AsList(oldValue, oldBase, newBase, outputLength).ToArray();
        }
        static public List<Int32> AutoAsList(string oldValue, Int32 oldBase, Int32 newBase)
        {
            return (oldBase == 2 || oldBase == 8 || oldBase == 10 || oldBase == 16)
                && (newBase == 2 || newBase == 8 || newBase == 10 || newBase == 16)
                ? Unsafe_2_8_10_16_AsList(oldValue, oldBase, newBase)
                : AsList(oldValue, oldBase, newBase);
        }
        static public List<Int32> AutoAsList(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            return (oldBase == 2 || oldBase == 8 || oldBase == 10 || oldBase == 16)
                && (newBase == 2 || newBase == 8 || newBase == 10 || newBase == 16)
                ? Unsafe_2_8_10_16_AsList(oldValue, oldBase, newBase, outputLength)
                : AsList(oldValue, oldBase, newBase, outputLength);
        }



        static public string    AsString(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (oldBase < 2 || oldBase > 36 || newBase < 2 || newBase > 36)
                throw new ArgumentOutOfRangeException("Bases must be between 2 and 36.");

            const string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            //  Convert number to decimal
            Int64 decimalValue = 0;
            foreach (char c in oldValue)
            {
                Int32 digit = CharToDigit(c);
                if (digit >= oldBase) throw new ArgumentException($"Digit '{c}' is invalid for base {oldBase}.");

                decimalValue = decimalValue * oldBase + digit;
            }

            //  Convert decimal to requested base
            string result = "";
            if (decimalValue == 0) return "0";
            else
            {
                Int64 current = decimalValue;
                while (current > 0)
                {
                    Int32 remainder = (Int32)(current % newBase);
                    result += digits[remainder];
                    current /= newBase;
                }
                return new string(result.Reverse().ToArray());
            }
        }
        static public string    AsString(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            if (oldBase < 2 || oldBase > 36 || newBase < 2 || newBase > 36)
                throw new ArgumentOutOfRangeException("Bases must be between 2 and 36.");

            const string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            //  Convert number to decimal
            Int64 decimalValue = 0;
            foreach (char c in oldValue)
            {
                Int32 digit = CharToDigit(c);
                if (digit >= oldBase) throw new ArgumentException($"Digit '{c}' is invalid for base {oldBase}.");

                decimalValue = decimalValue * oldBase + digit;
            }

            //  Convert decimal to requested base
            string result = "";
            if (decimalValue == 0) result = "0";
            else
            {
                Int64 current = decimalValue;
                while (current > 0)
                {
                    Int32 remainder = (Int32)(current % newBase);
                    result += digits[remainder];
                    current /= newBase;
                }
            }

            for (Int32 curId = result.Length; curId < outputLength; curId++) result += "0";

            return new string(result.Reverse().ToArray());
        }
        static public Int32[]    AsArray(string oldValue, Int32 oldBase, Int32 newBase) => AsList(oldValue, oldBase, newBase).ToArray();
        static public Int32[]    AsArray(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength) => AsList(oldValue, oldBase, newBase, outputLength).ToArray();
        static public List<Int32> AsList(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (oldBase < 2 || oldBase > 36 || newBase < 2 || newBase > 36)
                throw new ArgumentOutOfRangeException("Bases must be between 2 and 36.");

            //  Convert number to decimal
            Int64 decimalValue = 0;
            foreach (char c in oldValue)
            {
                Int32 digit = CharToDigit(c);
                if (digit >= oldBase) throw new ArgumentException($"Digit '{c}' is invalid for base {oldBase}.");

                decimalValue = decimalValue * oldBase + digit;
            }

            //  Convert decimal to requested base
            List<Int32> result = new List<Int32>();
            if (decimalValue == 0) result.Add(0);
            else
            {
                Int64 current = decimalValue;
                while (current > 0)
                {
                    Int32 remainder = (Int32)(current % newBase);
                    result.Add(remainder);
                    current /= newBase;
                }
                result.Reverse();
            }

            return result;
        }
        static public List<Int32> AsList(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            if (oldBase < 2 || oldBase > 36 || newBase < 2 || newBase > 36)
                throw new ArgumentOutOfRangeException("Bases must be between 2 and 36.");

            //  Convert number to decimal
            Int64 decimalValue = 0;
            foreach (char c in oldValue)
            {
                Int32 digit = CharToDigit(c);
                if (digit >= oldBase) throw new ArgumentException($"Digit '{c}' is invalid for base {oldBase}.");

                decimalValue = decimalValue * oldBase + digit;
            }

            //  Convert decimal to requested base
            List<Int32> result = new List<Int32>();
            if (decimalValue == 0) result.Add(0);
            else
            {
                Int64 current = decimalValue;
                while (current > 0)
                {
                    Int32 remainder = (Int32)(current % newBase);
                    result.Add(remainder);
                    current /= newBase;
                }
                result.Reverse();
            }

            //  Extend the length to min requested
            while (result.Count < outputLength) result.Insert(0, 0);

            return result;
        }

        static public string    AsString(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (oldBase < 2 || oldBase > 36 || newBase < 2 || newBase > 36)
                throw new ArgumentOutOfRangeException("Bases must be between 2 and 36.");

            //  Convert number to decimal
            Int64 decimalValue = 0;
            foreach (char c in oldValue)
            {
                Int32 digit = CharToDigit(c, customDigits);
                if (digit >= oldBase) throw new ArgumentException($"Digit '{c}' is invalid for base {oldBase}.");

                decimalValue = decimalValue * oldBase + digit;
            }

            //  Convert decimal to requested base
            string result = "";
            if (decimalValue == 0) return "0";
            else
            {
                Int64 current = decimalValue;
                while (current > 0)
                {
                    Int32 remainder = (Int32)(current % newBase);
                    result += customDigits[remainder];
                    current /= newBase;
                }
                return new string(result.Reverse().ToArray());
            }
        }
        static public string    AsString(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
        {
            if (oldBase < 2 || oldBase > 36 || newBase < 2 || newBase > 36)
                throw new ArgumentOutOfRangeException("Bases must be between 2 and 36.");

            //  Convert number to decimal
            Int64 decimalValue = 0;
            foreach (char c in oldValue)
            {
                Int32 digit = CharToDigit(c, customDigits);
                if (digit >= oldBase) throw new ArgumentException($"Digit '{c}' is invalid for base {oldBase}.");

                decimalValue = decimalValue * oldBase + digit;
            }

            //  Convert decimal to requested base
            string result = "";
            if (decimalValue == 0) result = "0";
            else
            {
                Int64 current = decimalValue;
                while (current > 0)
                {
                    Int32 remainder = (Int32)(current % newBase);
                    result += customDigits[remainder];
                    current /= newBase;
                }
            }

            for (Int32 curId = result.Length; curId < outputLength; curId++) result += "0";

            return new string(result.Reverse().ToArray());
        }
        static public Int32[]    AsArray(string oldValue, Int32 oldBase, Int32 newBase, string customDigits) => AsList(oldValue, oldBase, newBase, customDigits).ToArray();
        static public Int32[]    AsArray(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength) => AsList(oldValue, oldBase, newBase, customDigits, outputLength).ToArray();
        static public List<Int32> AsList(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (oldBase < 2 || oldBase > 36 || newBase < 2 || newBase > 36)
                throw new ArgumentOutOfRangeException("Bases must be between 2 and 36.");

            //  Convert number to decimal
            Int64 decimalValue = 0;
            foreach (char c in oldValue)
            {
                Int32 digit = CharToDigit(c, customDigits);
                if (digit >= oldBase) throw new ArgumentException($"Digit '{c}' is invalid for base {oldBase}.");

                decimalValue = decimalValue * oldBase + digit;
            }

            //  Convert decimal to requested base
            List<Int32> result = new List<Int32>();
            if (decimalValue == 0) result.Add(0);
            else
            {
                Int64 current = decimalValue;
                while (current > 0)
                {
                    Int32 remainder = (Int32)(current % newBase);
                    result.Add(remainder);
                    current /= newBase;
                }
                result.Reverse();
            }

            return result;
        }
        static public List<Int32> AsList(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
        {
            if (oldBase < 2 || oldBase > 36 || newBase < 2 || newBase > 36)
                throw new ArgumentOutOfRangeException("Bases must be between 2 and 36.");

            //  Convert number to decimal
            Int64 decimalValue = 0;
            foreach (char c in oldValue)
            {
                Int32 digit = CharToDigit(c, customDigits);
                if (digit >= oldBase) throw new ArgumentException($"Digit '{c}' is invalid for base {oldBase}.");

                decimalValue = decimalValue * oldBase + digit;
            }

            //  Convert decimal to requested base
            List<Int32> result = new List<Int32>();
            if (decimalValue == 0) result.Add(0);
            else
            {
                Int64 current = decimalValue;
                while (current > 0)
                {
                    Int32 remainder = (Int32)(current % newBase);
                    result.Add(remainder);
                    current /= newBase;
                }
                result.Reverse();
            }

            //  Extend the length to min requested
            while (result.Count < outputLength) result.Insert(0, 0);

            return result;
        }



        static public string    Fast_2_8_10_16_AsString(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16 ||
                newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException("Bases must be between 2 and 36.");

            return Unsafe_2_8_10_16_AsString(oldValue, oldBase, newBase);
        }
        static public string    Fast_2_8_10_16_AsString(string oldValue, Int32 oldBase, Int32 newBase, Int32 minOutputLength)
        {
            if (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16 ||
                newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException("Bases must be between 2 and 36.");

            return Unsafe_2_8_10_16_AsString(oldValue, oldBase, newBase, minOutputLength);
        }
        static public Int32[]    Fast_2_8_10_16_AsArray(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16 ||
                newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException("Bases must be between 2 and 36.");

            return Unsafe_2_8_10_16_AsArray(oldValue, oldBase, newBase);
        }
        static public Int32[]    Fast_2_8_10_16_AsArray(string oldValue, Int32 oldBase, Int32 newBase, Int32 minOutputLength)
        {
            if (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16 ||
                newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException("Bases must be between 2 and 36.");

            return Unsafe_2_8_10_16_AsArray(oldValue, oldBase, newBase, minOutputLength);
        }
        static public List<Int32> Fast_2_8_10_16_AsList(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16 ||
                newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException("Bases must be between 2 and 36.");

            return Unsafe_2_8_10_16_AsList(oldValue, oldBase, newBase);
        }
        static public List<Int32> Fast_2_8_10_16_AsList(string oldValue, Int32 oldBase, Int32 newBase, Int32 minOutputLength)
        {
            if (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16 ||
                newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException("Bases must be between 2 and 36.");

            return Unsafe_2_8_10_16_AsList(oldValue, oldBase, newBase, minOutputLength);
        }


        static private string    Unsafe_2_8_10_16_AsString(string oldValue, Int32 oldBase, Int32 newBase)
        {
            //  Convert the old value to decimal
            Int64 decimalValue = Convert.ToInt64(oldValue, oldBase);

            //  Convert decimal value to the new base
            return Convert.ToString(decimalValue, newBase).ToUpper();
        }
        static private string    Unsafe_2_8_10_16_AsString(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            //  Convert the old value to decimal
            Int64 decimalValue = Convert.ToInt64(oldValue, oldBase);

            //  Convert decimal value to the new base
            string result = Convert.ToString(decimalValue, newBase).ToUpper(), buffer = "";
            for (Int32 curId = result.Length; curId < outputLength; curId++) buffer += "0";
            return buffer + result;
        }
        static private Int32[]    Unsafe_2_8_10_16_AsArray(string oldValue, Int32 oldBase, Int32 newBase)
        {
            //  Convert the old value to decimal
            Int64 decimalValue = Convert.ToInt64(oldValue, oldBase);

            //  Calculate the length through string conversion
            string newValue = Convert.ToString(decimalValue, newBase).ToUpper();
            Int32[] result = new Int32[newValue.Length];

            for (Int32 curId = 0; curId < newValue.Length; curId++)
                result[curId] = Convert.ToInt32(newValue[curId].ToString(), newBase);

            return result;
        }
        static private Int32[]    Unsafe_2_8_10_16_AsArray(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            //  Convert the old value to decimal
            Int64 decimalValue = Convert.ToInt64(oldValue, oldBase);

            //  Calculate the length through string conversion
            string newValue = Convert.ToString(decimalValue, newBase).ToUpper();
            Int32[] result = new Int32[Math.Max(newValue.Length, outputLength)];
            Int32 realstartId = 0;

            for (Int32 curId = newValue.Length; curId < outputLength; curId++)
            {
                result[curId - newValue.Length] = 0;
                realstartId++;
            }

            for (Int32 curId = realstartId; curId < result.Length; curId++)
                result[curId] = Convert.ToInt32(newValue[curId - realstartId].ToString(), newBase);

            return result;
        }
        static private List<Int32> Unsafe_2_8_10_16_AsList(string oldValue, Int32 oldBase, Int32 newBase)
        {
            //  Convert the old value to decimal
            Int64 decimalValue = Convert.ToInt64(oldValue, oldBase);

            //  Convert dec to new base string
            string newValue = Convert.ToString(decimalValue, newBase).ToUpper();
            List<Int32> result = new List<Int32>();

            foreach (char c in newValue)
                result.Add(Convert.ToInt32(c.ToString(), newBase));

            return result;
        }
        static private List<Int32> Unsafe_2_8_10_16_AsList(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            //  Convert the old value to decimal
            Int64 decimalValue = Convert.ToInt64(oldValue, oldBase);

            //  Convert dec to new base string
            string newValue = Convert.ToString(decimalValue, newBase).ToUpper();
            List<Int32> result = new List<Int32>();

            for (Int32 curId = newValue.Length; curId < outputLength; curId++)
                result.Add(0);

            foreach (char c in newValue)
                result.Add(Convert.ToInt32(c.ToString(), newBase));

            return result;
        }




        static public Int32   LowBase(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (oldBase < 2 || oldBase > 10 || newBase < 2 || newBase > 10)
                throw new ArgumentOutOfRangeException("Bases must be between 2 and 10.");

            //  Convert the old value to decimal
            Int64 decimalValue = Convert.ToInt64(oldValue, oldBase);

            //  Convert decimal value to the new base
            return Convert.ToInt32(Convert.ToString(decimalValue, newBase).ToUpper());
        }
        static public Int32[] LowBaseArray(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (oldBase < 2 || oldBase > 10 || newBase < 2 || newBase > 10)
                throw new ArgumentOutOfRangeException("Bases must be between 2 and 10.");

            //  Convert the old value to decimal
            Int64 decimalValue = Convert.ToInt64(oldValue, oldBase);

            //  Calculate the length through string conversion
            string newValue = Convert.ToString(decimalValue, newBase).ToUpper();
            Int32[] result = new Int32[newValue.Length];

            for (Int32 curId = 0; curId < newValue.Length; curId++)
                result[curId] = Convert.ToInt32(newValue[curId].ToString(), newBase);

            return result;
        }
        static public List<Int32> LowBaseList(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (oldBase < 2 || oldBase > 10 || newBase < 2 || newBase > 10)
                throw new ArgumentOutOfRangeException("Bases must be between 2 and 10.");

            //  Convert the old value to decimal
            Int64 decimalValue = Convert.ToInt64(oldValue, oldBase);

            //  Convert dec to new base string
            string newValue = Convert.ToString(decimalValue, newBase).ToUpper();
            List<Int32> result = new List<Int32>();

            foreach (char c in newValue)
                result.Add(Convert.ToInt32(c.ToString(), newBase));

            return result;
        }
    }
}