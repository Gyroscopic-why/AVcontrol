using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;



namespace AVcontrol
{
    public class FromBinary
    {
        static public string ASCII(Byte[] ASCII)     => Encoding.ASCII.GetString(ASCII);
        static public string ASCII(List<Byte> ASCII) => Encoding.ASCII.GetString([.. ASCII]);

        static public string Utf8(Byte[] utf8bytes)     => Encoding.UTF8.GetString(utf8bytes);
        static public string Utf8(List<Byte> utf8bytes) => Encoding.UTF8.GetString([.. utf8bytes]);

        static public string Utf16(Byte[] utf16byte)     => Encoding.Unicode.GetString(utf16byte);
        static public string Utf16(List<Byte> utf16byte) => Encoding.Unicode.GetString([.. utf16byte]);

        static public string BigEndianUtf16(Byte[] utf16byte)     => Encoding.BigEndianUnicode.GetString(utf16byte);
        static public string BigEndianUtf16(List<Byte> utf16byte) => Encoding.BigEndianUnicode.GetString([.. utf16byte]);

        static public string Utf32(Byte[] utf32bytes)     => Encoding.UTF32.GetString(utf32bytes);
        static public string Utf32(List<Byte> utf32bytes) => Encoding.UTF32.GetString([.. utf32bytes]);



        public static T BigEndian<T>(Byte[] bytes) where T : unmanaged
            => LittleEndian<T>(Utils.Reverse(bytes));
        
        public static T LittleEndian<T>(Byte[] bytes) where T : unmanaged
        {
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




        static public List<Int16> BigEndianBytesToInt16(List<Byte> bytes)
        {
            if (bytes.Count % 2 != 0) throw new ArgumentException("Byte array length must be even", nameof(bytes));

            var result = new List<Int16>(bytes.Count / 2);

            for (var curId = 0; curId < bytes.Count; curId += 2)
            {
                Int16 value = (Int16)((bytes[curId] << 8) | bytes[curId + 1]);
                result.Add(value);
            }

            return result;
        }
        static public List<Int16> AutoBEBytesToInt16(List<Byte> bytes)
        {
            var result = new List<Int16>((bytes.Count + 1) / 2);

            for (var curId = 0; curId < bytes.Count; curId += 2)
            {
                Byte high = bytes[curId];
                Byte low = (curId + 1 < bytes.Count) ? bytes[curId + 1] : (Byte)0;
                result.Add((Int16)((high << 8) | low));
            }

            return result;
        }

        static public List<Int16> LEBytesToInt16(List<Byte> bytes)
        {
            if (bytes.Count % 2 != 0) throw new ArgumentException("Byte array length must be even", nameof(bytes));

            var result = new List<Int16>(bytes.Count / 2);

            for (var curId = 0; curId < bytes.Count; curId += 2)
            {
                Int16 value = (Int16)(bytes[curId] | (bytes[curId + 1] << 8));
                result.Add(value);
            }

            return result;
        }
        static public List<Int16> AutoLEBytesToInt16(List<Byte> bytes)
        {
            var result = new List<Int16>((bytes.Count + 1) / 2);

            for (var curId = 0; curId < bytes.Count; curId += 2)
            {
                Byte low = bytes[curId];
                Byte high = (curId + 1 < bytes.Count) ? bytes[curId + 1] : (Byte)0;
                result.Add((Int16)(low | (high << 8)));
            }

            return result;
        }



        static public List<UInt16> BEBytesToUInt16(List<Byte> bytes)
        {
            if (bytes.Count % 2 != 0) throw new ArgumentException("Byte array length must be even", nameof(bytes));

            var result = new List<UInt16>(bytes.Count / 2);

            for (var curId = 0; curId < bytes.Count; curId += 2)
            {
                UInt16 value = (UInt16)((bytes[curId] << 8) | bytes[curId + 1]);
                result.Add(value);
            }

            return result;
        }
        static public List<UInt16> AutoBEBytesToUInt16(List<Byte> bytes)
        {
            var result = new List<UInt16>((bytes.Count + 1) / 2);

            for (var curId = 0; curId < bytes.Count; curId += 2)
            {
                Byte high = bytes[curId];
                Byte low = (curId + 1 < bytes.Count) ? bytes[curId + 1] : (Byte)0;
                result.Add((UInt16)((high << 8) | low));
            }

            return result;
        }

        static public List<UInt16> LEBytesToUInt16(List<Byte> bytes)
        {
            if (bytes.Count % 2 != 0) throw new ArgumentException("Byte array length must be even", nameof(bytes));

            var result = new List<UInt16>(bytes.Count / 2);

            for (var curId = 0; curId < bytes.Count; curId += 2)
            {
                UInt16 value = (UInt16)(bytes[curId] | (bytes[curId + 1] << 8));
                result.Add(value);
            }

            return result;
        }
        static public List<UInt16> AutoLEBytesToUInt16(List<Byte> bytes)
        {
            var result = new List<UInt16>((bytes.Count + 1) / 2);

            for (var curId = 0; curId < bytes.Count; curId += 2)
            {
                Byte low = bytes[curId];
                Byte high = (curId + 1 < bytes.Count) ? bytes[curId + 1] : (Byte)0;
                result.Add((UInt16)(low | (high << 8)));
            }

            return result;
        }
    }
}