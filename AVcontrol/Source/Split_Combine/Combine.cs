using System;
using System.Collections.Generic;



namespace AVcontrol.Source.Split_Combine
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
    }
}