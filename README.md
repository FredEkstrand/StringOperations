
# String Operations

![Version 1.0.0](https://img.shields.io/badge/Version-1.0.0-brightgreen.svg) ![Licence MIT](https://img.shields.io/badge/Licence-MIT-blue.svg) [![Build status](https://ci.appveyor.com/api/projects/status/oraodekq86t9786r?svg=true)](https://ci.appveyor.com/project/FredEkstrand/enigmabinarycipher-rxip2)



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
Strings used in code samples.
```csharp
        private const string _s1 = "Jacuzzi";
        private const string _s2 = "Lorem ipsum dolor sit amet, [consectetur adipiscing elit]. Curabitur pretium {varius} pharetra. Donec luctus nisl non massa tincidunt @#&^% dapibus.";
        private const string _s3 = "UnsafeFileName\"<>?|\\/:.cs";
        private const string _s4 = "Lorem ipsum dolor sit amet";
        private const string _s5 = "torem ipsum dolor sit amet";
```
Example 1. PadCenter: Center string inside a defined column size. spaces would be padded to edge of column.
```csharp
string result = _s1.PadCenter(11,'#');
Console.WriteLine("String column:  ###########");
Console.WriteLine("PadCenter:      {0}", result);
Console.WriteLine();

/*
String column:  ###########
PadCenter:      ##Jacuzzi##
*/
```

Example 2. PadCenter: If text is wider than given column width it would return the string.
```csharp
string result = _s1.PadCenter(6, '*');
Console.WriteLine("String column:  ******");
Console.WriteLine("PadCenter:      {0}", result);

/*
String column:  ******
PadCenter:      Jacuzzi
*/
```

Example 3. PadCenter: If text is odd length in an even length column then it would be centered with left justified.
```csharp
string result = _s1.PadCenter(8, '#');
Console.WriteLine("String column:  ########");
Console.WriteLine("PadCenter:      {0}", result);

/*
String column:  ########
PadCenter:      Jacuzzi#
*/
```

Example 4. PadCenterCrop: If text is wider than given column width it would center and crop any characters outside the column on both sides.
```csharp
string result = _s1.PadCenterCrop(5, '#');
Console.WriteLine("String column:  #####");
Console.WriteLine("PadCenterCrop:  {0}", result);
 
/*
String column:  #####
PadCenterCrop:  acuzz
*/
```

Example 5. PadCenterCrop: If text is odd width and the column is even width it would center, with left justified, and crop any characters outside the column.
```csharp
string result = _s1.PadCenterCrop(6, '#');
Console.WriteLine("String column:  ######");
Console.WriteLine("PadCenterCrop:  {0}", result);

/*
String column:  ######
PadCenterCrop:  Jacuzz
*/
```

Example 6. PadLeft: Text is shorter than text column it would be right justified and added padding on the left up to column width.
```csharp
string result = _s1.PadLeft(8, '#');
Console.WriteLine("String column:  ########");
Console.WriteLine("PadLeft:        {0}", result);

/*
String column:  ########
PadLeft:        #Jacuzzi
*/
```

Example 7. PadLeft: Text is wider than given column size it would return the text.
```csharp
string result = _s1.PadLeft(6, '#');
Console.WriteLine("String column:  ######");
Console.WriteLine("PadLeft:        {0}", result);

/*
String column:  ######
PadLeft:        Jacuzzi
*/
```

Example 8. PadLeftCrop: Text is wider than text column it would be cropped on the left.
```csharp
string result = _s1.PadLeftCrop(6, '#');
Console.WriteLine("String column:  ######");
Console.WriteLine("PadLeftCrop:    {0}", result);

/*
String column:  ######
PadLeftCrop:    acuzzi
*/
```

Example 9. PadRight: Text is left justified and padding is added to the right.
```csharp
string result = _s1.PadRight(8, '#');
Console.WriteLine("String column:  ########");
Console.WriteLine("PadRight:       {0}", result);

/*
String column:  ########
PadRight:       Jacuzzi#
*/
```

Example 10. PadRight: If text is wider than defined text column width it would return the text.
```csharp
string result = _s1.PadRight(6, '#');
Console.WriteLine("String column:  ######");
Console.WriteLine("PadRight:       {0}", result);

/*
String column:  ######
PadRight:       Jacuzzi
*/
```

Example 11. PadRightCrop: If text is wider than defined text column it would be cropped on the right.
```csharp
string result = _s1.PadRightCrop(6, '#');
Console.WriteLine("String column:  ######");
Console.WriteLine("PadRightCrop:   {0}", result);
Console.WriteLine("");

/*
String column:  ######
PadRightCrop:   Jacuzz
*/
```

Example 12. String Replace: Replace each item in the character array with a given character value.
```csharp
char[] ch = new char[] { '{', '}', '[', ']' };
char chn = ' ';
string result = _s2.Replace(ch, chn);
Console.WriteLine("StringReplace \nOldText: {0} \nNewText: {1}",  _s2, result );

/*
StringReplace
OldText: Lorem ipsum dolor sit amet, [consectetur adipiscing elit]. Curabitur pretium {varius} pharetra. Donec luctus nisl non massa tincidunt @#&^% dapibus.
NewText: Lorem ipsum dolor sit amet,  consectetur adipiscing elit . Curabitur pretium  varius  pharetra. Donec luctus nisl non massa tincidunt @#&^% dapibus.
*/
```

Example 13. String Replace: Replace each item in the character array with the corresponding by array index character array values;
```csharp
char[] ch = new char[] { '{', '}', '[' };
char[] ch2 = new char[] { '?', '!', '*' };

string result = _s2.Replace(ch, ch2);
Console.WriteLine("StringReplace \nOldText: {0} \nNewText: {1}", _s2, result);

/*
StringReplace
OldText: Lorem ipsum dolor sit amet, [consectetur adipiscing elit]. Curabitur pretium {varius} pharetra. Donec luctus nisl non massa tincidunt @#&^% dapibus.
NewText: Lorem ipsum dolor sit amet, *consectetur adipiscing elit]. Curabitur pretium ?varius! pharetra. Donec luctus nisl non massa tincidunt @#&^% dapibus.
*/
```

Example 14. String Replace: Replace each item in the string array with the corresponding replacement string.
```csharp
string[] ch = new string[] { "non", "}", "elit", "]" };
string chn = "@";
string result = _s2.Replace(ch, chn);
Console.WriteLine("StringReplace \nOldText: {0} \nNewText: {1}", _s2, result);

/*
StringReplace
OldText: Lorem ipsum dolor sit amet, [consectetur adipiscing elit]. Curabitur pretium {varius} pharetra. Donec luctus nisl non massa tincidunt @#&^% dapibus.
NewText: Lorem ipsum dolor sit amet, [consectetur adipiscing @@. Curabitur pretium {varius@ pharetra. Donec luctus nisl @ massa tincidunt @#&^% dapibus.
*/
```

Example 15. First character to lower case: Replace the first upper case character 
```csharp

/*
FirstCharToLowercase
OldText: Lorem ipsum dolor sit amet
NewText: lorem ipsum dolor sit amet
*/
```

Example 16 First charcter to upper case: Replace the first lower case character to upper case.
```csharp

/*
FirstCharToUppercase
OldText: torem ipsum dolor sit amet
NewText: Torem ipsum dolor sit amet
*/
```

Example 17 Replace Escape and illegal characters from file name string.
```csharp

/*
NoEscapeIllegalChars
OldText:  
UnsafeFileName"<>?|\/:.cs
NewText: UnsafeFileName.cs
*/
```


Example 18 String to Stream
```csharp

/*

*/
```

Example 19 Stream to String
```csharp

/*

*/
```

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
