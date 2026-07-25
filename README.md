# AVcontrol - C# library for common variable operations

&nbsp;  
#  Quick README navigation
### [Latest version functionality](https://github.com/Gyroscopic-why/AVcontrol#all-functionality-v271)
### [Most stable versions](https://github.com/Gyroscopic-why/AVcontrol#most-stable-versions)
### [Changelog](https://github.com/Gyroscopic-why/AVcontrol#changelog)

---

&nbsp;

# All functionality (v2.7.1):
- SecureRandom (alternative to C# Cryptography.RandomNumberGenerator)
     - **Does not rely on any dependencies, uses only hardware randomness => wont be compromised**
     - **(Wildcard) Funcs for generating: (S)Byte, (U)Int16, (U)Int32, (U)Int64**
     - **(Wildcard) Shuffling of Array\<T\>, List\<T\>, Span\<T\> and strings**
     - (Standard) Funcs for generating: UInt64, Int32, Byte[], double  
       _Supports reseeding, autoReseeding, and SecureNext for reseeding before generating_  
       _Accepts minValue and maxValue for generating limits_
     - _Supports changing the RESEED_AFTER_BYTES_GENERATED interval_
     - Is based on ChaCha20 algorithm
     - slower than standard C# implementation
- FastRandom (alternative to C# standard Random class)
     - **Does not rely on any dependencies, uses only hardware randomness => wont be compromised**
     - **(Wildcard) Funcs for generating: (S)Byte, (U)Int16, (U)Int32, (U)Int64**
     - **(Wildcard) Shuffling of Array\<T\>, List\<T\>, Span\<T\> and strings**
     - (Standard) Funcs for generating: UInt64, Byte[], double  
       _Accepts minValue and maxValue for generating limits_
     - Uses Xoshiro256++ algorithm
     - a bit slower than standard C# Random
- Numsys (short for numeric systems)  
_for Conversions of numbers from one numeric system to another, supports:_
     - **Auto\<output Type here\> (uses Fast versions if possible)**
     - **Funcs supporting custom digits for conversions**  
       _Support for binary variants of conversions with wildcard type output, example: List\<(any integer type)\>_
     - Fast conversions (only) for bases 2, 8, 10, 16 
       _Support for direct number conversions_
     - extending output to a minimal length
     - low base conversions (for bases less or equal to 10)
- Utils, for:
     - **Reverse methods for string, integer-types, Lists, arrays, spans and some other collection**
     (Replacement of the inconsistent standart C# Linq implemetation)
     - **Flag for checking if the number is prime**
     - Conversions of List elements integer-types, supports:  
       _Wildcard input type, wildcard output type (type selected from (S)Byte, (U)Int16, (U)Int32, (U)Int64)_
     - Getting Intervals for strings, arrays and list (startId, endId)
     - XOR operations on Arrays, Lists & \<T\> integers
     - Conversions of List elements integer-types
- Types (for custom types)
    - **Datetime4b for compact datetime storing:**
        - **Length per 1 DateTime4b instance: 4 bytes**
        - **Compatible with C# DateTime**
        - Precision: 1 minute
        - Starting date: 01.01.2025 (1 January 2025)
- ToBinary, for:
     - **Converting Lists, Arrays And Spans of 16, 32 and 64 bit numbers (supports BigEndian, LittleEndian)**
     - **Converting 16, 32 and 64 bit numbers (supports BigEndian, LittleEndian)**
     - Converting text (strings / Spans) to binary (bytes), supports: ASCII, UTF-8, UTF-16, BigEndian UTF-16, UTF-32
- FromBinary, for:
     - **Converting Byte Lists, Arrays And Spans to any integer type, supports: BigEndian, LittleEndian**
     - Converting text from binary (bytes) to strings, supports: ASCII, UTF-8, UTF-16, BigEndian UTF-16, UTF-32
     - .Unsanitized_\<Encoding here\> for unfinished string byte sequences
        (supports: ASCII, Utf8, Utf16, BigEndianUtf16, Utf32)
 - Split (& Combine), for:
     - **Splitting integers into lists of smaller chunks
       (and combining them back together)**
     - Input:  wildcard Type (  (S)Byte, (U)Int16, (U)Int32, (U)Int64  )
     - Output: wildcard Type (  (S)Byte, (U)Int16, (U)Int32, (U)Int64  )


&nbsp;  


# Most stable versions
- **>  [AVcontrol v2.7.1_______________(44 kb)](https://github.com/Gyroscopic-why/AVcontrol/releases/tag/v2.7.1) (Windows/Linux/MacOS - Core 10)**
- **>  [AVcontrol v2.6.1_______________(39 kb)](https://github.com/Gyroscopic-why/AVcontrol/releases/tag/v2.6.1) (Windows/Linux/MacOS - Core 10)**
-   [AVcontrol v2.6____________________(36 kb)](https://github.com/Gyroscopic-why/AVcontrol/releases/tag/v2.6) (Windows/Linux/MacOS - Core 10)
- **>  [AVcontrol v2.5.1_______________(33 kb)](https://github.com/Gyroscopic-why/AVcontrol/releases/tag/v2.5.1) (Windows/Linux/MacOS - Core 10)**
-   [AVcontrol v2.4____________________(35 kb)](https://github.com/Gyroscopic-why/AVcontrol/releases/tag/v2.4) (Windows/Linux/MacOS - Core 10)
- **>  [AVcontrol v2.2.2_______________(32 kb)](https://github.com/Gyroscopic-why/AVcontrol/releases/tag/v2.2.2) (Windows only)**
-   [AVcontrol v2.1.1__________________(26 kb)](https://github.com/Gyroscopic-why/AVcontrol/releases/tag/v2.1.1) (Windows only)
- **>  [AVcontrol v1.8.2_______________(25 kb)](https://github.com/Gyroscopic-why/AVcontrol/releases/tag/v1.8.2) (Windows only)**
-   [AVcontrol v1.7____________________(22 kb)](https://github.com/Gyroscopic-why/AVcontrol/releases/tag/v1.7) (Windows only)
##### Starting from v2.3.10 and higher, all versions will be cross platform build with the .NET Core 10 framework


&nbsp;  


# Changelog


## v2.7.1 Changes:
- Fixed incorrect reversing of FromBinary.BigEndian(ReadOnlySpan) overload
- Fixed ease of use for both Utils.ReverseVoid()



## v2.7 Changes:

#### FromBinary:
+ .Unsanitized_ (supports: ASCII, Utf8, Utf16, BigEndianUtf16, Utf32)

#### SecureRandom:
+ Changing RESEED_AFTER_BYTES_GENERATED interval
+ .NextDouble (w/ interval support)
+ .Shuffle(Array\<T\> / List\<T\> / Span\<T\> / string)

#### FastRandom:
+ .Shuffle(Array\<T\> / List\<T\> / Span\<T\> / string)

##### Full code rewrite and refactor of directories



## v2.6.1 Changes:
+ Added support for working with Spans/ReadOnlySpans in ToBinary. & FromBinary.
-  Optimised FastRandom. & SecureRandom. in edge cases where interval (max - min) <= 1
-  Fixed result '0' to custom type T conversion in FastRandom. & SecureRandom.



## v2.6 Changes:
+ Added DateTime4b class for storing datetime in 4 bytes
  (alternative to C# DateTime which is 8 bytes)
- Compatible with C# DateTime
- Precision: 1 minute
- Start date: 01.01.2025 (1 January 2025)



## v2.5.1 Changes:
+ Massive optimisation using dynamic types
+ Merged Conversions. functionality into -> Utils.



## v2.5 Changes:
- Fully revamped Numsys with:
     + Wildcard type for output
     + Proper binary encoding & decoding
     + Fixed AsList being inaccessible in any scenario in .Auto()
     + Optimised lambda functions
     + Optimised converters working with custom digits
- Utils:
     + Reverse() for wildcard Integer types
- Random (Fast & Secure):
     + Wildcard type for output
     + QoL parameters renaming
- Split:
     +Added duplicate variants for unsigned counter-parts
- Combine:
     LE integers lists
     BE integers lists
     (Wildcard type for input)


     
## v2.4 Changes
- **Small features to SecureRandom class:**
   + NextByte(minValue, maxValue)   (also added to FastRandom)
   + SecureNextByte(minValue, maxValue)
   (supports minValue & maxValue presetting for a precise interval)
- **Fixed incorrect FromBinary.BigEndian behaviour**



## v2.3.10 Changes
- Switch from .NET Core 8.0 to .NET Core 10.0 (for increased supprot and performance)
- Added NuGet package release (nupkg release)



## v2.3 Changes
- **Added XOR operations on Arrays, Lists & <T> integers to Utils.cs**
- Added text FromBinary.cs conversions



## v2.2.2 Changes
- **Added support for O(√n) IsPrimary() check to Utils.cs**



## v2.2.1 Changes
- **Added support for custom autoReseeding, and failsafe to the setter**
- Fix bugs



## v2.2 Changes
### Added 2 classes for rng:
* **SecureRandom: alternative to C# Security.Cryptography RandomNumberGenerator**
  - **more secure: cant be compromised, since it does not rely on external dependencies**
  - **has 2 generation types: standart and ultra secure (second refreshes seed before every generation)**
  - supports notcustom autoReseed
* FastRandom: alternative to C# Random()
  - a bit slower (about 50% on benchmarks)
  - more secure: cant be compromised, since it does not rely on external dependencies


          
## v2.1.1 Changes
### Fixed Numsys. bugs:
- custom digit filling in .FromCustom() methods  
(incorrect filling: customDigits\[0\] instead of "0" or gDigits\[0\])
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

- **Fixed Numsys. AsBinary overloads that had weird bugs with custom digits**
- **Fixed Numsys. AsBinary overloads (custom digits and output extending) having wrong extender digits**

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
- AsType \> FromCustomAsType (Int32[], List)
- AsString \> CustomAsString (string)



## v1.8 Changes
- **Entire Numsys. class (still in testing)**
Includes
- Auto\<T\> functions
- Filtered Fast variants for bases 2, 4, 8, 10, 16
- Custom variants for different bases (not 2, 4, 8, 10 or 16)



---

&nbsp;  
&nbsp;  
&nbsp;  
&nbsp;  
&nbsp;  
&nbsp;  
&nbsp;  
&nbsp;  
&nbsp;  
&nbsp;  
&nbsp;  
&nbsp;  
&nbsp;  
&nbsp;  
&nbsp;  
&nbsp;  
&nbsp;  
&nbsp;  
&nbsp;  
&nbsp;  
&nbsp;  
&nbsp;  


 
---
###### Whoa didn't expect you to scroll this far down, alright here's a bonus:
---


&nbsp;  



# Most influential updates:
- **№1 - v2.7.1:**
     + Full code refactor, +.Unsanitized_.. to FromBinary. +.Shuffle to Random's classes, +.NextDouble w/ interval support
- **№2 - v2.5.1:**  
     + Numsys revamp with a lot of bugfixes, large scale transition to wildcard Type, and a lot of optimisation using double-wildcard type inputs
- **#3 - v2.6.1:**
     + Merged DateTime4b class with AVcontrol (v2.6), bugfixes and optimisations
- **№4 - v2.2.2:**  
     + Longest lasting stable version with Fast & Secure Random logic (almost 60 days)
- **№5 - v1.8.2:**  
     + Second longest lasting - first stable version with Numsys logic (almost 50 days)
- №6 - v2.1.1:  
     + Saved the day when the most broken build (2.0) was first released
- №7 - v1.7:
     + In the early stages of development of 1.8s (before 1.8.2 came out) roll backs were often performed to 1.7
- №8 - 1.4.1:
     + Most used version by far in the early development phase
