using System.Xml.Serialization;
using System.IO;
using System.Text;

namespace DataCashLib
{
  [XmlRoot("Response")]
  public class DataCashResponse
  {
    [XmlElement("status")]
    public string Status;


    [XmlElement("reason")]
    public string Reason;

    [XmlElement("information")]
    public string information;

    [XmlElement("merchantreference")]
    public string MerchantReference;

    [XmlElement("datacash_reference")]
    public string DatacashReference;

    [XmlElement("time")]
    public string Time;

    [XmlElement("mode")]
    public string Mode;

    [XmlElement("CardTxn")]
    public CardTxnResponseClass CardTxn;

    [XmlIgnore()]
    public string Xml
    {
      get
      {
        // Prepare XML serializer
        XmlSerializer serializer =
          new XmlSerializer(typeof(DataCashResponse));
        // Serialize into StringBuilder
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        serializer.Serialize(sw, this);
        sw.Flush();

        // Replace UTF-16 encoding with UTF-8 encoding
        string xml = sb.ToString();
        xml = xml.Replace("utf-16", "utf-8");
        return xml;
      }
    }
  }
}