using System;

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
    }
}