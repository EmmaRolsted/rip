using BiavlerProjekt.Graph;
using Caliburn.Micro;

namespace BiavlerProjekt.Main
{
    public class MainViewModel : Screen
    {
        public GraphViewModel GraphViewModel { get;} = Bootstrapper.Container.GetInstance<GraphViewModel>();
        public BiAvlerViewModel BiAvlerViewModel { get; } = Bootstrapper.Container.GetInstance<BiAvlerViewModel>();
        public MainViewModel() { }
    }
}
