using PomodoroEnterprise.Mobile.Models.Response;
using PomodoroEnterprise.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PomodoroEnterprise.Mobile.Views.TabPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectsPage : ContentPage
    {
        public ObservableCollection<Models.Response.ProjectListModel> Projects { get; set; }

        ServiceContext service = new ServiceContext();

        public ProjectsPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            Projects = await service.ProjectList();
            listProjects.ItemsSource = Projects;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProjectPage());
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as ProjectListModel;
            if (item != null)
            {
                await Navigation.PushAsync(new TaskListPage()
                {
                    ProjectId = item.Id,
                    Title = item.Name
                });
            }
        }
    }
}
