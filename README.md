# AVcontrol - C# library for some additional operations on variables

# All functionality (v2.1.1):
- Numsys (short for numeric systems) - for Conversions of numbers from one ns to another, supports:
     - Auto<output Type here> (uses Fast versions if possible)
     - Fast conversions (only) for bases 2, 8, 10, 16 
     - funcs supporting custom digits for conversions
     - Support for direct number conversions
     - Support for binary variants of conversions (List<Byte> and List<Int16> (for more convinient operationwith Utf16 LittleEndian)
     - extending output to a minimal length
     - low base conversions (for bases less or equal to 10)
- Conversions, for:
     - Conversions of Lists of different sized integers (supports BigEndian, LittleEndian)
     - Bytes lists to Int16/UInt16 conversions (supports BigEndian, LittleEndian, fast unsafe version, and last element filling to 0
- Utils, for:
     - Getting Intervals for strings, arrays and list (startId, endId)
     - Reverse methods for string, Lists, arrays, and some other collection (To replace the standart C# Linq implemetation)
- ToBinary, for:
     - Converting 16, 32 and 64 bit numbers (supports BigEndian, LittleEndian)
     - Converting text (strings) to binary (bytes), supports: ASCII, UTF-8, UTF-16, BigEndian UTF-16, UTF-32
     - Converting Lists of 16, 32 and 64 bit numbers (supports BigEndian, LittleEndian)
- FromBinary, for:
     - Converting Byte arrays to any integer type, supports: BigEndian, LittleEndian
     - Converting Byte arrays into List<Int16>, supports BigEndian, LittleEndian


# Most stable versions
- **> [AVcontrol v2.1.1_____(26 kb)](https://github.com/Gyroscopic-why/AVcontrol/releases/tag/v2.1.1)**
- [AVcontrol v1.9.2________(40 kb)](https://github.com/Gyroscopic-why/AVcontrol/releases/tag/v1.9.2)
- **> [AVcontrol v1.8.2_____(25 kb)](https://github.com/Gyroscopic-why/AVcontrol/releases/tag/v1.8.2)**
- **> [AVcontrol v1.7_______(22 kb)](https://github.com/Gyroscopic-why/AVcontrol/releases/tag/v1.7)**
- [AVcontrol v1.4.1________(18 kb)](https://github.com/Gyroscopic-why/AVcontrol/releases/tag/v1.4.1)



# Changes

## v2.1.1 Changes
### Fixed Numsys. bugs:
- custom digit filling in .FromCustom() methods
(incorrect filling: customDigits[0] instead of "0" or gDigits[0])
- fixed incorrect Converts. in LowBase overloads
- removed LowBase overloads with custom digits since they are impossible to make
(and honestly, they are pointless since you can just do Convert.ToInt32( ?CustomAsString( .. ))

### Optimised Split. code amount by using the C# T operator



## v2.1 Changes
### Massive optimisation
- **Rewrote most of the functionality with the C# T operator**
- **Improved ToBinary & FromBinary performance by using pointer magic**
- Conversions typechanging instead of converting

### Bugfixes: Fixed .Reverse() issues, i hate the standart implementation so much

### Added Utils class
- **Added Better Reverse() methods**
- Removed Intervals class and moved the functions to Utils



## v2.0 Test changes
**Added new Numsys methods to Numsys:**
- LowBase with custom character support
- ToDecimal (not final)
- FromDecimal (not final)

- lots of bugfixes in Numsys
- optimised Numsys further

**Added new methods to Split**
- Splits a number to digets
- Supports BigEndian & LittleEndian
- Supports different number bases



## v1.9.2 Changes
- **Fixed all Numsys bugs assotiated with .Reverse() working improperly



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
