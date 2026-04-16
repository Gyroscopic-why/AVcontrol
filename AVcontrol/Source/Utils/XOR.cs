using System;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Utils
    {
        static public T XOR<T>(T initial, T key) where T : unmanaged
        {
            TypeArgumentCheck<T>();

            Byte[] initialBytes = ToBinary.LittleEndian(initial);
            Byte[] keyBytes = ToBinary.LittleEndian(key);

            Byte[] resultBytes = XOR(initialBytes, keyBytes);
            return FromBinary.LittleEndian<T>(resultBytes);
        }
        static public Byte[] XOR(Byte[] initial, Byte[] key)
        {
            ArgumentNullException.ThrowIfNull(initial);
            ArgumentNullException.ThrowIfNull(key);

            if (key.Length == 0) throw new ArgumentException("Key cannot be empty", nameof(key));

            Byte[] result = new Byte[initial.Length];
            for (var i = 0; i < initial.Length; i++)
                result[i] = (Byte)(initial[i] ^ key[i % key.Length]);

            return result;
        }
        static public List<Byte> XOR(List<Byte> initial, List<Byte> key)
        {
            ArgumentNullException.ThrowIfNull(initial);
            ArgumentNullException.ThrowIfNull(key);

            if (key.Count == 0) throw new ArgumentException("Key cannot be empty", nameof(key));

            var result = new List<Byte>(initial.Count);
            for (var i = 0; i < initial.Count; i++)
                result.Add((Byte)(initial[i] ^ key[i % key.Count]));

            return result;
        }
    }
}