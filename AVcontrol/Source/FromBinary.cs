﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;



namespace AVcontrol
{
    public class FromBinary
    {
        public static T BigEndian<T>(Byte[] bytes) where T : unmanaged
        {
            Byte[] reversed = new Byte[bytes.Length];

            Array.Copy(bytes, reversed, bytes.Length);
            Utils.Reverse(reversed);

            return LittleEndian<T>(reversed);
        }
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
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            if (bytes.Count % 2 != 0) throw new ArgumentException("Byte array length must be even", nameof(bytes));

            var result = new List<Int16>(bytes.Count / 2);

            for (Int32 curId = 0; curId < bytes.Count; curId += 2)
            {
                Int16 value = (Int16)((bytes[curId] << 8) | bytes[curId + 1]);
                result.Add(value);
            }

            return result;
        }
        static public List<Int16> AutoBEBytesToInt16(List<Byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));

            var result = new List<Int16>((bytes.Count + 1) / 2);

            for (Int32 curId = 0; curId < bytes.Count; curId += 2)
            {
                Byte high = bytes[curId];
                Byte low = (curId + 1 < bytes.Count) ? bytes[curId + 1] : (Byte)0;
                result.Add((Int16)((high << 8) | low));
            }

            return result;
        }

        static public List<Int16> LEBytesToInt16(List<Byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            if (bytes.Count % 2 != 0) throw new ArgumentException("Byte array length must be even", nameof(bytes));

            var result = new List<Int16>(bytes.Count / 2);

            for (Int32 curId = 0; curId < bytes.Count; curId += 2)
            {
                Int16 value = (Int16)(bytes[curId] | (bytes[curId + 1] << 8));
                result.Add(value);
            }

            return result;
        }
        static public List<Int16> AutoLEBytesToInt16(List<Byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));

            var result = new List<Int16>((bytes.Count + 1) / 2);

            for (Int32 curId = 0; curId < bytes.Count; curId += 2)
            {
                Byte low = bytes[curId];
                Byte high = (curId + 1 < bytes.Count) ? bytes[curId + 1] : (Byte)0;
                result.Add((Int16)(low | (high << 8)));
            }

            return result;
        }



        static public List<UInt16> BEBytesToUInt16(List<Byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            if (bytes.Count % 2 != 0) throw new ArgumentException("Byte array length must be even", nameof(bytes));

            var result = new List<UInt16>(bytes.Count / 2);

            for (Int32 curId = 0; curId < bytes.Count; curId += 2)
            {
                UInt16 value = (UInt16)((bytes[curId] << 8) | bytes[curId + 1]);
                result.Add(value);
            }

            return result;
        }
        static public List<UInt16> AutoBEBytesToUInt16(List<Byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));

            var result = new List<UInt16>((bytes.Count + 1) / 2);

            for (Int32 curId = 0; curId < bytes.Count; curId += 2)
            {
                Byte high = bytes[curId];
                Byte low = (curId + 1 < bytes.Count) ? bytes[curId + 1] : (Byte)0;
                result.Add((UInt16)((high << 8) | low));
            }

            return result;
        }

        static public List<UInt16> LEBytesToUInt16(List<Byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            if (bytes.Count % 2 != 0) throw new ArgumentException("Byte array length must be even", nameof(bytes));

            var result = new List<UInt16>(bytes.Count / 2);

            for (Int32 curId = 0; curId < bytes.Count; curId += 2)
            {
                UInt16 value = (UInt16)(bytes[curId] | (bytes[curId + 1] << 8));
                result.Add(value);
            }

            return result;
        }
        static public List<UInt16> AutoLEBytesToUInt16(List<Byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));

            var result = new List<UInt16>((bytes.Count + 1) / 2);

            for (Int32 curId = 0; curId < bytes.Count; curId += 2)
            {
                Byte low = bytes[curId];
                Byte high = (curId + 1 < bytes.Count) ? bytes[curId + 1] : (Byte)0;
                result.Add((UInt16)(low | (high << 8)));
            }

            return result;
        }
    }
}