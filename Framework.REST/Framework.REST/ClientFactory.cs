using RestSharp;
using RestSharp.Authenticators;

namespace Framework.REST
{
    public class ClientFactory
    {
        public string Url { get; private set; }
        public string Password { get; private set; }
        public string UserName { get; private set; }

        private Settings settings;
        public Settings Settings
        {
            get { return settings; }
        }

        internal ClientFactory()
        {
            Settings _settings = new Settings();
            this.settings = _settings;
        }

        public RestClient GetClient()
        {
            // read from settings
            var client = new RestClient(Settings.CurrentHost)
            {
                //Authenticator = new HttpBasicAuthenticator(Settings.UserName, Settings.Password)
            };
            return client;
        }

        public static RestClient GetClient(string host, string userName, string password)
        {
            //host = "http://localhost";
            //userName = "dostapenko";
            //password = "k}6MgZ/q12";
            var client = new RestClient(host);
            client.Authenticator = new HttpBasicAuthenticator(userName, password);
            return client;
        }
    }
}