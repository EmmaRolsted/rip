using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiavlerProjekt.Graph;
using BiavlerProjekt.Main;
using Caliburn.Micro;

namespace BiavlerProjekt
{
    public class ModuleBootstrapper : IModule
    {
        public static  SimpleContainer Container { get; set; }
        public void Initialize(SimpleContainer container)
        {
            Container = container;
            Container.Singleton<GraphViewModel>();
            Container.Singleton<BiAvlerViewModel>();
            container.Singleton<MainViewModel>();
        }
    }
}
