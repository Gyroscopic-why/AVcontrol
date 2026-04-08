using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;



namespace AVcontrol
{
    public class FromBinary
    {
        static public string ASCII(Byte[] ASCII)             => Encoding.ASCII.GetString(ASCII);
        static public string ASCII(List<Byte> ASCII)         => Encoding.ASCII.GetString([.. ASCII]);
        static public string ASCII(ReadOnlySpan<byte> bytes) => Encoding.ASCII.GetString(bytes);

        static public string Utf8(Byte[] utf8bytes)          => Encoding.UTF8.GetString(utf8bytes);
        static public string Utf8(List<Byte> utf8bytes)      => Encoding.UTF8.GetString([.. utf8bytes]);
        static public string Utf8(ReadOnlySpan<byte> bytes)  => Encoding.UTF8.GetString(bytes);

        static public string Utf16(Byte[] utf16byte)         => Encoding.Unicode.GetString(utf16byte);
        static public string Utf16(List<Byte> utf16byte)     => Encoding.Unicode.GetString([.. utf16byte]);
        static public string Utf16(ReadOnlySpan<byte> bytes) => Encoding.Unicode.GetString(bytes);

        static public string BigEndianUtf16(Byte[] utf16byte)         => Encoding.BigEndianUnicode.GetString(utf16byte);
        static public string BigEndianUtf16(List<Byte> utf16byte)     => Encoding.BigEndianUnicode.GetString([.. utf16byte]);
        static public string BigEndianUtf16(ReadOnlySpan<byte> bytes) => Encoding.BigEndianUnicode.GetString(bytes);

        static public string Utf32(Byte[] utf32bytes)        => Encoding.UTF32.GetString(utf32bytes);
        static public string Utf32(List<Byte> utf32bytes)    => Encoding.UTF32.GetString([.. utf32bytes]);
        static public string Utf32(ReadOnlySpan<byte> bytes) => Encoding.UTF32.GetString(bytes);


        public static T LittleEndian<T>(ReadOnlySpan<byte> bytes) where T : unmanaged
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
        public static T BigEndian<T>(ReadOnlySpan<byte> bytes) where T : unmanaged
        {
            Span<byte> reversed = stackalloc byte[bytes.Length];
            bytes.CopyTo(reversed);
            Utils.Reverse(reversed);
            return LittleEndian<T>(reversed);
        }


        public static T BigEndian<T>(Byte[] bytes) where T : unmanaged
            => LittleEndian<T>(Utils.Reverse(bytes));
        public static T LittleEndian<T>(Byte[] bytes) where T : unmanaged
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
    }
}