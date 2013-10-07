using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace STS.Models.Helper
{
    public class EncryptionProvider
    {

        public static string GetHashValue(string textToHash)
        {
            if (!string.IsNullOrEmpty(textToHash))
            {
                MD5 md5Provider = new MD5CryptoServiceProvider();
                Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(textToHash);
                Byte[] encodedBytes = md5Provider.ComputeHash(originalBytes);
                string encodedString = BitConverter.ToString(encodedBytes);

                return encodedString.Replace("-", "");
            }
            else
            {
                return textToHash;
            }
        }

        public static string GetRandomPassword(int passwordLength)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars); ;
        }
    }
}
