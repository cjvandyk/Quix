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
        /// Validates that the given string object contains all alphabetic 
        /// characters(a-z and A-Z) returning True if it does and False if
        /// it doesn't.
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
        /// Validates that the given string object contains all alphabetic 
        /// characters(a-z and A-Z) returning True if it does and False if
        /// it doesn't.
        /// </summary>
        /// <param name="str">The given string builder object to check.</param>
        /// <param name="Classic">Switch to force RegEx comparison instead of Linq.</param>
        /// <returns>True if all characters in the given string are alphabetic, else False.</returns>
        public static bool IsAlphabetic(this System.Text.StringBuilder str, bool Classic = false)
        {
            return IsAlphabetic(str.ToString(), Classic);
        }
    }
}