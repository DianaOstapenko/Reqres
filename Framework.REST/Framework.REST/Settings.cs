using System;
using System.Collections.Generic;
using System.IO;
using Framework.Utility;

namespace Framework.REST
{
    public class Settings
    {
        public Settings()
        {
            const string settingsName = "settings.json";
            string defaultSettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, settingsName);
            string result = String.Empty;

            if (File.Exists(defaultSettingsPath))
            {
                result = File.ReadAllText(defaultSettingsPath);
            }
            Tools.Json.PopulateJson(result, this);

            CurrentHost = Hosts[0];
        }

        public List<string> Hosts { get; set; }

        public string CurrentHost { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
