using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Thrones
{
    internal class Canta
    {
        private class Dugum
        {
            public Esya Veri;
            public Dugum Sonraki;

            public Dugum(Esya veri)
            {
                Veri = veri;
                Sonraki = null;
            }
        }

        private Dugum tepe;         // Stack mantığıyla en üstteki eşya
        private int kapasite;
        private int sayac;

        public Canta(int kapasite)
        {
            this.kapasite = kapasite;
            tepe = null;
            sayac = 0;
        }

        // Eşya ekle (Push)
        public void Ekle(Esya esya)
        {
            if (DoluMu())
            {
                Console.WriteLine("⛔ Çanta dolu, yeni eşya eklenemez.");
                return;
            }

            Dugum yeni = new Dugum(esya);
            yeni.Sonraki = tepe;
            tepe = yeni;
            sayac++;

            Console.WriteLine($"🎒 '{esya.Ad}' çantaya eklendi.");
        }

        // Eşya çıkar (Pop)
        public Esya Cikar()
        {
            if (BosMu())
            {
                Console.WriteLine("📭 Çanta boş, eşya çıkarılamaz.");
                return null;
            }

            Esya cikarilan = tepe.Veri;
            tepe = tepe.Sonraki;
            sayac--;

            Console.WriteLine($"🚮 '{cikarilan.Ad}' çantadan çıkarıldı.");
            return cikarilan;
        }

        // Belirli bir eşyayı kullan (by name) ve sil
        public bool EsyaKullan(string esyaAdi)
        {
            if (BosMu()) return false;

            Dugum onceki = null;
            Dugum simdiki = tepe;

            while (simdiki != null)
            {
                if (simdiki.Veri.Ad.Equals(esyaAdi, StringComparison.OrdinalIgnoreCase))
                {
                    if (onceki == null) // ilk eleman
                        tepe = simdiki.Sonraki;
                    else
                        onceki.Sonraki = simdiki.Sonraki;

                    sayac--;
                    Console.WriteLine($"🧪 '{esyaAdi}' eşyası kullanıldı ve çantadan çıkarıldı.");
                    return true;
                }

                onceki = simdiki;
                simdiki = simdiki.Sonraki;
            }

            Console.WriteLine($"❌ '{esyaAdi}' çantada bulunamadı.");
            return false;
        }

        // Çantadaki en üst eşyayı göster
        public Esya Goster()
        {
            if (BosMu()) return null;
            return tepe.Veri;
        }

        public void Yazdir()
        {
            if (BosMu())
            {
                Console.WriteLine("🎒 Çanta boş.");
                return;
            }

            Console.WriteLine("🎒 Çantadaki Eşyalar (üstten alta):");
            Dugum gecici = tepe;
            while (gecici != null)
            {
                Console.WriteLine($"- {gecici.Veri}");
                gecici = gecici.Sonraki;
            }
        }

        public bool DoluMu() => sayac >= kapasite;
        public bool BosMu() => sayac == 0;
        public int Sayac() => sayac;

        public void Temizle()
        {
            tepe = null;
            sayac = 0;
        }
    }
}
