using System.Xml.Serialization;

namespace DataCashLib
{
  public class CardTxnRequestClass
  {
    [XmlElement("method")]
    public string Method;

    [XmlElement("Card")]
    public CardClass Card = new CardClass();
  }
}