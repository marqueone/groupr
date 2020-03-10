using System;
using System.Collections.Generic;

namespace net.marqueone.groupr.shared.Models.Exceptions
{
    public class GrouprException : Exception
    {
        public string Task { get; set; }
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
        public GrouprException() { }

        public GrouprException(string message)
          : base(message) { }

        public GrouprException(string message, Exception ex)
          : base(message, ex) { }
    }
}