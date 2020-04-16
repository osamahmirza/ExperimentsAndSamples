using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentListAPI.Entities
{
    public class UserReferenceClone
    {
        public string DisplayName { get; set; }
        public bool? IsAuthenticated { get; set; }
        public string Kind { get; set; }
        public string PermissionId { get; set; }
        public string PictureUrl { get; set; }
    }
}