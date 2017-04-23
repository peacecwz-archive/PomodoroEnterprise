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
    public partial class RegisterPage : ContentPage
    {
        ServiceContext service = new ServiceContext();

        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void Register_Clicked(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtPasswordConfirm.Text)
            {
                await DisplayAlert("Message", "Your password and password confirm are different", "OK");
            }
            else
            {
                var response = await service.Register(txtUsername.Text, txtPassword.Text, txtEmail.Text);
                if (response)
                {
                    await DisplayAlert("Message", "Registered Successfuly", "Ok");
                    await Navigation.PopModalAsync(true);
                }
                else
                {
                    await DisplayAlert("Message", "Register Error", "Ok");
                }
            }
        }
    }
}
