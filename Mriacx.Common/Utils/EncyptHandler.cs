using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Mriacx.Common.Utils
{
    public class EncyptHandler
    {
        #region RSA
        public const string RSAtoken = "Mdsd-DoCare2019RSA";
        /// <summary>
        /// generate private key and public key arr[0] for private key arr[1] for public key
        /// </summary>
        /// <returns></returns>
        public static string[] RSA_GenerateKeys()
        {
            var sKeys = new String[2];
            var rsa = new RSACryptoServiceProvider();
            sKeys[0] = rsa.ToXmlString(true);
            sKeys[1] = rsa.ToXmlString(false);
            return sKeys;
        }
        /// <summary>
        /// RSA Encrypt
        /// </summary>
        /// <param name="sSource" >Source string</param>
        /// <param name="sPublicKey" >public key</param>
        /// <returns></returns>
        public static string RSA_EncryptString(string sSource, string sPublicKey)
        {
            var rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(sPublicKey);
            var plainTxt = Encoding.UTF8.GetBytes(sSource);
            cipherbytes = rsa.Encrypt(plainTxt, true);
            return Convert.ToBase64String(cipherbytes);
        }

        /// <summary>
        /// RSA Decrypt
        /// </summary>
        /// <param name="sSource">Source string</param>
        /// <param name="sPrivateKey">Private Key</param>
        /// <returns></returns>
        public static string RSA_DecryptString(String sSource, string sPrivateKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(sPrivateKey);
            cipherbytes = rsa.Decrypt(Convert.FromBase64String(sSource), false);

            return Encoding.UTF8.GetString(cipherbytes);
        }
        #endregion

        #region MD5

        public const string MD5_Token = "Mdsd-DoCare2019MD5";
        public static string MD5_String(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            var data = Encoding.Default.GetBytes(str);
            var result = md5.ComputeHash(data);
            var ret = "";
            for (var i = 0; i < result.Length; i++)
                ret += result[i].ToString("x").PadLeft(2, '0');
            return ret;
        }
        public static string Md5WithToken(string str)
        {
            return MD5_String(str + MD5_Token);
        }

        #endregion

        #region DES

        private const string DES_Key = "Mriacx~€";//密钥，且必须为8位。

        /// <summary>
        /// Encrypt with DES。
        /// </summary>
        /// <param name="pToEncrypt">要加密的字符串。</param>
        /// <returns>以Base64格式返回的加密字符串。</returns>
        public static string DESEncrypt(string pToEncrypt)
        {
            using (var des = new DESCryptoServiceProvider())
            {
                var inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);
                des.Key = Encoding.ASCII.GetBytes(DES_Key);
                des.IV = Encoding.ASCII.GetBytes(DES_Key);
                var ms = new System.IO.MemoryStream();
                using (var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                var str = Convert.ToBase64String(ms.ToArray());
                ms.Close();
                return str;
            }
        }

        /**/
        /// <summary>
        /// 进行DES解密。
        /// </summary>
        /// <param name="pToDecrypt">要解密的以Base64</param>
        /// <returns>已解密的字符串。</returns>
        public static string DESDecrypt(string pToDecrypt)
        {
            var inputByteArray = Convert.FromBase64String(pToDecrypt);
            using (var des = new DESCryptoServiceProvider())
            {
                des.Key = Encoding.ASCII.GetBytes(DES_Key);
                des.IV = Encoding.ASCII.GetBytes(DES_Key);
                var ms = new System.IO.MemoryStream();
                using (var cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                var str = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return str;
            }
        }
        #endregion
    }
}
