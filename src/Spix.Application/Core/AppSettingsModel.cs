namespace Spix.Application.Core;

public class AppSettings
{
    public Logging Logging { get; set; }
    public ConnectionStrings ConnectionStrings { get; set; }
    public KeycloakConfig Keycloak { get; set; }
    public string AllowedHosts { get; set; }

    public AppSettings()
    {
        Logging = new Logging();
        ConnectionStrings = new ConnectionStrings();
        Keycloak = new KeycloakConfig();
    }
}

public class Logging
{
    public LogLevel LogLevel { get; set; }

    public Logging()
    {
        LogLevel = new LogLevel();
    }
}

public class LogLevel
{
    public string Default { get; set; }
    public string Microsoft_AspNetCore { get; set; }

    public LogLevel()
    {
        Default = "Information";
        Microsoft_AspNetCore = "Warning";
    }
}

public class ConnectionStrings
{
    public string DefaultConnection { get; set; }

    public ConnectionStrings()
    {
        DefaultConnection = "";
    }
}

public class KeycloakConfig
{
    public string Authority { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string Realm { get; set; }

    public KeycloakConfig()
    {
        Authority = "";
        ClientId = "";
        ClientSecret = "";
        Realm = "";
    }
}

