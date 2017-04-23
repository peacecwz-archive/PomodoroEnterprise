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
using PomodoroEnterprise.Mobile.Dependencies;
using Android.Media;
using Xamarin.Forms;
using PomodoroEnterprise.Mobile.Droid.Dependencies;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceMute))]
namespace PomodoroEnterprise.Mobile.Droid.Dependencies
{
    public class DeviceMute : IDeviceMute
    {
        AudioManager audio;

        public void Close()
        {
            audio = (AudioManager)Forms.Context.GetSystemService(Context.AudioService);
            audio.RingerMode = RingerMode.Silent;
        }

        public void Open()
        {
            audio = (AudioManager)Forms.Context.GetSystemService(Context.AudioService);
            audio.RingerMode = RingerMode.Normal;
        }
    }
}