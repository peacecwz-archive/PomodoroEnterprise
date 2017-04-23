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
    public partial class AddTaskPage : ContentPage
    {
        ServiceContext service = new ServiceContext();

        public int ProjectId { get; set; }

        public AddTaskPage()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var response = await service.AddTask(txtName.Text, datePicker.Date, ProjectId);
            if (response)
            {
                await DisplayAlert("Message", "Added Task", "Ok");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Message", "Error", "Ok");
            }
        }
    }
}
