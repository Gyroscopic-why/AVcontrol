using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;



namespace AVcontrol
{
    static public partial class FromBinary
    {
        static public T BigEndian<T>(Byte[] bytes) where T : unmanaged
            => LittleEndian<T>(Utils.Reverse(bytes));
        static public T LittleEndian<T>(Byte[] bytes) where T : unmanaged
        {
            Utils.TypeArgumentCheck<T>();

            if (bytes.Length != Marshal.SizeOf<T>())
                throw new ArgumentException("Byte array size doesn't match type size");

            unsafe
            {
                fixed (Byte* ptr = bytes)
                {
                    return *(T*)ptr;
                }
            }
        }



        static public T BigEndian<T>(List<Byte> bytes) where T : unmanaged
            => LittleEndian<T>(Utils.Reverse(bytes.ToArray()));
        static public T LittleEndian<T>(List<Byte> bytes) where T : unmanaged
            => LittleEndian<T>(bytes.ToArray());



        static public T LittleEndian<T>(ReadOnlySpan<Byte> bytes) where T : unmanaged
        {
            Utils.TypeArgumentCheck<T>();
            if (bytes.Length != Marshal.SizeOf<T>())
                throw new ArgumentException("Byte span size doesn't match type size");

            unsafe
            {
                fixed (byte* ptr = bytes)
                {
                    return *(T*)ptr;
                }
            }
        }
        static public T BigEndian<T>(ReadOnlySpan<Byte> bytes) where T : unmanaged
        {
            Span<byte> reversed = stackalloc byte[bytes.Length];

            bytes.CopyTo(reversed);
            Utils.Reverse(reversed);

            return LittleEndian<T>(reversed);
        }
    }
}