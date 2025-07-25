# AVcontrol - C# library for some additional operations on variables

# All functionality:
- Numsys (short for numeric systems) - for Conversions of numbers from one ns to another, supports:
     - Auto<output Type here> (uses Fast versions if possible)
     - Fast conversions (only) for bases 2, 8, 10, 16 
     - funcs supporting custom digits for conversions
     - extending output to a minimal length
     - low base conversions (for bases less or equal to 10)
- Conversions, for:
     - Array to Lists and vise-versa conversion (supports intervals)
     - Bytes lists to Int16/UInt16 conversions (supports BigEndian, LittleEndian, fast unsafe version, and last element filling to 0
- Intervals, for:
     - Intervals for strings, arrays and list
     - With startId and endId parameters for a more intuitive usage
     - Based on standart Linq functionality (though you are still absolutely free to use the standart C# implemetations)
- ToBinary, for:
     - Converting 16, 32 and 64 bit numbers to binary (bytes), supports Big endian & Little endian
     - Converting text (strings) to binary (bytes), supports: ASCII, UTF-8, UTF-16, BigEndian UTF-16, UTF-32
- FromBinary, for:
     - Converting text (strings) to binary (bytes), supports: ASCII, UTF-8, UTF-16, BigEndian UTF-16, UTF-32
     - For text conversion use the standart BitConverter as of now
     

# v1.8.1 Changes
Changed confusing naming for function in Numsys.cs that has custom digits as an input
Also added more functions in Numsys for working with custom digits
