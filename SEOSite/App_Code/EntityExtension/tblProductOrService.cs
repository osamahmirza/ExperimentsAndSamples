using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for tblProductOrService
/// </summary>
namespace ANewWebOrder
{
    public partial class tblProductOrService
    {
        private string _ModifiedID;
        public string ModifiedID
        {
            get
            {
                if (ID != 0)
                    return ID.ToString();
                else
                    return _ModifiedID;
            }
            set
            {
                _ModifiedID = value;
            }
        }
    }
}