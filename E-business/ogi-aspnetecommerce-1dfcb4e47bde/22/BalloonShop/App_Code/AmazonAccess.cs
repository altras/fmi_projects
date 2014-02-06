using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Xml;
using AmazonEcs;

public class AmazonAccess
{
  public AmazonAccess()
  {
    //
    // TODO: Add constructor logic here
    //
  }

  // returns a configured DataTable object that can be read by the UI
  private static DataTable GetResponseTable()
  {
    DataTable dt = new DataTable();
    dt.Columns.Add(new DataColumn("ASIN", Type.GetType("System.String")));
    dt.Columns.Add(new DataColumn("ProductName", Type.GetType("System.String")));
    dt.Columns.Add(new DataColumn("ProductPrice",
    Type.GetType("System.String")));
    dt.Columns.Add("ProductImageUrl", typeof(string));
    return dt;
  }

  // perform the Amazon search with SOAP and return results as a DataTable
  public static DataTable GetAmazonDataWithSoap()
  {
    // Create Amazon objects
    AWSECommerceService amazonService = new AWSECommerceService();
    ItemSearch itemSearch = new ItemSearch();
    ItemSearchRequest itemSearchRequest = new ItemSearchRequest();
    ItemSearchResponse itemSearchResponse;
    // Setup Amazon objects
    itemSearch.SubscriptionId = BalloonShopConfiguration.SubscriptionId;
    itemSearchRequest.Keywords = BalloonShopConfiguration.SearchKeywords;
    itemSearchRequest.SearchIndex = BalloonShopConfiguration.SearchIndex;
    itemSearchRequest.ResponseGroup =
    BalloonShopConfiguration.ResponseGroups.Split(',');
    itemSearch.Request = new AmazonEcs.ItemSearchRequest[1] { itemSearchRequest };

    // Will store search results
    DataTable responseTable = GetResponseTable();
    // If any problems occur, we prefer to send back empty result set 
    // instead of throwing exception
    try
    {
      itemSearchResponse = amazonService.ItemSearch(itemSearch);
      Item[] results = itemSearchResponse.Items[0].Item;
      // Browse the results
      foreach (AmazonEcs.Item item in results)
      {
        // product with incomplete information will be ignored
        try
        {

          //create a datarow, populate it and add it to the table
          DataRow dataRow = responseTable.NewRow();
          dataRow["ASIN"] = item.ASIN;
          dataRow["ProductName"] = item.ItemAttributes.Title;
          dataRow["ProductImageUrl"] = item.SmallImage.URL;
          dataRow["ProductPrice"] = item.OfferSummary.LowestNewPrice.
        FormattedPrice;
          responseTable.Rows.Add(dataRow);
        }
        catch
        {
          // Ignore products with incomplete information
        }
      }
    }
    catch (Exception e)
    {
      // ignore the error
    }
    // return the results
    return responseTable;
  }

  // perform the Amazon search with REST and return results as a DataTable
  public static DataTable GetAmazonDataWithRest()
  {
    // The response data table
    DataTable responseTable = GetResponseTable();
    // Compose the Amazon REST request URL
    string amazonRequest = string.Format("{0}&SubscriptionId={1}&Operation=ItemSearch&Keywords={2}&SearchIndex={3}&ResponseGroup={4}", BalloonShopConfiguration.AmazonRestUrl, BalloonShopConfiguration.SubscriptionId, BalloonShopConfiguration.SearchKeywords, BalloonShopConfiguration.SearchIndex, BalloonShopConfiguration.ResponseGroups);
    // If any problems occur, we prefer to send back empty result set 
    // instead of throwing exception
    try
    {
      // Load the Amazon response
      XmlDocument responseXmlDoc = new XmlDocument();
      responseXmlDoc.Load(amazonRequest);
      // Prepare XML document for searching
      XmlNamespaceManager xnm = new XmlNamespaceManager
        (responseXmlDoc.NameTable);
      xnm.AddNamespace("amz", "http://webservices.amazon.com/AWSECommerceService/2005-10-05");
      // Get the list of Item nodes
      XmlNodeList itemNodes = responseXmlDoc.SelectNodes("/amz:ItemSearchResponse/amz:Items/amz:Item", xnm);
      // Copy node data to the DataTable
      foreach (XmlNode itemNode in itemNodes)
      {
        try
        {
          // Create a new datarow and populate it with data
          DataRow dataRow = responseTable.NewRow();
          dataRow["ASIN"] = itemNode["ASIN"].InnerText;
          dataRow["ProductName"] = itemNode["ItemAttributes"]["Title"].InnerText;
          dataRow["ProductImageUrl"] = itemNode["SmallImage"]["URL"].InnerText;
          dataRow["ProductPrice"] = itemNode["OfferSummary"]
        ["LowestNewPrice"]["FormattedPrice"].InnerText;
          // Add the row to the results table
          responseTable.Rows.Add(dataRow);
        }
        catch
        {
          // Ignore products with incomplete information
        }
      }
    }
    catch
    {
      // Ignore all possible errors
    }
    return responseTable;
  }


}
