using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EventArgs
/// </summary>
namespace ANWO.Common
{
    public class ControlErrorArgs : EventArgs
    {
        public Exception InnerException { get; set; }
        public int Severity { get; set; }
        public string Message { get; set; }
        public List<string> Messages { get; set; }
        public bool LogOnly { get; set; }
    }

    public class GenericEventArgs : EventArgs
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class KeywordAndDescriptionArgs : EventArgs
    {
        public string Keyword { get; set; }
        public string Description { get; set; }
    }
}