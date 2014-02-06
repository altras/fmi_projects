using System;
using System.Text;
using SecurityLib;

public partial class SecurityLibTester3 : System.Web.UI.Page
{
  protected void processButton_Click(object sender, EventArgs e)
  {
    SecureCard encryptedCard =
    new SecureCard(cardHolderBox.Text, cardNumberBox.Text,
      issueDateBox.Text, expiryDateBox.Text,issueNumberBox.Text,
      cardTypeBox.Text);
    string encryptedData = encryptedCard.EncryptedData;
    SecureCard decryptedCard = new SecureCard(encryptedData);
    string decryptedData = string.Format(
      "{0}, {1}, {2}, {3}, {4}, {5}",
      decryptedCard.CardHolder, decryptedCard.CardNumber,
      decryptedCard.IssueDate, decryptedCard.ExpiryDate,
      decryptedCard.IssueNumber, decryptedCard.CardType);
    StringBuilder sb = new StringBuilder();
    sb.Append("Encrypted data:<br />");
    sb.Append("<textarea style=\"width:400px;height:150px;\">");
    sb.Append(encryptedData);
    sb.Append("</textarea><br />Decrypted data:");
    sb.Append(decryptedData);
    result.Text = sb.ToString();
  }
}
