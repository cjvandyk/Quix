using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rename
{
    class Program
    {
        /// <summary>
        /// Rename is a quick file renaming tool.  It is used in cases where
        /// one or more files contain 1 to n strings that needs to be removed
        /// from the file name(s).
        /// It will process all child folders as well thus touching the 
        /// entire folder tree.
        /// It only works with files, not folder names.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (args.Count() != 3)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Usage is: rename.exe <targetFolder> <searchString> <stringsToRemove>");
                Console.WriteLine("  where <stringsToRemove> is ` delimted.");
                Console.ForegroundColor = color;
            }
            else
            {
                string rootFolder = args[0];
                string fileFilter = args[1];
                List<string> removeStrings = args[2].Split('`').ToList();
                List<string> files = System.IO.Directory.GetFiles(rootFolder, fileFilter, System.IO.SearchOption.AllDirectories).ToList();
                string newName = "";
                foreach (string file in files)
                {
                    newName = file;
                    foreach (string removeString in removeStrings)
                    {
                        if (file.Contains(removeString))
                        {
                            newName = newName.Replace(removeString, ""); 
                        }
                    }
                    if (newName != file)
                    {
                        System.IO.File.Move(file, newName);
                    }
                }
            }
        }
    }
}
