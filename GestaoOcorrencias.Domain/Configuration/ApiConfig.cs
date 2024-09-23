namespace GestaoOcorrencias.Api.Configuration
{
    public interface IAppConfig
    {
        ConnectionStrings ConnectionStrings { get; set; }
    }
    public class AppConfig : IAppConfig
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string projGestaoOcorrencias { get; set; }
    }

    public class ApiSettings
    {
        public string projGestaoOcorrencias { get; set; }
    }
}
