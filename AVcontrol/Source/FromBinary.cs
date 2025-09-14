using System;
using System.Collections.Generic;

namespace AVcontrol
{
    public class FromBinary
    {
        static public Int16 BigEndian16(Byte[] bytes, Int32 startId, Int32 endId)
        {
            Int16 result = 0;

            if (startId >= 0 && startId < bytes.Length &&
                endId > startId && endId <= bytes.Length)
            {
                for (Int32 id = startId; id < endId; id++)
                    result = (Int16)((result << 8) + bytes[id]);
                //  Shift the result to the left by 8 bits and add the current Byte until we are done

            }
            else throw new ArgumentException("StartId or EndId is out of bounds", "startId or endId");

            return result;
        }
        static public Int32 BigEndian32(Byte[] bytes, Int32 startId, Int32 endId)
        {
            Int32 result = 0;

            if (startId >= 0 && startId < bytes.Length &&
                endId > startId && endId <= bytes.Length)
            {
                for (Int32 id = startId; id < endId; id++)
                    result = (result << 8) + bytes[id];
                //  Shift the result to the left by 8 bits and add the current Byte until we are done

            }
            else throw new ArgumentException("StartId or EndId is out of bounds", "startId or endId");

            return result;
        }
        static public Int64 BigEndian64(Byte[] bytes, Int32 startId, Int32 endId)
        {
            Int64 result = 0;

            if (startId >= 0 && startId < bytes.Length &&
                endId > startId && endId <= bytes.Length)
            {
                for (Int32 id = startId; id < endId; id++)
                    result = (result << 8) + bytes[id];
                //  Shift the result to the left by 8 bits and add the current Byte until we are done

            }
            else throw new ArgumentException("StartId or EndId is out of bounds", "startId or endId");

            return result;
        }
        static public UInt16 BigEndianU16(Byte[] bytes, Int32 startId, Int32 endId)
        {
            UInt16 result = 0;

            if (startId >= 0 && startId < bytes.Length &&
                endId > startId && endId <= bytes.Length)
            {
                for (Int32 id = startId; id < endId; id++)
                    result = (UInt16)((result << 8) + bytes[id]);
                //  Shift the result to the left by 8 bits and add the current Byte until we are done

            }
            else throw new ArgumentException("StartId or EndId is out of bounds", "startId or endId");

            return result;
        }
        static public UInt32 BigEndianU32(Byte[] bytes, Int32 startId, Int32 endId)
        {
            UInt32 result = 0;

            if (startId >= 0 && startId < bytes.Length &&
                endId > startId && endId <= bytes.Length)
            {
                for (Int32 id = startId; id < endId; id++)
                    result = (result << 8) + bytes[id];
                //  Shift the result to the left by 8 bits and add the current Byte until we are done

            }
            else throw new ArgumentException("StartId or EndId is out of bounds", "startId or endId");

            return result;
        }
        static public UInt64 BigEndianU64(Byte[] bytes, Int32 startId, Int32 endId)
        {
            UInt64 result = 0;

            if (startId >= 0 && startId < bytes.Length &&
                endId > startId && endId <= bytes.Length)
            {
                for (Int32 id = startId; id < endId; id++)
                    result = (result << 8) + bytes[id];
                //  Shift the result to the left by 8 bits and add the current Byte until we are done

            }
            else throw new ArgumentException("StartId or EndId is out of bounds", "startId or endId");

            return result;
        }



        static public Int16 LittleEndian16(Byte[] bytes, Int32 startId, Int32 endId)
        {
            Int16 result = 0;

            if (startId >= 0 && startId < bytes.Length &&
                endId > startId && endId <= bytes.Length)
            {
                for (Int32 id = startId; id < endId; id++)
                    result += (Int16) (bytes[id] << (8 * (id - startId)));

            }
            else throw new ArgumentException("StartId or EndId is out of bounds", "startId or endId");

            return result;
        }
        static public Int32 LittleEndian32(Byte[] bytes, Int32 startId, Int32 endId)
        {
            Int32 result = 0;

            if (startId >= 0 && startId < bytes.Length &&
                endId > startId && endId <= bytes.Length)
            {
                for (Int32 id = startId; id < endId; id++)
                    result += bytes[id] << (8 * (id - startId));

            }
            else throw new ArgumentException("StartId or EndId is out of bounds", "startId or endId");

            return result;
        }
        static public Int64 LittleEndian64(Byte[] bytes, Int32 startId, Int32 endId)
        {
            Int64 result = 0;

            if (startId >= 0 && startId < bytes.Length &&
                endId > startId && endId <= bytes.Length)
            {
                for (Int32 id = startId; id < endId; id++)
                    result += bytes[id] << (8 * (id - startId));

            }
            else throw new ArgumentException("StartId or EndId is out of bounds", "startId or endId");

            return result;
        }
        static public UInt16 LittleEndianU16(Byte[] bytes, Int32 startId, Int32 endId)
        {
            UInt16 result = 0;

            if (startId >= 0 && startId < bytes.Length &&
                endId > startId && endId <= bytes.Length)
            {
                for (Int32 id = startId; id < endId; id++)
                    result += (UInt16) (bytes[id] << (8 * (id - startId)));

            }
            else throw new ArgumentException("StartId or EndId is out of bounds", "startId or endId");

            return result;
        }
        static public UInt32 LittleEndianU32(Byte[] bytes, Int32 startId, Int32 endId)
        {
            UInt32 result = 0;

            if (startId >= 0 && startId < bytes.Length &&
                endId > startId && endId <= bytes.Length)
            {
                for (Int32 id = startId; id < endId; id++)
                    result += (UInt32) (bytes[id] << (8 * (id - startId)));

            }
            else throw new ArgumentException("StartId or EndId is out of bounds", "startId or endId");

            return result;
        }
        static public UInt64 LittleEndianU64(Byte[] bytes, Int32 startId, Int32 endId)
        {
            UInt64 result = 0;

            if (startId >= 0 && startId < bytes.Length &&
                endId > startId && endId <= bytes.Length)
            {
                for (Int32 id = startId; id < endId; id++)
                    result += (UInt64) (bytes[id] << (8 * (id - startId)));

            }
            else throw new ArgumentException("StartId or EndId is out of bounds", "startId or endId");

            return result;
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
    }
}