using PomodoroEnterprise.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PomodoroEnterprise.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        ServiceContext service = new ServiceContext();
        public bool IsRunning { get; set; }
        public bool IsHidden { get; set; }

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Register_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterPage());
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            IsRunning = true;
            IsHidden = false;
            var response = await service.Login(txtUsername.Text, txtPassword.Text);
            if (response)
            {
                App.Current.MainPage = new NavigationPage(new TabPages.HomePage());
            }
            else
            {
                await DisplayAlert("Message", "Your username or password is invalid", "Ok");
            }
            IsRunning = false;
            IsHidden = true;
        }
    }
}
