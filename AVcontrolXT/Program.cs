using System;
using System.Diagnostics;

using System.Linq;
using System.Collections.Generic;

using static System.Console;
using System.Numerics;



namespace AVcontrol.XT
{
    internal class Program
    {
        static void Main()
        {
            Span<Byte> a = [1, 2, 3, 4, 0, 0];
            Utils.ReverseInPlace(a);
            foreach (Byte gg in a) Write($"{gg} ");
            Write("\n");


            Span<Int32> b = [-1, 2, 3, -4, -0, 0000];
            Utils.ReverseInPlace(b);
            foreach (Int32 gg in b) Write($"{gg} ");
            Write("\n");



            Span<Int64> c = [];
            Utils.ReverseInPlace(c);
            foreach (Int64 gg in c) Write($"{gg} ");
            Write("\n");



            Span<UInt128> d = [1111111, 2222222222222222];
            Utils.ReverseInPlace(d);
            foreach (UInt128 gg in d) Write($"{gg} ");
            Write("\n");
            ReadKey();





            Stopwatch timer = new();

            //#region BENCHMARK 1
            //UInt64 offsetFromUser = UInt64.Parse(ReadLine()!);
            //List<Int64> ms1 = [], ms2 = [], ms3 =[], ms4 = [];
            //const Int64 totalAttempts = 20, iterationsPerAttempt = 10_000_000;
            //Write($"\n\n\n\t\t[i]  - Starting benchmark of {totalAttempts * iterationsPerAttempt / 1_000_000}m Numsys conversions");

            //for (var attempt = 0; attempt < totalAttempts; attempt++)
            //{
            //    UInt64 abobaakodajfp = (UInt64)attempt + 9109591237 + offsetFromUser;
            //    string number = abobaakodajfp.ToString();


            //    if (attempt % 4 == 0)
            //    {
            //        Write("\n\t\t\t64  bit   - ");
            //        timer.Start();
            //        for (var i = 0; i < iterationsPerAttempt; i++) Numsys.ToDecimal64(number, 32);

            //        timer.Stop();
            //        ms1.Add(timer.ElapsedMilliseconds);


            //        if (Numsys.ToDecimal64(number, 32).ToString() != Numsys.ToDecimal128(number, 32).ToString())
            //        {
            //            Write($"\n\t\t\tMISMATCH (out of range): 64-128" +
            //                $"\n\t64:  {Numsys.ToDecimal64(number, 32)}" +
            //                $"\n\t128: {Numsys.ToDecimal128(number, 32)}\n\n");
            //        }
            //    }
            //    else if (attempt % 4 == 1)
            //    {
            //        Write("\n\t\t\t128 bit   - ");
            //        timer.Start();
            //        for (var i = 0; i < iterationsPerAttempt; i++) Numsys.ToDecimal128(number, 32);

            //        timer.Stop();
            //        ms2.Add(timer.ElapsedMilliseconds);


            //        if (Numsys.ToDecimal128(number, 32).ToString() != Numsys.ToDecimal256(number, 32).ToString())
            //        {
            //            Write($"\n\t\t\tMISMATCH (out of range): 128-256:" +
            //                $"\n\t128: {Numsys.ToDecimal128(number, 32)}" +
            //                $"\n\t256: {Numsys.ToDecimal256(number, 32)}\n\n");
            //        }
            //    }
            //    else if (attempt % 4 == 2)
            //    {
            //        Write("\n\t\t\t256 bit   - ");
            //        timer.Start();
            //        for (var i = 0; i < iterationsPerAttempt; i++) Numsys.ToDecimal256(number, 32);

            //        timer.Stop();
            //        ms3.Add(timer.ElapsedMilliseconds);


            //        if (Numsys.ToDecimal256(number, 32).ToString() != Numsys.ToDecimalBigInteger(number, 32).ToString())
            //        {
            //            Write($"\n\t\t\tMISMATCH (out of range): 256-BigInteger:" +
            //                $"\n\t256: {Numsys.ToDecimal256(number, 32)}" +
            //                $"\n\tBig: {Numsys.ToDecimalBigInteger(number, 32)}\n\n");
            //        }
            //    }
            //    else
            //    {
            //        Write("\n\t\t\tBigINT    - ");
            //        timer.Start();
            //        for (var i = 0; i < iterationsPerAttempt; i++) Numsys.ToDecimalBigInteger(number, 32);

            //        timer.Stop();
            //        ms4.Add(timer.ElapsedMilliseconds);
            //    }




            //    string elapsed = ((double)timer.ElapsedMilliseconds / 1000).ToString().Replace(",", ".");
            //    Write($"\tAttempt {attempt + 1})\t RNG     {iterationsPerAttempt / 1_000_000}m: {elapsed}");
            //    timer.Reset();

            //    if (attempt % 4 == 3) Write('\n');
            //}

            //double min1 = (double)ms1.Min() / 1000, max1 = (double)ms1.Max() / 1000;
            //double min2 = (double)ms2.Min() / 1000, max2 = (double)ms2.Max() / 1000;
            //double min3 = (double)ms3.Min() / 1000, max3 = (double)ms3.Max() / 1000;
            //double min4 = (double)ms4.Min() / 1000, max4 = (double)ms4.Max() / 1000;
            //double minG = Math.Min(Math.Min(min1, min2), Math.Min(min3, min4)), maxG = Math.Max(Math.Max(max1, max2), Math.Max(max3, max4));

            //double sum1 = (double)ms1.Sum() / 1000, sum2 = (double)ms2.Sum() / 1000;
            //double sum3 = (double)ms3.Sum() / 1000, sum4 = (double)ms4.Sum() / 1000;

            //double avg1 = ms1.Average() / 1000, avg2 = ms2.Average() / 1000;
            //double avg3 = ms3.Average() / 1000, avg4 = ms4.Average() / 1000;
            //double avgGlobal = (avg1 + avg2 + avg3 + avg4) / 4;

            //string i1 = min1.ToString().Replace(",", "."), a1 = max1.ToString().Replace(",", ".");
            //string i2 = min2.ToString().Replace(",", "."), a2 = max2.ToString().Replace(",", ".");
            //string i3 = min3.ToString().Replace(",", "."), a3 = max3.ToString().Replace(",", ".");
            //string i4 = min4.ToString().Replace(",", "."), a4 = max4.ToString().Replace(",", ".");
            //string iG = minG.ToString().Replace(",", "."), aG = maxG.ToString().Replace(",", ".");

            //string v1 = avg1.ToString().Replace(",", "."), v2 = avg2.ToString().Replace(",", ".");
            //string v3 = avg3.ToString().Replace(",", "."), v4 = avg4.ToString().Replace(",", ".");
            //string vGlobal = avgGlobal.ToString().Replace(",", ".");

            //string s1 = sum1.ToString().Replace(",", "."), s2 = sum2.ToString().Replace(",", ".");
            //string s3 = sum3.ToString().Replace(",", "."), s4 = sum4.ToString().Replace(",", ".");
            //string sGlobal = (sum1 + sum2 + sum3 + sum4).ToString().Replace(",", ".");

            //Write("\n\n\t\t\tBenchmark finished");
            //Write($"\n\t\t64  bit    - {iterationsPerAttempt / 1_000_000}m operations   interval: {i1}-{a1}, average: {v1}");
            //Write($"\n\t\t128 bit    - {iterationsPerAttempt / 1_000_000}m operations   interval: {i2}-{a2}, average: {v2}");
            //Write($"\n\t\t256 bit    - {iterationsPerAttempt / 1_000_000}m operations   interval: {i3}-{a3}, average: {v3}");
            //Write($"\n\t\tBigINT     - {iterationsPerAttempt / 1_000_000}m operations   interval: {i4}-{a4}, average: {v4}");
            //Write($"\n\t\tGLOBAL     - {iterationsPerAttempt / 1_000_000}m operations   interval: ");

            //Write($"{iG}-{aG}, average: {vGlobal}");

            //Write("\n\n\n\t\t\tTotal time elapsed for");
            //Write($"\n\t\t64  bit    - {totalAttempts * iterationsPerAttempt / 1_000_000}m operations: {s1}\t[{(Int32)(sum1 / (sum1 + sum2 + sum3 + sum4) * 100)} %]");
            //Write($"\n\t\t128 bit    - {totalAttempts * iterationsPerAttempt / 1_000_000}m operations: {s2}\t[{(Int32)(sum2 / (sum1 + sum2 + sum3 + sum4) * 100)} %]");
            //Write($"\n\t\t256 bit    - {totalAttempts * iterationsPerAttempt / 1_000_000}m operations: {s3}\t[{(Int32)(sum3 / (sum1 + sum2 + sum3 + sum4) * 100)} %]");
            //Write($"\n\t\tBigINT     - {totalAttempts * iterationsPerAttempt / 1_000_000}m operations: {s4}\t[{(Int32)(sum4 / (sum1 + sum2 + sum3 + sum4) * 100)} %]");
            //Write($"\n\t\tGLOBAL     - {totalAttempts * iterationsPerAttempt / 1_000_000}m operations: {sGlobal}");

            //Write("\n\n\n\n\t\t\t\tDone! Press any key to start SecureRandom benchmark ");
            //ReadKey();
            //#endregion





            //for (var hide = 0; hide < 1; hide++)
            //{
            //    List<Int64> ms1 = [], ms2 = [];
            //    const Int32 totalAttempts = 10, iterationsPerAttempt = 100_000;
            //    Write($"\n\n\n\t\t[i]  - Starting benchmark of {totalAttempts * iterationsPerAttempt / 1_000_000}m rng Byte");

            //    for (var attempt = 0; attempt < totalAttempts; attempt++)
            //    {
            //        if (attempt % 2 == 0)
            //        {
            //            Write("\n\t\t\tSTDSEC     - ");
            //            timer.Start();
            //            for (var i = 0; i < iterationsPerAttempt; i++) test.Next<Byte>();

            //            timer.Stop();
            //            ms1.Add(timer.ElapsedMilliseconds);
            //        }
            //        else
            //        {
            //            Write("\n\t\t\tSECURE     - ");
            //            timer.Start();
            //            for (var i = 0; i < iterationsPerAttempt; i++) test.SecureNext<Byte>();

            //            timer.Stop();
            //            ms2.Add(timer.ElapsedMilliseconds);
            //        }

            //        string elapsed = ((double)timer.ElapsedMilliseconds / 1000).ToString().Replace(",", ".");
            //        Write($"\tAttempt {attempt + 1})\t RNG     {iterationsPerAttempt / 1_000}k: {elapsed}");
            //        timer.Reset();
            //    }

            //    double min1 = (double)ms1.Min() / 1000, max1 = (double)ms1.Max() / 1000;
            //    double min2 = (double)ms2.Min() / 1000, max2 = (double)ms2.Max() / 1000;
            //    double sum1 = (double)ms1.Sum() / 1000, sum2 = (double)ms2.Sum() / 1000;
            //    double avg1 = ms1.Average() / 1000, avg2 = ms2.Average() / 1000, avgGlobal = (avg1 + avg2) / 2;

            //    bool isFirst1 = min1 < min2, isFirst2 = max1 > max2;

            //    string i1 = min1.ToString().Replace(",", "."), a1 = max1.ToString().Replace(",", ".");
            //    string i2 = min2.ToString().Replace(",", "."), a2 = max2.ToString().Replace(",", ".");
            //    string v1 = avg1.ToString().Replace(",", "."), v2 = avg2.ToString().Replace(",", "."), v3 = avgGlobal.ToString().Replace(",", ".");
            //    string s1 = sum1.ToString().Replace(",", "."), s2 = sum2.ToString().Replace(",", "."), s3 = (sum1 + sum2).ToString().Replace(",", ".");

            //    Write("\n\n\t\t\tBenchmark finished");
            //    Write($"\n\t\tSTDSEC     - {iterationsPerAttempt / 1_000}k operations   interval: {i1}-{a1}, average: {v1}");
            //    Write($"\n\t\tSECURE     - {iterationsPerAttempt / 1_000}k operations   interval: {i2}-{a2}, average: {v2}");
            //    Write($"\n\t\tGLOBAL     - {iterationsPerAttempt / 1_000}k operations   interval: ");

            //    if (isFirst1) Write($"{i1}-");
            //    else Write($"{i2}-");
            //    if (isFirst2) Write($"{a1}, average: {v3}");
            //    else Write($"{a2}, average: {v3}");

            //    Write("\n\n\n\t\t\tTotal time elapsed for");
            //    Write($"\n\t\tSTDSEC     - {totalAttempts * iterationsPerAttempt / 1_000_000}m operations: {s1}\t[{(Int32)(sum1 / (sum1 + sum2) * 100)} %]");
            //    Write($"\n\t\tSECURE     - {totalAttempts * iterationsPerAttempt / 1_000_000}m operations: {s2}\t[{(Int32)(sum2 / (sum1 + sum2) * 100)} %]");
            //    Write($"\n\t\tGLOBAL     - {totalAttempts * iterationsPerAttempt / 1_000_000}m operations: {s3}");

            //    Write("\n\n\n\n\t\t\t\tDone! ");
            //    ReadKey();
            //}





            //for (var hide = 0; hide < 1; hide++)
            //{
            //    List<Int64> ms1 = [], ms2 = [];
            //    const Int32 totalAttempts = 10, iterationsPerAttempt = 100_000;
            //    Write($"\n\n\n\t\t[i]  - Starting benchmark of {totalAttempts * iterationsPerAttempt / 1_000_000}m rng Int32");

            //    for (var attempt = 0; attempt < totalAttempts; attempt++)
            //    {
            //        if (attempt % 2 == 0)
            //        {
            //            Write("\n\t\t\tSTDSEC     - ");
            //            timer.Start();
            //            for (var i = 0; i < iterationsPerAttempt; i++) test.Next();

            //            timer.Stop();
            //            ms1.Add(timer.ElapsedMilliseconds);
            //        }
            //        else
            //        {
            //            Write("\n\t\t\tSECURE     - ");
            //            timer.Start();
            //            for (var i = 0; i < iterationsPerAttempt; i++) test.SecureNext();

            //            timer.Stop();
            //            ms2.Add(timer.ElapsedMilliseconds);
            //        }

            //        string elapsed = ((double)timer.ElapsedMilliseconds / 1000).ToString().Replace(",", ".");
            //        Write($"\tAttempt {attempt + 1})\t RNG     {iterationsPerAttempt / 1_000}k: {elapsed}");
            //        timer.Reset();
            //    }

            //    double min1 = (double)ms1.Min() / 1000, max1 = (double)ms1.Max() / 1000;
            //    double min2 = (double)ms2.Min() / 1000, max2 = (double)ms2.Max() / 1000;
            //    double sum1 = (double)ms1.Sum() / 1000, sum2 = (double)ms2.Sum() / 1000;
            //    double avg1 = ms1.Average() / 1000, avg2 = ms2.Average() / 1000, avgGlobal = (avg1 + avg2) / 2;

            //    bool isFirst1 = min1 < min2, isFirst2 = max1 > max2;

            //    string i1 = min1.ToString().Replace(",", "."), a1 = max1.ToString().Replace(",", ".");
            //    string i2 = min2.ToString().Replace(",", "."), a2 = max2.ToString().Replace(",", ".");
            //    string v1 = avg1.ToString().Replace(",", "."), v2 = avg2.ToString().Replace(",", "."), v3 = avgGlobal.ToString().Replace(",", ".");
            //    string s1 = sum1.ToString().Replace(",", "."), s2 = sum2.ToString().Replace(",", "."), s3 = (sum1 + sum2).ToString().Replace(",", ".");

            //    Write("\n\n\t\t\tBenchmark finished");
            //    Write($"\n\t\tSTDSEC     - {iterationsPerAttempt / 1_000}k operations   interval: {i1}-{a1}, average: {v1}");
            //    Write($"\n\t\tSECURE     - {iterationsPerAttempt / 1_000}k operations   interval: {i2}-{a2}, average: {v2}");
            //    Write($"\n\t\tGLOBAL     - {iterationsPerAttempt / 1_000}k operations   interval: ");

            //    if (isFirst1) Write($"{i1}-");
            //    else Write($"{i2}-");
            //    if (isFirst2) Write($"{a1}, average: {v3}");
            //    else Write($"{a2}, average: {v3}");

            //    Write("\n\n\n\t\t\tTotal time elapsed for");
            //    Write($"\n\t\tSTDSEC     - {totalAttempts * iterationsPerAttempt / 1_000_000}m operations: {s1}\t[{(Int32)(sum1 / (sum1 + sum2) * 100)} %]");
            //    Write($"\n\t\tSECURE     - {totalAttempts * iterationsPerAttempt / 1_000_000}m operations: {s2}\t[{(Int32)(sum2 / (sum1 + sum2) * 100)} %]");
            //    Write($"\n\t\tGLOBAL     - {totalAttempts * iterationsPerAttempt / 1_000_000}m operations: {s3}");

            //    Write("\n\n\n\n\t\t\t\tDone! ");
            //    ReadKey();
            //}
        }
    }
}