using MyHomeSensors.ViewModels;
using Xamarin.Forms;

namespace MyHomeSensors.Views
{
    public partial class ChartsPage : ContentPage
    {
        public ChartsPage()
        {
            InitializeComponent();
            this.Appearing += ChartsPage_Appearing;
            
        }

        private void ChartsPage_Appearing(object sender, System.EventArgs e)
        {
            (BindingContext as ChartsPageViewModel).OnApear();
        }
    }
}
