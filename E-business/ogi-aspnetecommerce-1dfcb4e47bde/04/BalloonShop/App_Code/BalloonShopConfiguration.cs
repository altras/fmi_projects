using System.Configuration;

/// <summary>
/// Repository for BalloonShop configuration settings
/// </summary>
public static class BalloonShopConfiguration
{
    // Caches the connection string
    private static string dbConnectionString;
    // Caches the data provider name 
    private static string dbProviderName;

    static BalloonShopConfiguration()
    {
        dbConnectionString = ConfigurationManager.ConnectionStrings["BalloonShopConnection"].ConnectionString;
        dbProviderName = ConfigurationManager.ConnectionStrings["BalloonShopConnection"].ProviderName;
    }

    // Returns the connection string for the BalloonShop database
    public static string DbConnectionString
    {
        get
        {
            return dbConnectionString;
        }
    }

    // Returns the data provider name
    public static string DbProviderName
    {
        get
        {
            return dbProviderName;
        }
    }


    // Returns the address of the mail server
    public static string MailServer
    {
        get
        {
            return ConfigurationManager.AppSettings["MailServer"];
        }
    }

    // Returns the port of the mail server
    public static int MailServerPort
    {
        get
        {
            return System.Int32.Parse(ConfigurationManager.AppSettings["MailServerPort"]);
        }
    }

    // Returns the email username
    public static string MailUsername
    {
        get
        {
            return ConfigurationManager.AppSettings["MailUsername"];
        }
    }

    // Returns the email password
    public static string MailPassword
    {
        get
        {
            return ConfigurationManager.AppSettings["MailPassword"];
        }
    }

    // Returns the email password
    public static string MailFrom
    {
        get
        {
            return ConfigurationManager.AppSettings["MailFrom"];
        }
    }

    // Send error log emails?
    public static bool EnableErrorLogEmail
    {
        get
        {
            return bool.Parse(ConfigurationManager.AppSettings
            ["EnableErrorLogEmail"]);
        }
    }

    // Returns the email address where to send error reports
    public static string ErrorLogEmail
    {
        get
        {
            return ConfigurationManager.AppSettings["ErrorLogEmail"];
        }
    }
}
