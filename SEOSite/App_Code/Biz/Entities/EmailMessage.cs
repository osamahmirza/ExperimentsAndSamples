using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANWO.Biz.Entities
{
    public class EmailMessage
    {
        public EmailMessage()
        {
        }

        public string Title { get; set; }
        public string Message { get; set; }
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
    }
}