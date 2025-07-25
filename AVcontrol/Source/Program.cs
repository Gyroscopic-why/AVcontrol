using System;
using System.Collections.Generic;

using static System.Console;

namespace AVcontrol
{
    internal class Program
    {
        static void Main()
        {
            string baobab = Numsys.Auto<string>
            (
                (
                    13 + 0
                ).ToString(),
                8,
                3,
                10
            );
            Write("\n\t13 to base 3: " + baobab);


            Int32 oldv = 123;
            List<Int32> newv   = Numsys.AsList(oldv.ToString(), 10, 16);
            List<Int32> filled = Numsys.AsList(oldv.ToString(), 10, 16, 0);

            Write("\n\tBase 10:              " + oldv);
            Write("\n\tBase 16:              ");
            for (Int32 curId = 0; curId < newv.Count;   curId++) Write(newv[curId] + " ");
            Write("\n\tBase 16 [с приколом]: ");
            for (Int32 curId = 0; curId < filled.Count; curId++) Write(filled[curId] + " ");


            ReadKey();
        }
    }
}
