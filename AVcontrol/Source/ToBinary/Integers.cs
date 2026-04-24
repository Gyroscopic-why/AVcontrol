using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;



namespace AVcontrol
{
    static public partial class ToBinary
    {
        static public Byte[] LittleEndian<T>(T value) where T : unmanaged
        {
            Utils.TypeArgumentCheck<T>();

            Int32  size  = Marshal.SizeOf<T>();
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
        static public Byte[] LittleEndian<T>(T[] values) where T : unmanaged
        {
            Utils.TypeArgumentCheck<T>();

            Int32  elementSize = Marshal.SizeOf<T>(), offset = 0;
            Byte[] result = new Byte[values.Length * elementSize];

            foreach (var value in values)
            {
                Byte[] bytes = LittleEndian(value);
                Array.Copy(bytes, 0, result, offset, elementSize);
                offset += elementSize;
            }

            return result;
        }
        static public List<Byte> LittleEndian<T>(List<T> values) where T : unmanaged
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

        static public bool  LittleEndian<T>(T value, Span<Byte> destination) where T : unmanaged
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
        static public Int32 LittleEndian<T>(T[] values, Span<Byte> destination) where T : unmanaged
        {
            Int32 elemSize = Marshal.SizeOf<T>(), totalSize = values.Length * elemSize;

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



        static public Byte[] BigEndian<T>(T value) where T : unmanaged
            => Utils.Reverse(LittleEndian(value));
        static public Byte[] BigEndian<T>(T[] values) where T : unmanaged
        {
            Utils.TypeArgumentCheck<T>();

            Int32  elementSize = Marshal.SizeOf<T>(), offset = 0;
            Byte[] result = new Byte[values.Length * elementSize];

            foreach (var value in values)
            {
                Byte[] bytes = BigEndian(value);

                Array.Copy(bytes, 0, result, offset, elementSize);
                offset += elementSize;
            }

            return result;
        }
        static public List<Byte> BigEndian<T>(List<T> values) where T : unmanaged
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

        static public bool  BigEndian<T>(T   value,  Span<Byte> destination) where T : unmanaged
        {
            Int32 size = Marshal.SizeOf<T>();

            if (destination.Length < size ||
                !LittleEndian(value, destination)) return false;

            Utils.Reverse(destination[..size]);
            return true;
        }
        static public Int32 BigEndian<T>(T[] values, Span<Byte> destination) where T : unmanaged
        {
            Int32 elemSize = Marshal.SizeOf<T>(), totalSize = values.Length * elemSize;

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