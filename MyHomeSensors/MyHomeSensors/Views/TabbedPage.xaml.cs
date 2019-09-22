using Xamarin.Forms;

namespace MyHomeSensors.Views
{
    public partial class MyTabbedPage : TabbedPage
    {
        public MyTabbedPage()
        {
            InitializeComponent();

            var startPage = new StartPage()
            {
                IconImageSource = "start.png"
            };
           
            this.Children.Add(startPage);
        }
    }
}
