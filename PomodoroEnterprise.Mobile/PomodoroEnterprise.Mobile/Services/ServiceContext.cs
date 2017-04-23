using Newtonsoft.Json;
using PomodoroEnterprise.Mobile.Models.Request;
using PomodoroEnterprise.Mobile.Models.Response;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroEnterprise.Mobile.Services
{
    public class ServiceContext
    {
        #region Instance

        private static ServiceContext _context;

        public static ServiceContext Context
        {
            get
            {
                if (_context == null)
                    _context = new ServiceContext();
                return _context;
            }
        }

        #endregion

        private HttpClient _client;
        public HttpClient Client
        {
            get
            {
                if (_client == null)
                    _client = new HttpClient();
                _client.BaseAddress = new Uri(App.ApiURL);
                if (SettingsHelper.Instance.Token != null)
                    _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SettingsHelper.Instance.Token);
                return _client;
            }
        }

        public async Task<bool> Login(string username, string password)
        {
            Dictionary<string, string> formParams = new Dictionary<string, string>()
            {
                {"username",username },
                {"password",password },
                {"grant_type","password" },
            };
            var response = await Client.PostAsync("/oauth/token", new FormUrlEncodedContent(formParams));
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            else
            {
                var token = JsonConvert.DeserializeObject<Models.Response.LoginResultModel>(await response.Content?.ReadAsStringAsync());
                SettingsHelper.Instance.Token = token.AccessToken;
                return true;
            }
        }

        public async Task<bool> Register(string username, string password, string email)
        {
            var model = new RegisterRequestModel()
            {
                Username = username,
                Password = password,
                Email = email
            };
            var response = await Client.PostAsync("/api/account/register", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
            if (!response.IsSuccessStatusCode) return false;

            return true;
        }

        public async Task<ObservableCollection<ProjectListModel>> ProjectList()
        {
            var response = await Client.GetAsync("/api/projects/");
            if (!response.IsSuccessStatusCode) return new ObservableCollection<ProjectListModel>();

            var projectList = JsonConvert.DeserializeObject<ObservableCollection<ProjectListModel>>(await response.Content?.ReadAsStringAsync());
            return projectList;
        }

        public async Task<bool> AddProject(string name, string description)
        {
            var project = new ProjectListModel()
            {
                Name = name,
                Description = description
            };
            var response = await Client.PostAsync("/api/projects/", new StringContent(JsonConvert.SerializeObject(project), Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode) return false;

            return true;
        }

        public async Task<ObservableCollection<TaskListModel>> TaskList(int ProjectId)
        {
            var response = await Client.GetAsync($"/api/tasks/getbyproject/{ProjectId}");

            if (!response.IsSuccessStatusCode) return new ObservableCollection<TaskListModel>();

            return JsonConvert.DeserializeObject<ObservableCollection<TaskListModel>>(await response.Content?.ReadAsStringAsync());
        }

        public async Task<bool> AddTask(string name, DateTime deadline, int ProjectId)
        {
            var task = new TaskListModel()
            {
                Deadline = deadline,
                Name = name,
                ProjectId = ProjectId
            };
            var response = await Client.PostAsync("/api/tasks/", new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json"));
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }

        public async Task<bool> ImportDataFromTrello(string username,string password)
        {
            var response = await Client.GetAsync($"/api/integrate/trello?username={username}&password={password}");
            if (!response.IsSuccessStatusCode) return false;

            return true;
        }
    }
}
