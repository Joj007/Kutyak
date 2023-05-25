using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace Kutyak
{
    internal class Kutya
    {
        int foId;
        int fajtaId;
        int nevId;
        int eletkor;
        DateTime utolsoOrvosiEllenorzes;
        string magyarFajta;
        string angolFajta;
        string nev;

        public Kutya(string[] adatok)
        {
            this.foId = int.Parse(adatok[0]);
            this.fajtaId = int.Parse(adatok[1]);
            this.nevId = int.Parse(adatok[2]);
            this.eletkor = int.Parse(adatok[3]);
            string[] datumSeged = adatok[4].Split('.');
            this.utolsoOrvosiEllenorzes = new DateTime(int.Parse(datumSeged[0]), int.Parse(datumSeged[1]), int.Parse(datumSeged[2]));

            this.nev = File.ReadAllLines("kutyaNevek.csv").Skip(1).Where(n => n.Split(';')[0] == $"{nevId}").Select(n => n.Split(';')[1]).First();
            this.magyarFajta = File.ReadAllLines("kutyaFajtak.csv").Skip(1).Where(n => n.Split(';')[0] == $"{fajtaId}").Select(n => n.Split(';')[1]).First();
            this.angolFajta = File.ReadAllLines("kutyaFajtak.csv").Skip(1).Where(n => n.Split(';')[0] == $"{fajtaId}").Select(n => n.Split(';')[2]).First();

        }

        public int FoId { get => foId;}
        public int FajtaId { get => fajtaId;}
        public int NevId { get => nevId;}
        public int Eletkor { get => eletkor;}
        public DateTime UtolsoOrvosiEllenorzes { get => utolsoOrvosiEllenorzes;}
        public string MagyarFajta { get => magyarFajta;}
        public string AngolFajta { get => angolFajta;}
        public string Nev { get => nev;}

        public string nevEsFajta { get => $"{nev};{MagyarFajta}";}

        

    }
}
