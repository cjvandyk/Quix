#pragma warning disable IDE1006 // Naming Styles

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quix.Testing
{
    /// <summary>
    /// Author: Cornelius J. van Dyk blog.cjvandyk.com @cjvandyk  
    /// This code is provided under GNU GPL 3.0 and is a copyrighted work of the
    /// author and contributors.  Please see:
    /// https://github.com/cjvandyk/Quix/blob/master/LICENSE
    /// Source code has been held to 80 character width for printing and porting
    /// reasons.
    /// </summary>
    class Program
    {
        private static Quix.Logging log = new Logging();

        static void Main(string[] args)
        {
            using (Quix.Logging log2 = new Quix.Logging())
            {
                Log("log2", log2);
            }
            Log("log");
        }

        private static void Log(string message)
        {
            log.Log(message);
        }
        private static void Log(string message, Quix.Logging log)
        {
            log.Log(message);  
        }
    }
}
