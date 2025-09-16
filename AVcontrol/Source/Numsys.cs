using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;


namespace AVcontrol
{
    public class Numsys
    {
        static private readonly string gDigits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        static private Int32 CharToDigit(char c)
        {
            if (c >= '0' && c <= '9') return c - '0';
            else if (c >= 'A' && c <= 'Z') return c - 'A' + 10;
            else if (c >= 'a' && c <= 'z') return c - 'a' + 10;
            else throw new ArgumentException($"Invalid character: {c}");
        }
        static private Int32 CharToDigit(char c, Int32 oldBase, string customDigits)
        {
            Int32 buffer = customDigits.IndexOf(c);
            if (buffer < 0) throw new ArgumentException($"Invalid character: {c} in custom digits.");
            else if (buffer >= oldBase) throw new ArgumentException($"Digit '{buffer}' is invalid for base {oldBase}.");

            return buffer;
        }



        static private bool BaseArgumentCheck(Int32 oldBase, Int32 newBase)
            => BaseArgumentCheck(oldBase, newBase, 36);
        static private bool BaseArgumentCheck(Int32 oldBase, Int32 newBase, Int32 maxBaseLimit)
        {
            if (oldBase < 2 || oldBase > maxBaseLimit || newBase < 2 || newBase > maxBaseLimit)
                throw new ArgumentOutOfRangeException("Bases must be between 2 and " + maxBaseLimit + ".");
            if (oldBase == newBase) return false;
            return true;
        }

