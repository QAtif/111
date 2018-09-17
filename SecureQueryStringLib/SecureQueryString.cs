// Decompiled with JetBrains decompiler
// Type: SecureQueryString
// Assembly: SecureQueryStringLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C40AC0BD-F4E3-4AEB-AC1C-07E9D9892A80
// Assembly location: \\10.1.17.61\Team Sharing\Recruitment Admin Publish\bin\SecureQueryStringLib.dll

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Web;

public class SecureQueryString : NameValueCollection
{
  public static string QueryStringVar = "data";
  private readonly byte[] IV = new byte[8]
  {
    (byte) 240,
    (byte) 3,
    (byte) 45,
    (byte) 29,
    (byte) 0,
    (byte) 76,
    (byte) 173,
    (byte) 59
  };
  private DateTime _expireTime = DateTime.MaxValue;
  private const string cryptoKey = "ChangeThis!";
  private const string timeStampKey = "__TimeStamp__";

  public string EncryptedString
  {
    get
    {
      return HttpUtility.UrlEncode(this.encrypt(this.serialize()));
    }
  }

  public DateTime ExpireTime
  {
    get
    {
      return this._expireTime;
    }
    set
    {
      this._expireTime = value;
    }
  }

  public SecureQueryString()
  {
  }

  public SecureQueryString(string encryptedString)
  {
    this.deserialize(this.decrypt(encryptedString));
    if (DateTime.Compare(this.ExpireTime, DateTime.Now) < 0)
      throw new ExpiredQueryStringException();
  }

  public string decrypt(string encryptedQueryString)
  {
    try
    {
      byte[] inputBuffer = Convert.FromBase64String(encryptedQueryString.Replace(" ", "+"));
      TripleDESCryptoServiceProvider cryptoServiceProvider1 = new TripleDESCryptoServiceProvider();
      MD5CryptoServiceProvider cryptoServiceProvider2 = new MD5CryptoServiceProvider();
      cryptoServiceProvider1.Key = cryptoServiceProvider2.ComputeHash(Encoding.ASCII.GetBytes("ChangeThis!"));
      cryptoServiceProvider1.IV = this.IV;
      return Encoding.ASCII.GetString(cryptoServiceProvider1.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
    }
    catch (CryptographicException ex)
    {
      HttpContext.Current.Response.Redirect(ConfigurationSettings.AppSettings["StudentSignInPage"]);
      throw new InvalidQueryStringException();
    }
    catch (FormatException ex)
    {
      HttpContext.Current.Response.Redirect(ConfigurationSettings.AppSettings["StudentSignInPage"]);
      throw new InvalidQueryStringException();
    }
  }

  public string encrypt(string serializedQueryString)
  {
    byte[] bytes = Encoding.ASCII.GetBytes(serializedQueryString);
    TripleDESCryptoServiceProvider cryptoServiceProvider1 = new TripleDESCryptoServiceProvider();
    MD5CryptoServiceProvider cryptoServiceProvider2 = new MD5CryptoServiceProvider();
    cryptoServiceProvider1.Key = cryptoServiceProvider2.ComputeHash(Encoding.ASCII.GetBytes("ChangeThis!"));
    cryptoServiceProvider1.IV = this.IV;
    return Convert.ToBase64String(cryptoServiceProvider1.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length));
  }

  private void deserialize(string decryptedQueryString)
  {
    string str1 = decryptedQueryString;
    char[] chArray1 = new char[1]{ '&' };
    foreach (string str2 in str1.Split(chArray1))
    {
      char[] chArray2 = new char[1]{ '=' };
      string[] strArray = str2.Split(chArray2);
      if (strArray.Length == 2)
        this.Add(strArray[0], strArray[1]);
    }
    if (this["__TimeStamp__"] == null)
      return;
    this._expireTime = DateTime.Parse(this["__TimeStamp__"]);
  }

  private string serialize()
  {
    StringBuilder stringBuilder = new StringBuilder();
    foreach (string allKey in this.AllKeys)
    {
      stringBuilder.Append(allKey);
      stringBuilder.Append('=');
      stringBuilder.Append(this[allKey]);
      stringBuilder.Append('&');
    }
    stringBuilder.Append("__TimeStamp__");
    stringBuilder.Append('=');
    stringBuilder.Append((object) this._expireTime);
    return stringBuilder.ToString();
  }

  public override string ToString()
  {
    return this.EncryptedString;
  }
}
