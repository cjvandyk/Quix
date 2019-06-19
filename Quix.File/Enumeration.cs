#pragma warning disable IDE1006, IDE0017, CS0162, IDE0060 // Naming Styles, Simplify declaration (FQCN used), break after return, Remove unused (string[] args)

/// <summary>
/// Author: Cornelius J. van Dyk blog.cjvandyk.com @cjvandyk  
/// This code is provided under GNU GPL 3.0 and is a copyrighted work of the
/// author and contributors.  Please see:
/// https://github.com/cjvandyk/Quix/blob/master/LICENSE
/// Source code has been held to 80 character width for printing and porting
/// reasons.
/// </summary>
using System;
using System.Collections.Generic;
using System.Text;

namespace Quix.File
{
    /// <summary>
    /// Author: Cornelius J. van Dyk blog.cjvandyk.com @cjvandyk  
    /// This code is provided under GNU GPL 3.0 and is a copyrighted work of the
    /// author and contributors.  Please see:
    /// https://github.com/cjvandyk/Quix/blob/master/LICENSE
    /// Source code has been held to 80 character width for printing and porting
    /// reasons.
    /// </summary>
    
    public static class Enumeration
    {
        public static class childObjects
        {
            public static List<string> files;
            public static List<string> folders;
        }
    
        /// <summary>
        /// DEPRECATED - Use getAllChildFiles instead.
        /// </summary>
        /// <param name="folderUri">Full string path of the target folder.</param>
        /// <param name="includeFolders">(Optional)Indicate if folders and subfolders should be processed recursively for more files.  Default = true</param>
        /// <returns>A list of strings containing full path to identified files.</returns>
        public static List<string> getAllChildObjects(string folderUri, bool includeFolders = true)
        {
            return getAllChildFiles(folderUri, includeFolders);
        }

        /// <summary>
        /// Method returns a list of all files in a given folder and optionally, subfolders recursively.
        /// </summary>
        /// <param name="folderUri">Full string path of the target folder.</param>
        /// <param name="includeFolders">(Optional)Indicate if folders and subfolders should be processed recursively for more files.  Default = true</param>
        /// <returns>A list of strings containing full path to identified files.</returns>
        public static List<string> getAllChildFiles(string folderUri, bool includeFolders = true)
        {
            List<string> files = new List<string>();
            List<string> folders = new List<string>();
            if (!System.IO.Directory.Exists(folderUri))
            {
                return null;
            }
            files.AddRange(System.IO.Directory.EnumerateFiles(folderUri));
            if (includeFolders)
            {
                folders.AddRange(System.IO.Directory.EnumerateDirectories(folderUri));
            }
            foreach (string folder in folders)
            {
                files.AddRange(getAllChildFiles(folder));
            }
            return files;
        }
    }
}