        static private string DefaultBaseToCustom(string oldValue, string customDigits)
        {
            string result = "";
            for (var i = 0; i < oldValue.Length; i++)
                result += customDigits[gDigits.IndexOf(oldValue[i])];
            return result;
        }
        static private string DefaultBaseFromCustom(string oldValue, string customDigits)
        {
            string result = "";
            for (var i = 0; i < oldValue.Length; i++)
                result += gDigits[customDigits.IndexOf(oldValue[i])];
            return result;
        }
        static private List<Byte> DefaultBaseToCustom(List<Byte> oldValue, List<Byte> customDigits)
        {
            List<Byte> result = new List<Byte>();
            foreach (Byte b in oldValue)
                result.Add((Byte)customDigits[gDigits.IndexOf((char)b)]);
            return result;
        }
        static private List<Byte> DefaultBaseFromCustom(List<Byte> oldValue, List<Byte> customDigits)
        {
            List<Byte> result = new List<Byte>();
            foreach (Byte b in oldValue)
                result.Add((Byte)gDigits[customDigits.IndexOf(b)]);
            return result;
        }
        static private List<Int16> DefaultBaseToCustom(List<Int16> oldValue, List<Int16> customDigits)
        {
            List<Int16> result = new List<Int16>();
            foreach (Int16 b in oldValue)
                result.Add((Int16)customDigits[gDigits.IndexOf((char)b)]);
            return result;
        }
        static private List<Int16> DefaultBaseFromCustom(List<Int16> oldValue, List<Int16> customDigits)
        {
            List<Int16> result = new List<Int16>();
            foreach (Int16 b in oldValue)
                result.Add((Int16)gDigits[customDigits.IndexOf(b)]);
            return result;
        }



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
        static public Int64 ToDecimal(List<Int16> oldValue, Int32 oldBase)
        {
            Int64 decimalValue = 0;
            foreach (Int16 digit in oldValue)
            {
                if (digit >= oldBase) throw new ArgumentException($"Digit '{digit}' is invalid for base {oldBase}.");
                decimalValue = decimalValue * oldBase + digit;
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
        static public Int64 ToDecimalFromCustom(List<Int16> oldValue, Int32 oldBase, List<Int16> customDigits)
        {
            Int64 decimalValue = 0;
            foreach (Int16 digit in oldValue) decimalValue = decimalValue * oldBase + customDigits.IndexOf(digit);
            return decimalValue;
        }
        static public Int32 ToSmallDecimalFromCustom(string oldValue, Int32 oldBase, string customDigits)
        {
            Int32 decimalValue = 0;
            foreach (char digit in oldValue) decimalValue = decimalValue * oldBase + customDigits.IndexOf(digit);
            return decimalValue;
        }
        static public Int32 ToSmallDecimalFromCustom(List<Int16> oldValue, Int32 oldBase, List<Int16> customDigits)
        {
            Int32 decimalValue = 0;
            foreach (Int16 digit in oldValue) decimalValue = decimalValue * oldBase + customDigits.IndexOf(digit);
            return decimalValue;
        }
        static public string FromDecimal(Int64 decimalValue, Int32 newBase)
        {
            string result = "";
            Int64 current = decimalValue;

            while (current > 0)
            {
                Int32 remainder = (Int32)(current % newBase);
                result += gDigits[remainder];
                current /= newBase;
            }

            result.Reverse();
            return result;
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

            result.Reverse();
            return result;
        }
        static public List<Int32> FromDecimalAsBinary(Int64 decimalValue, Int32 newBase)
        {
            List<Int32> result = new List<Int32>();
            Int64 current = decimalValue;
            while (current > 0)
            {
                Int32 remainder = (Int32)(current % newBase);
                result.Add(remainder);
                current /= newBase;
            }
            result.Reverse();
            return result;
        }
        static public List<Byte>  FromDecimalToCustomAsBinary(Int64 decimalValue, Int32 newBase, string customDigits)
        {
            List<Byte> result = new List<Byte>();
            Int64 current = decimalValue;

            while (current > 0)
            {
                Int32 remainder = (Int32)(current % newBase);
                result.Add((Byte)customDigits[remainder]);
                current /= newBase;
            }

            result.Reverse();
            return result;
        }
        static public List<Int16> FromDecimalToCustomAsBinary(Int64 decimalValue, Int32 newBase, List<Int16> customDigits)
        {
            List<Int16> result = new List<Int16>();
            Int64 current = decimalValue;

            while (current > 0)
            {
                Int32 remainder = (Int32)(current % newBase);
                result.Add(customDigits[remainder]);
                current /= newBase;
            }

            result.Reverse();
            return result;
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
            if (!BaseArgumentCheck(oldBase, newBase)) return oldValue;
            
            Int64 decimalValue = ToDecimal(oldValue, oldBase);
            
            if (decimalValue == 0) return "0";
            else return FromDecimal(decimalValue, newBase);
        }
        static public string    AsString(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
            => AsString(oldValue, oldBase, newBase).PadLeft(outputLength, '0');
        static public Int32[]    AsArray(string oldValue, Int32 oldBase, Int32 newBase) => AsList(oldValue, oldBase, newBase).ToArray();
        static public Int32[]    AsArray(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
            => AsList(oldValue, oldBase, newBase, outputLength).ToArray();
        static public List<Int32> AsList(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return oldValue.Select(c => (Int32)c).ToList();

            Int64 decimalValue = ToDecimal(oldValue, oldBase);

            if (decimalValue == 0) return new List<Int32>() { 0 };
            else return FromDecimalToCustomAsBinary(decimalValue, newBase, gDigits).Select(b => (Int32)b).ToList();
        }
        static public List<Int32> AsList(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            List<Int32> result = AsList(oldValue, oldBase, newBase);

            while (result.Count < outputLength) result.Insert(0, 0);
            return result;
        }



        static public string        CustomAsString(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return oldValue;

            Int64 decimalValue = ToDecimalFromCustom(oldValue, oldBase, customDigits);

            if (decimalValue == 0) return customDigits[0].ToString();
            else return FromDecimalToCustom(decimalValue, newBase, customDigits);
        }
        static public string        CustomAsString(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
            => CustomAsString(oldValue, oldBase, newBase, customDigits).PadLeft(outputLength, customDigits[0]);
        static public string      ToCustomAsString(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return DefaultBaseToCustom(oldValue, customDigits);

            Int64 decimalValue = ToDecimal(oldValue, oldBase);
            
            if (decimalValue == 0) return customDigits[0].ToString();
            else return FromDecimalToCustom(decimalValue, newBase, customDigits);
        }
        static public string      ToCustomAsString(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
            => ToCustomAsString(oldValue, oldBase, newBase, customDigits).PadLeft(outputLength, customDigits[0]);
        static public string    FromCustomAsString(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return DefaultBaseFromCustom(oldValue, customDigits);

            Int64 decimalValue = ToDecimalFromCustom(oldValue, oldBase, customDigits);

            if (decimalValue == 0) return customDigits[0].ToString();
            else return FromDecimal(decimalValue, newBase);
        }
        static public string    FromCustomAsString(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
            => FromCustomAsString(oldValue, oldBase, newBase, customDigits).PadLeft(outputLength, customDigits[0]);
        static public Int32[]    FromCustomAsArray(string oldValue, Int32 oldBase, Int32 newBase, string customDigits) 
            => FromCustomAsList(oldValue, oldBase, newBase, customDigits).ToArray();
        static public Int32[]    FromCustomAsArray(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength) 
            => FromCustomAsList(oldValue, oldBase, newBase, customDigits, outputLength).ToArray();
        static public List<Int32> FromCustomAsList(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return DefaultBaseFromCustom(oldValue, customDigits).Select(c => (Int32)c).ToList();
            
            Int64 decimalValue = ToDecimalFromCustom(oldValue, oldBase, customDigits);

            if (decimalValue == 0) return new List<Int32>() { (Int32)customDigits[0] };
            else return FromDecimalAsBinary(decimalValue, newBase);
        }
        static public List<Int32> FromCustomAsList(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
        {
            List<Int32> result = FromCustomAsList(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, customDigits[0]);
            return result;
        }



        static public List<Byte> CustomAsBinary(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return oldValue.Select(c => (Byte)c).ToList();

            Int64 decimalValue = ToDecimalFromCustom(oldValue, oldBase, customDigits);
            
            if (decimalValue == 0) return new List<byte>() { (Byte)customDigits[0] };
            else return FromDecimalToCustomAsBinary(decimalValue, newBase, customDigits);
        }
        static public List<Byte> CustomAsBinary(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
        {
            List<Byte> result = CustomAsBinary(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, (Byte)customDigits[0]);
            return result;
        }
        static public List<Byte> ToCustomAsBinary(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) 
                return DefaultBaseToCustom
                (
                    oldValue.Select(c => (Byte)c).ToList(),
                    customDigits.Select(c => (Byte)c).ToList()
                );

            Int64 decimalValue = ToDecimal(oldValue, oldBase);

            if (decimalValue == 0) return new List<byte>() { (Byte)customDigits[0] };
            else return FromDecimalToCustomAsBinary(decimalValue, newBase, customDigits);
        }
        static public List<Byte> ToCustomAsBinary(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
        {
            List<Byte> result = ToCustomAsBinary(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, (Byte)customDigits[0]);
            return result;
        }
        static public List<Byte> FromCustomAsBinary(List<Byte> oldValue, Int32 oldBase, Int32 newBase, List<Byte> customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return DefaultBaseFromCustom (oldValue,customDigits);

            Int64 decimalValue = ToDecimalFromCustom(Conversions.ToInt16List(oldValue), oldBase, Conversions.ToInt16List(customDigits));

            if (decimalValue == 0) return new List<byte>() { (Byte)customDigits[0] };
            else return FromDecimalToCustomAsBinary(decimalValue, newBase, gDigits);
        }
        static public List<Byte> FromCustomAsBinary(List<Byte> oldValue, Int32 oldBase, Int32 newBase, List<Byte> customDigits, Int32 outputLength)
        {
            List<Byte> result = FromCustomAsBinary(oldValue, oldBase, newBase, customDigits);
            
            while (result.Count < outputLength) result.Insert(0, (Byte)customDigits[0]);
            return result;
        }



        static public List<Int16> CustomAsUtf16Binary(List<Int16> oldValue, Int32 oldBase, Int32 newBase, List<Int16> customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return oldValue;

            Int64 decimalValue = ToDecimalFromCustom(oldValue, oldBase, customDigits);

            if (decimalValue == 0) return new List<Int16>() { customDigits[0] };
            else return FromDecimalToCustomAsBinary(decimalValue, newBase, customDigits);
        }
        static public List<Int16> CustomAsUtf16Binary(List<Int16> oldValue, Int32 oldBase, Int32 newBase, List<Int16> customDigits, Int32 outputLength)
        {
            List<Int16> result = CustomAsUtf16Binary(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, customDigits[0]);
            return result;
        }
        static public List<Int16> ToCustomAsUtf16Binary(List<Int16> oldValue, Int32 oldBase, Int32 newBase, List<Int16> customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return DefaultBaseToCustom(oldValue, customDigits);

            Int64 decimalValue = ToDecimal(oldValue, oldBase);

            if (decimalValue == 0) return new List<Int16>() { customDigits[0] };
            else return FromDecimalToCustomAsBinary(decimalValue, newBase, customDigits);
        }
        static public List<Int16> ToCustomAsUtf16Binary(List<Int16> oldValue, Int32 oldBase, Int32 newBase, List<Int16> customDigits, Int32 outputLength)
        {
            List<Int16> result = ToCustomAsUtf16Binary(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, customDigits[0]);
            return result;
        }
        static public List<Int16> FromCustomAsUtf16Binary(List<Int16> oldValue, Int32 oldBase, Int32 newBase, List<Int16> customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return DefaultBaseFromCustom(oldValue, customDigits);

            Int64 decimalValue = ToDecimalFromCustom(oldValue, oldBase, customDigits);

            if (decimalValue == 0) return new List<Int16>() { (Int16)customDigits[0] };
            else return Conversions.ToInt16List(FromDecimalAsBinary(decimalValue, newBase));
        }
        static public List<Int16> FromCustomAsUtf16Binary(List<Int16> oldValue, Int32 oldBase, Int32 newBase, List<Int16> customDigits, Int32 outputLength)
        {
            List<Int16> result = FromCustomAsUtf16Binary(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, customDigits[0]);
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


        static private string Unsafe_2_8_10_16_AsString(string oldValue, Int32 oldBase, Int32 newBase)
            => Convert.ToString(Convert.ToInt64(oldValue, oldBase), newBase).ToUpper();
        static private string    Unsafe_2_8_10_16_AsString(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
            => Unsafe_2_8_10_16_AsString(oldValue, oldBase, newBase).PadLeft(outputLength, '0');
        static private Int32[]    Unsafe_2_8_10_16_AsArray(string oldValue, Int32 oldBase, Int32 newBase)
            => Unsafe_2_8_10_16_AsList(oldValue, oldBase, newBase).ToArray();
        static private Int32[]    Unsafe_2_8_10_16_AsArray(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
            => Unsafe_2_8_10_16_AsList(oldValue, oldBase, newBase, outputLength).ToArray();
        static private List<Int32> Unsafe_2_8_10_16_AsList(string oldValue, Int32 oldBase, Int32 newBase)
        {
            Int64 decimalValue = Convert.ToInt64(oldValue, oldBase);
            string newValue = Convert.ToString(decimalValue, newBase).ToUpper();

            List<Int32> result = new List<Int32>();
            foreach (char c in newValue) result.Add(Convert.ToInt32(c.ToString(), newBase));

            return result;
        }
        static private List<Int32> Unsafe_2_8_10_16_AsList(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            List<Int32> result = Unsafe_2_8_10_16_AsList(oldValue, oldBase, newBase);

            while (result.Count < outputLength) result.Insert(0, 0);
            return result;
        }



        static public Int32 LowBase(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (!BaseArgumentCheck(oldBase, newBase, 10)) return Convert.ToInt32(oldValue);

            Int64 decimalValue = Convert.ToInt64(oldValue, oldBase);
            return Convert.ToInt32(Convert.ToString(decimalValue, newBase).ToUpper());
        }
        static public Int32 LowBaseCustom(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase, customDigits.Length)) return Convert.ToInt32(oldValue);

            Int64 decimalValue = ToDecimalFromCustom(oldValue, oldBase, customDigits);

            if (decimalValue == 0) return 0;

            Int32 result = 0;
            for (var i = 0; i < oldValue.Length; i++) result = result * newBase + customDigits.IndexOf(oldValue[i]);
            return result;
        }
        static public Int32 LowBaseCustom(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
        {
            Int32 result = LowBaseCustom(oldValue, oldBase, newBase, customDigits);
            return Convert.ToInt32(result.ToString().PadLeft(outputLength, customDigits[0]));
        }
        static public Int32 LowBaseFromCustom(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase, customDigits.Length)) 
                return Convert.ToInt32(DefaultBaseFromCustom(oldValue, customDigits));

            Int64 decimalValue = ToDecimalFromCustom(oldValue, oldBase, customDigits);
            return Convert.ToInt32(Convert.ToString(decimalValue, newBase).ToUpper());
        }
        static public Int32 LowBaseFromCustom(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
        {
            Int32 result = LowBaseFromCustom(oldValue, oldBase, newBase, customDigits);
            return Convert.ToInt32(result.ToString().PadLeft(outputLength, customDigits[0]));
        }
        static public Int32 LowBaseToCustom(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase, customDigits.Length)) 
                return Convert.ToInt32(DefaultBaseToCustom(oldValue, customDigits));

            Int64 decimalValue = Convert.ToInt64(oldValue, oldBase);
            if (decimalValue == 0) return customDigits[0];

            Int32 result = 0;
            for (var i = 0; i < oldValue.Length; i++) result = result * newBase + customDigits.IndexOf(oldValue[i]);
            return result;
        }
        static public Int32 LowBaseToCustom(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
        {
            Int32 result = LowBaseToCustom(oldValue, oldBase, newBase, customDigits);
            return Convert.ToInt32(result.ToString().PadLeft(outputLength, customDigits[0]));
        }
        static public Int32[] LowBaseArray(string oldValue, Int32 oldBase, Int32 newBase)
            => LowBaseList(oldValue, oldBase, newBase).ToArray();
        static public List<Int32> LowBaseList(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (!BaseArgumentCheck(oldBase, newBase, 10)) return oldValue.Select(c => Convert.ToInt32(c.ToString())).ToList();

            Int64 decimalValue = Convert.ToInt64(oldValue, oldBase);
            string newValue = Convert.ToString(decimalValue, newBase).ToUpper();

            List<Int32> result = new List<Int32>();
            foreach (char c in newValue) result.Add(Convert.ToInt32(c.ToString(), newBase));

            return result;
        }
    }
}