using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHomeSensors.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationPageEx : NavigationPage
    {
        public NavigationPageEx()
        {
            InitializeComponent();
            this.Pushed += NavigationPageEx_Pushed;
        }

        private void NavigationPageEx_Pushed(object sender, NavigationEventArgs e)
        {
            Title = e.Page.Title;
        }
    }
}