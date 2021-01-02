Quix.dll contains a number of C# extension methods for addressing gaps in some
common libraries.

The following classes have been extended:

    System.String
    System.Text.StringBuilder

with these methods:

    IsAlphabetic()
        This method validates that the given string object contains all
        alphabetic characters (a-z and A-Z) returning True if it does and
        False  if it doesn't.
    
    IsNumeric()
        This method validates that the given string object contains all
        numeric characters (0-9) returning True if it does and False  if it
        doesn't.
    
    IsAlphaNumeric()
        This method validates that the given string object contains all
        alphabetic and/or numeric characters (a-z and A-Z and 0-9) returning 
        True if it does and False  if it doesn't.
    
    IsChar()
        This method takes a char[] as one of its arguments against which the
        given string object is validated.  If the given string object contains
        only characters found in the char[] it will return True, otherwise it
        will return False.
    
    Lines()
        This method returns the number of lines/sentences in the given string
        object.

    Words()
        This method returns the number of words used in the given string
        object.
