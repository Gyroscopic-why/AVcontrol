using System;
using System.Collections.Generic;



namespace AVcontrol
{
    static public class Combine
    {
        static public T_out LittleEndian<T_in, T_out>(List<T_in> initial, Int32 numbase)
        {
            Utils.TypeArgumentCheck<T_in>();
            Utils.TypeArgumentCheck<T_out>();

            Numsys.BaseArgumentCheck(numbase);

            Int64 result = 0;
            Int64 multiplier = 1;

            foreach (var digit in initial)
            {
                Byte parsedDigit = Convert.ToByte(digit);

                if (parsedDigit >= numbase)
                    throw new ArgumentException($"Digit {parsedDigit} is not valid for base {numbase}");

                result += parsedDigit * multiplier;
                multiplier *= numbase;
            }

            return (T_out)Convert.ChangeType(result, typeof(T_out));
        }
        static public T_out BigEndian<T_in, T_out>(List<T_in> initial, Int32 numbase)
            => LittleEndian<T_in, T_out>(Utils.Reverse(initial), numbase);


        static public T[] ToArray<T>(List<T[]> chunks)
        {
            ArgumentNullException.ThrowIfNull(chunks);

            var total = 0;
            for (var i = 0; i < chunks.Count; i++) total += chunks[i].Length;

            var result = new T[total];
            var offset = 0;
            for (var i = 0; i < chunks.Count; i++)
            {
                var c = chunks[i];
                Array.Copy(c, 0, result, offset, c.Length);
                offset += c.Length;
            }
            return result;
        }
        static public T[] ToArray<T>(List<T[]> chunks, Int32[] includeOrder)
        {
            ArgumentNullException.ThrowIfNull(chunks);
            ArgumentNullException.ThrowIfNull(includeOrder);

            var total = 0;
            for (var i = 0; i < chunks.Count; i++) total += chunks[includeOrder[i]].Length;

            var result = new T[total];
            var offset = 0;
            for (var i = 0; i < chunks.Count; i++)
            {
                var c = chunks[includeOrder[i]];
                Array.Copy(c, 0, result, offset, c.Length);
                offset += c.Length;
            }
            return result;
        }

        static public List<T> ToList<T>(List<List<T>> chunks)
        {
            ArgumentNullException.ThrowIfNull(chunks);

            var total = 0;
            for (var i = 0; i < chunks.Count; i++) total += chunks[i].Count;

            List<T> result = new(total);
            for (var i = 0; i < chunks.Count; i++) result.AddRange(chunks[i]);
            return result;
        }
        static public List<T> ToList<T>(List<List<T>> chunks, Int32[] includeOrder)
        {
            ArgumentNullException.ThrowIfNull(chunks);
            ArgumentNullException.ThrowIfNull(includeOrder);

            var total = 0;
            for (var i = 0; i < chunks.Count; i++) total += chunks[includeOrder[i]].Count;

            List<T> result = new(total);
            for (var i = 0; i < chunks.Count; i++) result.AddRange(chunks[includeOrder[i]]);
            return result;
        }
    }
}