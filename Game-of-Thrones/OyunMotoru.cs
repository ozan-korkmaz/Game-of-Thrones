using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Thrones
{
    internal class OyunMotoru
    {
        private List<Koy> koyler;
        private Canta canta;
        private KurtarmaSirasi sira;
        private EsyaAgaci agac;
        private int ilerlemeSayaci = 0;
        private bool oyunBasladi = false;

        public OyunMotoru()
        {
            koyler = SahteVeriYukleyici.KoyleriGetir();
            canta = new Canta(10);
            sira = new KurtarmaSirasi(10);
            agac = new EsyaAgaci();
        }

        public void OyunuBaslat()
        {
            Console.WriteLine("🔥 Game of Thrones Kurtarma Görevi Başladı!");

            // 1. Tüm köyleri sıraya al
            foreach (var koy in koyler)
            {
                sira.Ekle(koy.Ad);
            }

            Console.WriteLine("\n📦 Eşyalar yükleniyor ve ağaç yapısına ekleniyor...\n");

            // 2. Tüm köylerdeki eşyaları BST'ye ekle
            foreach (var koy in koyler)
            {
                foreach (var esya in koy.Esyalar)
                {
                    agac.Ekle(esya);
                }
            }

            agac.Yazdir();

            Console.WriteLine("\n⛑️ Kurtarma Görevi Başladı:\n");

            // 3. Köyleri sırayla kurtar ve eşya topla
            while (!sira.BosMu())
            {
                string koyAdi = sira.Cikar();
                Koy aktifKoy = koyler.Find(k => k.Ad == koyAdi);

                Console.WriteLine($"\n🔔 {koyAdi} köyündesin.");

                // Eğer bu köyün özel şartı varsa
                if (aktifKoy.GerekenEsyalar.Count > 0)
                {
                    bool eksikVar = false;

                    foreach (var gereken in aktifKoy.GerekenEsyalar)
                    {
                        if (!canta.EsyaKullan(gereken))
                        {
                            eksikVar = true;
                        }
                    }

                    if (eksikVar)
                    {
                        Console.WriteLine($"❌ '{koyAdi}' köyü gerekli eşyalar olmadan kurtarılamaz!");
                        continue;
                    }

                    Console.WriteLine($"✅ Gerekli eşyalar kullanıldı, {koyAdi} kurtarılıyor!");
                }

                foreach (var esya in aktifKoy.Esyalar)
                {
                    canta.Ekle(esya);
                }

                Console.WriteLine("\n🎒 Güncel Çanta Durumu:");
                canta.Yazdir();
            }


            Console.WriteLine("\n🎉 Tüm köyler kurtarıldı!");
            Console.WriteLine("\n🧠 Oyundaki tüm eşyalar (BST sıralı):");
            agac.Yazdir();
        }

        public void BirSonrakiKoyuKurtar()
        {
            if (!oyunBasladi)
            {
                Console.WriteLine("🔥 Game of Thrones Kurtarma Görevi Başladı!");
                foreach (var koy in koyler)
                {
                    sira.Ekle(koy.Ad);
                }

                Console.WriteLine("\n📦 Eşyalar yükleniyor ve ağaç yapısına ekleniyor...\n");

                foreach (var koy in koyler)
                {
                    foreach (var esya in koy.Esyalar)
                    {
                        agac.Ekle(esya);
                    }
                }

                oyunBasladi = true;
                Console.WriteLine("✅ Hazırlıklar tamamlandı. İlk köy kurtarılabilir.");
            }

            if (sira.BosMu())
            {
                Console.WriteLine("\n🎉 Tüm köyler kurtarıldı!");
                return;
            }

            string koyAdi = sira.Cikar();
            Koy aktifKoy = koyler.Find(k => k.Ad == koyAdi);

            Console.WriteLine($"\n🔔 {koyAdi} köyündesin.");

            // Gereken eşyalar kontrolü
            if (aktifKoy.GerekenEsyalar.Count > 0)
            {
                bool eksikVar = false;

                foreach (var gereken in aktifKoy.GerekenEsyalar)
                {
                    if (!canta.EsyaKullan(gereken))
                        eksikVar = true;
                }

                if (eksikVar)
                {
                    Console.WriteLine($"❌ '{koyAdi}' köyü gerekli eşyalar olmadan kurtarılamaz!");
                    return;
                }

                Console.WriteLine($"✅ Gerekli eşyalar kullanıldı, {koyAdi} kurtarılıyor!");
            }

            foreach (var esya in aktifKoy.Esyalar)
            {
                canta.Ekle(esya);
            }

            Console.WriteLine("\n🎒 Güncel Çanta Durumu:");
            canta.Yazdir();
        }

        public void EsyaAra(string ad)
        {
            Console.WriteLine($"🔍 '{ad}' eşyası aranıyor...");
            bool varMi = agac.Ara(ad);
            Console.WriteLine(varMi ? $"✅ '{ad}' bulundu!" : $"❌ '{ad}' bulunamadı.");
        }

        public void CantayiGoster()
        {
            Console.WriteLine("🎒 Çanta durumu:");
            canta.Yazdir();
        }

        public void EsyaKullan(string ad)
        {
            canta.EsyaKullan(ad);
        }


        public void KoyleriListele()
        {
            Console.WriteLine("📍 Oyundaki köyler:");
            foreach (var koy in koyler)
            {
                Console.WriteLine("- " + koy.Ad);
            }
        }

    }
}
