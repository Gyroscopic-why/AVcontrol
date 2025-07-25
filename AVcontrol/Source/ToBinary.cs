using System;
using System.Collections.Generic;
using System.Text;

namespace AVcontrol
{
    public class ToBinary
    {
        static public Byte[] ASCII(String ASCIIstring) => Encoding.ASCII.GetBytes(ASCIIstring);
        static public Byte[] ASCII(Char ASCIIchar) => Encoding.ASCII.GetBytes(ASCIIchar.ToString());

        static public Byte[] Utf8(String utf8string) => Encoding.UTF8.GetBytes(utf8string);
        static public Byte[] Utf8(Char utf8char) => Encoding.UTF8.GetBytes(utf8char.ToString());

        static public Byte[] Utf16(String utf16string) => Encoding.Unicode.GetBytes(utf16string);
        static public Byte[] Utf16(Char utf16char) => Encoding.Unicode.GetBytes(utf16char.ToString());

        static public Byte[] BigEndianUtf16(String utf16string) => Encoding.BigEndianUnicode.GetBytes(utf16string);
        static public Byte[] BigEndianUtf16(Char utf16char) => Encoding.BigEndianUnicode.GetBytes(utf16char.ToString());

        static public Byte[] Utf32(String utf32string) => Encoding.UTF32.GetBytes(utf32string);
        static public Byte[] Utf32(Char utf32char) => Encoding.UTF32.GetBytes(utf32char.ToString());




        static public Byte[] Byte(Byte value) => new[] { value };
        static public Byte[] SByte(SByte value) => new[] { (Byte)value };


        static public Byte[] BigEndian(Int16 value) => new[]
        {
            (Byte) (value >> 8),
            (Byte)  value
        };
        static public Byte[] BigEndian(UInt16 value) => new[]
        {
            (Byte) (value >> 8),
            (Byte)  value
        };


        static public Byte[] BigEndian(Int32 value) => new[]
        {
            (Byte) (value >> 24),
            (Byte) (value >> 16),
            (Byte) (value >> 8),
            (Byte)  value
        };
        static public Byte[] BigEndian(UInt32 value) => new[]
        {
            (Byte) (value >> 24),
            (Byte) (value >> 16),
            (Byte) (value >> 8),
            (Byte)  value
        };


        static public Byte[] BigEndian(Int64 value) => new[]
        {
            (Byte) (value >> 56),
            (Byte) (value >> 48),
            (Byte) (value >> 40),
            (Byte) (value >> 32),
            (Byte) (value >> 24),
            (Byte) (value >> 16),
            (Byte) (value >> 8),
            (Byte)  value
        };
        static public Byte[] BigEndian(UInt64 value) => new[]
        {
            (Byte) (value >> 56),
            (Byte) (value >> 48),
            (Byte) (value >> 40),
            (Byte) (value >> 32),
            (Byte) (value >> 24),
            (Byte) (value >> 16),
            (Byte) (value >> 8),
            (Byte)  value
        };




        static public Byte[] LittleEndian(Int16 value) => new[]
        {
            (Byte)  value,
            (Byte) (value >> 8)
        };
        static public Byte[] LittleEndian(UInt16 value) => new[]
        {
            (Byte)  value,
            (Byte) (value >> 8)
        };


        static public Byte[] LittleEndian(Int32 value) => new[]
        {
            (Byte)  value,
            (Byte) (value >> 8),
            (Byte) (value >> 16),
            (Byte) (value >> 24)
        };
        static public Byte[] LittleEndian(UInt32 value) => new[]
        {
            (Byte)  value,
            (Byte) (value >> 8),
            (Byte) (value >> 16),
            (Byte) (value >> 24)
        };


        static public Byte[] LittleEndian(Int64 value) => new[]
        {
            (Byte)  value,
            (Byte) (value >> 8),
            (Byte) (value >> 16),
            (Byte) (value >> 24),
            (Byte) (value >> 32),
            (Byte) (value >> 40),
            (Byte) (value >> 48),
            (Byte) (value >> 56)
        };
        static public Byte[] LittleEndian(UInt64 value) => new[]
        {
            (Byte)  value,
            (Byte) (value >> 8),
            (Byte) (value >> 16),
            (Byte) (value >> 24),
            (Byte) (value >> 32),
            (Byte) (value >> 40),
            (Byte) (value >> 48),
            (Byte) (value >> 56)
        };
    }
}