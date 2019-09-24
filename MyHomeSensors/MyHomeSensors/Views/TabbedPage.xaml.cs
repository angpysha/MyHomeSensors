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
                IconImageSource = "start.png",
                Title = "Start"
            };

            var chartsPage = new ChartsPage()
            {
                Title = "Charts",
                IconImageSource = "statistics.png"
            };

            this.Children.Add(startPage);
            this.Children.Add(chartsPage);
        }
    }
}
