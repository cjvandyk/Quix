# Quix.dll contains extension methods that enhance existing C# classes thus making life easier for developers.

The following classes have been extended:

  - System.String
  - System.Text.StringBuilder

with these methods:

  - `GetUrlRoot()`
    > _Get the URL root for the given string object containing a URL.<br>
       For example:<br>
          "https://cjvandyk.sharepoint.com".GetUrlRoot()<br>
          will return "https://cjvandyk.sharepoint.com" whereas<br>
          "https://cjvandyk.sharepoint.com/sites/Approval".GetUrlRoot()<br>
          will also return "https://cjvandyk.sharepoint.com"._

  - `IsAlphabetic()`
    > _Validates that the given string object contains all alphabetic
       characters (a-z and A-Z) returning True if it does and False if 
       it doesn't._
    
  - `IsNumeric()`
    > _Validates that the given string object contains all numeric 
       characters (0-9) returning True if it does and False  if it
       doesn't._
    
  - `IsAlphaNumeric()`
    > _Validates that the given string object contains all alphabetic 
       and/or numeric characters (a-z and A-Z and 0-9) returning True if it 
       does and False  if it doesn't._
    
  - `IsChar()`
    > _This method takes a char[] as one of its arguments against which the
       given string object is validated.  If the given string object contains
       only characters found in the char[] it will return True, otherwise it
       will return False._
   
  - `IsUrlRoot()`
    > _Check if the given string object containing a URL, is that of the
       URL root only.  Returns True if so, False if not.  For example:<br>
          "https://cjvandyk.sharepoint.com".IsUrlRootOnly()<br>
          will return True whereas<br>
          "https://cjvandyk.sharepoint.com/sites/Approval".IsUrlRootOnly()<br>
          will return False._

  - `Lines()`
    > _This method returns the number of lines/sentences in the given string
       object._

  - `Words()`
    > _This method returns the number of words used in the given string
       object._
