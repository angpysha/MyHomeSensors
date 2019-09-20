using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using MyHomeSensors.Services.Interfaces;
using Newtonsoft.Json;

namespace MyHomeSensors.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        private ICommand _testCommand;

        public ICommand TestCommand => _testCommand ??
                                       (_testCommand = new DelegateCommand(TestCommandExecute));

        private async void TestCommandExecute()
        {
            var fff = await _apiService.Search(@"{""type"":""bmp180""}");
            var bmps = JsonConvert.DeserializeObject<List<BMP180.BMP180>>(fff);
            int iii = 0;
        }

        public MainPageViewModel(INavigationService navigationService,IApiService apiService)
            : base(navigationService,apiService)
        {
            Title = "Main Page";
        }

        public override async void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
     


        }
    }
}
