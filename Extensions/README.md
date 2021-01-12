# Extensions.dll contains extension methods that enhance existing C# classes thus making life easier for developers.

The following classes have been extended:

    - System.Diagnostics.Process
    - System.Object
    - System.String
    - System.Text.StringBuilder

with these methods:

    - ### ***Elevate()***
        > Restarts the current process with elevated permissions.
            For example:
           `System.Diagnostics.Process.GetCurrentProcess().Elevate(args)`
            will restart the current console app in admin mode.

    -  ### ***Get()***
        > _Language extension for properties.  Use to set the value of the<br>
         extension property in question.<br>
         For example:<br>
           `Microsoft.SharePoint.Client client = new`<br>
           `  Microsoft.SharePoint.Client("https://cjvandyk.sharepoint.com");`<br>
           `client.ExecutingWebRequest += ClientContext_ExecutingWebRequest;
           `client.Set("HeaderDecoration", "NONISV|Crayveon|MyApp/1.0");`<br>
           This allows the creation of the extension property "HeaderDecoration"<br>
           which can be changed as needed.  Later in the delegate method we<br>
           refer back to the extension property value thus:<br>
           `private void ClientContext_ExecutingWebRequest(`<br>
              `object sender,` <br>
              `WebRequestEventArgs e)`<br>
            `{`<br>
              `e.WebRequestExecutor.WebRequest.UserAgent =`<br>
                `(string)e.Get("HeaderDecoration");`<br>
            `}`<br>
         NOTE: We did not have to access the ClientContext class in order to<br>
               retrieve the "HeaderDecoration" value since the extension was<br>
               done against the System.Object class.  As such, any object can<br>
               be used to retrieve the extension property value, as long as<br>
               you know the key value under which the property was stored and<br>
               you know the type to which the returned value needs to be cast.<br>
               A derived override method for Get() and Set() can be defined<br>
               using specific class objects if finer controls is needed.<br>_

  - ### ***GetUrlRoot()***
    > _Get the URL root for the given string object containing a URL.<br>
       For example:<br>
         `"https://cjvandyk.sharepoint.com".GetUrlRoot()`<br>
         will return "https://cjvandyk.sharepoint.com" whereas<br>
         `"https://cjvandyk.sharepoint.com/sites/Approval".GetUrlRoot()`<br>
         will also return "https://cjvandyk.sharepoint.com"._

  - ### ***IsAlphabetic()***
    > _Validates that the given string object contains all alphabetic<br>
       characters (a-z and A-Z) returning True if it does and False if<br>
       it doesn't.<br>
       For example:<br>
         `"abcXYZ".IsAlphabetic()`<br>
         will return True whereas<br>
         `"abc123".IsAlphabetic()`<br>
         will return False._
    
  - ### ***IsNumeric()***
    > _Validates that the given string object contains all numeric<br>
       characters (0-9) returning True if it does and False  if it<br>
       doesn't.<br>
       For example:<br>
         `"123456".IsNumeric()`<br>
         will return True whereas<br>
         `"abc123".IsNumeric()`<br>
         will return False._

  - ### ***IsAlphaNumeric()***
    > _Validates that the given string object contains all alphabetic<br>
       and/or numeric characters (a-z and A-Z and 0-9) returning True if it<br>
       does and False  if it doesn't.<br>
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
    > _This method takes a char[] as one of its arguments against which the<br>
       given string object is validated.  If the given string object contains<br>
       only characters found in the char[] it will return True, otherwise it<br>
       will return False.<br>
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
    > _This method returns the number of lines/sentences in the given string<br>
       object._

  - ### ***LoremIpsum()***
    > _Poplates the given string with a given number of paragraphs of dummy<br>
       text in the lorem ipsum style.
       For example:<br>
       `"".LoremIpsum(2)`<br>
       would yield<br>
       "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer<br> 
        aliquam arcu rhoncus erat consectetur, quis rutrum augue tincidunt.<br> 
        Suspendisse elit ipsum, lobortis lobortis tellus eu, vulputate<br> 
        fringilla lorem. Cras molestie nibh sed turpis dapibus sollicitudin<br> 
        ut a nulla. Suspendisse blandit suscipit egestas. Nunc et ante mattis<br> 
        nulla vehicula rhoncus. Vivamus commodo nunc id ultricies accumsan.<br> 
        Mauris vitae ante ut justo venenatis tempus.<br>
        <br>
        Nunc posuere, nisi eu convallis convallis, quam urna sagittis ipsum,<br> 
        et tempor ante libero ac ex. Aenean lacus mi, blandit non eros luctus,<br> 
        ultrices consectetur nunc. Vivamus suscipit justo odio, a porta massa<br> 
        posuere ac. Aenean varius leo non ipsum porttitor eleifend. Phasellus<br> 
        accumsan ultrices massa et finibus. Nunc vestibulum augue ut bibendum<br> 
        facilisis. Donec est massa, lobortis quis molestie at, placerat a<br> 
        neque. Donec quis bibendum leo. Pellentesque ultricies ac odio id<br> 
        pharetra. Nulla enim massa, lacinia nec nunc nec, egestas pulvinar<br> 
        odio. Sed pulvinar molestie justo, eu hendrerit nunc blandit eu.<br> 
        Suspendisse et sapien quis ipsum scelerisque rutrum."<br>_

  - ### ***Retry()***
    > _Checks if a System.Net.WebException contains a "Retry-After" header.<br>
      If it does, it sleeps the thread for that period (+ 60 seconds)<br>
      before reattempting to HTTP call that caused the exception in the<br>
      first place.  If no "Retry-After" header exist, the exception is<br>
      simply rethrown.<br>
      For example:<br>
      ```
      System.Net.HttpWebRequest request ...
      Try
      {
          request.GetResponse();
      }
      Catch (System.Net.WebException ex)
      {
          ex.Retry(request);
      }
      ```_

  - ### ***ReplaceTokens()***
    > _Takes a given string object and replaces 1 to n tokens in the string<br>
       with replacement tokens as defined in the given Dictionary of strings._

  - ### ***Set()***
      > _Language extension for properties.  Use to set the value of the<br>
         extension property in question.<br>
         For example:<br>
           `Microsoft.SharePoint.Client client = new`<br>
           `  Microsoft.SharePoint.Client("https://cjvandyk.sharepoint.com");`<br>
           `client.ExecutingWebRequest += ClientContext_ExecutingWebRequest;
           `client.Set("HeaderDecoration", "NONISV|Crayveon|MyApp/1.0");`<br>
           This allows the creation of the extension property "HeaderDecoration"<br>
           which can be changed as needed.  Later in the delegate method we<br>
           refer back to the extension property value thus:<br>
           `private void ClientContext_ExecutingWebRequest(`<br>
              `object sender,` <br>
              `WebRequestEventArgs e)`<br>
            `{`<br>
              `e.WebRequestExecutor.WebRequest.UserAgent =`<br>
                `(string)e.Get("HeaderDecoration");`<br>
            `}`<br>
         NOTE: We did not have to access the ClientContext class in order to<br>
               retrieve the "HeaderDecoration" value since the extension was<br>
               done against the System.Object class.  As such, any object can<br>
               be used to retrieve the extension property value, as long as<br>
               you know the key value under which the property was stored and<br>
               you know the type to which the returned value needs to be cast.<br>
               A derived override method for Get() and Set() can be defined<br>
               using specific class objects if finer controls is needed.<br>

  - ### ***ToBinary()***
    > _This method returns the given string represented in 1s and 0s as<br>
       a binary result.<br>
       For example:<br>
         `"This test".ToBinary()`<br>
         will return <br>
         `1010100 1101000 1101001 1110011 100000 1110100 1100101 1110011 1110100`_

  - ### ***Words()***
    > _This method returns the number of words used in the given string<br>
       object.
       For example:<br>
         `"This is my test".Words()`<br>
         will return 4 whereas<br>
         `"ThisIsMyTest".Words()`<br>
         will return 1._
