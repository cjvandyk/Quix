using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Extensions;

namespace AddLinks
{
    class Program
    {
        /// <summary>
        /// AddLinks is a quick clipboard utility.
        /// - It will read text from the clipboard.
        /// - Parse the text.
        /// - Replace strings in the text accroding to a file passed as argument.
        /// - Copy the new text back to the clipboard.
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        static void Main(string[] args)
        {
            if ((args.Count() != 1) || 
                (Extensions.Constants.HelpStrings.Contains(args[0].ToLower())))
            {
                ConsoleEx.WriteHelp(
                    new string[] {"Usage is: AddLinks.exe <linksDefinitionFile>",
                                  "  where <linksDefinitionFile> is the path to a text file.",
                                  " ",
                                  "  Tokens in the <linksDefinitionFile> are defined thus:",
                                  "  \"Token to find spaces OK\",\"<a href=\"URL link to replace token\">Token to find spaces OK</a>\"",
                                  "  \"Token 2\",\"<a href=\"https://url2\">Token 2</a>\"",
                                  "  \"Token 3\",\"<a href=\"https://url3\">Token 3</a>\"",
                                  "  etc.",
                                  "  NOTE: Lines are processed as containing a value to find",
                                  "        for replacement as well as the replacement value",
                                  "        itself.  Both values are encased in double quotes",
                                  "        and separated by a comma e.g.",
                                  "          \"Target\",\"Replacement\"",
                                  "        The encased double quotes as well as the trailing",
                                  "        return characters are automatically purged during",
                                  "        processing."});
            }
            else
            {
                try
                {
                    string fileText = System.IO.File.ReadAllText(args[0]);
                    string[] pairs = fileText.Split('\n');
                    Dictionary<string, string> replacements = new Dictionary<string, string>();
                    foreach (string pair in pairs)
                    {
                        replacements.Add(pair.Split(',')[0].TrimStart('"').TrimEnd('\r', '"'), 
                                         pair.Split(',')[1].TrimStart('"').TrimEnd('\r', '"'));
                    }
                    if (System.Windows.Clipboard.ContainsText())
                    {
                        string returnValue = System.Windows.Clipboard.GetText();
                        returnValue = returnValue.ReplaceTokens(replacements);
                        System.Windows.Clipboard.Clear();
                        System.Windows.Clipboard.SetText(returnValue);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
