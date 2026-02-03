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



        static private bool BaseArgumentCheck(Int32 oldBase, Int32 newBase, Int32 maxBaseLimit)
        {
            if (oldBase < 2 || oldBase > maxBaseLimit || newBase < 2 || newBase > maxBaseLimit)
                throw new ArgumentOutOfRangeException("Bases must be between 2 and " + maxBaseLimit + ".");
            if (oldBase == newBase) return false;
            return true;
        }
        static private bool BaseArgumentCheck(Int32 oldBase, Int32 newBase)
            => BaseArgumentCheck(oldBase, newBase, 36);

        static private void TypeArgumentCheck<T>()
        {
            if (typeof(T) != typeof( Byte)  &&
                typeof(T) != typeof(SByte)  &&
                typeof(T) != typeof( Int16) &&
                typeof(T) != typeof(UInt16) &&
                typeof(T) != typeof( Int32) &&
                typeof(T) != typeof(UInt32) &&
                typeof(T) != typeof( Int64) &&
                typeof(T) != typeof(UInt64))
                throw new InvalidOperationException("Type T must be (S)Byte, (U)Int16, (U)Int32, or (U)Int64");
        }



        static public Int64 ToDecimal   (string  oldValue, Int32 oldBase)
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
        static public Int64 ToDecimal<T>(List<T> oldValue, Int32 oldBase)
        {
            TypeArgumentCheck<T>();

            Int64 decimalValue = 0;
            foreach (T digit in oldValue)
            {
                Int64 parsedDigit  = Convert.ToInt64(digit);
                if   (parsedDigit >= oldBase) throw new ArgumentException(
                    $"Digit '{parsedDigit}' is invalid for base {oldBase}.");

                decimalValue = decimalValue * oldBase + parsedDigit;
            }
            return decimalValue;
        }
        static public Int64 ToDecimalFromCustom   (string  oldValue, Int32 oldBase, string customDigits)
        {
            Int64 decimalValue = 0;
            foreach (char c in oldValue)
            {
                Int32 digit = CharToDigit(c, oldBase, customDigits);
                decimalValue = decimalValue * oldBase + digit;
            }

            return decimalValue;
        }
        static public Int64 ToDecimalFromCustom<T>(List<T> oldValue, Int32 oldBase, List<T> customDigits)
        {
            TypeArgumentCheck<T>();

            Int64 decimalValue = 0;
            foreach (T digit in oldValue) decimalValue = decimalValue * oldBase + customDigits.IndexOf(digit);
            return decimalValue;
        }



        static public string   FromDecimal   (Int64 decimalValue, Int32 newBase)
            => FromDecimalToCustom(decimalValue, newBase, gDigits);
        static public List<T>  FromDecimal<T>(Int64 decimalValue, Int32 newBase)
        {
            TypeArgumentCheck<T>();

            List<T> result = [];
            Int64 current = decimalValue;

            while (current > 0)
            {
                result.Add((T)Convert.ChangeType(current % newBase, typeof(T)));
                current /= newBase;
            }

            return Utils.Reverse(result);
        }
        static public string   FromDecimalToCustom(Int64 decimalValue, Int32 newBase, string customDigits)
        {
            string result = "";
            Int64 current = decimalValue;
            while (current > 0)
            {
                Int32 remainder = (Int32)(current % newBase);
                result  += customDigits[remainder];
                current /= newBase;
            }

            return Utils.Reverse(result);
        }
        static public List<T>  FromDecimalToCustom<T>(Int64 decimalValue, Int32 newBase, List<T> customDigits)
        {
            TypeArgumentCheck<T>();

            List<T> result = [];
            Int64  current = decimalValue;

            while (current > 0)
            {
                Int32 remainder = (Int32)(current % newBase);
                result.Add(customDigits[remainder]);
                current /= newBase;
            }

            return Utils.Reverse(result);
        }





        static public T Auto<T> (string value, Int32 oldBase, Int32 newBase)
        {
            return typeof(T) switch
            {
                Type t when t == typeof(string)      => (T)(object)AutoAsString(value, oldBase, newBase),
                Type t when t == typeof(Int32[])     => (T)(object)AutoAsArray(value, oldBase, newBase),
                Type t when t == typeof(List<Int32>) => (T)(object)AutoAsList(value, oldBase, newBase),
                _ => throw new ArgumentException("Unsupported return type. Please provide string, Int32[] or List<Int32> for Auto()"),
            };
        }
        static public T Auto<T> (string value, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            return typeof(T) switch
            {
                Type t when t == typeof(string)      => (T)(object)AutoAsString(value, oldBase, newBase, outputLength),
                Type t when t == typeof(Int32[])     => (T)(object)AutoAsArray(value, oldBase, newBase, outputLength),
                Type t when t == typeof(List<Int32>) => (T)(object)AutoAsList(value, oldBase, newBase, outputLength),
                _ => throw new ArgumentException("Unsupported return type. Please provide string, Int32[] or List<Int32> for Auto()"),
            };
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
                : [.. AsList(oldValue, oldBase, newBase)];
        }
        static public Int32[]    AutoAsArray(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            return (oldBase == 2 || oldBase == 8 || oldBase == 10 || oldBase == 16)
                && (newBase == 2 || newBase == 8 || newBase == 10 || newBase == 16)
                ? Unsafe_2_8_10_16_AsArray(oldValue, oldBase, newBase, outputLength)
                : [.. AsList(oldValue, oldBase, newBase, outputLength)];
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
        static public Int32[]    AsArray(string oldValue, Int32 oldBase, Int32 newBase)
            => [.. AsList(oldValue, oldBase, newBase)];
        static public Int32[]    AsArray(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
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
            if (!BaseArgumentCheck(oldBase, newBase)) return (string)oldValue.Select(c => customDigits[gDigits.IndexOf(c)]);

            Int64 decimalValue = ToDecimal(oldValue, oldBase);
            
            if (decimalValue == 0) return customDigits[0].ToString();
            else return FromDecimalToCustom(decimalValue, newBase, customDigits);
        }
        static public string      ToCustomAsString(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
            => ToCustomAsString(oldValue, oldBase, newBase, customDigits).PadLeft(outputLength, customDigits[0]);
        static public string    FromCustomAsString(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return (string)oldValue.Select(c => gDigits[customDigits.IndexOf(c)]);

            Int64 decimalValue = ToDecimalFromCustom(oldValue, oldBase, customDigits);

            if (decimalValue == 0) return "0";
            else return FromDecimal(decimalValue, newBase);
        }
        static public string    FromCustomAsString(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
            => FromCustomAsString(oldValue, oldBase, newBase, customDigits).PadLeft(outputLength, '0');
        static public Int32[]    FromCustomAsArray(string oldValue, Int32 oldBase, Int32 newBase, string customDigits) 
            => [.. FromCustomAsList(oldValue, oldBase, newBase, customDigits)];
        static public Int32[]    FromCustomAsArray(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength) 
            => [.. FromCustomAsList(oldValue, oldBase, newBase, customDigits, outputLength)];
        static public List<Int32> FromCustomAsList(string oldValue, Int32 oldBase, Int32 newBase, string customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return [.. oldValue.Select(c => gDigits.IndexOf(c))];

            Int64 decimalValue = ToDecimalFromCustom(oldValue, oldBase, customDigits);

            if (decimalValue == 0) return [0];
            else return FromDecimal<Int32>(decimalValue, newBase);
        }
        static public List<Int32> FromCustomAsList(string oldValue, Int32 oldBase, Int32 newBase, string customDigits, Int32 outputLength)
        {
            List<Int32> result = FromCustomAsList(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, 0);
            return result;
        }





        static public List<T>     CustomAsBinary<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits)
        {
            if (!BaseArgumentCheck(oldBase, newBase)) return oldValue;

            Int64 decimalValue = ToDecimalFromCustom(oldValue, oldBase, customDigits);
            
            if (decimalValue == 0) return [customDigits[0]];
            else return FromDecimalToCustom(decimalValue, newBase, customDigits);
        }
        static public List<T>     CustomAsBinary<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits, Int32 outputLength)
        {
            List<T> result = CustomAsBinary(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, customDigits[0]);
            return result;
        }
        static public List<T>   ToCustomAsBinary<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits)
        {
            TypeArgumentCheck<T>();

            if (!BaseArgumentCheck(oldBase, newBase)) 
                return [.. oldValue.Select(b => (T)(object)customDigits[Convert.ToInt32(b)]!)];

            Int64 decimalValue = ToDecimal(oldValue, oldBase);

            if (decimalValue == 0) return [customDigits[0]];
            else return FromDecimalToCustom(decimalValue, newBase, customDigits);
        }
        static public List<T>   ToCustomAsBinary<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits, Int32 outputLength)
        {
            TypeArgumentCheck<T>();

            List<T> result = ToCustomAsBinary(oldValue, oldBase, newBase, customDigits);

            while (result.Count < outputLength) result.Insert(0, customDigits[0]);
            return result;
        }
        static public List<T> FromCustomAsBinary<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits)
        {
            TypeArgumentCheck<T>();

            if (!BaseArgumentCheck(oldBase, newBase)) return [.. oldValue.Select(c => (T)(object)customDigits.IndexOf(c))];

            Int64 decimalValue = ToDecimalFromCustom<T>(oldValue, oldBase, customDigits);

            if (decimalValue == 0) return [(T)(object)0];
            else return FromDecimal<T>(decimalValue, newBase);
        }
        static public List<T> FromCustomAsBinary<T>(List<T> oldValue, Int32 oldBase, Int32 newBase, List<T> customDigits, Int32 outputLength)
        {
            TypeArgumentCheck<T>();

            List<T> result = FromCustomAsBinary(oldValue, oldBase, newBase, customDigits);
            
            while (result.Count < outputLength) result.Insert(0, (T)(object)0);
            return result;
        }





        static public string    Fast_2_8_10_16_AsString(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16)
                throw new ArgumentOutOfRangeException(nameof(oldBase), "Bases must be 2, 8, 10 or 16");
            else if (newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException(nameof(newBase), "Bases must be 2, 8, 10 or 16");

            return Unsafe_2_8_10_16_AsString(oldValue, oldBase, newBase);
        }
        static public string    Fast_2_8_10_16_AsString(string oldValue, Int32 oldBase, Int32 newBase, Int32 minOutputLength)
        {
            if (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16)
                throw new ArgumentOutOfRangeException(nameof(oldBase), "Bases must be 2, 8, 10 or 16");
            else if (newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException(nameof(newBase), "Bases must be 2, 8, 10 or 16");

            return Unsafe_2_8_10_16_AsString(oldValue, oldBase, newBase, minOutputLength);
        }
        static public Int32[]    Fast_2_8_10_16_AsArray(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16)
                throw new ArgumentOutOfRangeException(nameof(oldBase), "Bases must be 2, 8, 10 or 16");
            else if (newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException(nameof(newBase), "Bases must be 2, 8, 10 or 16");

            return Unsafe_2_8_10_16_AsArray(oldValue, oldBase, newBase);
        }
        static public Int32[]    Fast_2_8_10_16_AsArray(string oldValue, Int32 oldBase, Int32 newBase, Int32 minOutputLength)
        {
            if (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16)
                throw new ArgumentOutOfRangeException(nameof(oldBase), "Bases must be 2, 8, 10 or 16");
            else if (newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException(nameof(newBase), "Bases must be 2, 8, 10 or 16");

            return Unsafe_2_8_10_16_AsArray(oldValue, oldBase, newBase, minOutputLength);
        }
        static public List<Int32> Fast_2_8_10_16_AsList(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16)
                throw new ArgumentOutOfRangeException(nameof(oldBase), "Bases must be 2, 8, 10 or 16");
            else if (newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException(nameof(newBase), "Bases must be 2, 8, 10 or 16");

            return Unsafe_2_8_10_16_AsList(oldValue, oldBase, newBase);
        }
        static public List<Int32> Fast_2_8_10_16_AsList(string oldValue, Int32 oldBase, Int32 newBase, Int32 minOutputLength)
        {
            if (oldBase != 2 && oldBase != 8 && oldBase != 10 && oldBase != 16)
                throw new ArgumentOutOfRangeException(nameof(oldBase), "Bases must be 2, 8, 10 or 16");
            else if (newBase != 2 && newBase != 8 && newBase != 10 && newBase != 16)
                throw new ArgumentOutOfRangeException(nameof(newBase), "Bases must be 2, 8, 10 or 16");

            return Unsafe_2_8_10_16_AsList(oldValue, oldBase, newBase, minOutputLength);
        }



        static private string    Unsafe_2_8_10_16_AsString(string oldValue, Int32 oldBase, Int32 newBase)
            => Convert.ToString(Convert.ToInt64(oldValue, oldBase), newBase).ToUpper();
        static private string    Unsafe_2_8_10_16_AsString(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
            => Unsafe_2_8_10_16_AsString(oldValue, oldBase, newBase).PadLeft(outputLength, '0');
        static private Int32[]    Unsafe_2_8_10_16_AsArray(string oldValue, Int32 oldBase, Int32 newBase)
            => [.. Unsafe_2_8_10_16_AsList(oldValue, oldBase, newBase)];
        static private Int32[]    Unsafe_2_8_10_16_AsArray(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
            => [.. Unsafe_2_8_10_16_AsList(oldValue, oldBase, newBase, outputLength)];
        static private List<Int32> Unsafe_2_8_10_16_AsList(string oldValue, Int32 oldBase, Int32 newBase)
        {
            Int64 decimalValue = Convert.ToInt64(oldValue, oldBase);
            string    newValue = Convert.ToString(decimalValue, newBase).ToUpper();

            return [.. oldValue.Select(c => Convert.ToInt32(c.ToString(), newBase))];
        }
        static private List<Int32> Unsafe_2_8_10_16_AsList(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            List<Int32> result = Unsafe_2_8_10_16_AsList(oldValue, oldBase, newBase);

            while (result.Count < outputLength) result.Insert(0, 0);
            return result;
        }



        static public Int32           LowBase(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (!BaseArgumentCheck(oldBase, newBase, 10)) return Convert.ToInt32(oldValue);

            Int64 decimalValue = ToDecimal(oldValue, oldBase);
            return Convert.ToInt32(FromDecimal(decimalValue, newBase));
        }
        static public Int32[]    LowBaseArray(string oldValue, Int32 oldBase, Int32 newBase)
            => [.. LowBaseList(oldValue, oldBase, newBase)]; 
        static public Int32[]    LowBaseArray(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
            => [.. LowBaseList(oldValue, oldBase, newBase, outputLength)];
        static public List<Int32> LowBaseList(string oldValue, Int32 oldBase, Int32 newBase)
        {
            if (!BaseArgumentCheck(oldBase, newBase, 10)) return [.. oldValue.Select(c => gDigits.IndexOf(c))];

            Int64 decimalValue = Convert.ToInt64 (oldValue,     oldBase);
            string newValue    = Convert.ToString(decimalValue, newBase).ToUpper();

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