using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Thrones
{
    internal class KurtarmaSirasi
    {
        private string[] koyler;
        private int bas;
        private int son;
        private int sayac;
        private int kapasite;

        public KurtarmaSirasi(int boyut)
        {
            kapasite = boyut;
            koyler = new string[kapasite];
            bas = 0;
            son = -1;
            sayac = 0;
        }

        public void Ekle(string koyAdi)
        {
            if (DoluMu())
            {
                Console.WriteLine("⛔ Kurtarma sırası dolu.");
                return;
            }

            son = (son + 1) % kapasite;
            koyler[son] = koyAdi;
            sayac++;
            Console.WriteLine($"📌 '{koyAdi}' sıraya eklendi.");
        }

        public string Cikar()
        {
            if (BosMu())
            {
                Console.WriteLine("📭 Sırada kurtarılacak köy kalmadı.");
                return null;
            }

            string silinen = koyler[bas];
            bas = (bas + 1) % kapasite;
            sayac--;
            Console.WriteLine($"✅ '{silinen}' kurtarıldı.");
            return silinen;
        }

        public string IlkKoy()
        {
            if (BosMu()) return null;
            return koyler[bas];
        }

        public void Yazdir()
        {
            if (BosMu())
            {
                Console.WriteLine("📭 Sıra boş.");
                return;
            }

            Console.WriteLine("📜 Kurtarılacak Köyler:");
            for (int i = 0; i < sayac; i++)
            {
                int index = (bas + i) % kapasite;
                Console.WriteLine($"- {koyler[index]}");
            }
        }

        public bool BosMu() => sayac == 0;
        public bool DoluMu() => sayac == kapasite;
        public int Sayac() => sayac;
    }
}
