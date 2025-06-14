using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Thrones
{
    internal class Koy
    {
        public string Ad { get; set; }
        public List<Esya> Esyalar { get; set; }
        public List<string> GerekenEsyalar { get; set; } = new List<string>();

        public override string ToString()
        {
            return Ad;
        }
    }
}
