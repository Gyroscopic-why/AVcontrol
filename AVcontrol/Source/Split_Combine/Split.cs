using System;
using System.Collections.Generic;



namespace AVcontrol
{
    static public class Split
    {
        static public List<T_out> LittleEndian <T_in, T_out>(T_in initial, Int32 numbase)
        {
            Utils.TypeArgumentCheck<T_in>();
            Utils.TypeArgumentCheck<T_out>();

            Int64 value = Convert.ToInt64(initial);

            Numsys.BaseArgumentCheck(numbase);
            if (value < numbase) return [(T_out)Convert.ChangeType(value, typeof(T_out))];

            Int32 digitCount = (Int32)(Math.Log(value, numbase) + 1);
            var result = new List<T_out>(digitCount);

            for (var i = 0; i < digitCount; i++)
                result.Add
                    (
                        (T_out)Convert.ChangeType
                        (
                            value / (Int64)Math.Pow(numbase, i) % numbase,
                            typeof(T_out)
                    )   );

            return result;
        }
        static public List<T_out> BigEndian    <T_in, T_out>(T_in initial, Int32 numbase)
            => Utils.Reverse(LittleEndian<T_in, T_out>(initial, numbase));



        static public List<T[]> ArrayFixedSize  <T>(T[] initial, Int32 inclusiveMinSize, Int32 exclusiveMaxSize)
        {
            ArgumentNullException.ThrowIfNull(initial);
            var sizes = ComputeFixedSizes(initial.Length, inclusiveMinSize, exclusiveMaxSize);
            return SliceArray(initial, sizes);
        }
        static public List<T[]> ArrayRandomSize <T>(T[] initial, Int32 inclusiveMinSize, Int32 exclusiveMaxSize)
        {
            ArgumentNullException.ThrowIfNull(initial);
            var sizes = ComputeRandomSizes(initial.Length, inclusiveMinSize, exclusiveMaxSize);
            return SliceArray(initial, sizes);
        }
        static public List<T[]> ArrayUniformSize<T>(T[] initial, Int32 fragmentCount, bool oversizeInFront)
        {
            ArgumentNullException.ThrowIfNull(initial);
            var sizes = ComputeUniformSizes(initial.Length, fragmentCount, oversizeInFront);
            return SliceArray(initial, sizes);
        }

        static public List<List<T>> ListFixedSize  <T>(List<T> initial, Int32 inclusiveMinSize, Int32 exclusiveMaxSize)
        {
            ArgumentNullException.ThrowIfNull(initial);
            var sizes = ComputeFixedSizes(initial.Count, inclusiveMinSize, exclusiveMaxSize);
            return SliceList(initial, sizes);
        }
        static public List<List<T>> ListRandomSize <T>(List<T> initial, Int32 inclusiveMinSize, Int32 exclusiveMaxSize)
        {
            ArgumentNullException.ThrowIfNull(initial);
            var sizes = ComputeRandomSizes(initial.Count, inclusiveMinSize, exclusiveMaxSize);
            return SliceList(initial, sizes);
        }
        static public List<List<T>> ListUniformSize<T>(List<T> initial, Int32 fragmentCount, bool oversizeInFront)
        {
            ArgumentNullException.ThrowIfNull(initial);
            var sizes = ComputeUniformSizes(initial.Count, fragmentCount, oversizeInFront);
            return SliceList(initial, sizes);
        }



        static private List<Int32> ComputeFixedSizes(Int32 length, Int32 inclusiveMinSize, Int32 exclusiveMaxSize)
        {
            inclusiveMinSize = inclusiveMinSize < 1 ? 1 : inclusiveMinSize;
            ArgumentOutOfRangeException.ThrowIfLessThan(exclusiveMaxSize, inclusiveMinSize);

            if (length == 0) return [];
            Int32 minFragmentCount = (length + exclusiveMaxSize - 1) / exclusiveMaxSize;

            if ((Int64)minFragmentCount * inclusiveMinSize > length)
                throw new ArgumentException($"Cannot split {length} elements into chunks of sizes [{inclusiveMinSize}-{exclusiveMaxSize})");

            return DistributeEvenly(length, minFragmentCount, oversizeFirst: true);
        }
        static private List<Int32> ComputeUniformSizes(Int32 length, Int32 fragmentCount, bool oversizeInFront)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(fragmentCount);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(fragmentCount, length);

            return DistributeEvenly(length, fragmentCount, oversizeFirst: oversizeInFront);
        }

        static private List<Int32> DistributeEvenly(Int32 length, Int32 n, bool oversizeFirst)
        {
            List<Int32> sizes = new(n);
            Int32 baseSize  = length / n;
            Int32 remainder = length % n;

            for (var i = 0; i < n; i++)
            {
                bool oversized = oversizeFirst ? i < remainder : i >= n - remainder;
                sizes.Add(oversized ? baseSize + 1 : baseSize);
            }
            return sizes;
        }
        static private List<Int32> ComputeRandomSizes(Int32 length, Int32 inclusiveMinSize, Int32 exclusiveMaxSize)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(inclusiveMinSize);
            ArgumentOutOfRangeException.ThrowIfLessThan(exclusiveMaxSize, inclusiveMinSize);
            if (length == 0) return [];

            inclusiveMinSize   = inclusiveMinSize < 1 ? 1 : inclusiveMinSize;
            Int32 maxInclusive = exclusiveMaxSize == inclusiveMinSize ? inclusiveMinSize : exclusiveMaxSize - 1;

            Int32 minCount = (length + maxInclusive - 1) / maxInclusive;
            Int32 maxCount = length / inclusiveMinSize;

            if (minCount < 1) minCount = 1;
            if (minCount > maxCount)
                throw new ArgumentException(
                    $"Cannot split {length} elements into chunks of sizes [{inclusiveMinSize}-{exclusiveMaxSize})");

            FastRandom randomDevice = new();
            Int32 count = (maxCount == minCount) ? minCount : randomDevice.Next(minCount, maxCount + 1);

            Int32 intervalCapacity = maxInclusive - inclusiveMinSize;
            Int32 surplus = length - count * inclusiveMinSize;

            List<Int32> sizes = new(count);
            for (Int32 i = 0; i < count; i++)
            {
                Int32 slotsLeft = count - 1 - i;

                Int32 lowAdd  = Math.Max(0, surplus - slotsLeft * intervalCapacity);
                Int32 highAdd = Math.Min(intervalCapacity, surplus);

                Int32 additional = (lowAdd == highAdd) ? lowAdd : randomDevice.Next(lowAdd, highAdd + 1);

                sizes.Add(inclusiveMinSize + additional);
                surplus -= additional;
            }
            return sizes;
        }

        static private List<T[]> SliceArray<T>(T[] initial, List<int> sizes)
        {
            List<T[]> result = new(sizes.Count);
            Int32 offset = 0;

            foreach (int size in sizes)
            {
                var chunk = new T[size];
                Array.Copy(initial, offset, chunk, 0, size);
                result.Add(chunk);
                offset += size;
            }
            return result;
        }
        static private List<List<T>> SliceList<T>(List<T> initial, List<int> sizes)
        {
            List<List<T>> result = new(sizes.Count);
            Int32 offset = 0;

            foreach (Int32 size in sizes)
            {
                result.Add(initial.GetRange(offset, size));
                offset += size;
            }
            return result;
        }
    }
}