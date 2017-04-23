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
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
            Children.Add(new ProjectsPage());
            Children.Add(new PomodorPage());
            Children.Add(new ReportPage());
        }

        protected override void OnAppearing()
        {
            if (App.IsSelected)
            {
                var masterPage = this as TabbedPage;
                masterPage.CurrentPage = masterPage.Children[1];
                App.IsSelected = false;
            }
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }
}
