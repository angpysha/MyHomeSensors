using MyHomeSensors.Models;
using MyHomeSensors.Services.Interfaces;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;

namespace MyHomeSensors.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {
        private ObservableCollection<Sensor> sensors;
        public ObservableCollection<Sensor> Sensors 
        { 
            get => sensors; 
            set => SetProperty(ref sensors,value); 
        }

        private DateTime date;
        public DateTime Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        private ICommand _dateSelectedCommad;
        public ICommand DateSelectedCommand => _dateSelectedCommad ??
            (_dateSelectedCommad = new DelegateCommand<DateTime?>(OnDateSelected));

        private async void OnDateSelected(DateTime? obj)
        {
           if (obj.HasValue)
            {
                await GetByDate(obj.Value);
            }
        }

        public string Title => "Start";
        public StartPageViewModel(INavigationService navigationService,IApiService apiService) : base(navigationService,apiService)
        {
            
        }

        private async Task GetByDate(DateTime date1)
        {
            IsLoading = true;
            Sensors?.Clear();
            var datefrom = new DateTime(date1.Year, date1.Month, date1.Day, 0, 0, 0, DateTimeKind.Utc);
            var dateto = new DateTime(date1.Year, date1.Month, date1.Day, 23, 59, 59, DateTimeKind.Utc);
            var datefromStr = datefrom.ToString("yyyy-MM-dd HH:mm:ss");
            var datetoStr = dateto.ToString("yyyy-MM-dd HH:mm:ss");
            var str = @"{""datefrom"":""" + datefromStr + @""",""dateto"":""" + datetoStr + @"""}";
            //var data = await _apiService.Search(String.Format(@"{""type"":""bmp180"",""datefrom"":""{0}"",""dateto"":""{1}""}",
            //            datefromStr,datetoStr));
            var data = await _apiService.Search(str);
            var convetedData = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(data);
            if (Sensors == null)
                Sensors = new ObservableCollection<Sensor>();
            var keys = convetedData.Select(x  => {
                var sensor = new Sensor();
                sensor.Values = new ObservableCollection<KeyPair>();
                var items = x.Select(y => {
                    var str = y.Value.ToString();
                    if (y.Key == "_id")
                    {
                        var val = y.Value as dynamic;
                        str = val["$oid"].ToString();
                    }
                    var pair = new KeyPair()
                    {
                        Key = y.Key,
                        Value = str
                    };
                    return pair;
                });
                foreach (var item in items)
                    sensor.Values.Add(item);
                return sensor;
            }).ToList();

            foreach (var sensor in keys)
            {
                Sensors.Add(sensor);
            }
          
            MainThread.BeginInvokeOnMainThread(() => {

                IsEmpty = Sensors.Count == 0;
                IsLoading = false;
           });
           
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Date = DateTime.Now;
        }
    }
}
