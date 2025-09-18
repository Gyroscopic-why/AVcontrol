using System;
using System.Diagnostics;

using static System.Console;



namespace AVcontrol
{
    internal class Program
    {
        static void Main()
        {
            Stopwatch timer = new Stopwatch();


            /*
            timer.Start();
            for (var i = 0; i < 20_000_000; i++)
            {
                Int32 parsedEncoding = Convert.ToInt32
                (
                    Numsys.ToDecimalFromCustom
                    (
                        new List<Int16>() { 1, 0 },
                    8,
                    new List<Int16>() { 0, 1, 2, 3, 4, 5, 6, 7 }
                    )
                );
            }
            timer.Stop();
            Write("Convert to Int32: " + timer.ElapsedMilliseconds + " ms\n");


            timer.Reset();
            timer.Start();
            for (var i = 0; i < 20_000_000; i++)
            {
                Int32 parsedEncoding = Numsys.ToSmallDecimalFromCustom
                (
                    new List<Int16>() { 1, 0 },
                    8,
                    new List<Int16>() { 0, 1, 2, 3, 4, 5, 6, 7 }
                );
            }
            timer.Stop();
            Write("Direct Int32: " + timer.ElapsedMilliseconds + " ms\n");*/



            Write("\n\t\tDone! ");
            ReadKey();
        }
    }
}
