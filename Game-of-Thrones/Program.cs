using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Thrones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OyunMotoru oyun = new OyunMotoru();

            bool devam = true;
            while (devam)
            {
                Console.WriteLine("\n--- Game of Thrones Kurtarma Menüsü ---");
                Console.WriteLine("1 - Köyleri kurtarmaya başla");
                Console.WriteLine("2 - Çantayı görüntüle");
                Console.WriteLine("3 - Eşya kullan");
                Console.WriteLine("4 - Eşya ara (ağaçta)");
                Console.WriteLine("5 - Oyundaki köyleri listele");
                Console.WriteLine("0 - Oyunu bitir");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();
                Console.WriteLine();

                switch (secim)
                {
                    case "1":
                        oyun.BirSonrakiKoyuKurtar();
                        break;

                    case "2":
                        oyun.CantayiGoster();
                        break;

                    case "3":
                        Console.Write("Kullanmak istediğiniz eşya: ");
                        string kullanilacak = Console.ReadLine();
                        oyun.EsyaKullan(kullanilacak);
                        break;

                    case "4":
                        Console.Write("Aranacak eşya adı: ");
                        string aranacak = Console.ReadLine();
                        oyun.EsyaAra(aranacak);
                        break;

                    case "5":
                        oyun.KoyleriListele();
                        break;

                    case "0":
                        devam = false;
                        Console.WriteLine("🛑 Oyun sonlandırıldı.");
                        break;

                    default:
                        Console.WriteLine("⚠️ Geçersiz seçim.");
                        break;
                }
            }
        }
    }
}
