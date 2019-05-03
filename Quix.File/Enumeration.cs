#pragma warning disable IDE1006 // Naming Styles

using System;
using System.Collections.Generic;
using System.Text;

namespace Quix.File
{
    public class Enumeration
    {
        public static List<string> getAllChildObjects(string folderUri, bool includeFolders = true)
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
                files.AddRange(getAllChildObjects(folder));
            }
            return files;
        }
    }
}
