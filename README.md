# AVcontrol - C# library for some additional operations on variables

# All functionality (v1.9.1):
- Numsys (short for numeric systems) - for Conversions of numbers from one ns to another, supports:
     - Auto<output Type here> (uses Fast versions if possible)
     - Fast conversions (only) for bases 2, 8, 10, 16 
     - funcs supporting custom digits for conversions
     - Support for direct number conversions
     - extending output to a minimal length
     - low base conversions (for bases less or equal to 10)
- Conversions, for:
     - Conversions of Lists of different sized integers (supports BigEndian, LittleEndian)
     - Bytes lists to Int16/UInt16 conversions (supports BigEndian, LittleEndian, fast unsafe version, and last element filling to 0
- Intervals, for:
     - Intervals for strings, arrays and list
     - With startId and endId parameters for a more intuitive usage
     - Based on standart Linq functionality (though you are still absolutely free to use the standart C# implemetations)
- ToBinary, for:
     - Converting 16, 32 and 64 bit numbers (supports BigEndian, LittleEndian)
     - Converting text (strings) to binary (bytes), supports: ASCII, UTF-8, UTF-16, BigEndian UTF-16, UTF-32
     - Converting Lists of 16, 32 and 64 bit numbers (supports BigEndian, LittleEndian)
- FromBinary, for:
     - Converting text (strings) to binary (bytes), supports: ASCII, UTF-8, UTF-16, BigEndian UTF-16, UTF-32
     - Converting Byte arrays into List<Int16>, supports BigEndian, LittleEndian
     - For text conversion use the standart BitConverter as of now

# Most stable versions
- **[AVcontrol v1.9.1](https://github.com/Gyroscopic-why/AVcontrol/releases/tag/v1.9.1)**
- **[AVcontrol v1.8.2](https://github.com/Gyroscopic-why/AVcontrol/releases/tag/v1.8.2)**
- **[AVcontrol v1.7](https://github.com/Gyroscopic-why/AVcontrol/releases/tag/v1.7)**
- [AVcontrol v1.4.1](https://github.com/Gyroscopic-why/AVcontrol/releases/tag/v1.4.1)



# Changes

## v1.9.1 Changes
- **Added more Conversions. methods**
- removed old ones because the new makes them obsolete and inconvenient

- **Fixed Numsys. AsBinary overflows that had weird bugs with custom digits**
- **Fixed Numsys. AsBinary overflows (custom digits and output extending) having wrong extender digits**

- Moved some old Conversions. functions to FromBinary. since that is the proper place for them to be



## v1.9 Changes
- **Added Conversions for Lists of different sized integers**
- **Added ToBinary for Lists of different sized integers**
- (in beta) Added Numsys AsBinary variants
- small bugfixes
- lots of optimisation and old code refactoring



## v1.8.2 Changes
- **Fixed bug with default "0" filling when using custom digits in some fuction in Numsys:**



## v1.8.1 Changes
**Added more variety to conversions with custom digits:**
- FromCustom (string)
- ToCustom (string)

**Also renamed old functions for better understanding:**
- AsType > FromCustomAsType (Int32[], List)
- AsString > CustomAsString (string)



## v1.8 Changes
- **Entire Numsys. class (still in testing)**
Includes
- Auto<T> functions
- Filtered Fast variants for bases 2, 4, 8, 10, 16
- Custom variants for different bases (not 2, 4, 8, 10 or 16)
