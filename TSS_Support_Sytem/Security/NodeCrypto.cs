using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TSS_Support_Sytem.Security
{
    public class NodeCrypto
    {
        public static string Encrypt(string toEncrypt, string key, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = UTF8Encoding.UTF8.GetBytes("abcdefghijklmnop");// hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;

            tdes.IV = Convert.FromBase64String("pdMBMjdeFdo="); // <-- DO NOT CHANGE THIS CODE FOR HELL SAKE


            tdes.Mode = CipherMode.CBC;  // which is default     
            // tdes.Padding = PaddingMode.PKCS7;  // which is default

            Console.WriteLine("key as string: {0}", Convert.ToBase64String(tdes.IV));

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0,
                toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
    }
}
