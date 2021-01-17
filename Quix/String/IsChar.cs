#pragma warning disable IDE1006, IDE0017, CS0162, IDE0060, IDE0079 // Naming Styles, Simplify declaration (FQCN used), break after return, Remove unused (string[] args, Remove unnecessary suppression)

/// <summary>
/// Author: Cornelius J. van Dyk blog.cjvandyk.com @cjvandyk
/// This code is provided under GNU GPL 3.0 and is a copyrighted work of the
/// author and contributors.  Please see:
/// https://github.com/cjvandyk/Quix/blob/master/LICENSE
/// </summary>

using System;
using System.Linq;

namespace Quix.String
{
    public static partial class Extensions
    {
        /// <summary>
        /// This method takes a char[] as one of its arguments against which 
        /// the given string object is validated.If the given string object 
        /// contains only characters found in the char[] it will return True,
        /// otherwise it will return False.
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
        /// This method takes a char[] as one of its arguments against which 
        /// the given string object is validated.If the given string object 
        /// contains only characters found in the char[] it will return True,
        /// otherwise it will return False.
        /// </summary>
        /// <param name="str">The given string builder object to check.</param>
        /// <param name="Chars">The array of valid characters that are checked in the string.</param>
        /// <param name="Classic">Switch to force RegEx comparison instead of Linq.</param>
        /// <returns>True if the given string contains only characters in the Chars array, else False.</returns>
        public static bool IsChar(this System.Text.StringBuilder str, char[] Chars, bool Classic = false)
        {
            return IsChar(str.ToString(), Chars, Classic);
        }
    }
}