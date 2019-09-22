using MyHomeSensors.Services;
using MyHomeSensors.Services.Interfaces;
using Prism;
using Prism.Ioc;
using MyHomeSensors.ViewModels;
using MyHomeSensors.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyHomeSensors
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("app:///"+$"{nameof(NavigationPageEx)}/"+nameof(MyTabbedPage));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<NavigationPageEx>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.Register<IHttpService, HttpService>();
            containerRegistry.Register<IApiService, ApiService>();
            new ContainerManager(Container);
            containerRegistry.RegisterForNavigation<MyTabbedPage, TabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<StartPage, StartPageViewModel>();
     
        }
    }
}
