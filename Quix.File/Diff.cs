#pragma warning disable IDE1006 // Naming Styles

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

    public static enum comparisonType
    {
        Attributes = 1,
        Binary = 2,
        Both = 3
    }

    public static class Diff
    {
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int memcmp(byte[] b1, byte[] b2, long count);

        public static bool compareByteArray(byte[] b1, byte[] b2)
        {
            return b1.Length == b2.Length & memcmp(b1, b2, b1.Length) == 0;
        }

        public static bool fileDiff(string compareThis, string withThis, comparisonType how2Compare = comparisonType.Binary)
        {
            bool match = true;
            switch (how2Compare)
            {
                case comparisonType.Attributes:
                    break;
                case comparisonType.Binary:
                    match = compareByteArray(System.IO.File.ReadAllBytes(compareThis), System.IO.File.ReadAllBytes(withThis));
                    break;
                case comparisonType.Both:
                    break;
                default:
                    throw new Exception("Unexpected comparisonType [" + how2Compare.ToString() + "]");
            }
            return match;
        }

        public static bool folderDiff(string compareThisFolder, string withThisFolder, comparisonType how2Compare = comparisonType.Binary)
        {
            bool match = true;
            switch (how2Compare)
            {
                case comparisonType.Attributes:
                    break;
                case comparisonType.Binary:
                    match = compareByteArray(System.IO.File.ReadAllBytes(compareThis), System.IO.File.ReadAllBytes(withThis));
                    break;
                case comparisonType.Both:
                    break;
                default:
                    throw new Exception("Unexpected comparisonType [" + how2Compare.ToString() + "]");
            }
            return match;
        }

        public static void FullDirList(DirectoryInfo dir, string searchPattern)
        {
            List<System.IO.FileInfo> files = new List<System.IO.FileInfo>();
            List<System.IO.DirectoryInfo> foldersInaccessible = new List<System.IO.DirectoryInfo>();
            try
            {
                foreach (FileInfo fi in dir.GetFiles(searchPattern))
                {
                    files.Add(fi);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                foldersInaccessible.Add(dir);
                //Console.WriteLine("Directory {0}  \n could not be accessed!!!!", dir.FullName);
                return;  // We alredy got an error trying to access dir so dont try to access it again
            }

            // process each directory
            // If I have been able to see the files in the directory I should also be able 
            // to look at its directories so I dont think I should place this in a try catch block
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                folders.Add(d);
                FullDirList(d, searchPattern);
            }

        }
    }
}