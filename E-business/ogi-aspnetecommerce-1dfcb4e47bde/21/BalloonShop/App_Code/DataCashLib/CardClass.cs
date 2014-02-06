using System.Xml.Serialization;

namespace DataCashLib
{
  public class CardClass
  {
    [XmlElement("pan")]
    public string CardNumber;

    [XmlElement("expirydate")]
    public string ExpiryDate;

    [XmlElement("startdate")]
    public string StartDate;

    [XmlElement("issuenumber")]
    public string IssueNumber;
  }
}