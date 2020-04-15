using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using DSClerk.Pres;
using Infragistics.Win.UltraWinTabbedMdi;

namespace DSClerk.BaseForms
{
    public class DSCPres : DSCSecurity
    {
        /// <summary>
        /// This method will show form according to appropriate parameters sent
        /// </summary>
        /// <param name="opener">The form which will be opening the new window</param>
        /// <param name="args">Args</param>
        /// <returns>bool</returns>
        /// <exception cref="Not Enought Permissions.">Not Enough Permissions</exception>
        public virtual bool DisplayForm(object opener, FormDisplayArgs args)
        {
            bool success = false;
            if (CanLoad(args))
            {
                if (this.CanDisplay)
                {
                    if (args.DisplayType == FormDisplayType.Form)
                    {
                        this.Show();
                        success = true;
                    }
                    else
                    {
                        this.ShowDialog();
                        success = true;
                    }
                }
                else
                {
                    throw new Exception("Not enough permissions.");
                }
            }
            return success;
        }
        /// <summary>
        /// Will help determining wheater to show form or not?
        /// </summary>
        /// <param name="args">Arguments</param>
        /// <returns>bool</returns>
        protected virtual bool CanLoad(FormDisplayArgs args)
        {
            bool success = false;
            if (args.TabbedMdiManager == null)
                success = true;
            else
            {
                if (args.TabbedMdiManager.TabGroups.Count > 0)
                {
                    foreach (var item in args.TabbedMdiManager.TabGroups[0].Tabs)
                    {
                        if (item.Form.GetType().FullName == args.FQTN)
                        {
                            success = false;
                            item.Form.Focus();
                            break;
                        }
                        else
                        {
                            success = true; 
                        }
                    }
                }
                else
                {
                    success = true;
                }
            }
            return success;
        }
    }
}
