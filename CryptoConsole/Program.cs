using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CryptoConsole
{
    internal class Program
    {

        static void Main(string[] args)
        {
            
            Console.WriteLine("Şifrelenecek metini giriniz ve enter tuşuna basınız:");

            string metin = Console.ReadLine();

            Console.WriteLine(Crypto.Sifrele(metin));
          


            Console.WriteLine("Çözmek istediğiniz şifreli metni giriniz: ");
            string sifreliMetin = Console.ReadLine();
            Console.WriteLine(Crypto.SifreCoz(sifreliMetin));

            Console.ReadLine();


        }
    }
}
