using System;
using System.Collections.Generic;

namespace AVcontrol
{
    public class Conversions
    {
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




        static public List<Byte> Int16ToBEBytes(List<Int16> values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            var result = new List<Byte>(values.Count * 2);
            foreach (var value in values)
            {
                result.Add((Byte)(value >> 8));
                result.Add((Byte)(value & 0xFF));
            }
            return result;
        }
        static public List<Byte> Int16ToLEBytes(List<Int16> values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            var result = new List<Byte>(values.Count * 2);
            foreach (var value in values)
            {
                result.Add((Byte)(value & 0xFF));
                result.Add((Byte)(value >> 8));
            }
            return result;
        }

        static public List<Byte> UInt16ToBEBytes(List<UInt16> values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            var result = new List<Byte>(values.Count * 2);
            foreach (var value in values)
            {
                result.Add((Byte)(value >> 8));
                result.Add((Byte)(value & 0xFF));
            }
            return result;
        }
        static public List<Byte> UInt16ToLEBytes(List<UInt16> values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            var result = new List<Byte>(values.Count * 2);
            foreach (var value in values)
            {
                result.Add((Byte)(value & 0xFF));
                result.Add((Byte)(value >> 8));
            }
            return result;
        }





        static public List<Int16> ToInt16List(List<Byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            var result = new List<Int16>(bytes.Count);
            foreach (var b in bytes) result.Add((Int16)b);
            return result;
        }
        static public List<UInt16> ToUInt16List(List<Byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            var result = new List<UInt16>(bytes.Count);
            foreach (var b in bytes) result.Add((UInt16)b);
            return result;
        }
        static public List<Byte> FromInt16List(List<Int16> values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            var result = new List<Byte>(values.Count);
            foreach (var v in values)
            {
                if (v < 0 || v > 255) throw new ArgumentOutOfRangeException(nameof(values), "All Int16 values must be in the range 0-255 to convert to Byte.");
                result.Add((Byte)v);
            }
            return result;
        }
        static public List<Byte> FromUInt16List(List<UInt16> values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            var result = new List<Byte>(values.Count);
            foreach (var v in values)
            {
                if (v > 255) throw new ArgumentOutOfRangeException(nameof(values), "All UInt16 values must be in the range 0-255 to convert to Byte.");
                result.Add((Byte)v);
            }
            return result;
        }



        static public List<Int32> ToInt32List(List<Byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            var result = new List<Int32>(bytes.Count);
            foreach (var b in bytes) result.Add((Int32)b);
            return result;
        }
        static public List<UInt32> ToUInt32List(List<Byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            var result = new List<UInt32>(bytes.Count);
            foreach (var b in bytes) result.Add((UInt32)b);
            return result;
        }
        static public List<Byte> FromInt32List(List<Int32> values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            var result = new List<Byte>(values.Count);
            foreach (var v in values)
            {
                if (v < 0 || v > 255) throw new ArgumentOutOfRangeException(nameof(values), "All Int32 values must be in the range 0-255 to convert to Byte.");
                result.Add((Byte)v);
            }
            return result;
        }
        static public List<Byte> FromUInt32List(List<UInt32> values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            var result = new List<Byte>(values.Count);
            foreach (var v in values)
            {
                if (v > 255) throw new ArgumentOutOfRangeException(nameof(values), "All UInt32 values must be in the range 0-255 to convert to Byte.");
                result.Add((Byte)v);
            }
            return result;
        }



        static public List<Int64> ToInt64List(List<Byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            var result = new List<Int64>(bytes.Count);
            foreach (var b in bytes) result.Add((Int64)b);
            return result;
        }
        static public List<UInt64> ToUInt64List(List<Byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            var result = new List<UInt64>(bytes.Count);
            foreach (var b in bytes) result.Add((UInt64)b);
            return result;
        }
        static public List<Byte> FromInt64List(List<Int64> values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            var result = new List<Byte>(values.Count);
            foreach (var v in values)
            {
                if (v < 0 || v > 255) throw new ArgumentOutOfRangeException(nameof(values), "All Int64 values must be in the range 0-255 to convert to Byte.");
                result.Add((Byte)v);
            }
            return result;
        }
        static public List<Byte> FromUInt64List(List<UInt64> values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            var result = new List<Byte>(values.Count);
            foreach (var v in values)
            {
                if (v > 255) throw new ArgumentOutOfRangeException(nameof(values), "All UInt64 values must be in the range 0-255 to convert to Byte.");
                result.Add((Byte)v);
            }
            return result;
        }
    }
}