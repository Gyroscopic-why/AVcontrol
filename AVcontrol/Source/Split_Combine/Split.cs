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
    }
}