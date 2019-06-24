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

namespace Quix
{
    public static class Core
    {
        /// <summary>
        /// This method will save the current console foreground color
        /// and then write the parameter passed ErrorMessage to the 
        /// console output in Red as an error before restoring the
        /// console foreground to the original color it had before
        /// the method was called.
        /// </summary>
        /// <param name="errorMessage">Output to write.</param>
        public static void writeConsoleError(string errorMessage)
        {
            // Save the current console foreground color;
            ConsoleColor clr = Console.ForegroundColor;
            // Set console output to red.
            Console.ForegroundColor = ConsoleColor.Red;
            // Write the error.
            Console.WriteLine(errorMessage);
            // Reset the console color.
            Console.ForegroundColor = clr;
        }

        /// <summary>
        /// Turn the currently running assembly name into a pathed file name
        /// string that can be used as a log file name.
        /// This method can also be called with a (false) paremeter to simply
        /// return the fully qualified path to the current executing assembly
        /// file name.
        /// </summary>
        /// <returns>Unique string representing the fully qualified path to
        ///          the executing assembly with spaces in the file name
        ///          portion of the string replaced by underscores e.g.
        ///          C:\Users\CvD\My Documents\App Name.exe
        ///          becomes
        ///          C:\Users\CvD\My Documents\App_Name.exe</returns>
        public static string getExecutingAssemblyFileName(bool noSpacesInFileName = true)
        {
            // No logging code should EVER terminate it's parent program 
            // through exceptions.
            try
            {
                return System.IO.Path.GetDirectoryName(
                           System.Reflection.Assembly.GetEntryAssembly()
                           .Location).TrimEnd('\\') + "\\" +  // Ensure no double
                                                              // trailing slash.
                       System.Uri.EscapeDataString(
                           System.Reflection.Assembly.GetEntryAssembly()
                           .ManifestModule.Name.Replace(" ", "_"));
            }
            catch (Exception ex)
            {
                // Write exception to Event Log.
                System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString());
                // Write exception info to the console in RED.
                writeConsoleError(ex.ToString());
                //Return empty string instead of null as null could cause
                // an exception to be trown by the calling code.
                return "";
            }
        }

        /// <summary>
        /// Strip "http://" and "https://" headers from URLs and replace
        /// forward slashes (/) with underscores (_) and spaces with 
        /// dashes (-).
        /// This is useful for turning a web URL into a log file name or
        /// part thereof.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string htmlStrip(string url)
        {
            // No logging code should EVER terminate it's parent program 
            // through exceptions.
            try
            {
                return url.ToLower().Replace("https://", "").Replace("http://", "")
                .Replace("/", "_").Replace(" ", "-");
            }
            catch (Exception ex)
            {
                // Write exception info to the console in RED.
                writeConsoleError(ex.ToString());
                //Return empty string instead of null as null could cause
                // an exception to be trown by the calling code.
                return "";
            }
        }

        /// <summary>
        /// This method returns the current date/time value as a string
        /// stamp in the format yyyyMMdd@hhmmss e.g. 20170704@090301567
        /// </summary>
        /// <returns></returns>
        public static string timeStamp()
        {
            // No logging code should EVER terminate it's parent program 
            // through exceptions.
            try
            {
                return DateTime.Now.Year.ToString() + "-" +
                    DateTime.Now.Month.ToString("d2") + "-" +
                    DateTime.Now.Day.ToString("d2") + "@" +
                    DateTime.Now.Hour.ToString("d2") + "." +
                    DateTime.Now.Minute.ToString("d2") + "." +
                    DateTime.Now.Second.ToString("d2") + "." +
                    DateTime.Now.Millisecond.ToString("d3");
            }
            catch (Exception ex)
            {
                writeConsoleError(ex.ToString());
                //Return empty string instead of null as null could cause
                // an exception to be trown by the calling code.
                return "";
            }
        }
    }
}
