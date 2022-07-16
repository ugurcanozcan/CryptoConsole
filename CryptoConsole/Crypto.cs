using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptoConsole
{
    internal static class Crypto
    {
        public static string Sifrele(string metin)
        {
            byte[] metinByte = UTF8Encoding.UTF8.GetBytes(metin);

            // Sistemin kripto servisine ait classı intsence alındı.
            using (MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider())
            {
                //anahtarımız şifrelemeye hazırlanmak üzere byte çevrildi.
                byte[] anahtarlar = provider.ComputeHash(UTF8Encoding.UTF8.GetBytes("Galatasaray"));

                using (TripleDESCryptoServiceProvider serviceProvider = new TripleDESCryptoServiceProvider()
                { Key = anahtarlar, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {

                    ICryptoTransform transform = serviceProvider.CreateEncryptor();
                    byte[] sonuc = transform.TransformFinalBlock(metinByte, 0, metinByte.Length);
                    return Convert.ToBase64String(sonuc);
                }
            }


        }

        public static string SifreCoz(string sifreliMetin)
        {
            byte[] sifreliMetinByte = Convert.FromBase64String(sifreliMetin);
            using (MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider())
            {
                //anahtarımız şifrelemeye hazırlanmak üzere byte çevrildi.
                byte[] anahtarlar = provider.ComputeHash(UTF8Encoding.UTF8.GetBytes("Galatasaray"));

                using (TripleDESCryptoServiceProvider serviceProvider = new TripleDESCryptoServiceProvider()
                { Key = anahtarlar, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {

                    ICryptoTransform transform = serviceProvider.CreateDecryptor();
                    byte[] sonuc = transform.TransformFinalBlock(sifreliMetinByte, 0, sifreliMetinByte.Length);

                    return UTF8Encoding.UTF8.GetString(sonuc);
                }
            }
        }



    }
}
