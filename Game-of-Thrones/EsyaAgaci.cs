using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Thrones
{
    internal class EsyaAgaci
    {
        private Dugum kok;

        private class Dugum
        {
            public Esya Veri;
            public Dugum Sol;
            public Dugum Sag;

            public Dugum(Esya veri)
            {
                Veri = veri;
            }
        }

        // Ekleme
        public void Ekle(Esya yeniEsya)
        {
            kok = EkleRec(kok, yeniEsya);
        }

        private Dugum EkleRec(Dugum dugum, Esya yeniEsya)
        {
            if (dugum == null)
                return new Dugum(yeniEsya);

            int karsilastirma = string.Compare(yeniEsya.Ad, dugum.Veri.Ad, StringComparison.OrdinalIgnoreCase);

            if (karsilastirma < 0)
                dugum.Sol = EkleRec(dugum.Sol, yeniEsya);
            else if (karsilastirma > 0)
                dugum.Sag = EkleRec(dugum.Sag, yeniEsya);

            return dugum;
        }

        // Arama
        public bool Ara(string esyaAdi)
        {
            return AraRec(kok, esyaAdi);
        }

        private bool AraRec(Dugum dugum, string esyaAdi)
        {
            if (dugum == null)
                return false;

            int karsilastirma = string.Compare(esyaAdi, dugum.Veri.Ad, StringComparison.OrdinalIgnoreCase);

            if (karsilastirma == 0)
                return true;
            else if (karsilastirma < 0)
                return AraRec(dugum.Sol, esyaAdi);
            else
                return AraRec(dugum.Sag, esyaAdi);
        }

        // Inorder yazdırma (A'dan Z'ye sıralı)
        public void Yazdir()
        {
            Console.WriteLine("🌲 Eşyalar (A'dan Z'ye):");
            InOrderRec(kok);
        }

        private void InOrderRec(Dugum dugum)
        {
            if (dugum != null)
            {
                InOrderRec(dugum.Sol);
                Console.WriteLine($"- {dugum.Veri}");
                InOrderRec(dugum.Sag);
            }
        }
    }
}
