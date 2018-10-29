using Framework.REST.RequestData;
using RestSharp;

namespace Framework.REST.EndPoints
{
    public class RegisterEndPoint
    {
        private readonly ClientFactory _clientFactory = new ClientFactory();

        public ClientFactory ClientFactory
        {
            get { return _clientFactory; }
        }

        public IRestResponse<RegisterResponse> Register(object jsonBody)
        {
            var client = ClientFactory.GetClient();
            RestRequest request = new RestRequest(RestConst.RegisterUrl, Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(jsonBody);

            var result = client.Execute<RegisterResponse>(request);
            return result;
        }
    }
}