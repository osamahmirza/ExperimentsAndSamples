using System;
using Infragistics.Win.UltraWinTabbedMdi;
namespace DSClerk.Pres
{
    public class FormDisplayArgs
    {
        public FormDisplayType DisplayType { get; set; }
        public UltraTabbedMdiManager TabbedMdiManager { get; set; }
        public string FQTN { get; set; }

        public FormDisplayArgs(FormDisplayType type)
        {
            DisplayType = type;
        }
        /// <summary>
        /// If form to show is going to be an MdiChild then following constructor should be used
        /// </summary>
        /// <param name="type">Dispaly Type</param>
        /// <param name="tabbedMdiManager">TabbedMdiManager</param>
        /// <param name="fqtn">Form which is going to be displayed</param>
        public FormDisplayArgs(FormDisplayType type, UltraTabbedMdiManager tabbedMdiManager, object fqtn)
        {
            DisplayType = type;
            TabbedMdiManager = tabbedMdiManager;
            FQTN = fqtn.GetType().FullName;
        }
    }
}
