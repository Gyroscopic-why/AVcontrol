using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;



namespace AVcontrol
{
    public class ToBinary
    {
        static public Byte[] ASCII(string ASCIIstring) => Encoding.ASCII.GetBytes(ASCIIstring);
        static public Byte[] ASCII(char ASCIIchar)     => Encoding.ASCII.GetBytes(ASCIIchar.ToString());
        public static Int32  ASCII(string text, Span<Byte> destination) => Encoding.ASCII.GetBytes(text, destination);

        static public Byte[] Utf8(string utf8string) => Encoding.UTF8.GetBytes(utf8string);
        static public Byte[] Utf8(char utf8char)     => Encoding.UTF8.GetBytes(utf8char.ToString());
        public static Int32  Utf8(string text, Span<Byte> destination) => Encoding.UTF8.GetBytes(text, destination);

        static public Byte[] Utf16(string utf16string) => Encoding.Unicode.GetBytes(utf16string);
        static public Byte[] Utf16(char utf16char)     => Encoding.Unicode.GetBytes(utf16char.ToString());
        public static Int32  Utf16(string text, Span<Byte> destination) => Encoding.Unicode.GetBytes(text, destination);

        static public Byte[] BigEndianUtf16(string utf16string) => Encoding.BigEndianUnicode.GetBytes(utf16string);
        static public Byte[] BigEndianUtf16(char utf16char)     => Encoding.BigEndianUnicode.GetBytes(utf16char.ToString());
        public static Int32  BigEndianUtf16(string text, Span<Byte> destination) => Encoding.BigEndianUnicode.GetBytes(text, destination);

        static public Byte[] Utf32(string utf32string) => Encoding.UTF32.GetBytes(utf32string);
        static public Byte[] Utf32(char utf32char)     => Encoding.UTF32.GetBytes(utf32char.ToString());
        public static Int32  Utf32(string text, Span<Byte> destination) => Encoding.UTF32.GetBytes(text, destination);



        public static Byte[] LittleEndian<T>(T value) where T : unmanaged
        {
            Utils.TypeArgumentCheck<T>();

            Int32 size = Marshal.SizeOf<T>();
            Byte[] bytes = new Byte[size];

            unsafe
            {
                fixed (Byte* ptr = bytes)
                {
                    *(T*)ptr = value;
                }
            }

            return bytes;
        }
        public static Byte[] LittleEndian<T>(T[] values) where T : unmanaged
        {
            Utils.TypeArgumentCheck<T>();

            Int32 elementSize = Marshal.SizeOf<T>();
            Byte[] result = new Byte[values.Length * elementSize];
            Int32 offset = 0;

            foreach (var value in values)
            {
                Byte[] bytes = LittleEndian(value);
                Array.Copy(bytes, 0, result, offset, elementSize);
                offset += elementSize;
            }

            return result;
        }
        public static List<Byte> LittleEndian<T>(List<T> values) where T : unmanaged
        {
            Utils.TypeArgumentCheck<T>();

            Int32 elementSize = Marshal.SizeOf<T>();
            List<Byte> result = new(values.Count * elementSize);

            foreach (var value in values)
            {
                Byte[] bytes = LittleEndian(value);
                result.AddRange(bytes);
            }

            return result;
        }
        public static bool LittleEndian<T>(T value, Span<Byte> destination) where T : unmanaged
        {
            Utils.TypeArgumentCheck<T>();
            Int32 size = Marshal.SizeOf<T>();
            if (destination.Length < size) return false;

            unsafe
            {
                fixed (Byte* ptr = destination)
                {
                    *(T*)ptr = value;
                }
            }
            return true;
        }
        public static Int32 LittleEndian<T>(T[] values, Span<Byte> destination) where T : unmanaged
        {
            Int32 elemSize = Marshal.SizeOf<T>();
            Int32 totalSize = values.Length * elemSize;
            if (destination.Length < totalSize)
                throw new ArgumentException("Destination span too small");

            Int32 offset = 0;
            foreach (var v in values)
            {
                LittleEndian(v, destination.Slice(offset, elemSize));
                offset += elemSize;
            }
            return totalSize;
        }


        public static Byte[] BigEndian<T>(T value) where T : unmanaged
            => Utils.Reverse(LittleEndian(value));
        public static Byte[] BigEndian<T>(T[] values) where T : unmanaged
        {
            Utils.TypeArgumentCheck<T>();

            Int32 elementSize = Marshal.SizeOf<T>();
            Byte[] result = new Byte[values.Length * elementSize];
            Int32 offset = 0;

            foreach (var value in values)
            {
                Byte[] bytes = BigEndian(value);

                Array.Copy(bytes, 0, result, offset, elementSize);
                offset += elementSize;
            }

            return result;
        }
        public static List<Byte> BigEndian<T>(List<T> values) where T : unmanaged
        {
            Utils.TypeArgumentCheck<T>();

            Int32 elementSize = Marshal.SizeOf<T>();
            List<Byte> result = new(values.Count * elementSize);

            foreach (var value in values)
            {
                Byte[] bytes = BigEndian(value);

                result.AddRange(bytes);
            }

            return result;
        }
        public static bool BigEndian<T>(T value, Span<Byte> destination) where T : unmanaged
        {
            Int32 size = Marshal.SizeOf<T>();
            if (destination.Length < size) return false;
            if (!LittleEndian(value, destination)) return false;
            Utils.Reverse(destination[..size]);
            return true;
        }
        public static Int32 BigEndian<T>(T[] values, Span<Byte> destination) where T : unmanaged
        {
            Int32 elemSize = Marshal.SizeOf<T>();
            Int32 totalSize = values.Length * elemSize;
            if (destination.Length < totalSize)
                throw new ArgumentException("Destination span too small");

            Int32 offset = 0;
            foreach (var v in values)
            {
                BigEndian(v, destination.Slice(offset, elemSize));
                offset += elemSize;
            }
            return totalSize;
        }
    }
}