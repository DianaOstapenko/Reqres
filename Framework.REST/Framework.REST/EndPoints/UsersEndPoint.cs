using System;
using System.Net;
using Framework.REST.RequestData;
using RestSharp;

namespace Framework.REST.EndPoints
{
    public class UsersEndPoint
    {
        private readonly ClientFactory _clientFactory = new ClientFactory();

        public ClientFactory ClientFactory
        {
            get { return _clientFactory; }
        }
        public UsersDto GetUsers()
        {
            var client = ClientFactory.GetClient();
            RestRequest request = new RestRequest(RestConst.UsersUrl);
            var result = client.Execute<UsersDto>(request);
            return result.Data;
        }

        public UsersDto GetUsersFromPage(int page)
        {
            var client = ClientFactory.GetClient();
            RestRequest request = new RestRequest($"{RestConst.UsersUrl}?page={page}");
            var result = client.Execute<UsersDto>(request);
            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Result status if 'GetAgents' is {result.StatusCode} [{result.StatusDescription}] but expected 200 [OK].");
            }
            return result.Data;
        }

        public UserDto GetSingleUser(int userIndex)
        {
            var client = ClientFactory.GetClient();
            RestRequest request = new RestRequest($"{RestConst.UsersUrl}/{userIndex}");
            var result = client.Execute<UserDto>(request);
            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Result status if 'GetAgents' is {result.StatusCode} [{result.StatusDescription}] but expected 200 [OK].");
            }
            return result.Data;
        }

        public IRestResponse<UserResponse> CreateUser(object jsonBody)
        {
            var client = ClientFactory.GetClient();
            RestRequest request = new RestRequest(RestConst.UsersUrl, Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(jsonBody);

            var result = client.Execute<UserResponse>(request);
            return result;
        }

        public IRestResponse<UserResponse> UpdateUser(int userIndex, object jsonBody, Method method = Method.PUT)
        {
            var client = ClientFactory.GetClient();
            RestRequest request = new RestRequest($"{RestConst.UsersUrl}/{userIndex}", method);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(jsonBody);

            var result = client.Execute<UserResponse>(request);
            return result;
        }
    }
}