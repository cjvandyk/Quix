using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quix.Testing
{
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
