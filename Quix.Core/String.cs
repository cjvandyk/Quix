using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quix.Core
{
    public static class String
    {
        /// <summary>
        /// Used to trim backslashes from strings.
        /// </summary>
        public static char[] backslash = { '\\' };

        /// <summary>
        /// Returns the root URL from a given URL string e.g.
        ///   https://blog.cjvandyk.com/sites/abc will return
        ///   https://blog.cjvandyk.com
        /// </summary>
        /// <param name="url">The given URL string to process.</param>
        /// <returns>The root URL of the given URL string.</returns>
        public static string GetUrlRoot(string url)
        {
            string root = url.ToLower().Replace("https://", "");
            return ("https://" + root.Substring(0, root.IndexOf('/')));
        }

        /// <summary>
        /// Returns true if the given url string is a root url only e.g.
        ///   https://blog.cjvandyk.com would return true but
        ///   https://blog.cjvandyk.com/sites/abc would return false.
        /// </summary>
        /// <param name="url">The URL parameter to evaluate for root.</param>
        /// <returns>True if the url is the root, else false.</returns>
        public static bool IsUrlRootOnly(string url)
        {
            if (url.ToLower().Replace("https://", "").IndexOf('/') == -1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the full path of the parent or containing folder.
        /// Input of C:\Users\C\Documents\Doc1.docx would return
        /// C:\Users\C\Documents
        /// while input of C:\Users\C\Documents\Folder1\ returns
        /// C:\Users\C\Documents
        /// </summary>
        /// <param name="fullPath">The full path of the item e.g.
        ///   C:\Users\C\Documents\Doc1.docx</param>
        /// <returns>Full path of the containing folder.</returns>
        public static string ParentFolderPath(string fullPath)
        {
            return (fullPath.TrimEnd(backslash).Substring(0, 
                fullPath.TrimEnd(backslash).LastIndexOf('\\')));
        }

        public static string CurrentFolder(string fullPath)
        {
            return "";
        }
    }
}
