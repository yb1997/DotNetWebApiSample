namespace PracticeWebApi.Common
{
    public class AppConfig
    {
        public ConnectionStringCollection ConnectionStrings { get; set; }
        public string Secret { get; set; } = "";
    }

    public class ConnectionStringCollection
    {
        public string DefaultConnection { get; set; } = "";
    }
}
