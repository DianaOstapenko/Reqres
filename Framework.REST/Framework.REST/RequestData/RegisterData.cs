namespace Framework.REST.RequestData
{
    public class RegisterRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }
    public class RegisterResponse
    {
        public string Token { get; set; }
        public string Error { get; set; }
    }
}