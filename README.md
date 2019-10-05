
# String Operations

![Version 1.0.0](https://img.shields.io/badge/Version-1.0.0-brightgreen.svg) ![Licence MIT](https://img.shields.io/badge/Licence-MIT-blue.svg) [![Build status](https://ci.appveyor.com/api/projects/status/oraodekq86t9786r?svg=true)](https://ci.appveyor.com/project/FredEkstrand/enigmabinarycipher-rxip2)

![image](https://github.com/FredEkstrand/ImageFiles/tree/master/StringOperations/BallofStrings.png)


# Overview

A collection of string operations that I have found useful time to time.

## Features
* PadCenter: Centers a string in a defined column width with padding on both ends.
* PadCenterCrop: Centers a string in a defined column width with padding. If the string is wider than the defined column it would be centered in the column. Then cropped on both ends to maintain column width.
* PadLeftCrop: Text in the defined text column would be right justified and added padding on the left up to column width.
* PadRightCrop: Text in the defined text column would be left justified and added padding on the right up to column width.
* Replace: Returns a new string in which all occurrences of all Unicode character in an array with the specified Unicode character.
* Replace: Returns a new string in which all occurrences of all substring in an array with the specified Unicode character.
* Replace: Returns a new string in which all occurrences of all Unicode characters in an array are replaced with the specified Unicode characters in an array at the same element index. 
* FirstCharToLowercase: Returns a new string in which the first character in the string is set to lower case.
* FirstCharToUppercase: Returns a new string in which the first character in the string is set to upper case.
* EscapeIllegalChars: Remove all escape and illegal characters in a file name.
* Remove: Returns a new string in which the specified characters from the current string are deleted.
* Remove: Returns a new string in which the specified substrings from the current string are deleted.
* ToTitleCase: Converts the specified string to title case.
* StringToStream: Return a converted string to a stream.
* StreamToString: Return a converted stream to a string;

# Getting started
The source code is written in C# and targeted for the .Net Framework 4.0 and later. Download the entire project and compile.

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
		private const string _s6 = "Lorem ipsum dolor sit amet foo, consectetur adipiscing elit foo. Curabitur pretium foo varius pharetra. Donec luctus foo nisl non massa tincidunt foo foo dapibus.";
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

Example 6. PadLeftCrop: Text is wider than text column it would be cropped on the left.
```csharp
string result = _s1.PadLeftCrop(6, '#');
Console.WriteLine("String column:  ######");
Console.WriteLine("PadLeftCrop:    {0}", result);

/*
String column:  ######
PadLeftCrop:    acuzzi
*/
```

Example 7. PadRightCrop: If text is wider than defined text column it would be cropped on the right.
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

Example 8. String Replace: Replace each item in the character array with a given character value.
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

Example 9. String Replace: Replace each item in the character array with the corresponding by array index character array values;
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

Example 10. String Replace: Replace each item in the string array with the corresponding replacement string.
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

Example 11. First character to lower case: Replace the first upper case character 
```csharp
string result = _s4.FirstCharToLowercase();
Console.WriteLine("FirstCharToLowercase \nOldText: {0} \nNewText: {1}", _s4, result);
/*
FirstCharToLowercase
OldText: Lorem ipsum dolor sit amet
NewText: lorem ipsum dolor sit amet
*/
```

Example 12. First charcter to upper case: Replace the first lower case character to upper case.
```csharp
string result = _s5.FirstCharToUppercase();
Console.WriteLine("FirstCharToUppercase \nOldText: {0} \nNewText: {1}", _s5, result);
/*
FirstCharToUppercase
OldText: torem ipsum dolor sit amet
NewText: Torem ipsum dolor sit amet
*/
```

Example 13. Replace Escape and illegal characters from file name string.
```csharp
string badStr = _s3;
badStr = BuildUnsafeFileName(badStr);
string result = badStr.EscapeIllegalChars();
Console.WriteLine("NoEscapeIllegalChars \nOldText: {0} \nNewText: {1}", badStr, result);
/*
NoEscapeIllegalChars
OldText:  
UnsafeFileName"<>?|\/:.cs
NewText: UnsafeFileName.cs
*/
```


Example 14. String to Stream
```csharp
String str = _s4;
Stream sm = StringUtil.StringToStream(str);
StreamReader sr = new StreamReader(sm, Encoding.Unicode);
string result = sr.ReadToEnd();

Console.WriteLine("StringToStream \nOldText: {0} \nNewText: {1}", _s4, result);
/*
StringToStream
OldText: Lorem ipsum dolor sit amet
NewText: Lorem ipsum dolor sit amet
*/
```

Example 15. Stream to String
```csharp
String str = _s4;
Stream sm = StringUtil.StringToStream(str);
string result = StringUtil.StreamToString(sm);

Console.WriteLine("StreamToString \nOldText: {0} \nNewText: {1}", _s4, result);

/*
StreamToString
OldText: Lorem ipsum dolor sit amet
NewText: Lorem ipsum dolor sit amet
*/
```

Example 16. Remove Characters
```csharp
char[] ca = new char[] { 'a', 'p' };
string str = String.Copy(_s6);
string result = str.Remove(ca);

Console.WriteLine("RemoveCharacters \nOldText: {0} \nNewText: {1}", str, result);
Console.WriteLine();

/*
RemoveCharacters
OldText: Lorem ipsum dolor sit amet foo, consectetur adipiscing elit foo. Curabitur pretium foo varius pharetra. Donec luctus foo nisl non massa tincidunt foo foo dapibus.
NewText: Lorem isum dolor sit met foo, consectetur diiscing elit foo. Curbitur retium foo vrius hretr. Donec luctus foo nisl non mss tincidunt foo foo dibus.
*/
```

Example 17. Remove Substrings
```csharp
string[] ca = new string[] { "foo", "." };
string str = String.Copy(_s6);
string result = str.Remove(ca);

Console.WriteLine("Remove Substrings \nOldText: {0} \nNewText: {1}", str, result);
Console.WriteLine();

/*
Remove Substrings
OldText: Lorem ipsum dolor sit amet foo, consectetur adipiscing elit foo. Curabitur pretium foo varius pharetra. Donec luctus foo nisl non massa tincidunt foo foo dapibus.
NewText: Lorem ipsum dolor sit amet , consectetur adipiscing elit  Curabitur pretium  varius pharetra Donec luctus  nisl non massa tincidunt   dapibus
*/
```

Example 18. ToTitleCase
```csharp
string str = String.Copy(_s6);
string result = str.ToTitleCase();

Console.WriteLine("ToTitleCase \nOldText: {0} \nNewText: {1}", str, result);
Console.WriteLine();

/*
ToTitleCase
OldText: Lorem ipsum dolor sit amet foo, consectetur adipiscing elit foo. Curabitur pretium foo varius pharetra. Donec luctus foo nisl non massa tincidunt foo foo dapibus.
NewText: Lorem Ipsum Dolor Sit Amet Foo, Consectetur Adipiscing Elit Foo. Curabitur Pretium Foo Varius Pharetra. Donec Luctus Foo Nisl Non Massa Tincidunt Foo Foo Dapibus.
*/
```

# Code Documentation
MSDN-style code documentation can be found  [here](http://fredekstrand.github.io/ClassDocStringOperations).

# History
 1.0.0.0 Initial release into the wild.

# Contributing

If you'd like to contribute, please fork the repository and use a feature
branch. Pull requests are always welcome.

# Contact
Fred Ekstrand
email: fredekstrandgithub@gmail.com

# Licensing

This project is licensed under the MIT License - see the LICENSE.md file for details.
