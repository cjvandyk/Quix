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
 - Quix.File
 - Quix.Logging
 - Quix.Testing
 
