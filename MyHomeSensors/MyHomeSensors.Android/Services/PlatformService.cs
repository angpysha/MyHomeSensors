using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyHomeSensors.Services.Interfaces;

namespace MyHomeSensors.Droid.Services
{
    public class PlatformService : IPlatformService
    {
        public Context context => ContextContainer.Instance.Context;

        public async Task OpenFaceRecognizer()
        {
            var intent = new Intent(context, typeof(IO.Github.Angpysha.MainActivity));
            context.StartActivity(intent);
        }
    }
}