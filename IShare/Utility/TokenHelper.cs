using Newtonsoft.Json;
using System;

namespace Utility
{
    public static class TokenHelper
    {
        public static string CreateToken(int userId)
        {
            DateTime dateTimeExp = DateTime.Now.AddMinutes(60);
            var tokenData = new { userId, dateTimeExp };
            var tokenOrg = JsonConvert.SerializeObject(tokenData);
            string token = tokenOrg.DESEncryption();
            return token;
        }


        //Create token
        public static string DESEncryption(this string Text, string sKey = null)
        {
            sKey = sKey ?? "ishare";
            try
            {
                System.Security.Cryptography.DESCryptoServiceProvider des = new System.Security.Cryptography.DESCryptoServiceProvider();
                byte[] inputByteArray;
                inputByteArray = System.Text.Encoding.Default.GetBytes(Text);
                string md5SKey = Get32MD5One(sKey).Substring(0, 8);
                des.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(md5SKey);
                des.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(md5SKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                System.Security.Cryptography.CryptoStream cs = new System.Security.Cryptography.CryptoStream(ms, des.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.StringBuilder ret = new System.Text.StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                return ret.ToString();
            }
            catch { return "error"; }
        }

        public static string DESDecrypt(string Text, string sKey = null)
        {
            sKey = sKey ?? "ishare";
            try
            {
                System.Security.Cryptography.DESCryptoServiceProvider des = new System.Security.Cryptography.DESCryptoServiceProvider();
                int len;
                len = Text.Length / 2;
                byte[] inputByteArray = new byte[len];
                int x, i;
                for (x = 0; x < len; x++)
                {
                    i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                    inputByteArray[x] = (byte)i;
                }
                string md5SKey = Get32MD5One(sKey).Substring(0, 8);
                des.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(md5SKey);
                des.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(md5SKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                System.Security.Cryptography.CryptoStream cs = new System.Security.Cryptography.CryptoStream(ms, des.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return System.Text.Encoding.Default.GetString(ms.ToArray());
            }
            catch { return "error"; }
        }

        public static string Get32MD5One(string source)
        {
            using (System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(source));
                System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                string hash = sBuilder.ToString();
                return hash.ToUpper();
            }
        }
    }
}
