using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Thrones
{
    internal class SahteVeriYukleyici
    {
        public static List<Koy> KoyleriGetir()
        {
            return new List<Koy>
    {
        new Koy
        {
            Ad = "Winterfell",
            Esyalar = new List<Esya>
            {
                new Esya("Hançer", 5),
                new Esya("Kurt Postu", 4),
                new Esya("Kış Pelerini", 2)
            }
        },
        new Koy
        {
            Ad = "Eyrie",
            Esyalar = new List<Esya>
            {
                new Esya("Tırmanma Halatı", 3),
                new Esya("Baltalı Kalkan", 6),
                new Esya("Ok ve Yay", 4)
            }
        },
        new Koy
        {
            Ad = "Braavos",
            Esyalar = new List<Esya>
            {
                new Esya("Yüzsüz Maskesi", 7),
                new Esya("İksir", 2),
                new Esya("Altın Kesesi", 5)
            }
        },
        new Koy
        {
            Ad = "Highgarden",
            Esyalar = new List<Esya>
            {
                new Esya("Gül Tacı", 1),
                new Esya("Zırh", 6),
                new Esya("Şifalı Bitki", 3)
            }
        },
        new Koy
        {
            Ad = "Storm's End",
            Esyalar = new List<Esya>
            {
                new Esya("Balta", 4),
                new Esya("İksir", 3),
                new Esya("Fırtına Miğferi", 5)
            },
            GerekenEsyalar = new List<string> { "Balta", "İksir" }
        },
        new Koy
        {
            Ad = "Casterly Rock",
            Esyalar = new List<Esya>
            {
                new Esya("Valyrian Kılıcı", 10),
                new Esya("Kalkan", 5),
                new Esya("Mızrak", 4)
            },
            GerekenEsyalar = new List<string> { "Valyrian Kılıcı", "Kalkan" }
        },
        new Koy
        {
            Ad = "Dragonstone",
            Esyalar = new List<Esya>
            {
                new Esya("Ejderha Camı", 8),
                new Esya("Yüzsüz Maskesi", 7),
                new Esya("Ateş Kalkanı", 6)
            },
            GerekenEsyalar = new List<string> { "Ejderha Camı", "Yüzsüz Maskesi" }
        }
    };
        }

    }
}
