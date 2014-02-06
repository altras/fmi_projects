using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace SecurityLib
{
  public static class StringEncryptor
  {
    public static string Encrypt(string sourceData)
    {
      // set key and initialization vector values
      byte[] key = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
      byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
      try
      {
        // convert data to byte array
        byte[] sourceDataBytes =
          System.Text.ASCIIEncoding.ASCII.GetBytes(sourceData);

        // get target memory stream
        MemoryStream tempStream = new MemoryStream();

        // get encryptor and encryption stream
        DESCryptoServiceProvider encryptor =
          new DESCryptoServiceProvider();
        CryptoStream encryptionStream =
          new CryptoStream(tempStream,
            encryptor.CreateEncryptor(key, iv),
            CryptoStreamMode.Write);

        // encrypt data
        encryptionStream.Write(sourceDataBytes, 0,
          sourceDataBytes.Length);
        encryptionStream.FlushFinalBlock();

        // put data into byte array
        byte[] encryptedDataBytes = tempStream.GetBuffer();

        // convert encrypted data into string
        return Convert.ToBase64String(encryptedDataBytes, 0,
         (int)tempStream.Length);
      }
      catch
      {
        throw new StringEncryptorException(
          "Unable to encrypt data.");
      }
    }

    public static string Decrypt(string sourceData)
    {
      // set key and initialization vector values
      byte[] key = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
      byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
      try
      {
        // convert data to byte array
        byte[] encryptedDataBytes =
          Convert.FromBase64String(sourceData);

        // get source memory stream and fill it 
        MemoryStream tempStream =
          new MemoryStream(encryptedDataBytes, 0,
            encryptedDataBytes.Length);


        // get decryptor and decryption stream 
        DESCryptoServiceProvider decryptor =
          new DESCryptoServiceProvider();
        CryptoStream decryptionStream =
          new CryptoStream(tempStream,
            decryptor.CreateDecryptor(key, iv),
            CryptoStreamMode.Read);

        // decrypt data 
        StreamReader allDataReader =
          new StreamReader(decryptionStream);
        return allDataReader.ReadToEnd();
      }
      catch
      {
        throw new StringEncryptorException(
          "Unable to decrypt data.");
      }
    }
  }
}
