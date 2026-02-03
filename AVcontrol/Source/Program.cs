using System;
using System.Diagnostics;

using System.Linq;
using System.Collections.Generic;

using static System.Console;



namespace AVcontrol
{
    internal class Program
    {
        static void Main()
        { 
            Stopwatch   timer = new();
            Random   standart = new();
            FastRandom   fast = new();
            SecureRandom test = new();

            



            for (var hide = 0; hide < 1; hide++)
            { 
                List<Int64> ms1 = [], ms2 = [];
                const Int64 totalAttempts = 10, iterationsPerAttempt = 100_000_000;
                Write($"\n\n\n\t\t[i]  - Starting benchmark of {totalAttempts * iterationsPerAttempt / 1_000_000_000}b rng Int32");

                for (var attempt = 0; attempt < totalAttempts; attempt++)
                {
                    if (attempt % 2 == 0)
                    {
                        Write("\n\t\t\tSTANDART   - ");
                        timer.Start();
                        for (var i = 0; i < iterationsPerAttempt; i++) standart.Next();

                        timer.Stop();
                        ms1.Add(timer.ElapsedMilliseconds);
                    }
                    else
                    {
                        Write("\n\t\t\tFASTSEC    - ");
                        timer.Start();
                        for (var i = 0; i < iterationsPerAttempt; i++) fast.Next();

                        timer.Stop();
                        ms2.Add(timer.ElapsedMilliseconds);
                    }

                    string elapsed = ((double)timer.ElapsedMilliseconds / 1000).ToString().Replace(",", ".");
                    Write($"\tAttempt {attempt + 1})\t RNG     {iterationsPerAttempt / 1_000_000}m: {elapsed}");
                    timer.Reset();
                }

                double min1 = (double)ms1.Min() / 1000, max1 = (double)ms1.Max() / 1000;
                double min2 = (double)ms2.Min() / 1000, max2 = (double)ms2.Max() / 1000;
                double sum1 = (double)ms1.Sum() / 1000, sum2 = (double)ms2.Sum() / 1000;
                double avg1 = ms1.Average() / 1000, avg2 = ms2.Average() / 1000, avgGlobal = (avg1 + avg2) / 2;

                bool isFirst1 = min1 < min2, isFirst2 = max1 > max2;

                string i1 = min1.ToString().Replace(",", "."), a1 = max1.ToString().Replace(",", ".");
                string i2 = min2.ToString().Replace(",", "."), a2 = max2.ToString().Replace(",", ".");
                string v1 = avg1.ToString().Replace(",", "."), v2 = avg2.ToString().Replace(",", "."), v3 = avgGlobal.ToString().Replace(",", ".");
                string s1 = sum1.ToString().Replace(",", "."), s2 = sum2.ToString().Replace(",", "."), s3 = (sum1 + sum2).ToString().Replace(",", ".");

                Write("\n\n\t\t\tBenchmark finished");
                Write($"\n\t\tSTANDART   - {iterationsPerAttempt / 1_000_000}m operations   interval: {i1}-{a1}, average: {v1}");
                Write($"\n\t\tFASTSEC    - {iterationsPerAttempt / 1_000_000}m operations   interval: {i2}-{a2}, average: {v2}");
                Write($"\n\t\tGLOBAL     - {iterationsPerAttempt / 1_000_000}m operations   interval: ");

                if (isFirst1) Write($"{i1}-");
                else Write($"{i2}-");
                if (isFirst2) Write($"{a1}, average: {v3}");
                else Write($"{a2}, average: {v3}");

                Write("\n\n\n\t\t\tTotal time elapsed for");
                Write($"\n\t\tSTANDART   - {totalAttempts * iterationsPerAttempt / 1_000_000_000}b operations: {s1}");
                Write($"\n\t\tFASTSEC    - {totalAttempts * iterationsPerAttempt / 1_000_000_000}b operations: {s2}");
                Write($"\n\t\tGLOBAL     - {totalAttempts * iterationsPerAttempt / 1_000_000_000}b operations: {s3}");

                Write("\n\n\n\n\t\t\t\tDone! Press any key to start SecureRandom benchmark ");
                ReadKey();
            }





            for (var hide = 0; hide < 1; hide++)
            {
                List<Int64> ms1 = [], ms2 = [];
                const Int32 totalAttempts = 10, iterationsPerAttempt = 100_000;
                Write($"\n\n\n\t\t[i]  - Starting benchmark of {totalAttempts * iterationsPerAttempt / 1_000_000}m rng Byte");

                for (var attempt = 0; attempt < totalAttempts; attempt++)
                {
                    if (attempt % 2 == 0)
                    {
                        Write("\n\t\t\tSTDSEC     - ");
                        timer.Start();
                        for (var i = 0; i < iterationsPerAttempt; i++) test.NextByte();

                        timer.Stop();
                        ms1.Add(timer.ElapsedMilliseconds);
                    }
                    else
                    {
                        Write("\n\t\t\tSECURE     - ");
                        timer.Start();
                        for (var i = 0; i < iterationsPerAttempt; i++) test.SecureNextByte();

                        timer.Stop();
                        ms2.Add(timer.ElapsedMilliseconds);
                    }

                    Write($"\tAttempt {attempt + 1})\t RNG     {iterationsPerAttempt / 1_000}k: {timer.ElapsedMilliseconds / 1000}.{timer.ElapsedMilliseconds % 1000}");
                    timer.Reset();
                }

                double min1 = (double)ms1.Min() / 1000, max1 = (double)ms1.Max() / 1000;
                double min2 = (double)ms2.Min() / 1000, max2 = (double)ms2.Max() / 1000;
                double sum1 = (double)ms1.Sum() / 1000, sum2 = (double)ms2.Sum() / 1000;
                double avg1 = ms1.Average() / 1000, avg2 = ms2.Average() / 1000, avgGlobal = (avg1 + avg2) / 2;

                bool isFirst1 = min1 < min2, isFirst2 = max1 > max2;

                string i1 = min1.ToString().Replace(",", "."), a1 = max1.ToString().Replace(",", ".");
                string i2 = min2.ToString().Replace(",", "."), a2 = max2.ToString().Replace(",", ".");
                string v1 = avg1.ToString().Replace(",", "."), v2 = avg2.ToString().Replace(",", "."), v3 = avgGlobal.ToString().Replace(",", ".");
                string s1 = sum1.ToString().Replace(",", "."), s2 = sum2.ToString().Replace(",", "."), s3 = (sum1 + sum2).ToString().Replace(",", ".");

                Write("\n\n\t\t\tBenchmark finished");
                Write($"\n\t\tSTDSEC     - {iterationsPerAttempt / 1_000}k operations   interval: {i1}-{a1}, average: {v1}");
                Write($"\n\t\tSECURE     - {iterationsPerAttempt / 1_000}k operations   interval: {i2}-{a2}, average: {v2}");
                Write($"\n\t\tGLOBAL     - {iterationsPerAttempt / 1_000}k operations   interval: ");

                if (isFirst1) Write($"{i1}-");
                else Write($"{i2}-");
                if (isFirst2) Write($"{a1}, average: {v3}");
                else Write($"{a2}, average: {v3}");

                Write("\n\n\n\t\t\tTotal time elapsed for");
                Write($"\n\t\tSTDSEC     - {totalAttempts * iterationsPerAttempt / 1_000_000}m operations: {s1}");
                Write($"\n\t\tSECURE     - {totalAttempts * iterationsPerAttempt / 1_000_000}m operations: {s2}");
                Write($"\n\t\tGLOBAL     - {totalAttempts * iterationsPerAttempt / 1_000_000}m operations: {s3}");

                Write("\n\n\n\n\t\t\t\tDone! ");
                ReadKey();
            }





            for (var hide = 0; hide < 1; hide++)
            {
                List<Int64> ms1 = [], ms2 = [];
                const Int32 totalAttempts = 10, iterationsPerAttempt = 100_000;
                Write($"\n\n\n\t\t[i]  - Starting benchmark of {totalAttempts * iterationsPerAttempt / 1_000_000}m rng Int32");

                for (var attempt = 0; attempt < totalAttempts; attempt++)
                {
                    if (attempt % 2 == 0)
                    {
                        Write("\n\t\t\tSTDSEC     - ");
                        timer.Start();
                        for (var i = 0; i < iterationsPerAttempt; i++) test.Next();

                        timer.Stop();
                        ms1.Add(timer.ElapsedMilliseconds);
                    }
                    else
                    {
                        Write("\n\t\t\tSECURE     - ");
                        timer.Start();
                        for (var i = 0; i < iterationsPerAttempt; i++) test.SecureNext();

                        timer.Stop();
                        ms2.Add(timer.ElapsedMilliseconds);
                    }

                    Write($"\tAttempt {attempt + 1})\t RNG     {iterationsPerAttempt / 1_000}k: {timer.ElapsedMilliseconds / 1000}.{timer.ElapsedMilliseconds % 1000}");
                    timer.Reset();
                }

                double min1 = (double)ms1.Min() / 1000, max1 = (double)ms1.Max() / 1000;
                double min2 = (double)ms2.Min() / 1000, max2 = (double)ms2.Max() / 1000;
                double sum1 = (double)ms1.Sum() / 1000, sum2 = (double)ms2.Sum() / 1000;
                double avg1 = ms1.Average() / 1000, avg2 = ms2.Average() / 1000, avgGlobal = (avg1 + avg2) / 2;

                bool isFirst1 = min1 < min2, isFirst2 = max1 > max2;

                string i1 = min1.ToString().Replace(",", "."), a1 = max1.ToString().Replace(",", ".");
                string i2 = min2.ToString().Replace(",", "."), a2 = max2.ToString().Replace(",", ".");
                string v1 = avg1.ToString().Replace(",", "."), v2 = avg2.ToString().Replace(",", "."), v3 = avgGlobal.ToString().Replace(",", ".");
                string s1 = sum1.ToString().Replace(",", "."), s2 = sum2.ToString().Replace(",", "."), s3 = (sum1 + sum2).ToString().Replace(",", ".");

                Write("\n\n\t\t\tBenchmark finished");
                Write($"\n\t\tSTDSEC     - {iterationsPerAttempt / 1_000}k operations   interval: {i1}-{a1}, average: {v1}");
                Write($"\n\t\tSECURE     - {iterationsPerAttempt / 1_000}k operations   interval: {i2}-{a2}, average: {v2}");
                Write($"\n\t\tGLOBAL     - {iterationsPerAttempt / 1_000}k operations   interval: ");

                if (isFirst1) Write($"{i1}-");
                else Write($"{i2}-");
                if (isFirst2) Write($"{a1}, average: {v3}");
                else Write($"{a2}, average: {v3}");

                Write("\n\n\n\t\t\tTotal time elapsed for");
                Write($"\n\t\tSTDSEC     - {totalAttempts * iterationsPerAttempt / 1_000_000}m operations: {s1}");
                Write($"\n\t\tSECURE     - {totalAttempts * iterationsPerAttempt / 1_000_000}m operations: {s2}");
                Write($"\n\t\tGLOBAL     - {totalAttempts * iterationsPerAttempt / 1_000_000}m operations: {s3}");

                Write("\n\n\n\n\t\t\t\tDone! ");
                ReadKey();
            }
        }
    }
}