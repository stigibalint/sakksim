using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sakkoswpf
{

    public class Jatszma
    {
        private List<string> lepesek;

        public Jatszma()
        {
            lepesek = new List<string>();
        }

        public Jatszma(string fajlSor)
        {
            lepesek = fajlSor.Trim().Split('\t').ToList();
        }

        public int LepesekSzama => lepesek.Count();

        public char Nyertes => LepesekSzama % 2 == 0 ? 'v' : 's';

        public int HuszarokLepesszama => lepesek.Count(lepes => lepes[0] == 'H');

        public int VezerekLepesszama => lepesek.Count(lepes => lepes[0] == 'V');

        
        public bool VezertUtott()
        {
            int lepesSzamlal = 0;
            List<string> Vezerek = new List<string> { "d1", "d8" };

            return lepesek.Any(lepes =>
            {
                if (lepes.Contains('V'))
                {
                    int index = lepesSzamlal % 2 == 0 ? 1 : 0;
                    Vezerek[index] = lepes.Substring(lepes.Length - 2);
                }
                return lepes.Contains($"x{Vezerek[0]}") || lepes.Contains($"x{Vezerek[1]}");
            });
        }

     public int TisztLepesszama(char tisztjel)
        {
            return lepesek.Count(lepes => lepes[0] == tisztjel);
        }


        public bool TobbMintHuszBabuMaradt()
        {
            int osszesBabu = 32;

            foreach (var lepes in lepesek)
            {
                if (lepes.Contains('x'))
                {
                    osszesBabu -= 1;
                }
            }
            return osszesBabu < 20;
        }


    }
}