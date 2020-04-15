using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DSClerk.Pres;

using Infragistics.Win.AppStyling;

namespace DSClerk
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            ultraTabbedMdiManager1.MdiParent = this;
            //Get settings from database
            StyleManager.Load("..\\..\\style\\Office2007Black.isl");

        }

        void fileToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ultraExplorerBar1_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {
            //Use FormTabManager.cs
            if (e.Item.Key == "New Student")
            {
                Student stdRegister = new Student();
                stdRegister.MdiParent = this;
                stdRegister.Text = "Student";
                stdRegister.DisplayForm(this, new FormDisplayArgs(FormDisplayType.Form, ultraTabbedMdiManager1, stdRegister));
            }
            else if (e.Item.Key == "Students")
            {
                Students students = new Students();
                students.MdiParent = this;
                students.Text = "Students";
                students.DisplayForm(this, new FormDisplayArgs(FormDisplayType.Form, ultraTabbedMdiManager1, students));
            }
            else if (e.Item.Key == "Student Relation Mgmt")
            {
                StudentRM studentRM = new StudentRM();
                studentRM.MdiParent = this;
                studentRM.Text = "Student Relation Management";
                studentRM.DisplayForm(this, new FormDisplayArgs(FormDisplayType.Form, ultraTabbedMdiManager1, studentRM));
            }
            else if (e.Item.Key == "New Instructor")
            {
                Instructor instructor = new Instructor();
                instructor.MdiParent = this;
                instructor.Text = "Instructor";
                instructor.DisplayForm(this, new FormDisplayArgs(FormDisplayType.Form, ultraTabbedMdiManager1, instructor));
            }
            else if (e.Item.Key == "Instructors")
            {
                Instructors instructors = new Instructors();
                instructors.MdiParent = this;
                instructors.Text = "Instructor";
                instructors.DisplayForm(this, new FormDisplayArgs(FormDisplayType.Form, ultraTabbedMdiManager1, instructors));
            }
        }
    }
}
