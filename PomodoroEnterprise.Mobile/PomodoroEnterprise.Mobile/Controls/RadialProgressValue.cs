using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PomodoroEnterprise.Mobile.Controls
{
    public class RadialProgressValue : Xamarin.Forms.View
    {
        public RadialProgressValue()
        {

        }

        public static readonly Xamarin.Forms.BindableProperty MinimumProperty = Xamarin.Forms.BindableProperty.Create<RadialProgressValue, int>(p => p.Minimum, default(int));

        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public static readonly Xamarin.Forms.BindableProperty MaximumProperty = Xamarin.Forms.BindableProperty.Create<RadialProgressValue, int>(p => p.Maximum, default(int));

        public int Maximum
        {
            get { return (int)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public static readonly Xamarin.Forms.BindableProperty ValueProperty = Xamarin.Forms.BindableProperty.Create<RadialProgressValue, int>(p => p.Value, default(int));

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly Xamarin.Forms.BindableProperty FillColorProperty = Xamarin.Forms.BindableProperty.Create<RadialProgressValue, Color>(p => p.FillColor, default(Color));

        public Xamarin.Forms.Color FillColor
        {
            get { return (Xamarin.Forms.Color)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }

    }
}
