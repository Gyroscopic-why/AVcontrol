using System;



namespace AVcontrol
{
    static public partial class Utils
    {
        static public bool IsPrime(Int32 number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            Int32 boundary = (Int32)Math.Floor(Math.Sqrt(number));
            for (Int32 i = 3; i <= boundary; i += 2) if (number % i == 0) return false;
            return true;
        }



        static public Int32 DigitCount(Int32 num)
        {
            if (num == Int32.MinValue ||
                num == Int32.MaxValue  ) return 10;

            UInt32 n = (UInt32)(num < 0 ? -num : num);

            if (n <            10U) return 1;
            if (n <           100U) return 2;
            if (n <         1_000U) return 3;
            if (n <        10_000U) return 4;
            if (n <       100_000U) return 5;
            if (n <     1_000_000U) return 6;
            if (n <    10_000_000U) return 7;
            if (n <   100_000_000U) return 8;
            if (n < 1_000_000_000U) return 9;
            return 10;
        }
        static public Int32 DigitCount(Int64 num)
        {
            if (num == Int64.MinValue ||
                num == Int64.MaxValue  ) return 19;

            UInt64 n = (UInt64)(num < 0 ? -num : num);

            if (n <                        10UL) return 1;
            if (n <                       100UL) return 2;
            if (n <                     1_000UL) return 3;
            if (n <                    10_000UL) return 4;
            if (n <                   100_000UL) return 5;
            if (n <                 1_000_000UL) return 6;
            if (n <                10_000_000UL) return 7;
            if (n <               100_000_000UL) return 8;
            if (n <             1_000_000_000UL) return 9;
            if (n <            10_000_000_000UL) return 10;
            if (n <           100_000_000_000UL) return 11;
            if (n <         1_000_000_000_000UL) return 12;
            if (n <        10_000_000_000_000UL) return 13;
            if (n <       100_000_000_000_000UL) return 14;
            if (n <     1_000_000_000_000_000UL) return 15;
            if (n <    10_000_000_000_000_000UL) return 16;
            if (n <   100_000_000_000_000_000UL) return 17;
            if (n < 1_000_000_000_000_000_000UL) return 18;
            return 19;
        }
    }
}