using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TSS_Support_Sytem.Security
{
    public class AES256
    {
        public static string Decrypt(string cipherData, string keyString, string ivString)
        {
            byte[] key = Encoding.UTF8.GetBytes(keyString);
            byte[] iv = Encoding.UTF8.GetBytes(ivString);

            try
            {
                using (var rijndaelManaged =
                       new RijndaelManaged { Key = key, IV = iv, Mode = CipherMode.CBC })
                using (var memoryStream =
                       new MemoryStream(Convert.FromBase64String(cipherData)))
                using (var cryptoStream =
                       new CryptoStream(memoryStream,
                           rijndaelManaged.CreateDecryptor(key, iv),
                           CryptoStreamMode.Read))
                {
                    return new StreamReader(cryptoStream).ReadToEnd();
                }
            }
            catch (CryptographicException e)
            {
                return null;
            }
            
        }

        public static string EncryptString(string message, string KeyString, string IVString)
        {
            byte[] Key = ASCIIEncoding.UTF8.GetBytes(KeyString);
            byte[] IV = ASCIIEncoding.UTF8.GetBytes(IVString);

            string encrypted = null;
            RijndaelManaged rj = new RijndaelManaged();
            rj.Key = Key;
            rj.IV = IV;
            rj.Mode = CipherMode.CBC;

            try
            {
                MemoryStream ms = new MemoryStream();

                using (CryptoStream cs = new CryptoStream(ms, rj.CreateEncryptor(Key, IV), CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(message);
                        sw.Close();
                    }
                    cs.Close();
                }
                byte[] encoded = ms.ToArray();
                encrypted = Convert.ToBase64String(encoded);

                ms.Close();
            }
            catch (CryptographicException e)
            {
                return null;
            }
            catch (UnauthorizedAccessException e)
            {
                return null;
            }
            catch (Exception e)
            {
                
            }
            finally
            {
                rj.Clear();
            }
            return encrypted;
        }
    }
}
