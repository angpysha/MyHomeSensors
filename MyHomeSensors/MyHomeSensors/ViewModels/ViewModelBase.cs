using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using MyHomeSensors.Services.Interfaces;

namespace MyHomeSensors.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }
        protected readonly IApiService _apiService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService,IApiService apiService)
        {
            NavigationService = navigationService;
            _apiService = apiService;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual async void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
