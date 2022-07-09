using EasieR.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EasieR.Implementation.Crypt
{
    public class CryptUtil
    {
        public static byte[] EncryptStringNew(string toEncrypt, string privateKey)
        {
            try
            {
                var key = GetKey(privateKey);

                using (var aes = Aes.Create())
                using (var encryptor = aes.CreateEncryptor(key, key))
                {
                    var plainText = Encoding.UTF8.GetBytes(toEncrypt);
                    return encryptor.TransformFinalBlock(plainText, 0, plainText.Length);
                }
            }
            catch (Exception ex)
            {
                throw new GeneralErrorException("Not valid key!");
            }

        }

        public static string DecryptToStringNew(byte[] encryptedData, string privateKey)
        {
            try
            {
                var key = GetKey(privateKey);
                using (var aes = Aes.Create())
                using (var encryptor = aes.CreateDecryptor(key, key))
                {
                    var decryptedBytes = encryptor
                        .TransformFinalBlock(encryptedData, 0, encryptedData.Length);
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
            catch (Exception ex)
            {
                throw new GeneralErrorException("Not valid key!");
            }
    
        }
        private static byte[] GetKey(string password)
        {
            var keyBytes = Encoding.UTF8.GetBytes(password);
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(keyBytes);
            }
        }
        public static string RandomString(int length)
        {
            Random rand = new Random();
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = pool[rand.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }

    }

}
