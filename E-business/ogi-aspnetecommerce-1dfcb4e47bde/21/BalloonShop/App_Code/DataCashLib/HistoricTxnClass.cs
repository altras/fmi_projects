using System.Xml.Serialization;

namespace DataCashLib
{
  public class HistoricTxnClass
  {
    [XmlElement("reference")]
    public string Reference;

    [XmlElement("authcode")]
    public string AuthCode;

    [XmlElement("method")]
    public string Method;

    [XmlElement("tran_code")]
    public string TranCode;

    [XmlElement("duedate")]
    public string DueDate;
  }
}