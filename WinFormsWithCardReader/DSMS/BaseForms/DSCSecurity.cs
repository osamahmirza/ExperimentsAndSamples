using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSClerk.BaseForms
{
    public class DSCSecurity : Form
    {
        protected virtual bool CanDisplay 
        { 
            get 
            { 
                return true; 
            } 
        }

    }
}
