#pragma warning disable IDE1006, IDE0017, CS0162, IDE0060 // Naming Styles, Simplify declaration (FQCN used), break after return, Remove unused (string[] args)

/// <summary>
/// Author: Cornelius J. van Dyk blog.cjvandyk.com @cjvandyk
/// This code is provided under GNU GPL 3.0 and is a copyrighted work of the
/// author and contributors.  Please see:
/// https://github.com/cjvandyk/Quix/blob/master/LICENSE
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;

namespace Quix
{
    /// <summary>
    /// Extension class for string and text objects.
    /// </summary>
    public static class String
    {
        /// <summary>
        /// Checks if the given string contains all alphabetic characters.
        /// </summary>
        /// <param name="str">The given string object to check.</param>
        /// <param name="Classic">Switch to force RegEx comparison instead of Linq.</param>
        /// <returns>True if all characters in the given string are alphabetic, else False.</returns>
        public static bool IsAlphabetic(this System.String str, bool Classic = false)
        {
            if (Classic)  //No LINQ available e.g. .NET 2.0
            {
                return System.Text.RegularExpressions.Regex.IsMatch(str, @"^[a-zA-Z]+$");
            }
            else  //This method is on average 670% faster than the Classic RegEx method.
            {
                return str.ToCharArray().All(Char.IsLetter);
            }
        }

        /// <summary>
        /// Checks if the given string contains all alphabetic characters.
        /// </summary>
        /// <param name="str">The given string builder object to check.</param>
        /// <param name="Classic">Switch to force RegEx comparison instead of Linq.</param>
        /// <returns>True if all characters in the given string are alphabetic, else False.</returns>
        public static bool IsAlphabetic(this System.Text.StringBuilder str, bool Classic = false)
        {
            return IsAlphabetic(str.ToString(), Classic);
        }

        /// <summary>
        /// Checks if the given string contains all numeric characters.
        /// </summary>
        /// <param name="str">The given string object to check.</param>
        /// <param name="Classic">Switch to force RegEx comparison instead of Linq.</param>
        /// <returns>True if all characters in the given string are numeric, else False.</returns>
        public static bool IsNumeric(this System.String str, bool Classic = false)
        {
            if (Classic)  //No LINQ available e.g. .NET 2.0
            {
                return System.Text.RegularExpressions.Regex.IsMatch(str, @"^[0-9]+$");
            }
            else  //This method is on average 670% faster than the Classic RegEx method.
            {
                return str.ToCharArray().All(Char.IsDigit);
            }
        }

        /// <summary>
        /// Checks if the given string contains all numeric characters.
        /// </summary>
        /// <param name="str">The given string builder object to check.</param>
        /// <param name="Classic">Switch to force RegEx comparison instead of Linq.</param>
        /// <returns>True if all characters in the given string are numeric, else False.</returns>
        public static bool IsNumeric(this System.Text.StringBuilder str, bool Classic = false)
        {
            return IsNumeric(str.ToString(), Classic);
        }

        /// <summary>
        /// Checks if the given string contains only alphabetic and numeric characters.
        /// </summary>
        /// <param name="str">The given string object to check.</param>
        /// <param name="Classic">Switch to force RegEx comparison instead of Linq.</param>
        /// <returns>True if all characters in the given string are either alphabetic or numeric, else False.</returns>
        public static bool IsAlphaNumeric(this System.String str, bool Classic = false)
        {
            if (Classic)  //No LINQ available e.g. .NET 2.0
            {
                return System.Text.RegularExpressions.Regex.IsMatch(str, @"^[a-zA-Z0-9]+$");
            }
            else  //This method is on average 670% faster than the Classic RegEx method.
            {
                return str.ToCharArray().All(Char.IsLetterOrDigit);
            }
        }

        /// <summary>
        /// Checks if the given string contains only alphabetic and numeric characters.
        /// </summary>
        /// <param name="str">The given string builder object to check.</param>
        /// <param name="Classic">Switch to force RegEx comparison instead of Linq.</param>
        /// <returns>True if all characters in the given string are either alphabetic or numeric, else False.</returns>
        public static bool IsAlphaNumeric(this System.Text.StringBuilder str, bool Classic = false)
        {
            return IsAlphaNumeric(str.ToString(), Classic);
        }

        /// <summary>
        /// Check if the given string contains only the characters in the Chars array being passed.
        /// </summary>
        /// <param name="str">The given string object to check.</param>
        /// <param name="Chars">The array of valid characters that are checked in the string.</param>
        /// <param name="Classic">Switch to force RegEx comparison instead of Linq.</param>
        /// <returns>True if the given string contains only characters in the Chars array, else False.</returns>
        public static bool IsChar(this System.String str, char[] Chars, bool Classic = false)
        {
            if (Classic)  //No LINQ available e.g. .NET 2.0
            {
                string comparor = @"^[";
                foreach (char c in Chars)
                {
                    comparor += c;
                }
                comparor += "]+$";
                return System.Text.RegularExpressions.Regex.IsMatch(str, comparor);
            }
            else
            {
                foreach (char c in str.ToCharArray())
                {
                    if (!Chars.Contains(c))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Check if the given string contains only the characters in the Chars array being passed.
        /// </summary>
        /// <param name="str">The given string builder object to check.</param>
        /// <param name="Chars">The array of valid characters that are checked in the string.</param>
        /// <param name="Classic">Switch to force RegEx comparison instead of Linq.</param>
        /// <returns>True if the given string contains only characters in the Chars array, else False.</returns>
        public static bool IsChar(this System.Text.StringBuilder str, char[] Chars, bool Classic = false)
        {
            return IsChar(str.ToString(), Chars, Classic);
        }

        /// <summary>
        /// Returns the number of sentences in the given string object.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <returns>The number of sentences in the given object.</returns>
        public static int Lines(this System.String str)
        {
            return str.Split(new char[] { '\n' },
                             StringSplitOptions.RemoveEmptyEntries)
                      .Length;
        }

        /// <summary>
        /// Returns the number of sentences in the given string builder object.
        /// </summary>
        /// <param name="str">A System.Text.StringBuilder object.</param>
        /// <returns>The number of sentences in the given object.</returns>
        public static int Lines(this System.Text.StringBuilder str)
        {
            return str.ToString()
                      .Split(new char[] { '\n' },
                             StringSplitOptions.RemoveEmptyEntries)
                      .Length;
        }

        /// <summary>
        /// Returns the number of words in the given string object.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <returns>The number of words in the given object.</returns>
        public static int Words(this System.String str)
        {
            return str.Split(new char[] { ' ',
                                          '.',
                                          '?',
                                          '!',
                                          ';' },
                             StringSplitOptions.RemoveEmptyEntries)
                      .Length;
        }

        /// <summary>
        /// Returns the number of words in the given string builder object.
        /// </summary>
        /// <param name="str">A System.Text.StringBuilder object.</param>
        /// <returns>The number of words in the given object.</returns>
        public static int Words(this System.Text.StringBuilder str)
        {
            return str.ToString()
                      .Split(new char[] { ' ',
                                          '.',
                                          '?',
                                          '!',
                                          ';' },
                             StringSplitOptions.RemoveEmptyEntries)
                      .Length;
        }
    }
}
