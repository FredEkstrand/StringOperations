/*
Open source MIT License
Copyright (c) 2017 Fred A Ekstrand Jr.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

A746-8U6HF-VAPG3-150J5-96793-L2MJ1-E3EJ
*/
using System;
using System.Text;

namespace Ekstrand.Text
{
    /// <summary>
    /// A collection of string operations.
    /// </summary>
    public static class StringOperations
    {
        /// <summary>
        /// Center align text in a defined string column. 
        /// </summary>
        /// <param name="str">String to be centered in string column.</param>
        /// <param name="totalWidth">Integer total width of the string column (length) to place a string in.</param>
        /// <param name="paddingChar">Char padding character default is space.</param>
        /// <returns>Return a string centered in defined length.</returns>
        /// <remarks>If given string is larger than given string column length the given string is returned.</remarks>
        public static string PadCenter(this string str, int totalWidth, char paddingChar = ' ')
        {
            if (str.Length > totalWidth || str.Length == totalWidth)
            { return str; }

            StringBuilder sb = new StringBuilder();

            int idx = 0;
            int value = totalWidth - str.Length;
            value = value / 2;

            for (int i = 0; i < totalWidth; i++)
            {

                if (i >= value && idx < str.Length)
                {
                    sb.Append(str[idx]);
                    idx++;
                }
                else
                {
                    sb.Append(paddingChar);
                }
            }
            return sb.ToString();
        }


        /// <summary>
        /// Center align text in a defined string column. If given string is larger it would be centered and crop on both ends.
        /// </summary>
        /// <param name="str">String to be inserted in the string column</param>
        /// <param name="totalWidth">Integer string column width (length).</param>
        /// <param name="paddingChar">Char char value used to padded the inserted string into defined string column.</param>
        /// <returns>Return a string with the inserted string centered aligned. The return string would also cropped any characters from the given string if needed.</returns>
        public static string PadCenterCrop(this string str, int totalWidth, char paddingChar = ' ')
        {
            StringBuilder sb = new StringBuilder();
            FillString(sb, totalWidth, paddingChar);

            int idx = 0;
            int clip = 0;
            int value = totalWidth - str.Length;

            if (value < 0)
            {
                clip = value * -1;
                clip = clip / 2;
            }
            else
            {
                value = value / 2;
            }

            for (int i = 0; i < totalWidth; i++)
            {
                if (value < 0)
                {
                    if((i+clip) < str.Length)
                    {
                        sb[i] = str[i + clip];
                    }
                }
                else
                {
                    if (i >= value && idx < str.Length)
                    {
                        sb[i] = str[idx];
                        idx++;
                    }
                    else
                    {
                        sb.Append(paddingChar);
                    }
                }
    
            }

            return sb.ToString();
        }


        /// <summary>
        /// Left align text in a defined string column.
        /// </summary>
        /// <param name="str">String to be inserted into a defined sting column.</param>
        /// <param name="totalWidth">Integer total width of the string column (length).</param>
        /// <param name="paddingChar">Char character value used for padding. Default is space.</param>
        /// <returns>Returns a new string with given string left aligned to string column and any characters over the defined column width would be cropped.</returns>
        public static string PadRightCrop(this string str, int totalWidth, char paddingChar = ' ')
        {
            StringBuilder sb = new StringBuilder(totalWidth);

            sb = FillString(sb, totalWidth, paddingChar);

            for (int i = 0; i < sb.Length; i++)
            {
                if (i == str.Length) { break; }
                sb[i] = str[i];
            }

            return sb.ToString();
        }


        /// <summary>
        /// Right align text in a defined string column.
        /// </summary>
        /// <param name="str">String to be inserted into a string column.</param>
        /// <param name="totalWidth">Integer total width of the string column (length).</param>
        /// <param name="paddingChar">Char character value used for padding. Default is space.</param>
        /// <returns>Returns a new string with the given string right aligned to the string column and any characters over the defined column would be cropped.</returns>
        public static string PadLeftCrop(this string str, int totalWidth, char paddingChar = ' ')
        {
            int length1 = totalWidth - 1;
            StringBuilder sb = new StringBuilder(totalWidth);

            sb = FillString(sb, totalWidth);

            for (int i = str.Length; i > 0; i--)
            {
                if (length1 == -1) { break; }
                sb[length1] = str[i - 1];
                length1--;
            }

            return sb.ToString();
        }


        /// <summary>
        /// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
        /// </summary>
        /// <param name="str">String to have its characters replaced.</param>
        /// <param name="oldChars">The Unicode character array of characters to be replaced.</param>
        /// <param name="newChar">The Unicode character to replace all occurrences of oldChar. </param>
        /// <returns>
        /// A string that is equivalent to this instance except that all instances of oldChar are replaced with newChar. If oldChar is not found in the current instance, the method returns the current instance unchanged. 
        /// </returns>
        public static string Replace(this string str, char[] oldChars, char newChar)
        {
            for (int i = 0; i < oldChars.Length; i++)
            {
                str = str.Replace(oldChars[i], newChar);
            }
            return str;
        }


        /// <summary>
        /// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
        /// </summary>
        /// <param name="str">String to have its characters replaced.</param>
        /// <param name="oldChars">The Unicode character array of characters to be replaced</param>
        /// <param name="newChars">The Unicode character to replace all occurrences of oldChar[] at same element index.</param>
        /// <returns>
        ///  A string that is equivalent to this instance except that all instances of oldChar are replaced with newChar. If oldChar is not found in the current instance, the method returns the current instance unchanged. 
        /// </returns>
        public static string Replace(this string str, char[] oldChars, char[] newChars)
        {
            if(oldChars.Length != newChars.Length)
            {
                throw new Exception("Given character arrays are not of same length.");
            }

            for (int i = 0; i < oldChars.Length; i++)
            {
                str = str.Replace(oldChars[i], newChars[i]);
            }
            return str;
        }

        /// <summary>
        /// Populates the string builder a defined number of blanks.
        /// </summary>
        /// <param name="sb">StringBuilder instance to populate blanks into.</param>
        /// <param name="length">Integer number of blanks to be inserted into the StringBuiler.</param>
        /// <returns>Returns the StringBuilder with populated blanks (spaces).</returns>
        private static StringBuilder FillString(StringBuilder sb, int length)
        {
            for (int i = 0; i < length; i++)
            {
                sb.Append(" ");
            }

            return sb;
        }

        /// <summary>
        /// Populates the string builder with defined character.
        /// </summary>
        /// <param name="sb">StringBuilder instance to populate blanks into.</param>
        /// <param name="length">Integer number of blanks to be inserted into the StringBuiler.</param>
        /// <param name="chr">Character to be used to populate the StringBuilder.</param>
        /// <returns>Returns the StringBuilder with populated blanks (spaces).</returns>
        private static StringBuilder FillString(StringBuilder sb, int length, char chr)
        {
            for (int i = 0; i < length; i++)
            {
                sb.Append(chr);
            }
            return sb;
        }
    }
}
