using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANWO.Biz.Entities
{
    public class MultiColumn<T> where T : class
    {
        public MultiColumn()
        {
            Columns = new List<T>();
        }
        public List<T> Columns { get; set; }
    }
}