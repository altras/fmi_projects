using System;
using System.Text;
using SecurityLib;

public partial class SecurityLibTester2 : System.Web.UI.Page
{
  protected void processButton_Click(object sender, EventArgs e)
  {
    string stringToEncrypt = encryptBox.Text;
    string stringToDecrypt = decryptBox.Text;
    string encryptedString =
    StringEncryptor.Encrypt(stringToEncrypt);
    if (stringToDecrypt == "")
    {
      stringToDecrypt = encryptedString;
    }
    string decryptedString =
    StringEncryptor.Decrypt(stringToDecrypt);

    StringBuilder sb = new StringBuilder();
    sb.Append("Encrypted data: ");
    sb.Append(encryptedString);
    sb.Append("<br />Decrypted data: ");
    sb.Append(decryptedString);
    result.Text = sb.ToString();
  }
}
