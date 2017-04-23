using PomodoroEnterprise.Mobile.Dependencies;
using PomodoroEnterprise.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PomodoroEnterprise.Mobile.Views.TabPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PomodorPage : ContentPage
    {
        SettingsModel settings;
        IDeviceMute deviceMute;

        double settings_pomodor = 25; // Bunu LoadMethodundan alabilirsin.
        public PomodorPage()
        {
            InitializeComponent();
            _lblTime.Text = this.settings_pomodor + ":00";
        }
        

        protected override void OnAppearing()
        {
            if(App.SelectedTask ==null)
            {
                main1.IsVisible = false;
                main2.IsVisible = true;
            }
            else
            {
                main1.IsVisible = true;
                main2.IsVisible = false;
            }
            settings = SettingsHelper.Instance.Settings;
            settings_pomodor = settings.LongPomodorTime;
            progressBar.Maximum = settings.LongPomodorTime * 60;
            progressBar.Minimum = 0;
            progressBar.Value = settings.LongPomodorTime * 60;
        }

        private void _btnTimerStarter_Clicked(object sender, EventArgs e)
        {
            if (App.IsTimerStarted) return;
            _btnTimerStarter.IsEnabled = false;
            App.IsTimerStarted = true;
            double full_time = this.settings_pomodor * 60; // 25 dakika
            _lblTime.Text = String.Format("{0}", (full_time / 60).ToString() + ":00");
            if (settings.IsQuiet)
            {
                deviceMute = DependencyService.Get<Dependencies.IDeviceMute>(DependencyFetchTarget.GlobalInstance);
                deviceMute.Close();
            }
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                full_time--;
                if (full_time % 60 == 0)
                {
                    _lblTime.Text = String.Format("{0}", (full_time / 60).ToString() + ":0");
                }
                else
                {
                    double second = full_time % 60;
                    double minutes = Math.Floor(full_time / 60);
                    _lblTime.Text = minutes + ":" + second;
                    progressBar.Value = Convert.ToInt32(full_time);
                }
                if (full_time == 0)
                {
                    _btnTimerStarter.IsEnabled = true;
                    App.IsTimerStarted = false;
                    if (deviceMute != null) deviceMute.Open();
                    DisplayAlert("Süre Doldu", "Geri sayım süresi bitti!", "Ok");
                    return false;
                }
                return true;
            });
        }
    }
}
