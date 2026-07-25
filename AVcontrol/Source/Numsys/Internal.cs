using System;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static private readonly string gDigits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";



        static private UInt64 CharToDigit64(char c)
        {
            if (c >= '0' && c <= '9') return (UInt64)(c - '0');
            else if (c >= 'A' && c <= 'Z') return (UInt64)(c - 'A' + 10);
            else if (c >= 'a' && c <= 'z') return (UInt64)(c - 'a' + 10);
            else throw new ArgumentException($"Invalid character: {c}");
        }
        static private UInt64 CharToDigit64(char c, Int32 oldBase, string customDigits)
        {
            UInt64 buffer = (UInt64)customDigits.IndexOf(c);
            if (buffer < 0) throw new ArgumentException($"Invalid character: {c} in custom digits.");
            else if (buffer >= (UInt64)oldBase) throw new ArgumentException($"Digit '{buffer}' is invalid for base {oldBase}.");

            return buffer;
        }
        static private UInt128 CharToDigit128(char c)
        {
            if (c >= '0' && c <= '9') return (UInt128)(c - '0');
            else if (c >= 'A' && c <= 'Z') return (UInt128)(c - 'A' + 10);
            else if (c >= 'a' && c <= 'z') return (UInt128)(c - 'a' + 10);
            else throw new ArgumentException($"Invalid character: {c}");
        }
        static private UInt128 CharToDigit128(char c, Int32 oldBase, string customDigits)
        {
            UInt128 buffer = (UInt128)customDigits.IndexOf(c);
            if (buffer < 0) throw new ArgumentException($"Invalid character: {c} in custom digits.");
            else if (buffer >= (UInt128)oldBase) throw new ArgumentException($"Digit '{buffer}' is invalid for base {oldBase}.");

            return buffer;
        }



        static internal bool BaseArgumentCheck(Int32 oldBase, Int32 newBase,
            Int32 maxOldBaseLimit, Int32 maxNewBaseLimit)
        {
            if (oldBase < 2 || oldBase > maxOldBaseLimit)
                throw new ArgumentOutOfRangeException
                (
                    nameof(oldBase),
                    $"old bases must be between 2 and {maxOldBaseLimit}"
                );
            else if (newBase < 2 || newBase > maxNewBaseLimit)
                throw new ArgumentOutOfRangeException
                (
                    nameof(newBase),
                    $"new base must be between 2 and {maxNewBaseLimit}"
                );

            return oldBase != newBase;
        }
        static internal bool BaseArgumentCheck(Int32 oldBase, Int32 newBase, Int32 maxBaseLimit)
            => BaseArgumentCheck(oldBase, newBase, maxBaseLimit, maxBaseLimit);
        static internal bool BaseArgumentCheck(Int32 oldBase, Int32 newBase)
            => BaseArgumentCheck(oldBase, newBase, 36, 36);
        static internal void BaseArgumentCheck(Int32 numbase)
        {
            if (numbase < 2 || numbase > 36)
                throw new ArgumentOutOfRangeException
                (
                    nameof(numbase),
                    "the number base must be between 2 and 36."
                );
        }
    }
}