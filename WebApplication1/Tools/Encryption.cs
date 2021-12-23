using System.Security.Cryptography;
using System.Text;

public class Encryption
{
    public static string MD5(string text)
    {
        MD5 md5 = new MD5CryptoServiceProvider();

        md5.ComputeHash(Encoding.ASCII.GetBytes(text));

        byte[] result = md5.Hash;

        StringBuilder strBuilder = new StringBuilder();
        for (int i = 0; i < result.Length; i++)
        {  
            strBuilder.Append(result[i].ToString("x2"));
        }

        return strBuilder.ToString();
    }
}