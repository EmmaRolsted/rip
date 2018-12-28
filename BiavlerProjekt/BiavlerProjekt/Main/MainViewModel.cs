using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiavlerProjekt.Graph;
using Caliburn.Micro;

namespace BiavlerProjekt.Main
{
    public class MainViewModel
    {

        public BiAvlerViewModel BiAvlerViewModel { get; } = ModuleBootstrapper.Container.GetInstance<BiAvlerViewModel>();
        public GraphViewModel GraphViewModel { get; } = ModuleBootstrapper.Container.GetInstance<GraphViewModel>();

        public MainViewModel()
        {
            
        }
    }
}
