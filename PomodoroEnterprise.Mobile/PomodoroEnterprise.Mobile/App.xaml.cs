using PomodoroEnterprise.Mobile.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PomodoroEnterprise.Mobile
{
    public partial class App : Application
    {
#if !DEBUG
        public static string ApiURL = "http://localhost:11268/";
#else
        public static string ApiURL = "http://pomodoroenterprise.azurewebsites.net/";
#endif

        public static TaskListModel SelectedTask { get; set; }
        public static bool IsSelected { get; set; } = false;
        public static bool IsTimerStarted { get; set; } = false;
        public App()
        {
            InitializeComponent();
            if (SettingsHelper.Instance.Token == null)
                MainPage = new NavigationPage(new PomodoroEnterprise.Mobile.Views.LoginPage());
            else
                MainPage = new NavigationPage(new Views.TabPages.HomePage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
