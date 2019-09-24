using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyHomeSensors.CustomControls;
using Xamarin.Forms.Platform.Android;

namespace MyHomeSensors.Droid.Renderers
{
    public class ExtendedTabbedPageRenderer : VisualElementRenderer<ExtendedTabPage>
    {
        public ExtendedTabbedPageRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<ExtendedTabPage> e)
        {
            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

        
    }
}