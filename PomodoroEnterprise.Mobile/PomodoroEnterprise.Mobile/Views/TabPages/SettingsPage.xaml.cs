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
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var settings = SettingsHelper.Instance.Settings;
            if (settings == null) return;
            slPomodorLongTime.Value = settings.LongPomodorTime;
            slPomodorPeriodCount.Value = settings.PeriodPomodorCount;
            slPomodorPeriodTime.Value = settings.PeriodPomodorTime;
            slPomodorShortTime.Value = settings.ShortPomodorTime;
            swIsQuite.IsToggled = settings.IsQuiet;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var settings = new SettingsModel()
            {
                IsQuiet = swIsQuite.IsToggled,
                LongPomodorTime = (int)slPomodorLongTime.Value,
                PeriodPomodorCount = (int)slPomodorPeriodCount.Value,
                PeriodPomodorTime = (int)slPomodorPeriodTime.Value,
                ShortPomodorTime = (int)slPomodorShortTime.Value
            };
            SettingsHelper.Instance.Settings = settings;
            await Navigation.PopAsync();
        }

        private void slPomodorLongTime_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblPomodorLongTime.Text = ((int)(e.NewValue + 1)).ToString();
        }

        private void slPomodorShortTime_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblPomodorShortTime.Text = ((int)(e.NewValue)).ToString();
        }

        private void slPomodorPeriodTime_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblPomodorPeriodTime.Text = ((int)(e.NewValue)).ToString();
        }

        private void slPomodorPeriodCount_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblPomodorPeriodCount.Text = ((int)(e.NewValue)).ToString();
        }

        private async void ImportTrello_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TrelloIntegratePage());
        }

        private void Logout_Clicked(object sender, EventArgs e)
        {
            SettingsHelper.Instance.Logout();
            App.Current.MainPage = new LoginPage();
        }
    }
}
