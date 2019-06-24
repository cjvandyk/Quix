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
    /// <summary>
    /// Usage : Quix.Logging log = new Quix.Logging();
    ///         log.Init(); //This will initialize the log file to be in the 
    ///                       executing assembly's folder with the assembly's
    ///                       name, spaces replaced with underscores and .log
    ///                       appended to the end e.g. Run.exe.log
    ///         or
    ///         log.Init("Test"); //This will do the same initialization, but
    ///                             will concatenate the user's string to the
    ///                             name of the log file before the .log
    ///                             extention e.g. Run.exe.Test.log
    ///         log.Log("Whatever you wish to log");
    /// Content is written to the log file with a date/time stamp preceding
    /// the user's string that is logged to allow for precise identification
    /// of executed actions.
    /// The date/time stamp format is yyyyMMdd@hhmmssfff.
    /// </summary>
    public static class Static
    {
        /// <summary>
        /// Used to save the cursor output position and console color when 
        /// static screen output is needed.
        /// </summary>
        private static int _cursorLeft, _cursorTop;
        private static ConsoleColor _outputColor;
        /// <summary>
        /// Contains the path of the log file.
        /// </summary>
        private static string _logPath = 
            Quix.Core.getExecutingAssemblyFileName() + Quix.Core.timeStamp()
            + ".log";
        /// <summary>
        /// The output log file stream.
        /// </summary>
        private static System.IO.StreamWriter _writer = 
            new System.IO.StreamWriter(_logPath, true);
        /// <summary>
        /// When set to true, will output logging content to the console
        /// as well as the log file.  Default = true;
        /// </summary>
        public static bool logToConsole { get; set; } = true;

        /// <summary>
        /// Initialize the log file path, but include an identifying string
        /// provided by the caller, in the name of the log file.
        /// The log file can be changed at any time by a call to the 
        /// Initialize() method as the inclusion of the caller provided
        /// string in the log file name will cause the log file to be 
        /// different from the default that was initialized upon class
        /// creation, provided a non null string was passed as the 
        /// logFileString.  Any spaces in the logFileString are replaced by
        /// dashed (-) in the process.  The current log file can also be 
        /// changed by simply calling this method again and providing a 
        /// different caller provided string at any time.  This allows the 
        /// calling code the ability to log certain parts of the code in one 
        /// log file and then change the log file for other parts of the code 
        /// providing maximum flexibility.
        /// </summary>
        /// <param name="logFileString"></param>
        public static void reInitializeLogFile(string logFileString = null)
        {
            // No logging code should EVER terminate it's parent program 
            // through exceptions.
            try
            {
                try
                {
                    _writer.Flush();
                    _writer.Close();
                    _writer.Dispose();
                }
                catch { }  // Swallow exception if there's a problem flushing
                           // the file.
                if (logFileString == null)
                {
                    _logPath = Quix.Core.getExecutingAssemblyFileName() + 
                        Quix.Core.timeStamp() + ".log";
                }
                else
                {
                    _logPath = Quix.Core.getExecutingAssemblyFileName() + 
                        Quix.Core.timeStamp() + "." + 
                        System.Uri.EscapeDataString(logFileString.Replace(
                            " ", "-")) + ".log";
                }
                _writer = new System.IO.StreamWriter(_logPath, true);
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Warning);
                // Write exception info to the console in RED.
                Quix.Core.writeConsoleError(ex.ToString());
            }
        }

        /// <summary>
        /// Log the message to the log file, provided the logging was 
        /// initialized.
        /// </summary>
        /// <param name="message">The message being logged.</param>
        /// <param name="noTimeStamp">Used to override the default inclusion
        /// of date/time stamp in each logged line.</param>
        /// <param name="staticOutputLocation">Used to set console output to a
        /// fixed location.  This is useful for output such as progress
        /// percentage etc.</param>
        /// <returns>true if logging was successful, false if not.</returns>
        public static bool Log(string message, bool noTimeStamp = false,
            bool staticOutputLocation = false)
        {
            // No logging code should EVER terminate it's parent program 
            // through exceptions.
            try
            {
                // We use a single & because if we're not logging to the 
                // console, it does not matter to what value 
                // staticOutputLocation is set.  The use of single & prevents
                // run time evaluation of the value of staticOutputLocation
                // if logToConsole is false thus improving runtime execution
                // performance.
                if (logToConsole & staticOutputLocation)
                {
                    // We want static location output so we capture the current
                    // cursor location.
                    _cursorLeft = Console.CursorLeft;
                    _cursorTop = Console.CursorTop;
                }
                // Write to the log file.
                _writer.WriteLine(prependTimeStamp(message, noTimeStamp));
                // Flush the writer so no messages are stuck in the buffer.
                _writer.Flush();
                // Check if console output is required.
                if (logToConsole)
                {
                    // Are we keeping output in a static location?
                    if (staticOutputLocation)
                    {
                        // Reset the cursor before output.
                        Console.CursorTop = _cursorTop;
                        Console.CursorLeft = _cursorLeft;
                        // Output the message with a large trailing
                        // blank to clear previous output from the static 
                        // console line.
                        Console.WriteLine(
                            prependTimeStamp(message, noTimeStamp) +
                            "                                               " +
                            "                                               " +
                            "                         ");
                        // Reset the cursor after output.
                        Console.CursorTop = _cursorTop;
                        Console.CursorLeft = _cursorLeft;
                    }
                    // No static output location is required.
                    else
                    {
                        // Simply write the message to the console.
                        Console.WriteLine(prependTimeStamp(
                            message, noTimeStamp));
                    }
                }
            }
            // Something went wrong.
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Warning);
                _outputColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                // Check if output is going to the console.
                if (logToConsole)
                {
                    // Write console output, stamped if needed.
                    Console.WriteLine(
                        prependTimeStamp(ex.ToString(), noTimeStamp));
                }
                // No logging code should EVER terminate it's parent program 
                // through exceptions.  Wrap this file output in a try/catch
                // in case file writing throws an exception.
                try
                {
                    // Reset the writer to open log file in append mode.
                    using (System.IO.StreamWriter writer = 
                        new System.IO.StreamWriter(_logPath, true))
                    {
                        // Write the exception to the log file, stamped if 
                        // needed.
                        writer.WriteLine(
                            prependTimeStamp(ex.ToString(), noTimeStamp));
                        // Flush the file writer buffer.
                        writer.Flush();
                    }
                }
                // Have to distinguish between inner and outer exceptions.
                catch (Exception ex2)
                {
                    System.Diagnostics.EventLog.WriteEntry("Application", ex2.ToString(), System.Diagnostics.EventLogEntryType.Warning);
                    // Write the inner exception error.
                    Quix.Core.writeConsoleError(ex2.ToString());
                }
                // Reset the console foreground color.
                Console.ForegroundColor = _outputColor;
                // Return false since something went wrong during logging.
                return false;
            }
            // Logging succeeded.
            return true;
        }

        /// <summary>
        /// This method will write an error message with extended error
        /// handling in case there's console output issues so as to 
        /// preserve stability.
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static bool Error(string Message)
        {
            // No logging code should EVER terminate it's parent program 
            // through exceptions.
            try
            {
                Quix.Core.writeConsoleError("ERROR!!! >>> " + Message);
            }
            // As a super method, just swallow the error.
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Used to build output text with or without the date/time stamp
        /// depending on the value of noTimeStamp.
        /// </summary>
        /// <param name="message">The message to stamp if needed.</param>
        /// <returns>A string message that is stamped if needed.  The default
        /// is to stamp the message.</returns>
        public static string prependTimeStamp(
            string message, bool noTimeStamp = false)
        {
            // No logging code should EVER terminate it's parent program 
            // through exceptions.
            try
            {
                if (noTimeStamp)
                {
                    // No timestamp needed.  Simply return the message.
                    return message;
                }
                // The inclusion of a comma (,) between the timestamp and the
                // message is intentional.  This allows for importing of log
                // file output into a spreadsheet via comma separated value 
                // (CSV) format while splitting timestamps and messages for
                // sorting and filtering purposes.
                return Quix.Core.timeStamp() + "  >>>  ," + message;
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Warning);
                Quix.Core.writeConsoleError(ex.ToString());
                //Return empty string instead of null as null could cause
                // an exception to be trown by the calling code.
                return "";
            }
        }
    }
}
