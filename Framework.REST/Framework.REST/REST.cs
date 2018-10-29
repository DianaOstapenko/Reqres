using Framework.REST.EndPoints;

namespace Framework.REST
{
    public class REST
    {
        internal static string UserName { get; set; }
        internal static string UserPass { get; set; }
        public static string Url { get; set; }

        public static UsersEndPoint Users { get; } = new UsersEndPoint();
        public static RegisterEndPoint Register { get; } = new RegisterEndPoint();
    }
}