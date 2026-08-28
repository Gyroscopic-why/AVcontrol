using System;



namespace AVcontrol.XT
{
    static public partial class Numsys
    {
        static private UInt256 CharToDigit256(char c)
        {
            if (c >= '0' && c <= '9') return (UInt256)(c - '0');
            else if (c >= 'A' && c <= 'Z') return (UInt256)(c - 'A' + 10);
            else if (c >= 'a' && c <= 'z') return (UInt256)(c - 'a' + 10);
            else throw new ArgumentException($"Invalid character: {c}");
        }
        static private UInt256 CharToDigit256(char c, Int32 oldBase, string customDigits)
        {
            UInt256 buffer = (UInt256)customDigits.IndexOf(c);
            if (buffer < 0) throw new ArgumentException($"Invalid character: {c} in custom digits.");
            else if (buffer >= (UInt256)oldBase) throw new ArgumentException($"Digit '{buffer}' is invalid for base {oldBase}.");

            return buffer;
        }
    }
}