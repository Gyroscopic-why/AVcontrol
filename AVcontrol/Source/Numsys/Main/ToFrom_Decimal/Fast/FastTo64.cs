using System;
using System.Numerics;
using System.Collections.Generic;



namespace AVcontrol
{
    static public partial class Numsys
    {
        static public UInt64 FastToDecimalFromCustom64<TDigit, TAlphabet>(
            ReadOnlySpan<TDigit> oldValue,
            ReadOnlySpan<TAlphabet> reverseCustomDigits,
            Int32? oldBase = null)
                where TDigit : IBinaryInteger<TDigit>
                where TAlphabet : IBinaryInteger<TAlphabet>
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(reverseCustomDigits.Length, 2);
            UInt64 radixU = (UInt64)(oldBase ?? reverseCustomDigits.Length), result = 0;

            ArgumentOutOfRangeException.ThrowIfLessThan(radixU, 2u);
            Int32 maxIndex = reverseCustomDigits.Length - 1;

            foreach (TDigit rawDigit in oldValue)
            {
                Int32 index = Int32.CreateChecked(rawDigit);
                if ((UInt32)index > (UInt32)maxIndex)
                    throw new ArgumentOutOfRangeException
                    (
                        nameof(oldValue),
                        $"Digit {index} is out of the alphabet range 0..{maxIndex}."
                    );

                result = result * radixU + UInt64.CreateChecked(reverseCustomDigits[index]);
            }

            return result;
        }
        static public UInt64 FastToDecimalFromCustom64<TDigit, TAlphabet>(
            List<TDigit> oldValue,
            List<TAlphabet> reverseCustomDigits,
            Int32? oldBase = null)
            where TDigit : IBinaryInteger<TDigit>
            where TAlphabet : IBinaryInteger<TAlphabet>
            => FastToDecimalFromCustom64(
                   System.Runtime.InteropServices.CollectionsMarshal.AsSpan(oldValue),
                   System.Runtime.InteropServices.CollectionsMarshal.AsSpan(reverseCustomDigits),
                   oldBase);
    }
}