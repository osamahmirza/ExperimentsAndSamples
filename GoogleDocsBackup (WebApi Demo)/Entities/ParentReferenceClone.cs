using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentListAPI.Entities
{
    public class ParentReferenceClone 
    {
        public string ETag { get; set; }
        public string Id { get; set; }
        public bool? IsRoot { get; set; }
        public string Kind { get; set; }
        public string ParentLink { get; set; }
        public string SelfLink { get; set; }
    }
}