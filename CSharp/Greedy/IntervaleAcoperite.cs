using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg.Greedy
{
    [TestClass]
    public class IntervaleAcoperite
    {
        class Punct : IComparable<Punct>
        {
            internal bool e_start;
            internal int valoare;
            
            internal Punct(bool _e_start, int _valoare)
            {
                this.e_start = _e_start;
                this.valoare = _valoare;
            }

            public int CompareTo(Punct other)
            {
                return  this.valoare - other.valoare;
            }
        }

        class Interval : IComparable<Interval>
        {
            internal Punct start;
            internal Punct end;

            public int CompareTo(Interval other)
            {
                return this.start.CompareTo(other.start);
            }
            internal Interval(Punct _start, Punct _end)
            {
                this.start = _start;
                this.end = _end;
            }

        }


        int RezolvaLacomBetter(List<Interval> lista_intervale)
        {
            //sortam in functie de valorile endpointurilor
            lista_intervale.Sort(Comparer<Interval>.Create((p, q) => p.end.valoare - q.end.valoare));
            Interval[] intervale = lista_intervale.ToArray();
            int numar_intervale = 1;
            Interval current = intervale[0];
            for (int i = 1 ; i < intervale.Length; i++)
            {
                if (intervale[i].start.valoare > current.end.valoare)
                {
                    numar_intervale++;
                    current = intervale[i];
                }
            }
            return numar_intervale;
        }

        public IntervaleAcoperite() { }

        int RezolvaLacom(List<Interval> lista_intervale)
        {
            lista_intervale.Sort();
            Interval[] sir_intervale = lista_intervale.ToArray();
            int numar_intervale = 1;

            int i = 1;
            int val_start_cur = sir_intervale[0].start.valoare;
            int val_end_cur = sir_intervale[0].end.valoare;
            while (i < sir_intervale.Count())
            {
                Interval current = sir_intervale[i];

                if (current.end.valoare <= val_end_cur)
                {
                    val_end_cur = current.end.valoare;
                    val_start_cur = current.start.valoare;
                    i++;
                }
                else
                {
                    if (current.start.valoare > val_end_cur) //daca nu se suprapun, marim numarul de intervale si setam intervalul de referinta
                    {
                        numar_intervale++;
                        val_start_cur = current.start.valoare;
                        val_end_cur = current.end.valoare;                        
                    }
                    else // setam intervalul de referinta ca intersectia celor 2 si NU marim numarul de intervale
                    {
                        val_start_cur = current.start.valoare;                        
                    }
                    i++;
                }                
            }
            return numar_intervale;
        }

        [TestMethod]
        public void IntervaleAcoperiteTest()
        {
            Interval i1 = new Interval(new Punct(true, 1), new Punct(false, 4));
            Interval i2 = new Interval(new Punct(true, 2), new Punct(false, 3));
            Interval i3 = new Interval(new Punct(true, 5), new Punct(false, 7));
            Interval i4 = new Interval(new Punct(true, 6), new Punct(false, 11));
            Interval i5 = new Interval(new Punct(true, 8), new Punct(false, 9));
            Interval i6 = new Interval(new Punct(true, 10), new Punct(false, 13));
            Interval i7 = new Interval(new Punct(true, 12), new Punct(false, 14));


            List<Interval> lista_intervale = new List<Interval>() { i1, i2, i3, i4,i5,i6, i7};
            int test1 = this.RezolvaLacom(lista_intervale);
            int test2 = this.RezolvaLacomBetter(lista_intervale);
            Assert.AreEqual(test1, 4);
            Assert.AreEqual(test2, 4);

        }

    }
}
