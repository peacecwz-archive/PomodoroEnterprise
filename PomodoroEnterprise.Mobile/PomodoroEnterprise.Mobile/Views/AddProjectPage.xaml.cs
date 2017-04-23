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
    public partial class AddProjectPage : ContentPage
    {
        ServiceContext service = new ServiceContext();

        public AddProjectPage()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var response = await service.AddProject(txtName.Text, txtDescription.Text);
            if (response)
            {
                await DisplayAlert("Message", "Added Project", "Ok");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Message", "Error adding Project", "Ok");
            }
        }
    }
}
