# Quix Utilities
A suite of tools and utilities to assist with C# development.
The toolset contains the following projects:
 - Quix.Core
   Quix.Core contains common useful methods such as:
   - `public static void writeConsoleError(string errorMessage)`
     > _Used to capture the current console foreground color, change it to red, write the error message and then change the foreground color back to the original color._
   - `public static string getExecutingAssemblyFileName(bool noSpacesInFileName = true)`
     > _Used to get the full folder path and name of the currently executing assembly._
   - `public static string htmlStrip(string url)`
     > _Used to get a log file usable string of the current HTML URI by stripping off "https://" or "http://", replacing forward slash ( / ) with underscore ( _ ) and spaces with dash ( - )._
   - `public static string timeStamp()`
     > _Used to get a string representation of the current date/time stamp in the format "yyyy-MM-dd@hh.mm.ss.ttt" ex. "2019-07-18@14.54.26.825._
   - `public static Microsoft.Win32.RegistryKey getRegistryKey(string registryPath)`
     > _Used to get a given Registry key based on the path e.g. "@"SOFTWARE\Microsoft\NET Framework Setup\NDP\._
   - `private static string getDotNET45PlusVersion()`
     > _Private method used by getDotNETVersion() to get the .NET version on the current computer when the version is 4.5 or later._
   - `private static string convert45PlusVersion(int versionNumber)`
     > _Used to convert the .NET build number into a human recognizable .NET version._
   - `public static string getDotNETVersion()`
     > _Used to get the .NET version on the current computer._
 - Quix.ThreadSafe
   Quix.ThreadSafe contains methods designed for working with Dictionary objects in a thread-safe manner.  The class contains methods such as:
   - `public static object Get(string key, ref Dictionary<string, object> dictionary, int timeout = 60000)`
     > _Used to get an object from the referenced Dictionary given it's key string._
   - `public static string Set(ref object value, string key, ref Dictionary<string, object> dictionary, int timeout = 60000)`
     > _Used to update an object in the referenced Dictionary given an object reference._
   - `public static string Add(ref object value, string key, ref Dictionary<string, object> dictionary, int timeout = 60000)`
     > _Used to add a referenced object to the referenced Dictionary using it's key string._
   - `public static string Remove(string key, ref Dictionary<string, object> dictionary, int timeout = 60000)`
     > _Used to remove an object from the referenced Dictionary given it's key string._
 - Quix.File
 - Quix.Logging
 - Quix.Testing
 
