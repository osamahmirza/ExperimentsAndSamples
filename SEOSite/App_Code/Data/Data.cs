using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANewWebOrder;

/// <summary>
/// Summary description for Data
/// </summary>
namespace ANWO
{
    public class Data
    {
        //Default constructor
        public Data()
        {
        }

        private ANWODataContext _NWODC;
        public ANWODataContext NWODC
        {
            get
            {
                if (_NWODC == null)
                {
                    _NWODC = new ANWODataContext() { ObjectTrackingEnabled = true };
                }
                return _NWODC;
            }
        }
    }
}