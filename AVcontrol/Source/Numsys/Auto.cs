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
                Type t when t == typeof(string)      => (T)(object)AutoAsString(value, oldBase, newBase),
                Type t when t == typeof(Int32[])     => (T)(object)AutoAsArray(value, oldBase, newBase),
                Type t when t == typeof(List<Int32>) => (T)(object)AutoAsList(value, oldBase, newBase),
                _ => throw new ArgumentException("Unsupported return type. Please provide string, Int32[] or List<Int32> for Auto()"),
            };
        }
        static public T Auto<T>(string value, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            return typeof(T) switch
            {
                Type t when t == typeof(string)      => (T)(object)AutoAsString(value, oldBase, newBase, outputLength),
                Type t when t == typeof(Int32[])     => (T)(object)AutoAsArray(value, oldBase, newBase, outputLength),
                Type t when t == typeof(List<Int32>) => (T)(object)AutoAsList(value, oldBase, newBase, outputLength),
                _ => throw new ArgumentException("Unsupported return type. Please provide string, Int32[] or List<Int32> for Auto()"),
            };
        }



        static public string AutoAsString(string oldValue, Int32 oldBase, Int32 newBase)
        {
            return (oldBase == 2 || oldBase == 8 || oldBase == 10 || oldBase == 16)
                && (newBase == 2 || newBase == 8 || newBase == 10 || newBase == 16)
                ? Unsafe_2_8_10_16_AsString(oldValue, oldBase, newBase)
                : AsString(oldValue, oldBase, newBase);
        }
        static public string AutoAsString(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
        {
            return (oldBase == 2 || oldBase == 8 || oldBase == 10 || oldBase == 16)
                && (newBase == 2 || newBase == 8 || newBase == 10 || newBase == 16)
                ? Unsafe_2_8_10_16_AsString(oldValue, oldBase, newBase, outputLength)
                : AsString(oldValue, oldBase, newBase, outputLength);
        }

        static public Int32[] AutoAsArray(string oldValue, Int32 oldBase, Int32 newBase)
        {
            return (oldBase == 2 || oldBase == 8 || oldBase == 10 || oldBase == 16)
                && (newBase == 2 || newBase == 8 || newBase == 10 || newBase == 16)
                ? Unsafe_2_8_10_16_AsArray(oldValue, oldBase, newBase)
                : [.. AsList(oldValue, oldBase, newBase)];
        }
        static public Int32[] AutoAsArray(string oldValue, Int32 oldBase, Int32 newBase, Int32 outputLength)
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
    }
}