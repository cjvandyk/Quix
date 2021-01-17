#pragma warning disable IDE1006, IDE0017, CS0162, IDE0060, IDE0079 // Naming Styles, Simplify declaration (FQCN used), break after return, Remove unused (string[] args, Remove unnecessary suppression)

/// <summary>
/// Author: Cornelius J. van Dyk blog.cjvandyk.com @cjvandyk
/// This code is provided under GNU GPL 3.0 and is a copyrighted work of the
/// author and contributors.  Please see:
/// https://github.com/cjvandyk/Quix/blob/master/LICENSE
/// </summary>

using System;

namespace Quix.String
{
    public static partial class Extensions
    {
        /// <summary>
        /// Get the URL root for the given string object containing a URL.
        /// For example:
        ///   "https://cjvandyk.sharepoint.com".GetUrlRoot() 
        ///   will return "https://cjvandyk.sharepoint.com" whereas
        ///   "https://cjvandyk.sharepoint.com/sites/Approval".GetUrlRoot()
        ///   will also return "https://cjvandyk.sharepoint.com".
        /// </summary>
        /// <param name="url">The System.String object containing the URL
        /// from which the root is to be extracted.</param>
        /// <returns>The root of the URL given the URL string.</returns>
        public static string GetUrlRoot(this System.String url)
        {
            string root = url.ToLower().Replace("https://", "");
            return ("https://" + root.Substring(0, root.IndexOf('/')));
        }

        /// <summary>
        /// Get the URL root for the given string builder object containing a
        /// URL.  For example:
        ///   "https://cjvandyk.sharepoint.com".GetUrlRoot() 
        ///   will return "https://cjvandyk.sharepoint.com" whereas
        ///   "https://cjvandyk.sharepoint.com/sites/Approval".GetUrlRoot()
        ///   will also return "https://cjvandyk.sharepoint.com".
        /// </summary>
        /// <param name="url">The System.Text.StringBuilder object containing
        /// the URL from which the root is to be extracted.</param>
        /// <returns>The root of the URL given the URL string.</returns>
        public static string GetUrlRoot(this System.Text.StringBuilder url)
        {
            return GetUrlRoot(url.ToString());
        }
    }
}
