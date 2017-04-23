using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using PomodoroEnterprise.Mobile.Controls;
using RadialProgress;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(RadialProgressValue), typeof(PomodoroEnterprise.Mobile.Droid.CustomControls.RadialProgressRenderer))]
namespace PomodoroEnterprise.Mobile.Droid.CustomControls
{
    public class RadialProgressRenderer : ViewRenderer<RadialProgressValue, RadialProgressView>
    {
        RadialProgressView _radial;

        public RadialProgressRenderer()
        {
            _radial = new RadialProgressView(Forms.Context);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<RadialProgressValue> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || this.Element == null)
                return;

            if (e.OldElement != null)
                e.OldElement.PropertyChanged -= HandlePropertyChanged;

            if (this.Element != null)
            {
                this.Element.PropertyChanged += HandlePropertyChanged;
            }


            var element = (RadialProgressValue)Element;
            _radial.MaxValue = element.Maximum;
            _radial.MinValue = element.Minimum;
            _radial.Value = element.Value;
            SetNativeControl(_radial);
        }

        private void HandlePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == RadialProgressValue.MaximumProperty.PropertyName)
            {
                _radial.MaxValue = Element.Maximum;
            }
            else if (e.PropertyName == RadialProgressValue.MinimumProperty.PropertyName)
            {
                _radial.MinValue = Element.Minimum;
            }
            else if(e.PropertyName == RadialProgressValue.ValueProperty.PropertyName)
            {
                _radial.Value = Element.Value;
            }
        }
    }
}