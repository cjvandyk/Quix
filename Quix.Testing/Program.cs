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
    /// https://opensource.org/licenses/GPL-3.0
    /// Source code has been held to 80 character width for printing and porting
    /// reasons.
    /// </summary>
    class Program
    {
        private static readonly Quix.Logging _log = new Logging();

        /// <summary>
        /// Testing app for Quix Utilities.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            using (Quix.Logging log2 = new Quix.Logging())
            {
                Log("log2", log2);
                Quix.Static.logToEventLog = true;
                sLog("slog2");
            }
            Log("log");
            sLog("slog");
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
            sLog(string.Format("{0} Text files, {1} Binary files and {2} Lock files.", textFiles, binaryFiles, lockFiles));
        }

        /// <summary>
        /// Short hand method for calling the logging tool.
        /// </summary>
        /// <param name="message">The message to log.</param>
        private static void Log(string message)
        {
            _log.Log(message);
        }

        /// <summary>
        /// Short hand method for calling the logging tool.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="log">The logging instance to use for logging.</param>
        private static void Log(string message, Quix.Logging log)
        {
            log.Log(message);    
        }

        /// <summary>
        /// Short hand method for calling the logging tool.
        /// </summary>
        /// <param name="message">The message to log.</param>
        private static void sLog(string message)
        {
            Quix.Static.Log(message);
        }
    }
}
