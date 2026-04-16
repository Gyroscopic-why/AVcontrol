using System;
using System.Text;
using System.Buffers;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class FromBinary
    {
        static public string Unsanitized_ASCII(Byte[] bytes, out Byte[] leftover)
        {
            leftover = [];
            return Encoding.ASCII.GetString(bytes);
        }
        static public string Unsanitized_ASCII(List<Byte> bytes, out List<Byte> leftover)
        {
            leftover = [];
            return Encoding.ASCII.GetString([..bytes]);
        }
        static public string Unsanitized_ASCII(ReadOnlySpan<Byte> bytes, out ReadOnlySpan<Byte> leftover)
        {
            leftover = [];
            return Encoding.ASCII.GetString(bytes);
        }



        static public string Unsanitized_Utf8(Byte[] bytes, out Byte[] leftover)
        {
            (string result, Int32 bytesUsed) = DecodeUtf8(bytes.AsSpan());
            leftover = bytes[bytesUsed..];
            return result;
        }
        static public string Unsanitized_Utf8(List<Byte> bytes, out List<Byte> leftover)
            => Unsanitized_Utf8([.. bytes], out leftover);
        static public string Unsanitized_Utf8(ReadOnlySpan<Byte> bytes, out ReadOnlySpan<Byte> leftover)
        {
            (string result, Int32 bytesUsed) = DecodeUtf8(bytes);
            leftover = bytes[bytesUsed..];
            return result;
        }

        static private (string result, Int32 bytesUsed) DecodeUtf8(ReadOnlySpan<Byte> span)
        {
            if (span.IsEmpty) return ("", 0);

            //  Considering worst variant: max length = length in bytes (For full ASCII 1 byte)
            char[]? rentedBuffer = null;
            Span<char> charSpan = span.Length <= 256
                ? stackalloc char[span.Length]
                : (rentedBuffer = new char[span.Length]);

            Int32 charPos = 0;
            Int32 bytePos = 0;

            while (bytePos < span.Length)
            {
                Byte  b = span[bytePos];

                Int32 bytesNeeded;
                if ((b & 0x80) == 0) bytesNeeded = 1;          // 1 Byte (ASCII)
                else if ((b & 0xE0) == 0xC0) bytesNeeded = 2;  // 2 Byte (FLCS2 / UCS-2)
                else if ((b & 0xF0) == 0xE0) bytesNeeded = 3;  // 3 Byte
                else if ((b & 0xF8) == 0xF0) bytesNeeded = 4;  // 4 Byte (UTF-32)

                else break;  // Invalid start byte - truncate
                if (bytePos + bytesNeeded > span.Length) break;  // Uncomplete char at the end - truncate

                Int32 codePoint;
                if (bytesNeeded == 1) codePoint = b;
                else if (bytesNeeded == 2)
                    codePoint = ((b & 0x1F) << 6)
                        | (span[bytePos + 1] & 0x3F);
                else if (bytesNeeded == 3) 
                    codePoint = ((b & 0x0F) << 12)
                        | ((span[bytePos + 1] & 0x3F) << 6)
                        |  (span[bytePos + 2] & 0x3F);
                else codePoint = ((b & 0x07) << 18)
                        | ((span[bytePos + 1] & 0x3F) << 12)
                        | ((span[bytePos + 2] & 0x3F) << 6)
                        |  (span[bytePos + 3] & 0x3F);

                if (codePoint <= 0xFFFF) charSpan[charPos++] = (char)codePoint;
                else  //  Surrogate pair for code points above U+FFFF
                {
                    codePoint -= 0x10000;
                    charSpan[charPos++] = (char)(0xD800 + (codePoint >> 10));
                    charSpan[charPos++] = (char)(0xDC00 + (codePoint & 0x3FF));
                }

                bytePos += bytesNeeded;
            }

            string result = new(charSpan[0..charPos]);
            if (rentedBuffer != null) ArrayPool<char>.Shared.Return(rentedBuffer);
            return (result, bytePos);
        }



        static public string Unsanitized_Utf16(Byte[] bytes, out Byte[] leftover)
            => Unsanitized_Utf16(bytes, false, out leftover);
        static public string Unsanitized_Utf16(List<Byte> bytes, out List<Byte> leftover)
            => Unsanitized_Utf16([.. bytes], false, out leftover);
        static public string Unsanitized_Utf16(ReadOnlySpan<Byte> bytes, out ReadOnlySpan<Byte> leftover)
            => Unsanitized_Utf16(bytes, false, out leftover);

        static public string Unsanitized_BigEndianUtf16(Byte[] bytes, out Byte[] leftover)
            => Unsanitized_Utf16(bytes, true, out leftover);
        static public string Unsanitized_BigEndianUtf16(List<Byte> bytes, out List<Byte> leftover)
            => Unsanitized_Utf16([.. bytes], true, out leftover);
        static public string Unsanitized_BigEndianUtf16(ReadOnlySpan<Byte> bytes, out ReadOnlySpan<Byte> leftover)
            => Unsanitized_Utf16(bytes, true, out leftover);

        static private string Unsanitized_Utf16(Byte[] interval, bool bigEndian, out Byte[] leftover)
        {
            Int32 validBytes = interval.Length;
            if (validBytes < 2)
            {
                leftover = [.. interval];
                return "";
            }

            validBytes -= validBytes % 2;

            Int32 lastWordOffset = validBytes - 2;
            Byte  lo = interval[lastWordOffset], hi = interval[lastWordOffset + 1];

            Int32 codeUnit = bigEndian ? (lo << 8) | hi : (hi << 8) | lo;
            if (codeUnit is >= 0xD800 and <= 0xDBFF) validBytes -= 2;

            leftover = [.. interval[validBytes..]];
            return (bigEndian ? Encoding.BigEndianUnicode : Encoding.Unicode).GetString(interval[..validBytes]);
        }
        static private string Unsanitized_Utf16(Byte[] interval, bool bigEndian, out List<Byte> leftover)
        {
            string result = Unsanitized_Utf16(interval, bigEndian, out Byte[] arrLeftover);
            leftover = [.. arrLeftover];
            return result;
        }
        static private string Unsanitized_Utf16(ReadOnlySpan<Byte> interval, bool bigEndian, out ReadOnlySpan<Byte> leftover)
        {
            string result = Unsanitized_Utf16([.. interval], bigEndian, out Byte[] arrLeftover);
            leftover = arrLeftover;
            return result;
        }



        static public string Unsanitized_Utf32(Byte[] bytes, out Byte[] leftover)
        {
            Int32 validLen = bytes.Length / 4 * 4;
            leftover = bytes[validLen..];
            return Encoding.UTF32.GetString(bytes, 0, validLen);
        }
        static public string Unsanitized_Utf32(List<Byte> bytes, out List<Byte> leftover)
            => Unsanitized_Utf32([.. bytes], out leftover);
        static public string Unsanitized_Utf32(ReadOnlySpan<Byte> bytes, out ReadOnlySpan<Byte> leftover)
            => Unsanitized_Utf32(bytes, out leftover);
    }
}