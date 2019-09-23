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

        public string Title => "Start";
        public StartPageViewModel(INavigationService navigationService,IApiService apiService) : base(navigationService,apiService)
        {

        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            var date1 = DateTime.Now;
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
            foreach (var listItem in convetedData)
            {
                var sensor = new Sensor();
                sensor.Values = new ObservableCollection<KeyPair>();
                foreach (var pair in listItem)
                {
                    if (pair.Value is string strVal)
                    {
                        sensor.Values.Add(new KeyPair()
                        {
                            Key = pair.Key,
                            Value = strVal
                        });
                    }
                }
                Sensors.Add(sensor);
            }
        }
    }
}
