﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANWO.Biz.Entities
{
    public class Category
    {
        public int ID { get; set; }

        public int? ParentID { get; set; }
        
        public string Name { get; set; }
    }

}