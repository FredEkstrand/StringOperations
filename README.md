
# String Operations

![Version 1.0.0](https://img.shields.io/badge/Version-1.0.0-brightgreen.svg) ![Licence MIT](https://img.shields.io/badge/Licence-MIT-blue.svg)


<img src="https://github.com/FredEkstrand/ImageFiles/raw/master/StringOperations/BallofStrings.png " width=150 height=150 />

# Overview

A collection of string operations that I have found useful time to time.

## Features
* Pad Center. Centers a string in a defined column width with padding. If string is larger than the defined column width the string would be returned.
* Pad Center Crop. Centers a string in a defined column width with padding. If the string is wider than the defined column it would be centered in the column. Then cropped on both ends to maintain column width.
* Pad Left Crop. Pad left a string in a defined column width. If the string is larger than the defined column after adding the padding it would be cropped. The cropping would be on the right end of the string to maintain column width.
* Pad Right Crop. Pad right a string in a defined column width.  If the string is larger than the defined column after adding the padding it would be cropped. The cropping would be on the left end of the string to maintain column width.
* Returns a new string in which all occurrences of all Unicode character in an array with the specified Unicode character.
* Returns a new string in which all occurrences of all Unicode characters in an array are replaced with the specified Unicode characters in an array at the same element index.

# Getting started
The souce code is written in C# and targeted for the .Net Framework 4.0 and later. Download the entire project and compile.

# Usage
Once you have compiled the project reference the dll in your Visual Studio project.
Then in your code file add the following to the collection of using statement.
```csharp
using Ekstrand.Text;
```
#### Examples
1) Center string in a defined column width
```csharp
private const string StringSet2 = "Jacuzzi";
string result = StringSet2.PadCenter(9, '#');

/* result string value: #Jacuzzi# */
```
{ additional code examples please }

# Code Documentation
MSDN-style code documentation can be found  [here](http://fredekstrand.github.io/StringOperations).

# History
 1.0.0 Initial release into the wild.

# Contributing

If you'd like to contribute, please fork the repository and use a feature
branch. Pull requests are always welcome.

# Contact
Fred Ekstrand
email: fredekstrandgithub@gmail.com

# Licensing

This project is licensed under the MIT License - see the LICENSE.md file for details.
