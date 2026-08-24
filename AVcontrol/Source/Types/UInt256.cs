using System;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;



namespace AVcontrol
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct UInt256(ulong l0, ulong l1, ulong l2, ulong l3)
        : IComparable<UInt256>,
          IComparable,
          IEquatable<UInt256>,
          IFormattable
    {
        private readonly ulong _0 = l0, _1 = l1, _2 = l2, _3 = l3;

        static public readonly UInt256 Zero = default;
        static public readonly UInt256 One  = new(1, 0, 0, 0);
        static public readonly UInt256 MinValue = Zero;
        static public readonly UInt256 MaxValue = new(ulong.MaxValue, ulong.MaxValue, ulong.MaxValue, ulong.MaxValue);

        public UInt256(ulong low64) : this(low64, 0, 0, 0) { }

        // ------------------------------------------------------------------- Implicit widening
        static public implicit operator UInt256(byte   v) => new(v);
        static public implicit operator UInt256(ushort v) => new(v);
        static public implicit operator UInt256(uint   v) => new(v);
        static public implicit operator UInt256(ulong  v) => new(v);

        // ------------------------------------------------------------------- Explicit signed → unsigned
        static public explicit operator UInt256(sbyte v)
        {
            if (v < 0) throw new OverflowException();
            return new((ulong)v);
        }
        static public explicit operator UInt256(short v)
        {
            if (v < 0) throw new OverflowException();
            return new((ulong)v);
        }
        static public explicit operator UInt256(int v)
        {
            if (v < 0) throw new OverflowException();
            return new((ulong)v);
        }
        static public explicit operator UInt256(long v)
        {
            if (v < 0) throw new OverflowException();
            return new((ulong)v);
        }

        // ------------------------------------------------------------------- Explicit narrowing
        static public explicit operator byte(UInt256 v)
        {
            if (v._1 != 0 || v._2 != 0 || v._3 != 0 || v._0 > byte.MaxValue)
                throw new OverflowException();
            return (byte)v._0;
        }

        static public explicit operator ushort(UInt256 v)
        {
            if (v._1 != 0 || v._2 != 0 || v._3 != 0 || v._0 > ushort.MaxValue)
                throw new OverflowException();
            return (ushort)v._0;
        }

        static public explicit operator uint(UInt256 v)
        {
            if (v._1 != 0 || v._2 != 0 || v._3 != 0 || v._0 > uint.MaxValue)
                throw new OverflowException();
            return (uint)v._0;
        }

        static public explicit operator ulong(UInt256 v)
        {
            if (v._1 != 0 || v._2 != 0 || v._3 != 0)
                throw new OverflowException();
            return v._0;
        }



        static public explicit operator sbyte(UInt256 v)
        {
            if (v._1 != 0 || v._2 != 0 || v._3 != 0 || v._0 > (ulong)sbyte.MaxValue)
                throw new OverflowException();
            return (sbyte)v._0;
        }

        static public explicit operator short(UInt256 v)
        {
            if (v._1 != 0 || v._2 != 0 || v._3 != 0 || v._0 > (ulong)short.MaxValue)
                throw new OverflowException();
            return (short)v._0;
        }

        static public explicit operator int(UInt256 v)
        {
            if (v._1 != 0 || v._2 != 0 || v._3 != 0 || v._0 > int.MaxValue)
                throw new OverflowException();
            return (int)v._0;
        }

        static public explicit operator long(UInt256 v)
        {
            if (v._1 != 0 || v._2 != 0 || v._3 != 0 || v._0 > long.MaxValue)
                throw new OverflowException();
            return (long)v._0;
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte TruncateToByte() => (byte)_0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort TruncateToUInt16() => (ushort)_0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint TruncateToUInt32() => (uint)_0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong TruncateToUInt64() => _0;

        // Signed – treat the low bits as the target signed type
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte TruncateToSByte() => unchecked((sbyte)_0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short TruncateToInt16() => unchecked((short)_0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int TruncateToInt32() => unchecked((int)_0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long TruncateToInt64() => unchecked((long)_0);

        // ------------------------------------------------------------------- BigInteger interop
        static public explicit operator BigInteger(UInt256 v)
        {
            byte[] bytes = new byte[32];
            Unsafe.WriteUnaligned(ref bytes[0], v._0);
            Unsafe.WriteUnaligned(ref bytes[8], v._1);
            Unsafe.WriteUnaligned(ref bytes[16], v._2);
            Unsafe.WriteUnaligned(ref bytes[24], v._3);
            return new BigInteger(bytes, isUnsigned: true, isBigEndian: false);
        }

        static public explicit operator UInt256(BigInteger value)
        {
            if (value.Sign < 0) throw new OverflowException();
            byte[] bytes = value.ToByteArray(isUnsigned: true, isBigEndian: false);
            if (bytes.Length > 32) throw new OverflowException();

            Span<byte> span = stackalloc byte[32];
            span.Clear();
            bytes.CopyTo(span);

            return new UInt256
            (
                Unsafe.ReadUnaligned<ulong>(ref span[0]),
                Unsafe.ReadUnaligned<ulong>(ref span[8]),
                Unsafe.ReadUnaligned<ulong>(ref span[16]),
                Unsafe.ReadUnaligned<ulong>(ref span[24])
            );
        }

        // ------------------------------------------------------------------- Unchecked arithmetic
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static public UInt256 operator +(UInt256 a, UInt256 b) => Add(a, b, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static public UInt256 operator -(UInt256 a, UInt256 b) => Sub(a, b, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static public UInt256 operator *(UInt256 a, UInt256 b) => Mul(a, b, out _);

        static public UInt256 operator /(UInt256 dividend, UInt256 divisor)
        {
            if (divisor == Zero) throw new DivideByZeroException();
            if (dividend < divisor) return Zero;

            return (UInt256)((BigInteger)dividend / (BigInteger)divisor);
        }
        static public UInt256 operator %(UInt256 dividend, UInt256 divisor)
        {
            if (divisor == Zero) throw new DivideByZeroException();
            if (dividend < divisor) return dividend;

            return (UInt256)((BigInteger)dividend % (BigInteger)divisor);
        }
        

        // ------------------------------------------------------------------- Checked arithmetic
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static public UInt256 operator checked +(UInt256 a, UInt256 b)
        {
            var result = Add(a, b, out bool overflow);
            if (overflow) throw new OverflowException();
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static public UInt256 operator checked -(UInt256 a, UInt256 b)
        {
            var result = Sub(a, b, out bool overflow);
            if (overflow) throw new OverflowException();
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static public UInt256 operator checked *(UInt256 a, UInt256 b)
        {
            var result = Mul(a, b, out bool overflow);
            if (overflow) throw new OverflowException();
            return result;
        }

        // checked / and % are the same as unchecked for unsigned types
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static public UInt256 operator checked /(UInt256 a, UInt256 b) => a / b;

        // Increment / decrement
        static public UInt256 operator ++(UInt256 v) => v + One;
        static public UInt256 operator --(UInt256 v) => v - One;

        static public UInt256 operator checked ++(UInt256 v) => checked(v + One);
        static public UInt256 operator checked --(UInt256 v) => checked(v - One);

        // ------------------------------------------------------------------- Bitwise operators
        static public UInt256 operator &(UInt256 a, UInt256 b) =>
            new(a._0 & b._0, a._1 & b._1, a._2 & b._2, a._3 & b._3);

        static public UInt256 operator |(UInt256 a, UInt256 b) =>
            new(a._0 | b._0, a._1 | b._1, a._2 | b._2, a._3 | b._3);

        static public UInt256 operator ^(UInt256 a, UInt256 b) =>
            new(a._0 ^ b._0, a._1 ^ b._1, a._2 ^ b._2, a._3 ^ b._3);

        static public UInt256 operator ~(UInt256 a) =>
            new(~a._0, ~a._1, ~a._2, ~a._3);

        // ------------------------------------------------------------------- Shift operators
        static public UInt256 operator <<(UInt256 value, int shift)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(shift);
            if (shift == 0) return value;
            if (shift >= 256) return Zero;

            int t = shift >> 6;
            int s = shift & 63;

            ulong n0 = 0, n1 = 0, n2 = 0, n3 = 0;

            if (s == 0)
            {
                switch (t)
                {
                    case 0: n0 = value._0; n1 = value._1; n2 = value._2; n3 = value._3; break;
                    case 1: n1 = value._0; n2 = value._1; n3 = value._2; break;
                    case 2: n2 = value._0; n3 = value._1; break;
                    case 3: n3 = value._0; break;
                }
            }
            else
            {
                switch (t)
                {
                    case 0:
                        n0 = value._0 << s;
                        n1 = (value._1 << s) | (value._0 >> (64 - s));
                        n2 = (value._2 << s) | (value._1 >> (64 - s));
                        n3 = (value._3 << s) | (value._2 >> (64 - s));
                        break;
                    case 1:
                        n1 = value._0 << s;
                        n2 = (value._1 << s) | (value._0 >> (64 - s));
                        n3 = (value._2 << s) | (value._1 >> (64 - s));
                        break;
                    case 2:
                        n2 = value._0 << s;
                        n3 = (value._1 << s) | (value._0 >> (64 - s));
                        break;
                    case 3:
                        n3 = value._0 << s;
                        break;
                }
            }

            return new UInt256(n0, n1, n2, n3);
        }

        static public UInt256 operator >>(UInt256 value, int shift)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(shift);
            if (shift == 0) return value;
            if (shift >= 256) return Zero;

            int t = shift >> 6;
            int s = shift & 63;

            ulong n0 = 0, n1 = 0, n2 = 0, n3 = 0;

            if (s == 0)
            {
                switch (t)
                {
                    case 0: n0 = value._0; n1 = value._1; n2 = value._2; n3 = value._3; break;
                    case 1: n0 = value._1; n1 = value._2; n2 = value._3; break;
                    case 2: n0 = value._2; n1 = value._3; break;
                    case 3: n0 = value._3; break;
                }
            }
            else
            {
                switch (t)
                {
                    case 0:
                        n0 = (value._0 >> s) | (value._1 << (64 - s));
                        n1 = (value._1 >> s) | (value._2 << (64 - s));
                        n2 = (value._2 >> s) | (value._3 << (64 - s));
                        n3 = value._3 >> s;
                        break;
                    case 1:
                        n0 = (value._1 >> s) | (value._2 << (64 - s));
                        n1 = (value._2 >> s) | (value._3 << (64 - s));
                        n2 = value._3 >> s;
                        break;
                    case 2:
                        n0 = (value._2 >> s) | (value._3 << (64 - s));
                        n1 = value._3 >> s;
                        break;
                    case 3:
                        n0 = value._3 >> s;
                        break;
                }
            }

            return new UInt256(n0, n1, n2, n3);
        }


        // ------------------------------------------------------------------- Comparison operators
        static public bool operator ==(UInt256 a, UInt256 b) =>
            a._0 == b._0 && a._1 == b._1 && a._2 == b._2 && a._3 == b._3;

        static public bool operator !=(UInt256 a, UInt256 b) => !(a == b);

        static public bool operator <(UInt256 a, UInt256 b) => Compare(a, b) < 0;
        static public bool operator <=(UInt256 a, UInt256 b) => Compare(a, b) <= 0;
        static public bool operator >(UInt256 a, UInt256 b) => Compare(a, b) > 0;
        static public bool operator >=(UInt256 a, UInt256 b) => Compare(a, b) >= 0;

        // ------------------------------------------------------------------- Core arithmetic helpers
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt256 Add(UInt256 a, UInt256 b, out bool overflow)
        {
            ulong lo = a._0 + b._0;
            ulong carry = (lo < a._0) ? 1UL : 0;

            ulong mid1 = a._1 + b._1 + carry;
            carry = (mid1 < a._1 || (carry == 1 && mid1 == a._1)) ? 1UL : 0;

            ulong mid2 = a._2 + b._2 + carry;
            carry = (mid2 < a._2 || (carry == 1 && mid2 == a._2)) ? 1UL : 0;

            ulong hi = a._3 + b._3 + carry;
            overflow = (hi < a._3 || (carry == 1 && hi == a._3));

            return new UInt256(lo, mid1, mid2, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt256 Sub(UInt256 a, UInt256 b, out bool overflow)
        {
            ulong lo = a._0 - b._0;
            ulong borrow = (lo > a._0) ? 1UL : 0;

            ulong mid1 = a._1 - b._1 - borrow;
            borrow = (mid1 > a._1 || (borrow == 1 && mid1 == a._1)) ? 1UL : 0;

            ulong mid2 = a._2 - b._2 - borrow;
            borrow = (mid2 > a._2 || (borrow == 1 && mid2 == a._2)) ? 1UL : 0;

            ulong hi = a._3 - b._3 - borrow;
            overflow = (hi > a._3 || (borrow == 1 && hi == a._3));

            return new UInt256(lo, mid1, mid2, hi);
        }

        // Schoolbook multiplication: 256×256 → 512 bits, low 256 bits returned, overflow if any higher limb non‑zero
        private static UInt256 Mul(UInt256 a, UInt256 b, out bool overflow)
        {
            Span<ulong> limbs = stackalloc ulong[8];
            limbs.Clear();

            for (int i = 0; i < 4; i++)
            {
                ulong ai = GetLimb(a, i);
                if (ai == 0) continue;

                ulong carry = 0;
                for (int j = 0; j < 4; j++)
                {
                    ulong bj = GetLimb(b, j);
                    ulong high = Math.BigMul(ai, bj, out ulong low);

                    ulong currentLimb = limbs[i + j];

                    ulong sumLow = currentLimb + low;
                    ulong carryLow = (sumLow < currentLimb) ? 1UL : 0UL;

                    ulong finalSum = sumLow + carry;
                    ulong carryFinal = (finalSum < sumLow) ? 1UL : 0UL;

                    limbs[i + j] = finalSum;

                    carry = high + carryLow + carryFinal;
                }

                limbs[i + 4] = carry;
            }

            // overflow
            overflow = limbs[4] != 0 || limbs[5] != 0 || limbs[6] != 0 || limbs[7] != 0;

            return new UInt256(limbs[0], limbs[1], limbs[2], limbs[3]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong GetLimb(UInt256 v, int index) => index switch
        {
            0 => v._0,
            1 => v._1,
            2 => v._2,
            3 => v._3,
            _ => 0
        };

        // ------------------------------------------------------------------- Comparison
        private static int Compare(UInt256 a, UInt256 b)
        {
            if (a._3 != b._3) return a._3.CompareTo(b._3);
            if (a._2 != b._2) return a._2.CompareTo(b._2);
            if (a._1 != b._1) return a._1.CompareTo(b._1);
            return a._0.CompareTo(b._0);
        }

        // ------------------------------------------------------------------- ToString / Parse
        public override string ToString() => ToDecimalString();

        public string ToString(string? format, IFormatProvider? formatProvider = null)
        {
            if (string.IsNullOrEmpty(format)) format = "G";

            return format.ToUpperInvariant() switch
            {
                "G" or "D" => ToDecimalString(),
                "X" => ToHexString(true),
                "x" => ToHexString(false),
                _ => throw new FormatException($"Unsupported format string: {format}")
            };
        }

        private string ToDecimalString()
        {
            if (this == Zero) return "0";
            return ((BigInteger)this).ToString("D", CultureInfo.InvariantCulture);
        }

        private string ToHexString(bool uppercase)
        {
            Span<char> chars = stackalloc char[64];
            WriteHex(chars, _3, 0, uppercase);
            WriteHex(chars, _2, 16, uppercase);
            WriteHex(chars, _1, 32, uppercase);
            WriteHex(chars, _0, 48, uppercase);

            int start = 0;
            while (start < 63 && chars[start] == '0') start++;
            return chars[start..].ToString();
        }

        private static void WriteHex(Span<char> dest, ulong val, int offset, bool uppercase)
        {
            const string hexUpper = "0123456789ABCDEF";
            const string hexLower = "0123456789abcdef";
            string table = uppercase ? hexUpper : hexLower;
            for (int i = 15; i >= 0; i--)
            {
                dest[offset + i] = table[(int)(val & 0xF)];
                val >>= 4;
            }
        }

        static public UInt256 Parse(string s) => Parse(s, NumberStyles.Integer, null);

        static public UInt256 Parse(string s, NumberStyles style, IFormatProvider? provider)
        {
            if (!TryParse(s, style, provider, out var result))
                throw new FormatException("Input string was not in a correct format.");
            return result;
        }

        static public bool TryParse(string? s, out UInt256 result) =>
            TryParse(s, NumberStyles.Integer, null, out result);

        static public bool TryParse(string? s, NumberStyles style, IFormatProvider? provider, out UInt256 result)
        {
            result = Zero;
            if (string.IsNullOrWhiteSpace(s)) return false;

            s = s!.Trim();
            string str = s;
            if (str.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                str = str[2..];
            if (str.Length == 0) return false;

            bool isHex = (style & NumberStyles.AllowHexSpecifier) != 0 ||
                         s!.StartsWith("0x", StringComparison.OrdinalIgnoreCase);
            int fromBase = isHex ? 16 : 10;

            foreach (char c in str)
            {
                int digit = isHex ? HexDigit(c) : (c - '0');
                if (digit < 0 || digit >= fromBase) return false;

                UInt256 temp;
                try
                {
                    temp = checked(result * (uint)fromBase + (uint)digit);
                }
                catch (OverflowException)
                {
                    return false;
                }
                result = temp;
            }
            return true;
        }

        private static int HexDigit(char c) => c switch
        {
            >= '0' and <= '9' => c - '0',
            >= 'A' and <= 'F' => c - 'A' + 10,
            >= 'a' and <= 'f' => c - 'a' + 10,
            _ => -1
        };

        // ------------------------------------------------------------------- IEquatable, IComparable
        public bool Equals(UInt256 other) => this == other;
        public override bool Equals(object? obj) => obj is UInt256 other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(_0, _1, _2, _3);

        public int CompareTo(UInt256 other) => Compare(this, other);
        public int CompareTo(object? obj)
        {
            if (obj is null) return 1;
            if (obj is UInt256 other) return CompareTo(other);
            throw new ArgumentException("Object is not a UInt256");
        }
    }
}