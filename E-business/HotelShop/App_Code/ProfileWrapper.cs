using System;
using System.Web;
using System.Web.Security;
using SecurityLib;


/// <summary>
/// A wrapper around profile information, including
/// credit card encryption functionality.
/// </summary>
public class ProfileWrapper
{
  private string address1;
  private string address2;
  private string city;
  private string region;
  private string postalCode;
  private string country;
  private string shippingRegion;
  private string dayPhone;
  private string evePhone;
  private string mobPhone;
  private string email;
  private string creditCard;
  private string creditCardHolder;
  private string creditCardNumber;
  private string creditCardIssueDate;
  private string creditCardIssueNumber;
  private string creditCardExpiryDate;
  private string creditCardType;

  public string Address1
  {
    get
    {
      return address1;
    }
    set
    {
      address1 = value;
    }
  }
  public string Address2
  {
    get
    {
      return address2;
    }
    set
    {
      address2 = value;
    }
  }
  public string City
  {
    get
    {
      return city;
    }
    set
    {
      city = value;
    }
  }
  public string Region
  {
    get
    {
      return region;
    }
    set
    {
      region = value;
    }
  }
  public string PostalCode
  {
    get
    {
      return postalCode;
    }
    set
    {
      postalCode = value;
    }
  }
  public string Country
  {
    get
    {
      return country;
    }
    set
    {
      country = value;
    }
  }
  public string ShippingRegion
  {
    get
    {
      return shippingRegion;
    }
    set
    {
      shippingRegion = value;
    }
  }
  public string DayPhone
  {
    get
    {
      return dayPhone;
    }
    set
    {
      dayPhone = value;
    }
  }
  public string EvePhone
  {
    get
    {
      return evePhone;
    }
    set
    {
      evePhone = value;
    }
  }
  public string MobPhone
  {
    get
    {
      return mobPhone;
    }
    set
    {
      mobPhone = value;
    }
  }
  public string Email
  {
    get
    {
      return email;
    }
    set
    {
      email = value;
    }
  }
  public string CreditCard
  {
    get
    {
      return creditCard;
    }
    set
    {
      creditCard = value;
    }
  }
  public string CreditCardHolder
  {
    get
    {
      return creditCardHolder;
    }
    set
    {
      creditCardHolder = value;
    }
  }
  public string CreditCardNumber
  {
    get
    {
      return creditCardNumber;
    }
    set
    {
      creditCardNumber = value;
    }
  }
  public string CreditCardIssueDate
  {
    get
    {
      return creditCardIssueDate;
    }
    set
    {
      creditCardIssueDate = value;
    }
  }
  public string CreditCardIssueNumber
  {
    get
    {
      return creditCardIssueNumber;
    }
    set
    {
      creditCardIssueNumber = value;
    }
  }
  public string CreditCardExpiryDate
  {
    get
    {
      return creditCardExpiryDate;
    }
    set
    {
      creditCardExpiryDate = value;
    }
  }
  public string CreditCardType
  {
    get
    {
      return creditCardType;
    }
    set
    {
      creditCardType = value;
    }
  }

  public ProfileWrapper()
  {
    ProfileCommon profile =
    HttpContext.Current.Profile as ProfileCommon;
    address1 = profile.Address1;
    address2 = profile.Address2;
    city = profile.City;
    region = profile.Region;
    postalCode = profile.PostalCode;
    country = profile.Country;
    shippingRegion =
      (profile.ShippingRegion == null
      || profile.ShippingRegion == "" 
      ? "1" : profile.ShippingRegion);
    dayPhone = profile.DayPhone;
    evePhone = profile.EvePhone;
    mobPhone = profile.MobPhone;
    email = Membership.GetUser(profile.UserName).Email;

    try
    {
      SecureCard secureCard = new SecureCard(profile.CreditCard);
      creditCard = secureCard.CardNumberX;
      creditCardHolder = secureCard.CardHolder;
      creditCardNumber = secureCard.CardNumber;
      creditCardIssueDate = secureCard.IssueDate;
      creditCardIssueNumber = secureCard.IssueNumber;
      creditCardExpiryDate = secureCard.ExpiryDate;
      creditCardType = secureCard.CardType;
    }
    catch
    {
      creditCard = "Not entered.";
    }
  }

  public void UpdateProfile()
  {
    ProfileCommon profile =
     HttpContext.Current.Profile as ProfileCommon;
    profile.Address1 = address1;
    profile.Address2 = address2;
    profile.City = city;
    profile.Region = region;
    profile.PostalCode = postalCode;
    profile.Country = country;
    profile.ShippingRegion = shippingRegion;
    profile.DayPhone = dayPhone;
    profile.EvePhone = evePhone;
    profile.MobPhone = mobPhone;
    profile.CreditCard = creditCard;
    MembershipUser user = Membership.GetUser(profile.UserName);
    user.Email = email;
    Membership.UpdateUser(user); try
    {
      SecureCard secureCard = new SecureCard(
         creditCardHolder, creditCardNumber,
         creditCardIssueDate, creditCardExpiryDate,
         creditCardIssueNumber, creditCardType);
      profile.CreditCard = secureCard.EncryptedData;
    }
    catch
    {
      creditCard = "";
    }
  }
}