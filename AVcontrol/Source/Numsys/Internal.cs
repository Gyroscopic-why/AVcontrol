using System;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static private readonly string gDigits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";



        static private Int32 CharToDigit(char c)
        {
            if (c >= '0' && c <= '9') return c - '0';
            else if (c >= 'A' && c <= 'Z') return c - 'A' + 10;
            else if (c >= 'a' && c <= 'z') return c - 'a' + 10;
            else throw new ArgumentException($"Invalid character: {c}");
        }
        static private Int32 CharToDigit(char c, Int32 oldBase, string customDigits)
        {
            Int32 buffer = customDigits.IndexOf(c);
            if (buffer < 0) throw new ArgumentException($"Invalid character: {c} in custom digits.");
            else if (buffer >= oldBase) throw new ArgumentException($"Digit '{buffer}' is invalid for base {oldBase}.");

            return buffer;
        }



        static internal bool BaseArgumentCheck(Int32 oldBase, Int32 newBase, Int32 maxBaseLimit)
        {
            if (oldBase < 2 || oldBase > maxBaseLimit || newBase < 2 || newBase > maxBaseLimit)
                throw new ArgumentOutOfRangeException("Bases must be between 2 and " + maxBaseLimit + ".");

            if (oldBase == newBase) return false;
            return true;
        }
        static internal bool BaseArgumentCheck(Int32 oldBase, Int32 newBase)
            => BaseArgumentCheck(oldBase, newBase, 36);
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