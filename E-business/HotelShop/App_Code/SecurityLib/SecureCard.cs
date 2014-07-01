using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SecurityLib
{
  public class SecureCard
  {
    private bool isDecrypted = false;
    private bool isEncrypted = false;
    private string cardHolder;
    private string cardNumber;
    private string issueDate;
    private string expiryDate;
    private string issueNumber;
    private string cardType;
    private string encryptedData;
    private XmlDocument xmlCardData;

    public SecureCard(string newEncryptedData)
    {
      // constructor for use with encrypted data
      encryptedData = newEncryptedData;
      DecryptData();
    }

    public SecureCard(string newCardHolder,
      string newCardNumber, string newIssueDate,
      string newExpiryDate, string newIssueNumber,
      string newCardType)
    {
      // constructor for use with decrypted data
      cardHolder = newCardHolder;
      cardNumber = newCardNumber;
      issueDate = newIssueDate;
      expiryDate = newExpiryDate;
      issueNumber = newIssueNumber;
      cardType = newCardType;
      EncryptData();
    }

    private void CreateXml()
    {
      // encode card details as XML document
      xmlCardData = new XmlDocument();
      XmlElement documentRoot =
        xmlCardData.CreateElement("CardDetails");
      XmlElement child;

      child = xmlCardData.CreateElement("CardHolder");
      child.InnerXml = cardHolder;
      documentRoot.AppendChild(child);

      child = xmlCardData.CreateElement("CardNumber");
      child.InnerXml = cardNumber;
      documentRoot.AppendChild(child);

      child = xmlCardData.CreateElement("IssueDate");
      child.InnerXml = issueDate;
      documentRoot.AppendChild(child);

      child = xmlCardData.CreateElement("ExpiryDate");
      child.InnerXml = expiryDate;
      documentRoot.AppendChild(child);


      child = xmlCardData.CreateElement("IssueNumber");
      child.InnerXml = issueNumber;
      documentRoot.AppendChild(child);

      child = xmlCardData.CreateElement("CardType");
      child.InnerXml = cardType;
      documentRoot.AppendChild(child);
      xmlCardData.AppendChild(documentRoot);
    }

    private void ExtractXml()
    {
      // get card details out of XML document
      cardHolder =
        xmlCardData.GetElementsByTagName(
          "CardHolder").Item(0).InnerXml;
      cardNumber =
        xmlCardData.GetElementsByTagName(
          "CardNumber").Item(0).InnerXml;
      issueDate =
        xmlCardData.GetElementsByTagName(
          "IssueDate").Item(0).InnerXml;
      expiryDate =
        xmlCardData.GetElementsByTagName(
          "ExpiryDate").Item(0).InnerXml;
      issueNumber =
        xmlCardData.GetElementsByTagName(
          "IssueNumber").Item(0).InnerXml;
      cardType =
        xmlCardData.GetElementsByTagName(
          "CardType").Item(0).InnerXml;
    }

    private void EncryptData()
    {
      try
      {
        // put data into XML doc
        CreateXml();
        // encrypt data
        encryptedData =
          StringEncryptor.Encrypt(xmlCardData.OuterXml);
        // set encrypted flag
        isEncrypted = true;
      }
      catch
      {
       throw new SecureCardException("Unable to encrypt data.");
      }
    }

    private void DecryptData()
    {
      try
      {
        // decrypt data
        xmlCardData = new XmlDocument();
        xmlCardData.InnerXml =
          StringEncryptor.Decrypt(encryptedData);
        // extract data from XML
        ExtractXml();
        // set decrypted flag
        isDecrypted = true;
      }
      catch
      {
       throw new SecureCardException("Unable to decrypt data.");
      }
    }

    public string CardHolder
    {
      get
      {
        if (isDecrypted)
        {
          return cardHolder;
        }
        else
        {
          throw new SecureCardException("Data not decrypted.");
        }
      }
    }

    public string CardNumber
    {
      get
      {
        if (isDecrypted)
        {
          return cardNumber;
        }
        else
        {
          throw new SecureCardException("Data not decrypted.");
        }
      }
    }

    public string CardNumberX
    {
      get
      {
        if (isDecrypted)
        {
          return "XXXX-XXXX-XXXX-"
             + cardNumber.Substring(cardNumber.Length - 4, 4);
        }
        else
        {
          throw new SecureCardException("Data not decrypted.");
        }
      }
    }

    public string IssueDate
    {
      get
      {
        if (isDecrypted)
        {
          return issueDate;
        }
        else
        {
          throw new SecureCardException("Data not decrypted.");
        }
      }
    }

    public string ExpiryDate
    {
      get
      {
        if (isDecrypted)
        {
          return expiryDate;
        }
        else
        {
          throw new SecureCardException("Data not decrypted.");
        }
      }
    }

    public string IssueNumber
    {
      get
      {
        if (isDecrypted)
        {
          return issueNumber;
        }
        else
        {
          throw new SecureCardException("Data not decrypted.");
        }
      }
    }

    public string CardType
    {
      get
      {
        if (isDecrypted)
        {
          return cardType;
        }
        else
        {
          throw new SecureCardException("Data not decrypted.");
        }
      }
    }

    public string EncryptedData
    {
      get
      {
        if (isEncrypted)
        {
          return encryptedData;
        }
        else
        {
          throw new SecureCardException("Data not decrypted.");
        }
      }
    }
  }
}