using BiavlerProjekt.Graph;
using BiavlerProjekt.Main;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Windows;

namespace BiavlerProjekt
{
    public class Bootstrapper : BootstrapperBase
    {
        public static SimpleContainer Container { get; set; }
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            Container = new SimpleContainer();

            Container.Singleton<IWindowManager, WindowManager>();

            Container.RegisterSingleton(typeof(MainViewModel), "MainViewViewModel", typeof(MainViewModel));

            Container.RegisterSingleton(typeof(BiAvlerViewModel), "BiAvlerViewModel", typeof(BiAvlerViewModel));
            Container.RegisterSingleton(typeof(GraphViewModel), "MainViewViewModel", typeof(GraphViewModel));
        }

        protected override object GetInstance(Type service, string key)
        {
            object instance = Container.GetInstance(service, key);
            if (instance != null)
                return instance;
            throw new InvalidOperationException("could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return Container.GetAllInstances(service);
        }
        protected override void BuildUp(object instance)
        {
            Container.BuildUp(instance);
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
