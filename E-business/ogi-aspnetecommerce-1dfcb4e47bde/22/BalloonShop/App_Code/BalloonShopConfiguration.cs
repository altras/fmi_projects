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
    // Store the number of products per page
    private readonly static int productsPerPage;
    // Store the product description length for product lists
    private readonly static int productDescriptionLength;
    // Store the name of your shop
    private readonly static string siteName;

    static BalloonShopConfiguration()
    {
        dbConnectionString = ConfigurationManager.ConnectionStrings["BalloonShopConnection"].ConnectionString;
        dbProviderName = ConfigurationManager.ConnectionStrings["BalloonShopConnection"].ProviderName;
        productsPerPage = System.Int32.Parse(ConfigurationManager.AppSettings["ProductsPerPage"]);
        productDescriptionLength = System.Int32.Parse(ConfigurationManager.AppSettings["ProductDescriptionLength"]);
        siteName = ConfigurationManager.AppSettings["SiteName"];
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

    // Returns the maximum number of products to be displayed on a page
    public static int ProductsPerPage
    {
        get
        {
            return productsPerPage;
        }
    }

    // Returns the length of product descriptions in products lists
    public static int ProductDescriptionLength
    {
        get
        {
            return productDescriptionLength;
        }
    }

    // Returns the length of product descriptions in products lists
    public static string SiteName
    {
        get
        {
            return siteName;
        }
    }

    // The PayPal shopping cart URL
    public static string PaypalUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["PaypalUrl"];
        }
    }

    // The PayPal e-mail account
    public static string PaypalEmail
    {
        get
        {
            return ConfigurationManager.AppSettings["PaypalEmail"];
        }
    }

    // Currency code (such as USD)
    public static string PaypalCurrency
    {
        get
        {
            return ConfigurationManager.AppSettings["PaypalCurrency"];
        }
    }

    // Return URL after a successful transaction
    public static string PaypalReturnUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["PaypalReturnUrl"];
        }
    }

    // Return URL after a canceled transaction
    public static string PaypalCancelUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["PaypalCancelUrl"];
        }
    }

    // Returns the number of days for shopping cart expiration
    public static int CartPersistDays
    {
      get
      {
        return int.Parse(ConfigurationManager.AppSettings["CartPersistDays"]);
      }
    }

    // Returns the email address for customers to contact the site
    public static string CustomerServiceEmail
    {
      get
      {
        return
           ConfigurationManager.AppSettings["CustomerServiceEmail"];
      }
    }

    // The "from" address for auto-generated order processor emails
    public static string OrderProcessorEmail
    {
      get
      {
        return
           ConfigurationManager.AppSettings["OrderProcessorEmail"];
      }
    }

    // The email address to use to contact the supplier
    public static string SupplierEmail
    {
      get
      {
        return ConfigurationManager.AppSettings["SupplierEmail"];
      }
    }

    // DataCash client code
    public static string DataCashClient
    {
      get
      {
        return ConfigurationManager.AppSettings["DataCashClient"];
      }
    }

    // DataCash password
    public static string DataCashPassword
    {
      get
      {
        return ConfigurationManager.AppSettings["DataCashPassword"];
      }
    }

    // DataCash currency
    public static string DataCashCurrency
    {
      get
      {
        return ConfigurationManager.AppSettings["DataCashCurrency"];
      }
    }

    // DataCash server URL
    public static string DataCashUrl
    {
      get
      {
        return ConfigurationManager.AppSettings["DataCashUrl"];
      }
    }

    // Amazon ECS REST URL
    public static string AmazonRestUrl
    {
      get
      {
        return ConfigurationManager.AppSettings["AmazonRestUrl"];
      }
    }

    // Subscription ID to access ECS
    public static string SubscriptionId
    {
      get
      {
        return ConfigurationManager.AppSettings["AmazonSubscriptionID"];
      }
    }

    // the Amazon.com associate ID
    public static string AssociateId
    {
      get
      {
        return ConfigurationManager.AppSettings["AmazonAssociateID"];
      }
    }

    // keywords used to do the Amazon search
    public static string SearchKeywords
    {

      get
      {
        return ConfigurationManager.AppSettings["AmazonSearchKeywords"];
      }
    }

    // search location
    public static string SearchIndex
    {
      get
      {
        return ConfigurationManager.AppSettings["AmazonSearchIndex"];
      }
    }

    // the Amazon response groups
    public static string ResponseGroups
    {
      get
      {
        return ConfigurationManager.AppSettings["AmazonResponseGroups"];
      }
    }

}
