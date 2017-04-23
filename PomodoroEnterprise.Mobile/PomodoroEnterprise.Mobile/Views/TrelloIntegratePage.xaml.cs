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
    public partial class TrelloIntegratePage : ContentPage
    {
        ServiceContext service = new ServiceContext();

        public TrelloIntegratePage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var response = await service.ImportDataFromTrello(txtUsername.Text, txtPassword.Text);
            if (response)
            {
                await DisplayAlert("Message", "Your trello data imported", "Ok");
                App.Current.MainPage = new Views.TabPages.HomePage();
            }
            else
            {
                await DisplayAlert("Message", "Something happened", "Ok");
            }
        }
    }
}
