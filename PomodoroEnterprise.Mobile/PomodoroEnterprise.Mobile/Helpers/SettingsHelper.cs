using Newtonsoft.Json;
using PomodoroEnterprise.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PomodoroEnterprise.Mobile
{
    public class SettingsHelper
    {
        #region Instance

        private static SettingsHelper _instance;
        public static SettingsHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SettingsHelper();
                return _instance;
            }
        }

        #endregion

        public string Token
        {
            get
            {
                if (Application.Current.Properties.ContainsKey("Token"))
                    return Application.Current.Properties["Token"].ToString();
                return null;
            }
            set
            {
                if (Application.Current.Properties.ContainsKey("Token"))
                    Application.Current.Properties["Token"] = value;
                else
                    Application.Current.Properties.Add("Token", value);
            }
        }

        public SettingsModel Settings
        {
            get
            {
                if (Application.Current.Properties.ContainsKey("Settings"))
                {
                    string json = Application.Current.Properties["Settings"].ToString();
                    return JsonConvert.DeserializeObject<SettingsModel>(json);
                }
                return new SettingsModel();
            }
            set
            {
                if (Application.Current.Properties.ContainsKey("Settings"))
                {
                    Application.Current.Properties["Settings"] = JsonConvert.SerializeObject(value);
                }
                else
                    Application.Current.Properties.Add("Settings", JsonConvert.SerializeObject(value));
            }
        }

        public void Logout()
        {
            if (Application.Current.Properties.ContainsKey("Token"))
            {
                Application.Current.Properties.Remove("Token");
            }
        }
    }
}
