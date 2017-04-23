using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PomodoroEnterprise.API.Helpers
{
    public class SettingsHelper
    {
        public string TrelloAppID
        {
            get
            {
                return Get("TrelloAppID");
            }
        }

        private static string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}