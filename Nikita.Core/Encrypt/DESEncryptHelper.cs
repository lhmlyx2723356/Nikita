using System;
using System.Security.Cryptography;
using System.Text;

namespace Nikita.Core.Encrypt
{
    /// <summary>
    /// DES加密/解密类。
    /// </summary>
    public class DESEncryptHelper
    {
        #region ========加密========

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string Encrypt(string strText)
        {
            return Encrypt(strText, "litianping");
        }

        /// <summary>
        /// 加密数据
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string Encrypt(string strText, string strKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            var inputByteArray = Encoding.Default.GetBytes(strText);
            var forStoringInConfigFile = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strKey, "md5");
            if (forStoringInConfigFile != null)
                des.Key = Encoding.ASCII.GetBytes(forStoringInConfigFile.Substring(0, 8));
            var hashPasswordForStoringInConfigFile = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strKey, "md5");
            if (hashPasswordForStoringInConfigFile != null)
                des.IV = Encoding.ASCII.GetBytes(hashPasswordForStoringInConfigFile.Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        #endregion ========加密========

        #region ========解密========

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string Decrypt(string strText)
        {
            return Decrypt(strText, "litianping");
        }

        /// <summary>
        /// 解密数据
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string Decrypt(string strText, string strKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            var len = strText.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x;
            for (x = 0; x < len; x++)
            {
                var i = Convert.ToInt32(strText.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            var hashPasswordForStoringInConfigFile = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strKey, "md5");
            if (hashPasswordForStoringInConfigFile != null)
                des.Key = Encoding.ASCII.GetBytes(hashPasswordForStoringInConfigFile.Substring(0, 8));
            var passwordForStoringInConfigFile = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strKey, "md5");
            if (passwordForStoringInConfigFile != null)
                des.IV = Encoding.ASCII.GetBytes(passwordForStoringInConfigFile.Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }

        #endregion ========解密========
    }
}