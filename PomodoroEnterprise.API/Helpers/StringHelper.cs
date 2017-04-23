using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PomodoroEnterprise.API
{
    public static class StringHelper
    {
        public static string Hash(this string text)
        {
            if ((text == null) || (text.Length == 0))
            {
                return String.Empty;
            }

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] textToHash = Encoding.Default.GetBytes(text);
            byte[] result = md5.ComputeHash(textToHash);

            return System.BitConverter.ToString(result);
        }
    }
}