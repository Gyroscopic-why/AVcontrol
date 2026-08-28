using System;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static public T Auto<T>(string value, Int32 oldBase, Int32 newBase)
        {
            return typeof(T) switch
            {
                Type t when t == typeof(string)  => (T)(object)AutoAsString (value, oldBase, newBase),
                Type t when t == typeof(T[])     => (T)(object)AutoAsList<T>(value, oldBase, newBase).ToArray(),
                Type t when t == typeof(List<T>) => (T)(object)AutoAsList<T>(value, oldBase, newBase),
                _ => throw new ArgumentException
                (
                    "Unsupported return type for Auto()\n" +
                    "Please provide string, T[] or List<T> (where T is an integer type)"
                ),
            };
        }
        static public T Auto<T>(string value, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            return typeof(T) switch
            {
                Type t when t == typeof(string)  => (T)(object)AutoAsString (value, oldBase, newBase, outputLength),
                Type t when t == typeof(T[])     => (T)(object)AutoAsList<T>(value, oldBase, newBase, outputLength).ToArray(),
                Type t when t == typeof(List<T>) => (T)(object)AutoAsList<T>(value, oldBase, newBase, outputLength),
                _ => throw new ArgumentException
                (
                    "Unsupported return type for Auto()\n" +
                    "Please provide string, T[] or List<T> (where T is an integer type)"
                ),
            };
        }

        static public string AutoAsString(string oldValue, Int32 oldBase, Int32 newBase)
        {
            return (oldBase == 2 || oldBase == 8 || oldBase == 10 || oldBase == 16)
                && (newBase == 2 || newBase == 8 || newBase == 10 || newBase == 16)
                ? Unsafe_2_8_10_16_AsString(oldValue, oldBase, newBase)
                : AsStringBigInteger(oldValue, oldBase, newBase);
        }
        static public string AutoAsString(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            return (oldBase == 2 || oldBase == 8 || oldBase == 10 || oldBase == 16)
                && (newBase == 2 || newBase == 8 || newBase == 10 || newBase == 16)
                ? Unsafe_2_8_10_16_AsString(oldValue, oldBase, newBase, outputLength)
                : AsStringBigInteger(oldValue, oldBase, newBase, outputLength);
        }

        static public List<T> AutoAsList<T>(string oldValue, Int32 oldBase, Int32 newBase)
        {
            return (oldBase == 2 || oldBase == 8 || oldBase == 10 || oldBase == 16)
                && (newBase == 2 || newBase == 8 || newBase == 10 || newBase == 16)
                ? Unsafe_2_8_10_16_AsList<T>(oldValue, oldBase, newBase)
                : AsListBigInteger<T>(oldValue, oldBase, newBase);
        }
        static public List<T> AutoAsList<T>(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            return (oldBase == 2 || oldBase == 8 || oldBase == 10 || oldBase == 16)
                && (newBase == 2 || newBase == 8 || newBase == 10 || newBase == 16)
                ? Unsafe_2_8_10_16_AsList<T>(oldValue, oldBase, newBase, outputLength)
                : AsListBigInteger<T>(oldValue, oldBase, newBase, outputLength);
        }
    }
}