using System;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Utils
    {
        static internal void TypeArgumentCheck<T>()
        {
            Type type = typeof(T);
            if (type != typeof(Byte) &&
                type != typeof(SByte) &&

                type != typeof(Int16) &&
                type != typeof(UInt16) &&

                type != typeof(Int32) &&
                type != typeof(UInt32) &&

                type != typeof(Int64) &&
                type != typeof(UInt64))
                throw new InvalidOperationException("Type T must be (S)Byte, (U)Int16, (U)Int32, or (U)Int64");
        }
        static internal void TypeArgumentCheck(Type type)
        {
            if (type != typeof(Byte) &&
                type != typeof(SByte) &&

                type != typeof(Int16) &&
                type != typeof(UInt16) &&

                type != typeof(Int32) &&
                type != typeof(UInt32) &&

                type != typeof(Int64) &&
                type != typeof(UInt64))
                throw new InvalidOperationException("Type T must be (S)Byte, (U)Int16, (U)Int32, or (U)Int64");
        }

        static internal readonly Dictionary<Type, UInt64> maxValues = new()
        {
            { typeof(Byte),      Byte.MaxValue},
            { typeof(SByte),  (UInt64) SByte.MaxValue},

            { typeof(Int16),  (UInt64) Int16.MaxValue},
            { typeof(UInt16),  UInt16.MaxValue},

            { typeof(Int32),    Int32.MaxValue},
            { typeof(UInt32),  UInt32.MaxValue},

            { typeof(Int64),    Int64.MaxValue},
            { typeof(UInt64),  UInt64.MaxValue}
        };
        static internal UInt64 GetMaxValue(Type type) => maxValues[type];


        static public List<T_out> ConvertType<T_in, T_out>(List<T_in> initial) where T_in : unmanaged
        {
            TypeArgumentCheck<T_in>();
            TypeArgumentCheck<T_out>();

            ArgumentNullException.ThrowIfNull(initial);

            var result = new List<T_out>(initial.Count);

            for (var i = 0; i < initial.Count; i++)
                result.Add((T_out)Convert.ChangeType(initial[i], typeof(T_out)));

            return result;
        }
        static public T_out[] ConvertType<T_in, T_out>(T_in[] initial) where T_in : unmanaged
        {
            TypeArgumentCheck<T_in>();
            TypeArgumentCheck<T_out>();

            ArgumentNullException.ThrowIfNull(initial);

            var result = new T_out[initial.Length];

            for (var i = 0; i < initial.Length; i++)
                result[i] = (T_out)Convert.ChangeType(initial[i], typeof(T_out));

            return result;
        }
    }
}