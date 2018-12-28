using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.TextFormatting;
using Caliburn.Micro;

namespace BiavlerProjekt
{
    public class Bootstrapper : BootstrapperBase
    {
 
        public Bootstrapper()
        {
            Initialize();

            

        }


        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<BiAvlerViewModel>();
        }
    }
}
