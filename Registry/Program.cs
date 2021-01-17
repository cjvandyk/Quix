using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Extensions;

namespace Registry
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(".");
            if (System.Diagnostics.Process.GetCurrentProcess().Elevate(args))
            {
                Process();
            }
        }

        static void Process()
        {
            Microsoft.Win32.RegistryKey key =
                Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(
                    "*\\shell", true);
            key.CreateSubKey("Run in CMD Shell");
            key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(
                "*\\shell\\Run in CMD Shell", true);
            key.CreateSubKey("command");
            key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(
                "*\\shell\\Run in CMD Shell\\command", true);
            key.SetValue("", @"C:\APPS\UX.exe %1");
            key.Close();
            Console.WriteLine("Done!");
        }
    }
}
