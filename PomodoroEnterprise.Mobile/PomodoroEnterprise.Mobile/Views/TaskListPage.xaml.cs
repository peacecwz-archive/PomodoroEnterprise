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

namespace PomodoroEnterprise.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskListPage : ContentPage
    {
        ServiceContext service = new ServiceContext();

        public ObservableCollection<TaskListModel> Tasks { get; set; }

        public int ProjectId { get; set; }
        public TaskListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            Tasks = await service.TaskList(ProjectId);
            listTasks.ItemsSource = Tasks;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTaskPage()
            {
                ProjectId = ProjectId
            });
        }

        private async void listTasks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as TaskListModel;
            if (item != null)
            {
                App.SelectedTask = item;
                App.IsSelected = true;
                await Navigation.PopAsync();
            }
        }
    }
}
