using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kutyak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Kutya> kutyak = new List<Kutya>();
            File.ReadAllLines("Kutyak.csv").Skip(1).ToList().ForEach(n => kutyak.Add(new Kutya(n.Split(';'))));
            Console.WriteLine($"2. feladat: Kutyanevek száma: {File.ReadAllLines("KutyaNevek.csv").Skip(1).Count()}");
            Console.WriteLine($"6. feladat: Kutyák átlag életkora: {Math.Round(kutyak.Average(n => n.Eletkor), 2)}");
            Console.WriteLine($"7. feladat: Legidősebb kutya neve és fajtája: {kutyak.Where(n => n.Eletkor == (kutyak.Max(m => m.Eletkor))).First().nevEsFajta}");
            Console.WriteLine("8. feladat: Január 10.-én vizsgált kutya fajták: ");
            kutyak.Where(n => n.UtolsoOrvosiEllenorzes == new DateTime(2018, 01, 10)).GroupBy(n => n.MagyarFajta).ToList().ForEach(n => Console.WriteLine($"\t{n.Key}: {n.Count()} kutya"));
            Console.WriteLine($"9. feladat: Legjobban leterhelt nap: {kutyak.GroupBy(n => n.UtolsoOrvosiEllenorzes).Where(n=>n.Count()== kutyak.GroupBy(m => m.UtolsoOrvosiEllenorzes).Max(m => m.Count())).First().Key.ToShortDateString()}: {kutyak.GroupBy(n => n.UtolsoOrvosiEllenorzes).Max(n=>n.Count())} kutya");
            Console.WriteLine("10. feladat: névstatisztika.txt");
            File.WriteAllLines("Névstatisztika.txt" ,kutyak.GroupBy(n=>n.Nev).OrderByDescending(n=>n.Count()).Select(n=>$"{n.Key}, {n.Count()}").ToArray());
        }
    }
}
