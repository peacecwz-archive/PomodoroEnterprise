using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroEnterprise.Mobile.Models.Response
{
    public class LoginResultModel
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}
