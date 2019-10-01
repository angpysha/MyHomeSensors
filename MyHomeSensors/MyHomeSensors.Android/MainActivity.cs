using Android.App;
using Android.Content.PM;
using Android.OS;
using MyHomeSensors.Droid.Services;
using MyHomeSensors.Services.Interfaces;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;

namespace MyHomeSensors.Droid
{
    [Activity(Label = "MyHomeSensors", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            var container = new ContextContainer();
            ContextContainer.Instance.Context = this;
            base.OnCreate(bundle);
            Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
            containerRegistry.Register<IPlatformService, PlatformService>();
        }
    }
}

