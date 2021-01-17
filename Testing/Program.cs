#pragma warning disable IDE1006, IDE0017, CS0162, IDE0060 // Naming Styles, Simplify declaration (FQCN used), break after return, Remove unused (string[] args)

/// <summary>
/// Author: Cornelius J. van Dyk blog.cjvandyk.com @cjvandyk
/// This code is provided under GNU GPL 3.0 and is a copyrighted work of the
/// author and contributors.  Please see:
/// https://github.com/cjvandyk/Quix/blob/master/LICENSE
/// </summary>
using System;
using System.Text;
using System.Linq;

using Extensions;

namespace Quix.Testing
{
    class Program
    {
        /// <summary>
        /// Testing app for Quix Utilities.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            TestExtensions();
            Console.WriteLine();
            //    TestQuixStringExtensions();
            //    using (Quix.Logging log2 = new Quix.Logging())
            //    {
            //        Log("log2", log2);
            //        Quix.Static.logToEventLog = true;
            //        sLog("slog2");
            //    }
            //    Log("log");
            //    sLog("slog");
            //    string folderPath = System.IO.Path.GetDirectoryName(
            //        System.Reflection.Assembly.GetEntryAssembly().Location)
            //        .TrimEnd('\\');
            //    for (int i = 0; i < 3; i++)  //Traverse to the solution root.
            //    {
            //        folderPath = folderPath.Substring(0, folderPath.LastIndexOf(@"\"));
            //    }
            //    //List<string> files = Quix.File.Enumeration.getAllChildObjects(folderPath);
            //    //int textFiles = 0, binaryFiles = 0, lockFiles = 0;
            //    //foreach (string file in files)
            //    //{
            //    //    switch (Quix.File.FileType.getFileType(file))
            //    //    {
            //    //        case File.FileType.Content.Text:
            //    //            textFiles++;
            //    //            break;
            //    //        case File.FileType.Content.Binary:
            //    //            binaryFiles++;
            //    //            break;
            //    //    }
            //    //}
            //    //Log(string.Format("{0} Text files, {1} Binary files and {2} Lock files.", textFiles, binaryFiles, lockFiles));
            //    //sLog(string.Format("{0} Text files, {1} Binary files and {2} Lock files.", textFiles, binaryFiles, lockFiles));
            //}

            ///// <summary>
            ///// Short hand method for calling the logging tool.
            ///// </summary>
            ///// <param name="message">The message to log.</param>
            //private static void Log(string message)
            //{
            //    _log.Log(message);
            //}

            ///// <summary>
            ///// Short hand method for calling the logging tool.
            ///// </summary>
            ///// <param name="message">The message to log.</param>
            ///// <param name="log">The logging instance to use for logging.</param>
            //private static void Log(string message, Quix.Logging log)
            //{
            //    log.Log(message);
            //}

            ///// <summary>
            ///// Short hand method for calling the logging tool.
            ///// </summary>
            ///// <param name="message">The message to log.</param>
            //private static void sLog(string message)
            //{
            //    Quix.Static.Log(message);
            //}

            //private static void TestQuixStringExtensions()
            //{
            //    string str = "This is my test sentence!  This is the second sentence. \nIs this the second line? \nThis could be line three; then again it could still be two.";
            //    System.Text.StringBuilder stringBuilder = new StringBuilder();
            //    stringBuilder.Append(str);
            //    Console.WriteLine(str.Words());
            //    Console.WriteLine(stringBuilder.Words());
            //    Console.WriteLine(str.Lines());
            //    Console.WriteLine(stringBuilder.Lines());
        }

        enum testEnum { first, second, third };
        static bool TestExtensions()
        {
            string s1, s2, tempStr;
            TimeSpan t1, t2;
            DateTime start;

            s1 = "ABC12345";
            s2 = "ABC12345";
            start = DateTime.UtcNow;
            for (int x = 0; x < 1000000; x++)
            {
                System.Text.RegularExpressions.Regex.Replace(s1, @"^[A-Za-z]+", "");
            }
            t1 = DateTime.UtcNow - start;
            start = DateTime.UtcNow;
            for (int x = 0; x < 1000000; x++)
            {
                s2.Where(char.IsDigit).ToArray();
            }
            t2 = DateTime.UtcNow - start;



            "sos".ToMorseCode().MorseCodeBeep();

            //Test System.String.ToBinary() and
            //Test System.Text.StringStringBuilder.ToBinary()
            string str = "This is a test";
            Console.WriteLine(str);
            str = str.ToBinary();
            Console.WriteLine(str);

            //Test System.String.ToEnum() and
            //Test System.Text.StringStringBuilder.ToEnum()
            var testEnumResult = "first".ToEnum<testEnum>();
            Console.WriteLine(testEnumResult == testEnum.first);

            //Test System.Object.Set() and 
            //     System.Object.Get()
            string s = "abc";
            Console.WriteLine(s);
            s.Set("s", (object)"xyz");
            Console.WriteLine(s);
            s = (string)s.Get("s");
            Console.WriteLine(s);
            int i = 3;
            Console.WriteLine(i);
            i.Set("i", (object)9);
            Console.WriteLine(i);
            i = (int)i.Get("i");
            Console.WriteLine(i);
            Console.WriteLine(i.Get("s"));
            Console.WriteLine(s.Get("i"));

            //Test System.String.LoremIpsum() and 
            //     System.Text.StringBuilder.LoremIpsum()
            Console.WriteLine("abc".LoremIpsum(2).ToBinary());
            if ("abc".LoremIpsum(2).ToBinary().Length == 8721)
            {
                return true;
            }
            return false;
        }


    }
}
