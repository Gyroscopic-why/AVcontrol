using System;
using System.Text;



namespace AVcontrol
{
    static public partial class ToBinary
    {
        static public Byte[] ASCII(string ASCIIstring) => Encoding.ASCII.GetBytes(ASCIIstring);
        static public Byte[] ASCII(char ASCIIchar)     => Encoding.ASCII.GetBytes(ASCIIchar.ToString());
        static public Int32  ASCII(string text, Span<Byte> destination) => Encoding.ASCII.GetBytes(text, destination);


        static public Byte[] Utf8(string utf8string) => Encoding.UTF8.GetBytes(utf8string);
        static public Byte[] Utf8(char utf8char)     => Encoding.UTF8.GetBytes(utf8char.ToString());
        static public Int32  Utf8(string text, Span<Byte> destination) => Encoding.UTF8.GetBytes(text, destination);


        static public Byte[] Utf16(string utf16string) => Encoding.Unicode.GetBytes(utf16string);
        static public Byte[] Utf16(char utf16char)     => Encoding.Unicode.GetBytes(utf16char.ToString());
        static public Int32  Utf16(string text, Span<Byte> destination) => Encoding.Unicode.GetBytes(text, destination);


        static public Byte[] BigEndianUtf16(string utf16string) => Encoding.BigEndianUnicode.GetBytes(utf16string);
        static public Byte[] BigEndianUtf16(char utf16char)     => Encoding.BigEndianUnicode.GetBytes(utf16char.ToString());
        static public Int32  BigEndianUtf16(string text, Span<Byte> destination) => Encoding.BigEndianUnicode.GetBytes(text, destination);


        static public Byte[] Utf32(string utf32string) => Encoding.UTF32.GetBytes(utf32string);
        static public Byte[] Utf32(char utf32char)     => Encoding.UTF32.GetBytes(utf32char.ToString());
        static public Int32  Utf32(string text, Span<Byte> destination) => Encoding.UTF32.GetBytes(text, destination);
    }
}