
![Project type](https://github.com/FredEkstrand/ImageFiles/raw/master/CodeIcon.png )

![Version 1.0.0](https://img.shields.io/badge/Version-1.0.0-brightgreen.svg) ![Licence MIT](https://img.shields.io/badge/Licence-MIT-blue.svg)

# Overview

A collection of string operations.

## Features
* Pad Center string in a defined column width.
* Pad Center Crop.
* Pad Left Crop.
* Pad Right Crop.
* Returns a new string in which all occurrences of all Unicode character in an array with the specified Unicode character.
* Returns a new string in which all occurrences of all Unicode characters in an array are replaced with the specified Unicode characters in an array at the same element index.

## Installing
The souce code and provided DLL is written in C# and targeted for the .Net Framework 4.0 and later.
You can download the DLL [here](#)

## Getting Started
Once downloaded add a reference to the dll in your Visual Studio project.
Then in your code file add the following to the collection of using statement.
```csharp
using Ekstrand.Text;
```
### Examples
1) Center string in a defined column width
```csharp
private const string StringSet2 = "Jacuzzi";
string result = StringSet2.PadCenter(9, '#');
/* Results
    #Jacuzzi#
*/
```


### Documentation
Class documentation [here](http://fredekstrand.github.io/StringOperations) 

## History
 1.0.0 Initial release into the wild.
 
## Contributing

If you'd like to contribute, please fork the repository and use a feature
branch. Pull requests are always welcome.

## Contact
Fred Ekstrand 
email: fredekstrandgithub@gmail.com
## Licensing

This project is licensed under the MIT License - see the LICENSE.md file for details.

