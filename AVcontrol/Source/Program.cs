using System;
using System.Linq;
using System.Collections.Generic;

using static System.Console;


namespace AVcontrol
{
    internal class Program
    {
        static void Main()
        {
            string baobab = "aboba";
            string external = "abo";
            Byte[] external2 = new byte[] { 0, 1, 2 }; // a, b, o
            Byte[] overflows = { 0, 0, 4, 4, 0 };

            List<Int16> ids = new List<Int16>();
            for (var i = 0; i < baobab.Length; i++)
                ids.Add((Int16)external.IndexOf(baobab[i]));

            Byte[] decoded = Conversions.FromInt16List
            (
                Numsys.FromCustomAsUtf16Binary
                (
                    Numsys.ToCustomAsUtf16Binary
                    (
                        Conversions.ToInt16List
                        (
                            overflows.ToList()
                        ),
                        10,
                        3,
                        Conversions.ToInt16List
                        (
                            external2.ToList()
                        )
                    ),
                    3,
                    10,
                    Conversions.ToInt16List
                    (
                        external2.ToList()
                    )
                )
            ).ToArray();


            Write("\n\tРезультат за-декодирования: ");
            for (var i = 0; i < decoded.Length; i++) Write(decoded[i] + " ");

            ReadKey();
        }
    }
}
