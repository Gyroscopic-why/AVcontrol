using System;
using System.Text;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class FromBinary
    {
        static public string ASCII(Byte[] ASCII)             => Encoding.ASCII.GetString(ASCII);
        static public string ASCII(List<Byte> ASCII)         => Encoding.ASCII.GetString([.. ASCII]);
        static public string ASCII(ReadOnlySpan<Byte> bytes) => Encoding.ASCII.GetString(bytes);


        static public string Utf8(Byte[] utf8bytes)         => Encoding.UTF8.GetString(utf8bytes);
        static public string Utf8(List<Byte> utf8bytes)     => Encoding.UTF8.GetString([.. utf8bytes]);
        static public string Utf8(ReadOnlySpan<Byte> bytes) => Encoding.UTF8.GetString(bytes);


        static public string Utf16(Byte[] utf16byte)         => Encoding.Unicode.GetString(utf16byte);
        static public string Utf16(List<Byte> utf16byte)     => Encoding.Unicode.GetString([.. utf16byte]);
        static public string Utf16(ReadOnlySpan<Byte> bytes) => Encoding.Unicode.GetString(bytes);


        static public string BigEndianUtf16(Byte[] utf16byte)         => Encoding.BigEndianUnicode.GetString(utf16byte);
        static public string BigEndianUtf16(List<Byte> utf16byte)     => Encoding.BigEndianUnicode.GetString([.. utf16byte]);
        static public string BigEndianUtf16(ReadOnlySpan<Byte> bytes) => Encoding.BigEndianUnicode.GetString(bytes);
        

        static public string Utf32(Byte[] utf32bytes)        => Encoding.UTF32.GetString(utf32bytes);
        static public string Utf32(List<Byte> utf32bytes)    => Encoding.UTF32.GetString([.. utf32bytes]);
        static public string Utf32(ReadOnlySpan<Byte> bytes) => Encoding.UTF32.GetString(bytes);
    }
}