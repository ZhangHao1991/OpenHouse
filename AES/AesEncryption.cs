using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AES
{
    public class AesEncryption
    {
        private static readonly byte[] Salt = Encoding.ASCII.GetBytes("tIWKrbWwo8empPMR"); // 自定义盐值，需要保持16位长度

        // AES加密
        public static byte[] Encrypt(string plainText, string password)
        {
            byte[] encryptedBytes;
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

            using (AesManaged aes = new AesManaged())
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;
                var key = new Rfc2898DeriveBytes(password, Salt, 1000); // 密码学中的PBKDF2算法，用于生成安全的随机密钥
                aes.Key = key.GetBytes(aes.KeySize / 8); // 获取256位密钥
                aes.IV = key.GetBytes(aes.BlockSize / 8); // 获取128位IV

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(plainBytes, 0, plainBytes.Length);
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        // AES解密
        public static string Decrypt(byte[] encryptedBytes, string password)
        {
            string plainText;
            using (AesManaged aes = new AesManaged())
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;
                var key = new Rfc2898DeriveBytes(password, Salt, 1000); // 密码学中的PBKDF2算法，用于生成安全的随机密钥
                aes.Key = key.GetBytes(aes.KeySize / 8); // 获取256位密钥
                aes.IV = key.GetBytes(aes.BlockSize / 8); // 获取128位IV

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(encryptedBytes, 0, encryptedBytes.Length);
                    }
                    plainText = Encoding.UTF8.GetString(ms.ToArray());
                }
            }

            return plainText;
        }


        public static string AESjia(string plainText)
        {
            // 设置加密密码
            string password = "ZMP16rZc3DHzmVKc";

            // 加密字符串
            byte[] encryptedBytes = AesEncryption.Encrypt(plainText, password);

            // 输出加密结果

            return Convert.ToBase64String(encryptedBytes);
        }

        public static string AESjian(string plainText)
        {
            // 设置加密密码
            string password = "ZMP16rZc3DHzmVKc";

            byte[] encryptedBytes = Convert.FromBase64String(plainText);

            // 调用解密函数
            string decryptedText = AesEncryption.Decrypt(encryptedBytes, password);
            return decryptedText;
        }
    }
}
