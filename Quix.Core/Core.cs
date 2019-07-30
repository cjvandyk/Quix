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
        public static string getExecutingAssemblyFileName(
            bool noSpacesInFileName = true)
        {
            // No logging code should EVER terminate it's parent program 
            // through exceptions.
            try
            {
                return System.IO.Path.GetDirectoryName(
                           System.Reflection.Assembly.GetEntryAssembly()
                           .Location).TrimEnd('\\') + "\\" +  //Ensure no double
                                                              //trailing slash.
                       System.Uri.EscapeDataString(
                           System.Reflection.Assembly.GetEntryAssembly()
                           .ManifestModule.Name.Replace(" ", "_"));
            }
            catch (Exception ex)
            {
                // Write exception to Event Log.
                System.Diagnostics.EventLog.WriteEntry("Application", 
                    ex.ToString(), System.Diagnostics.EventLogEntryType.Warning);
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
                return url.ToLower()
                    .Replace("https://", "")
                    .Replace("http://", "")
                    .Replace("/", "_")
                    .Replace(" ", "-");
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

        /// <summary>
        /// Returns the base RegistryKey from the Windows registry.
        /// </summary>
        /// <param name="registryPath">The registry path beyond HKLM.</param>
        /// <returns>Microsoft.Win32.RegistryKey</returns>
        public static Microsoft.Win32.RegistryKey getRegistryKey(
            string registryPath)
        {
            return Microsoft.Win32.RegistryKey.OpenBaseKey(
                    Microsoft.Win32.RegistryHive.LocalMachine,
                    Microsoft.Win32.RegistryView.Registry32)
                .OpenSubKey(registryPath);
        }

        /// <summary>
        /// Private method to return .NET version string when version is 4.5+
        /// </summary>
        /// <returns>String containing the version</returns>
        private static string getDotNET45PlusVersion()
        {
            const string registrySubKeyPath =
                @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";
            string returnString = "";
            using (var registryBaseKey = getRegistryKey(registrySubKeyPath))
            {
                if (registryBaseKey != null && registryBaseKey
                    .GetValue("Release") != null)
                {
                    returnString = 
                        convert45PlusVersion((int)registryBaseKey
                        .GetValue("Release"));
                }
                else
                {
                    returnString = $"Unable to detect .NET version!";
                }
            }
            return returnString;
        }

        // Checking the version using >= enables forward compatibility.
        /// <summary>
        /// Private method to convert registry version number to real world
        /// number.
        /// </summary>
        /// <param name="versionNumber">The registry version number.</param>
        /// <returns>String containing the version number.</returns>
        private static string convert45PlusVersion(int versionNumber)
        {
            if (versionNumber >= 528040)
                return "4.8 or later";
            if (versionNumber >= 461808)
                return "4.7.2";
            if (versionNumber >= 461308)
                return "4.7.1";
            if (versionNumber >= 460798)
                return "4.7";
            if (versionNumber >= 394802)
                return "4.6.2";
            if (versionNumber >= 394254)
                return "4.6.1";
            if (versionNumber >= 393295)
                return "4.6";
            if (versionNumber >= 379893)
                return "4.5.2";
            if (versionNumber >= 378675)
                return "4.5.1";
            if (versionNumber >= 378389)
                return "4.5";
            // This code should never execute. A non-null release key should
            // mean that 4.5 or later is installed.
            return "No 4.5 or later version detected";
        }

        /// <summary>
        /// Public method to get the .NET version number.
        /// </summary>
        /// <returns>String containing the .NET version number.</returns>
        public static string getDotNETVersion()
        {
            const string registrySubKeyPath =
                @"SOFTWARE\Microsoft\NET Framework Setup\NDP\";
            string returnString = "";
            bool ver45PlusPresent = false;
            using (var registryBaseKey = getRegistryKey(registrySubKeyPath))
            {
                foreach (var versionKeyName in registryBaseKey.GetSubKeyNames())
                {
                    if (versionKeyName == "v4")
                    {
                        returnString += "\n" + getDotNET45PlusVersion();
                        ver45PlusPresent = true;
                    }
                    else if (versionKeyName.StartsWith("v4.0") && 
                        ver45PlusPresent)
                    {
                        continue;
                    }
                    else if (versionKeyName.StartsWith("v"))
                    {
                        Microsoft.Win32.RegistryKey versionKey = 
                            registryBaseKey.OpenSubKey(versionKeyName);
                        // Get the .NET Framework version value.
                        var name = (string)versionKey.GetValue("Version", "");
                        // Get the service pack (SP) number.
                        var sp = versionKey.GetValue("SP", "").ToString();
                        // Get the installation flag, or an empty string if 
                        // there is none.
                        var install = versionKey.GetValue("Install", "")
                            .ToString();
                        if (string.IsNullOrEmpty(install)) // No install info; 
                                                           // it must be in a 
                                                           // child subkey.
                        {
                            returnString += "\n" + $"{versionKeyName}  {name}";
                        }
                        else
                        {
                            if (!(string.IsNullOrEmpty(sp)) && install == "1")
                            {
                                returnString += "\n" + $"{name} SP{sp}";
                            }
                        }
                        if (!string.IsNullOrEmpty(name))
                        {
                            continue;
                        }
                        foreach (var subKeyName in versionKey.GetSubKeyNames())
                        {
                            Microsoft.Win32.RegistryKey subKey = 
                                versionKey.OpenSubKey(subKeyName);
                            name = (string)subKey.GetValue("Version", "");
                            if (!string.IsNullOrEmpty(name))
                                sp = subKey.GetValue("SP", "").ToString();
                            install = subKey.GetValue("Install", "")
                                .ToString();
                            if (string.IsNullOrEmpty(install)) // No install
                                                               // info, it 
                                                               // must be 
                                                               // later.
                            {
                                returnString += "\n" + $"{versionKeyName}" +
                                    $"  {name}";
                            }
                            else
                            {
                                if (!(string.IsNullOrEmpty(sp))
                                    && install == "1")
                                {
                                    returnString += "\n" + $"{subKeyName}" +
                                        $"  {name}  SP{sp}";
                                }
                                else if (install == "1")
                                {
                                    returnString += "\n" + $"  {subKeyName}" +
                                        $"  {name}";
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(returnString);
            return returnString;
        }
    }
}
