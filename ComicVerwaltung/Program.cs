using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicVerwaltung
{
    class Program
    {
        private static IEnumerable<Comic> KatalogGenerieren()
        {
            return new List<Comic> {
            new Comic { Name = "Jonny America vs. the Pinko", Folge=6},
            new Comic { Name = "Rock and Roll (limitierte Auflage)", Folge=19},
            new Comic { Name = "Woman's Work", Folge=36},
            new Comic { Name = "Hippie Madness (Fehldruck)", Folge=57},
            new Comic { Name = "Revenge of the New Wave Freak (beschädigt)", Folge=68},
            new Comic { Name = "Black Monday", Folge=74},
            new Comic { Name = "Tribal Tattoo Madness", Folge=83},
            new Comic { Name = "The Death of an Object", Folge=97}};
        }

        private static Dictionary<int, decimal> PreiseAufbauen()
        {
            return new Dictionary<int, decimal>
            {
                { 6, 3600M },
                { 19, 500M },
                { 36, 650M },
                { 57, 13525M },
                { 68, 250M },
                { 74, 75M },
                { 83, 25M },
                { 97, 35M }
            };
        }

        static void Main(string[] args)
        {
            IEnumerable<Comic> comics = KatalogGenerieren();
            Dictionary<int, decimal> werte = PreiseAufbauen();

            var amTeuersten =
                from comic in comics
                where werte[comic.Folge] > 500
                orderby werte[comic.Folge] descending
                select comic;

            foreach (Comic comic in amTeuersten)
                Console.WriteLine("{0} ist {1} € wert", comic.Name, werte[comic.Folge]);
            Console.ReadKey();

        }
    }
}
