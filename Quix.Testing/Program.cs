#pragma warning disable IDE1006 // Naming Styles

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quix.Testing
{
    /// <summary>
    /// Author: Cornelius J. van Dyk blog.cjvandyk.com @cjvandyk  
    /// This code is provided under GNU GPL 3.0 and is a copyrighted work of the
    /// author and contributors.  Please see:
    /// https://github.com/cjvandyk/Quix/blob/master/LICENSE
    /// Source code has been held to 80 character width for printing and porting
    /// reasons.
    /// </summary>
    class Program
    {
        private static Quix.Logging log = new Logging();

        static void Main(string[] args)
        {
            using (Quix.Logging log2 = new Quix.Logging())
            {
                Log("log2", log2);
            }
            Log("log");
            string folderPath = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetEntryAssembly().Location)
                .TrimEnd('\\');
            for (int i = 0; i < 3; i++)  //Traverse to the solution root.
            {
                folderPath = folderPath.Substring(0, folderPath.LastIndexOf(@"\"));
            }
            List<string> files = Quix.File.Enumeration.getAllChildObjects(folderPath);
            int textFiles = 0, binaryFiles = 0, lockFiles = 0;
            foreach (string file in files)
            {
                switch (Quix.File.FileType.getFileType(file))
                {
                    case File.FileType.Content.Text:
                        textFiles++;
                        break;
                    case File.FileType.Content.Binary:
                        binaryFiles++;
                        break;
                }
            }
            Log(string.Format("{0} Text files, {1} Binary files and {2} Lock files.", textFiles, binaryFiles, lockFiles));
        }

        private static void Log(string message)
        {
            log.Log(message);
        }
        private static void Log(string message, Quix.Logging log)
        {
            log.Log(message);    
        }
    }
}
