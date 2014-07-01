using System.Xml.Serialization;

namespace DataCashLib
{
  public class CardTxnResponseClass
  {
    [XmlElement("card_scheme")]
    public string CardScheme;

    [XmlElement("country")]
    public string Country;

    [XmlElement("issuer")]
    public string Issuer;

    [XmlElement("authcode")]
    public string AuthCode;
  }
}