#pragma warning disable IDE1006 // Naming Styles

using System;
/// <summary>
/// Author: Cornelius J. van Dyk blog.cjvandyk.com @cjvandyk  
/// This code is provided under GNU GPL 3.0 and is a copyrighted work of the
/// author and contributors.  Please see:
/// https://github.com/cjvandyk/Quix/blob/master/LICENSE
/// Source code has been held to 80 character width for printing and porting
/// reasons.
/// </summary>
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
    public class Logging:IDisposable
    {
        /// <summary>
        /// Used to save the cursor output position and console color when 
        /// static screen output is needed.
        /// </summary>
        private int cursorLeft, cursorTop;
        private ConsoleColor outputColor;
        /// <summary>
        /// The output log file stream.
        /// </summary>
        private System.IO.StreamWriter writer = null;

        /// <summary>
        /// Constructor method to auto initialize the logger.
        /// </summary>
        public Logging()
        {
            // No logging code should EVER terminate it's parent program 
            // through exceptions.
            try
            {
                Initialize();
                logToConsole = true;
            }
            catch (Exception ex)
            {
                // Write exception info to the console in RED.
                writeConsoleError(ex.ToString());
            }
        }

#region IDisposable Support
        private bool isDisposed = false; // Used to prevent redundant calls.

        protected virtual void Dispose(bool disposing)
        {
            // No logging code should EVER terminate it's parent program 
            // through exceptions.
            try
            {
                if (!isDisposed)  // First time called.
                {
                    if (disposing)
                    {
                        if (writer != null)  // writer is set to null upon object
                                             // initialization so if writer is not null
                                             // it should be disposed of.
                        {
                            try  // Wrap .Close() in a try/catch in case writer was
                                 // assigned but already closed.
                            {
                                writer.Close();
                                writer.Dispose();
                            }
                            catch (Exception ex)  // Caught when writer is already
                                                  // closed.
                            {
                                try
                                {
                                    writer.Dispose();
                                }
                                catch { } // Swallow exception.  No logging
                                          // code should EVER terminate it's parent
                                          // program through exceptions.
                            }
                        }
                    }
                    isDisposed = true;
                }
            }
            catch (Exception ex)
            {
                // Write exception info to the console in RED.
                writeConsoleError(ex.ToString());
            }
        }

        /// <summary>
        /// Class destructor.
        /// </summary>
        ~Logging()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        /// <summary>
        /// Destructor method to dispose of held objects.
        /// </summary>
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
#endregion

        /// <summary>
        /// Contains the path of the log file.
        /// </summary>
        public string logPath { get; set; }

        /// <summary>
        /// Is set to true when the log path is initialized.
        /// Logging will only succeed on True since the writer has to be
        /// initialized.
        /// </summary>
        private bool Initialized { get; set; }

        /// <summary>
        /// When set to true, will output logging content to the console
        /// as well as the log file.  Default = true;
        /// </summary>
        public bool logToConsole { get; set; } = true;

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
        public string getExecutingAssemblyFileName(bool noSpacesInFileName = true)
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
                // Write exception info to the console in RED.
                writeConsoleError(ex.ToString());
                //Return empty string instead of null as null could cause
                // an exception to be trown by the calling code.
                return "";
            }
        }

        /// <summary>
        /// Initialize the log file path.
        /// This method is intentionally left as "public" because:
        /// 1. It enables manually forcing initialization if needed.
        /// 2. It is non destructive as the writer stream is opened in append
        ///    mode.
        /// This is useful in cases where the executing assembly was initiated
        /// from removable media and the media has become unavailable since
        /// execution initiation because the writer stream log file is
        /// co-located with the executing assembly.
        /// </summary>
        public void Initialize()
        {
            // No logging code should EVER terminate it's parent program 
            // through exceptions.
            try
            {
                logPath = getExecutingAssemblyFileName() + TimeStamp() + ".log";
                writer = new System.IO.StreamWriter(logPath, true);
                Initialized = true;
            }
            catch (Exception ex)
            {
                // Write exception info to the console in RED.
                writeConsoleError(ex.ToString());
            }
        }

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
        public void Initialize(string logFileString)
        {
            // No logging code should EVER terminate it's parent program 
            // through exceptions.
            try
            {
                logPath = getExecutingAssemblyFileName() + TimeStamp() + "." +
                    System.Uri.EscapeDataString(logFileString.Replace(" ", "-")) +
                    ".log";
                writer = new System.IO.StreamWriter(logPath, true);
                Initialized = true;
            }
            catch (Exception ex)
            {
                // Write exception info to the console in RED.
                writeConsoleError(ex.ToString());
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
        public string htmlStrip(string url)
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
        /// Log the message to the log file, provided the logging was initialized.
        /// </summary>
        /// <param name="message">The message being logged.</param>
        /// <param name="noTimeStamp">Used to override the default inclusion
        /// of date/time stamp in each logged line.</param>
        /// <param name="staticOutputLocation">Used to set console output to a
        /// fixed location.  This is useful for output such as progress
        /// percentage etc.</param>
        /// <returns>true if logging was successful, false if not.</returns>
        public bool Log(string message, bool noTimeStamp = false, 
            bool staticOutputLocation = false)
        {
            // Check if log file was initialized.
            if (!Initialized)  
            {
                // Since the log file is not initialized, we write and error
                // message to the console and return false.
                writeConsoleError("Quix.Logging NOT initialized." +
                    "  Call Quix.Logging.Initialize();");
                return false;
            }
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
                    cursorLeft = Console.CursorLeft;
                    cursorTop = Console.CursorTop;
                }
                // Write to the log file.
                writer.WriteLine(appendTimeStamp(message, noTimeStamp));
                // Flush the writer so no messages are stuck in the buffer.
                writer.Flush();
                // Check if console output is required.
                if (logToConsole)
                {
                    // Are we keeping output in a static location?
                    if (staticOutputLocation)
                    {
                        // Reset the cursor before output.
                        Console.CursorTop = cursorTop;
                        Console.CursorLeft = cursorLeft;
                        // Output the message with a large trailing
                        // blank to clear previous output from the static 
                        // console line.
                        Console.WriteLine(
                            appendTimeStamp(message, noTimeStamp) +
                            "                                                                                                                       ");
                        // Reset the cursor after output.
                        Console.CursorTop = cursorTop;
                        Console.CursorLeft = cursorLeft;
                    }
                    // No static output location is required.
                    else
                    {
                        // Simply write the message to the console.
                        Console.WriteLine(message);
                    }
                }
            }
            // Something went wrong.
            catch (Exception ex)
            {
                outputColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                // Check if output is going to the console.
                if (logToConsole)
                {
                    // Write console output, stamped if needed.
                    Console.WriteLine(appendTimeStamp(ex.ToString(), noTimeStamp));
                }
                // No logging code should EVER terminate it's parent program 
                // through exceptions.  Wrap this file output in a try/catch
                // in case file writing throws an exception.
                try
                {
                    // Reset the writer to open log file in append mode.
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(logPath, true))
                    {
                        // Write the exception to the log file, stamped if needed.
                        writer.WriteLine(appendTimeStamp(ex.ToString(), noTimeStamp));
                        // Flush the file writer buffer.
                        writer.Flush();
                    }
                }
                // Have to distinguish between inner and outer exceptions.
                catch (Exception ex2)
                {
                    // Write the inner exception error.
                    writeConsoleError(ex2.ToString());
                }
                // Reset the console foreground color.
                Console.ForegroundColor = outputColor;
                // Return false since something went wrong during logging.
                return false;
            }
            // Logging succeeded.
            return true;
        }

        /// <summary>
        /// Used to build output text with or without the date/time stamp
        /// depending on the value of noTimeStamp.
        /// </summary>
        /// <param name="message">The message to stamp if needed.</param>
        /// <returns>A string message that is stamped if needed.  The default
        /// is to stamp the message.</returns>
        public string appendTimeStamp(string message, bool noTimeStamp = false)
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
                // message is intentional.  This allows for importing of log file
                // output into a spreadsheet via comma separated value (CSV) format
                // while splitting timestamps and messages for sorting and
                // filtering purposes.
                return TimeStamp() + "  >>>  ," + message;
            }
            catch (Exception ex)
            {
                writeConsoleError(ex.ToString());
                //Return empty string instead of null as null could cause
                // an exception to be trown by the calling code.
                return "";
            }
        }

        /// <summary>
        /// This method will save the current console foreground color
        /// and then write the parameter passed ErrorMessage to the 
        /// console output in Red as an error before restoring the
        /// console foreground to the original color it had before
        /// the method was called.
        /// </summary>
        /// <param name="errorMessage">Output to write.</param>
        public void writeConsoleError(string errorMessage)
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
        /// This method will write an error message with extended error
        /// handling in case there's console output issues so as to 
        /// preserve stability.
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public bool Error(string Message)
        {
            // No logging code should EVER terminate it's parent program 
            // through exceptions.
            try
            {
                writeConsoleError("ERROR!!! >>> " + Message);
            }
            // As a super method, just swallow the error.
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// This method returns the current date/time value as a string
        /// stamp in the format yyyyMMdd@hhmmss e.g. 20170704@090301567
        /// </summary>
        /// <returns></returns>
        public string TimeStamp()
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
