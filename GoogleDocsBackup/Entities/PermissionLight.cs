using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.Apis.Drive.v2.Data;

namespace DocumentListAPI.Entities
{
    public class PermissionLight
    {
        public string DocID { get; set; }
        public PermissionList Permissions { get; set; }
    }
}