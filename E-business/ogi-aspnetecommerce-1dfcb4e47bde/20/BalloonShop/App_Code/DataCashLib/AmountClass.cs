using System.Xml.Serialization;

namespace DataCashLib
{
  public class AmountClass
  {
    [XmlAttribute("currency")]
    public string Currency;

    [XmlText()]
    public string Amount;
  }
}
