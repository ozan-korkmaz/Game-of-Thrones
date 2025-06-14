using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Thrones
{
    internal class Esya
    {
        public string Ad { get; set; }
        public int Gucluluk { get; set; }

        public Esya(string ad, int gucluluk)
        {
            Ad = ad;
            Gucluluk = gucluluk;
        }

        public override string ToString()
        {
            return $"{Ad} (Güç: {Gucluluk})";
        }
    }
}
