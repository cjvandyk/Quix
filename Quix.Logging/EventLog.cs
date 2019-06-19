#pragma warning disable IDE1006, IDE0017, CS0162, IDE0060 // Naming Styles, Simplify declaration (FQCN used), break after return, Remove unused (string[] args)

/// <summary>
/// Author: Cornelius J. van Dyk blog.cjvandyk.com @cjvandyk  
/// This code is provided under GNU GPL 3.0 and is a copyrighted work of the
/// author and contributors.  Please see:
/// https://github.com/cjvandyk/Quix/blob/master/LICENSE
/// Source code has been held to 80 character width for printing and porting
/// reasons.
/// </summary>
using System;

namespace Quix
{
    class EventLog : IDisposable
    {
        private System.Diagnostics.EventLog _evt { get; set ; }
        private System.Diagnostics.EventLogEntryType _elet { get; set; }
        private bool _fixedELET = false;

        public EventLog(string source = "Application", string log = "Application")
        {
            try
            {
                if (!System.Diagnostics.EventLog.SourceExists(source))
                {
                    System.Diagnostics.EventLog.CreateEventSource(source, log);
                }
                _evt = new System.Diagnostics.EventLog(log);
                _evt.Source = source;
            }
            catch { }
        }

        public void Dispose()
        {
            ((IDisposable)_evt).Dispose();
        }

        public bool setConstantLogEntryType(System.Diagnostics.EventLogEntryType constantType)
        {
            try
            {
                _elet = constantType;
                _fixedELET = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Write(string message, System.Diagnostics.EventLogEntryType elet = System.Diagnostics.EventLogEntryType.Information)
        {
            try
            {
                if (_fixedELET)
                {
                    _evt.WriteEntry(message.Substring(0, 32767), _elet);
                }
                else
                {
                    _evt.WriteEntry(message.Substring(0, 32767), elet);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
