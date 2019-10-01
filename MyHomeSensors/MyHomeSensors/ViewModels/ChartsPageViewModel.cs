using Microcharts;
using MyHomeSensors.Models;
using MyHomeSensors.Services.Interfaces;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
#nullable enable
namespace MyHomeSensors.ViewModels
{
    public class ChartsPageViewModel : ViewModelBase
    {
        private ObservableCollection<Sensor> sensors;
        public ObservableCollection<Sensor> Sensors
        {
            get => sensors;
            set => SetProperty(ref sensors, value);
        }

        private Chart _chart;
        public Chart Chart
        {
            get => _chart;
            set => SetProperty(ref _chart, value);
        }

        public ChartsPageViewModel(INavigationService navigationService,IApiService apiService) : base(navigationService,apiService)
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

            var numbers = new List<double>();
            var entries = new List<ChartEntry>();
            foreach(var item in convetedData)
            {
                foreach (var pair in item)
                {
                    if (pair.Key.ToLower() == "temperature")
                    {
                        var num = double.Parse(pair.Value as string);
                        numbers.Add(num);
                        entries.Add(new ChartEntry((float)num));
                    }
                }
            }


    
            Chart = new LineChart()
            {
                Entries = entries
            };
            
        }

        public async void OnApear()
        {
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

            var numbers = new List<double>();
            var entries = new List<ChartEntry>();
            string? test = null;

            var numm = convetedData.Select(x => x.FirstOrDefault(k => k.Key == "temperature"))
               .Select(x => double.Parse(x.Value as string)).ToList();
            foreach (var item in convetedData)
            {
                foreach (var pair in item)
                {
                    if (pair.Key.ToLower() == "temperature")
                    {
                        var num = double.Parse(pair.Value as string);
                        numbers.Add(num);
                        entries.Add(new ChartEntry((float)num) { Label = num.ToString("F2"),ValueLabel = num.ToString("F2"),Color = SKColor.Parse("#3498db")});
                    }
                }
            }

            Chart = new LineChart()
            {
                Entries = entries,
                PointSize = 15,
                PointMode = PointMode.Square,
                LabelTextSize = 15,
                IsAnimated = true,
                MinValue = 0,
                MaxValue = 35,
                LineSize = 5
            };
        }
    }
}
