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

            var infoPage = new InfoPage()
            {
                Title = "Info",
                //IconImageSource = "info.png"
            };
            this.CurrentPageChanged += MyTabbedPage_CurrentPageChanged;
            this.Children.Add(startPage);
            this.Children.Add(chartsPage);
            this.Children.Add(infoPage);
        }

        private void MyTabbedPage_CurrentPageChanged(object sender, System.EventArgs e)
        {
            Title = CurrentPage.Title;
        }
    }
}
