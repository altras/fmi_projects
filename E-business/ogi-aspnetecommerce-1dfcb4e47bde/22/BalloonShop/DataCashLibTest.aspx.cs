using System;
using DataCashLib;
using System.Text;
using System.IO;
using System.Xml.Serialization;

public partial class DataCashLibTest : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    // Prepare StringBuilder for output
    StringBuilder sb = new StringBuilder();

    // Initialize variables
    DataCashRequest request;
    XmlSerializer requestSerializer =
       new XmlSerializer(typeof(DataCashRequest));
    DataCashResponse response;
    XmlSerializer responseSerializer =
       new XmlSerializer(typeof(DataCashResponse));
    StringBuilder xmlBuilder;
    StringWriter xmlWriter;
    string dataCashUrl =
       "https://testserver.datacash.com/Transaction";
    string dataCashClient = "99341800";
    string dataCashPassword = "bbdNsX7p";

    // Construct pre request
    request = new DataCashRequest();
    request.Authentication.Client = dataCashClient;
    request.Authentication.Password = dataCashPassword;
    request.Transaction.TxnDetails.MerchantReference = "9999999";
    request.Transaction.TxnDetails.Amount.Amount = "49.99";
    request.Transaction.TxnDetails.Amount.Currency = "GBP";
    request.Transaction.CardTxn.Method = "pre";
    request.Transaction.CardTxn.Card.CardNumber =
       "4444333322221111";
    request.Transaction.CardTxn.Card.ExpiryDate = "10/11";

    // Display pre request
    sb.AppendLine("Pre Request:");
    xmlBuilder = new StringBuilder();
    xmlWriter = new StringWriter(xmlBuilder);
    requestSerializer.Serialize(xmlWriter, request);
    sb.AppendLine(xmlBuilder.ToString());
    sb.AppendLine();

    // Get pre response
    response = request.GetResponse(dataCashUrl);

    // Display pre response
    sb.AppendLine("Pre Response:");
    xmlBuilder = new StringBuilder();
    xmlWriter = new StringWriter(xmlBuilder);
    responseSerializer.Serialize(xmlWriter, response);
    sb.AppendLine(xmlBuilder.ToString());
    sb.AppendLine();

    // Construct fulfil request
    request = new DataCashRequest();
    request.Authentication.Client = dataCashClient;
    request.Authentication.Password = dataCashPassword;
    request.Transaction.HistoricTxn.Method = "fulfill";
    request.Transaction.HistoricTxn.AuthCode =
       response.MerchantReference;
    request.Transaction.HistoricTxn.Reference =
       response.DatacashReference;

    // Display fulfil request
    sb.AppendLine("Fulfil Request:");
    xmlBuilder = new StringBuilder();
    xmlWriter = new StringWriter(xmlBuilder);
    requestSerializer.Serialize(xmlWriter, request);
    sb.AppendLine(xmlBuilder.ToString());
    sb.AppendLine();

    // Get fulfil response
    response = request.GetResponse(dataCashUrl);

    // Display fulfil response
    sb.AppendLine("Fulfil Response:");
    xmlBuilder = new StringBuilder();
    xmlWriter = new StringWriter(xmlBuilder);
    responseSerializer.Serialize(xmlWriter, response);
    sb.AppendLine(xmlBuilder.ToString());

    // Output result
    OutputBox.Text = sb.ToString();
  }
}
