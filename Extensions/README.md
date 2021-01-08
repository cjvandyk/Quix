# Extensions.dll contains extension methods that enhance existing C# classes thus making life easier for developers.

The following classes have been extended:

  - System.Diagnostics.Process
  - System.String
  - System.Text.StringBuilder

with these methods:

   -  `Elevate()`
      > _Restarts the current process with elevated permissions.<br>
         For example:<br>
           System.Diagnostics.Process.GetCurrentProcess().Elevate(args)<br>
           will restart the current console app in admin mode._

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
       it doesn't.
       For example:<br>
         "abcXYZ".IsAlphabetic()<br>
         will return True whereas<br>
         "abc123".IsAlphabetic()<br>
         will return False._
    
  - `IsNumeric()`
    > _Validates that the given string object contains all numeric 
       characters (0-9) returning True if it does and False  if it
       doesn't.
       For example:<br>
         "123456".IsNumeric()<br>
         will return True whereas<br>
         "abc123".IsNumeric()<br>
         will return False._

  - `IsAlphaNumeric()`
    > _Validates that the given string object contains all alphabetic 
       and/or numeric characters (a-z and A-Z and 0-9) returning True if it 
       does and False  if it doesn't.
       For example:<br>
         "abc123".IsAlphaNumeric()<br>
         will return True whereas<br>
         "abcxyz".IsAlphaNumeric()<br>
         will also return True and<br>
         "123456".IsAlphaNumeric()<br>
         will also return True but<br>
         "abc!@#".IsAlphaNumeric()<br>
         will return False._
    
  - `IsChar()`
    > _This method takes a char[] as one of its arguments against which the
       given string object is validated.  If the given string object contains
       only characters found in the char[] it will return True, otherwise it
       will return False.
       For example:<br>
         "aacc".IsChar(new char[] {'a', 'c'})<br>
         will return True whereas<br>
         "abc123".IsNumeric()<br>
         will return False._
   
  - `IsUrlRoot()`
    > _Check if the given string object containing a URL, is that of the<br>
       URL root only.  Returns True if so, False if not.<br>
       For example:<br>
         "https://cjvandyk.sharepoint.com".IsUrlRootOnly()<br>
         will return True whereas<br>
         "https://cjvandyk.sharepoint.com/sites/Approval".IsUrlRootOnly()<br>
         will return False._

  - `Lines()`
    > _This method returns the number of lines/sentences in the given string
       object._

  - `LoremIpsum()`
    > _Poplates the given string with a given number of paragraphs of dummy
       text in the lorem ipsum style e.g.
       "".LoremIpsum(2)
       would yield
       "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer 
        aliquam arcu rhoncus erat consectetur, quis rutrum augue tincidunt. 
        Suspendisse elit ipsum, lobortis lobortis tellus eu, vulputate 
        fringilla lorem. Cras molestie nibh sed turpis dapibus sollicitudin 
        ut a nulla. Suspendisse blandit suscipit egestas. Nunc et ante mattis 
        nulla vehicula rhoncus. Vivamus commodo nunc id ultricies accumsan. 
        Mauris vitae ante ut justo venenatis tempus.
        
        Nunc posuere, nisi eu convallis convallis, quam urna sagittis ipsum, 
        et tempor ante libero ac ex. Aenean lacus mi, blandit non eros luctus, 
        ultrices consectetur nunc. Vivamus suscipit justo odio, a porta massa 
        posuere ac. Aenean varius leo non ipsum porttitor eleifend. Phasellus 
        accumsan ultrices massa et finibus. Nunc vestibulum augue ut bibendum 
        facilisis. Donec est massa, lobortis quis molestie at, placerat a 
        neque. Donec quis bibendum leo. Pellentesque ultricies ac odio id 
        pharetra. Nulla enim massa, lacinia nec nunc nec, egestas pulvinar 
        odio. Sed pulvinar molestie justo, eu hendrerit nunc blandit eu. 
        Suspendisse et sapien quis ipsum scelerisque rutrum."

  - `ReplaceTokens()`
    > _Takes a given string object and replaces 1 to n tokens in the string
       with replacement tokens as defined in the given Dictionary of strings._

  - `Words()`
    > _This method returns the number of words used in the given string
       object.
       For example:<br>
         "This is my test".Words()<br>
         will return 4 whereas<br>
         "ThisIsMyTest".Words()<br>
         will return 1._
