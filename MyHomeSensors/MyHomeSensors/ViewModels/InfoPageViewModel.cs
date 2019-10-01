using MyHomeSensors.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MyHomeSensors.ViewModels
{
    public class InfoPageViewModel : BindableBase
    {
        private readonly IPlatformService _platformService;
        private ICommand _openFaceRecognitionPageCommand;
        public ICommand OpenFaceRecognitionPageCommand => _openFaceRecognitionPageCommand ??
            (_openFaceRecognitionPageCommand = new DelegateCommand(OpenFaceRecognitionPageCommandExecute));
        public InfoPageViewModel(IPlatformService platformService)
        {
            _platformService = platformService;
        }

        private async void OpenFaceRecognitionPageCommandExecute()
        {
            //MainThread a
            await _platformService.OpenFaceRecognizer();
        }
    }
}
