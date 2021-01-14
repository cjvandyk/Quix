# Quix Utilities

[![Join the chat at https://gitter.im/ExtensionsCS/community](https://badges.gitter.im/ExtensionsCS/community.svg)](https://gitter.im/ExtensionsCS/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

A suite of tools and utilities to assist with C# development.
The toolset contains the following projects:
 - Extensions
   Extensions.dll contains extension methods that enhance existing C# classes thus making life easier for developers.
   The following classes have been extended:
     System.Diagnostics.Process
     System.String
     System.Text.StringBuilder
   with these methods:
   
   - ### ***Elevate()***
      > _Restarts the current process with elevated permissions.<br>
         For example:<br>
           `System.Diagnostics.Process.GetCurrentProcess().Elevate(args)`<br>
           will restart the current console app in admin mode._
           
   - ### ***GetUrlRoot()***
      > _Get the URL root for the given string object containing a URL.<br>
         For example:<br>
           `"https://cjvandyk.sharepoint.com".GetUrlRoot()`<br>
           will return "https://cjvandyk.sharepoint.com" whereas<br>
           `"https://cjvandyk.sharepoint.com/sites/Approval".GetUrlRoot()`<br>
           will also return "https://cjvandyk.sharepoint.com"._
           
   - ### ***IsAlphabetic()***
      > _Validates that the given string object contains all alphabetic
         characters (a-z and A-Z) returning True if it does and False if 
         it doesn't.
         For example:<br>
           `"abcXYZ".IsAlphabetic()`<br>
           will return True whereas<br>
           `"abc123".IsAlphabetic()`<br>
           will return False._
           
   - ### ***IsNumeric()***
      > _Validates that the given string object contains all numeric 
         characters (0-9) returning True if it does and False  if it
         doesn't.
         For example:<br>
           `"123456".IsNumeric()`<br>
           will return True whereas<br>
           `"abc123".IsNumeric()`<br>
           will return False._
           
   - ### ***IsAlphaNumeric()***
      > _Validates that the given string object contains all alphabetic 
         and/or numeric characters (a-z and A-Z and 0-9) returning True if it 
         does and False  if it doesn't.
         For example:<br>
           `"abc123".IsAlphaNumeric()`<br>
           will return True whereas<br>
           `"abcxyz".IsAlphaNumeric()`<br>
           will also return True and<br>
           `"123456".IsAlphaNumeric()`<br>
           will also return True but<br>
           `"abc!@#".IsAlphaNumeric()`<br>
           will return False._
           
   - ### ***IsChar()***
      > _This method takes a char[] as one of its arguments against which the
         given string object is validated.  If the given string object contains
         only characters found in the char[] it will return True, otherwise it
         will return False.
         For example:<br>
           `"aacc".IsChar(new char[] {'a', 'c'})`<br>
           will return True whereas<br>
           `"abc123".IsChar(new char[] {'a', 'c'})`<br>
           will return False._
   
   - ### ***IsUrlRoot()***
      > _Check if the given string object containing a URL, is that of the<br>
         URL root only.  Returns True if so, False if not.<br>
         For example:<br>
           `"https://cjvandyk.sharepoint.com".IsUrlRootOnly()`<br>
           will return True whereas<br>
           `"https://cjvandyk.sharepoint.com/sites/Approval".IsUrlRootOnly()`<br>
           will return False._
           
   - ### ***Lines()***
      > _This method returns the number of lines/sentences in the given string
         object._
         
   - ### ***LoremIpsum()***
      > _Poplates the given string with a given number of paragraphs of dummy<br>
         text in the lorem ipsum style e.g.<br>
         `"".LoremIpsum(2)`<br>
         would yield:<br>
         "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer 
          aliquam arcu rhoncus erat consectetur, quis rutrum augue tincidunt. 
          Suspendisse elit ipsum, lobortis lobortis tellus eu, vulputate 
          fringilla lorem. Cras molestie nibh sed turpis dapibus sollicitudin 
          ut a nulla. Suspendisse blandit suscipit egestas. Nunc et ante mattis 
          nulla vehicula rhoncus. Vivamus commodo nunc id ultricies accumsan. 
          Mauris vitae ante ut justo venenatis tempus.<br><br>
          Nunc posuere, nisi eu convallis convallis, quam urna sagittis ipsum, 
          et tempor ante libero ac ex. Aenean lacus mi, blandit non eros luctus, 
          ultrices consectetur nunc. Vivamus suscipit justo odio, a porta massa 
          posuere ac. Aenean varius leo non ipsum porttitor eleifend. Phasellus 
          accumsan ultrices massa et finibus. Nunc vestibulum augue ut bibendum 
          facilisis. Donec est massa, lobortis quis molestie at, placerat a 
          neque. Donec quis bibendum leo. Pellentesque ultricies ac odio id 
          pharetra. Nulla enim massa, lacinia nec nunc nec, egestas pulvinar 
          odio. Sed pulvinar molestie justo, eu hendrerit nunc blandit eu. 
          Suspendisse et sapien quis ipsum scelerisque rutrum."_
          
   - ### ***ReplaceTokens()***
      > _Takes a given string object and replaces 1 to n tokens in the string
         with replacement tokens as defined in the given Dictionary of strings._
         
   - ### ***Words()***
      > _This method returns the number of words used in the given string
         object.
         For example:<br>
           `"This is my test".Words()`<br>
           will return 4 whereas<br>
           `"ThisIsMyTest".Words()`<br>
           will return 1._


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
 
