using System.Xml.Serialization;
using System.IO;
using System.Net;
using System.Text;

namespace DataCashLib
{
  [XmlRoot("Request")]
  public class DataCashRequest
  {
    [XmlElement("Authentication")]
    public AuthenticationClass Authentication =
    new AuthenticationClass();

    [XmlElement("Transaction")]
    public TransactionClass Transaction = new TransactionClass();

    public DataCashResponse GetResponse(string url)
    {
      // Configure HTTP Request
      HttpWebRequest httpRequest = WebRequest.Create(url)
      as HttpWebRequest;
      httpRequest.Method = "POST";

      // Prepare correct encoding for XML serialization
      UTF8Encoding encoding = new UTF8Encoding();

      // Use Xml property to obtain serialized XML data
      // Convert into bytes using encoding specified above and
      // get length
      byte[] bodyBytes = encoding.GetBytes(Xml);
      httpRequest.ContentLength = bodyBytes.Length;

      // Get HTTP Request stream for putting XML data into
      Stream httpRequestBodyStream =
      httpRequest.GetRequestStream();

      // Fill stream with serialized XML data
      httpRequestBodyStream.Write(bodyBytes, 0, bodyBytes.Length);
      httpRequestBodyStream.Close();

      // Get HTTP Response
      HttpWebResponse httpResponse = httpRequest.GetResponse()
      as HttpWebResponse;
      StreamReader httpResponseStream =
      new StreamReader(httpResponse.GetResponseStream(),
      System.Text.Encoding.ASCII);

      // Extract XML from response
      string httpResponseBody = httpResponseStream.ReadToEnd();
      httpResponseStream.Close();


      // Ignore everything that isn't XML by removing headers
      httpResponseBody = httpResponseBody.Substring(
      httpResponseBody.IndexOf("<?xml"));

      // Deserialize XML into DataCashResponse
      XmlSerializer serializer =
      new XmlSerializer(typeof(DataCashResponse));
      StringReader responseReader =
      new StringReader(httpResponseBody);

      // Return DataCashResponse result
      return serializer.Deserialize(responseReader)
      as DataCashResponse;
    }

    [XmlIgnore()]
    public string Xml
    {
      get
      {
        // Prepare XML serializer
        XmlSerializer serializer =
          new XmlSerializer(typeof(DataCashRequest));

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