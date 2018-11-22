using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg.Grafuri
{
    [TestClass]
    public class CaleaCeaMaiScurta2
    {
        List<Nod> graf = new List<Nod>();

        public CaleaCeaMaiScurta2() { }

        CaleaCeaMaiScurta2(List<Nod> graf)
        {
            this.graf = graf;
        }

        struct DistantaCuNrMinMargini : IEquatable<DistantaCuNrMinMargini>
        {
            internal int distanta;
            internal int nr_min_margini;
            internal DistantaCuNrMinMargini(int _dist, int _nr_min_margini)
            {
                this.distanta = _dist;
                this.nr_min_margini = _nr_min_margini;
            }

            public bool Equals(DistantaCuNrMinMargini other)
            {
                return distanta == other.distanta && nr_min_margini == other.nr_min_margini;
            }
        }

        class Margine
        {
            internal int lungime;
            internal Nod destinatie;
            internal Margine( Nod _dest, int _lung)
            {
                this.lungime = _lung;
                this.destinatie = _dest;
            }

        }
     
        class Nod : IComparable<Nod>, IEquatable<Nod>
        {
            internal int id;
            internal DistantaCuNrMinMargini _dist_cu_nr_min_margini;
            internal List<Margine> margini;

            internal Nod(int _id, List<Margine> _margini)
            {
                this.id = _id;
                this.margini = _margini;
                _dist_cu_nr_min_margini = new DistantaCuNrMinMargini(int.MaxValue, 0);
                margini = _margini;
            }

            public int CompareTo(Nod other)
            {
                if (_dist_cu_nr_min_margini.distanta != other._dist_cu_nr_min_margini.distanta)
                    return _dist_cu_nr_min_margini.distanta - other._dist_cu_nr_min_margini.distanta;
                if (_dist_cu_nr_min_margini.nr_min_margini != other._dist_cu_nr_min_margini.nr_min_margini)
                    return _dist_cu_nr_min_margini.nr_min_margini - other._dist_cu_nr_min_margini.nr_min_margini;
                return id - other.id;
            }

            public bool Equals(Nod other)
            {
                return id == other.id && _dist_cu_nr_min_margini.Equals(other._dist_cu_nr_min_margini);
            }
        }

        DistantaCuNrMinMargini CalculeazaCaleaCeaMaiScurta(Nod source, Nod dest)
        {
            SortedSet<Nod> coada = new SortedSet<Nod>(this.graf);
            coada.Remove(source);
            //modificam sursa sa fie aleasa prima
            source._dist_cu_nr_min_margini = new DistantaCuNrMinMargini(0, 0);
            coada.Add(source);

            while (coada.Count > 0)
            {
                Nod nod_curent = coada.First();

                if (nod_curent.Equals(dest))
                    return nod_curent._dist_cu_nr_min_margini;
                int lungime_curenta = nod_curent._dist_cu_nr_min_margini.distanta;
                int nr_margini_curent = nod_curent._dist_cu_nr_min_margini.nr_min_margini;
                coada.Remove(nod_curent);

                foreach (Margine margine in nod_curent.margini)
                {
                    Nod nod_temp = margine.destinatie;
                    int distanta_nou = lungime_curenta + margine.lungime;
                    int nr_min_margini_nou = nod_curent._dist_cu_nr_min_margini.nr_min_margini + 1;
                    if ( nod_temp._dist_cu_nr_min_margini.distanta > distanta_nou || 
                        (nod_temp._dist_cu_nr_min_margini.distanta == distanta_nou && nod_temp._dist_cu_nr_min_margini.nr_min_margini > nr_min_margini_nou) )
                    {
                        DistantaCuNrMinMargini _dist_cu_nr_margini_noua = new DistantaCuNrMinMargini(distanta_nou, nr_min_margini_nou);
                        coada.Remove(nod_temp);
                        nod_temp._dist_cu_nr_min_margini = _dist_cu_nr_margini_noua;
                        coada.Add(nod_temp);
                    }
                }
            }
            return new DistantaCuNrMinMargini(0,0);
        }

        [TestMethod]
        public void CaleaCeaMaiScurta2Test()
        {
        
            //construim arbore de test
            Nod n1 = new Nod(1, null);
            Nod n2 = new Nod(2, null);
            Nod n3 = new Nod(3, null);
            Nod n4 = new Nod(4, null);
            Nod n5 = new Nod(5, null);
            Nod n6 = new Nod(6, null);
            Nod n7 = new Nod(7, null);

            Margine m12 = new Margine(n2, 2);
            Margine m23 = new Margine(n3, 3);
            Margine m37 = new Margine(n7, 3);
            Margine m76 = new Margine(n6, 3);
            Margine m65 = new Margine(n5, 65);
            Margine m51 = new Margine(n1, 16);
            Margine m24 = new Margine(n4, 5);
            Margine m26 = new Margine(n6, 9);

            n1.margini = new List<Margine>() { m12 };
            n2.margini = new List<Margine>() { m23, m24, m26 };
            n3.margini = new List<Margine>() { m37 };
            n4.margini = new List<Margine>();
            n5.margini = new List<Margine>() { m51 };
            n6.margini = new List<Margine>() { m65 };
            n7.margini = new List<Margine>() { m76 };


            List<Nod> graf = new List<Nod>() { n1, n2, n3, n4, n5, n6, n7 };

            CaleaCeaMaiScurta2 calea = new CaleaCeaMaiScurta2(graf);

            DistantaCuNrMinMargini dist =  calea.CalculeazaCaleaCeaMaiScurta(n2, n6);
            
            Assert.AreNotEqual(dist, new DistantaCuNrMinMargini(0,0));

            Assert.AreEqual(dist.nr_min_margini, 1);
            Assert.AreEqual(dist.distanta, 9);

            

            //construim arbore de test
            n1 = new Nod(1, null);
            n2 = new Nod(2, null);
            n3 = new Nod(3, null);
            n4 = new Nod(4, null);
            n5 = new Nod(5, null);
            n6 = new Nod(6, null);
            n7 = new Nod(7, null);

            m12 = new Margine(n2, 2);
            m23 = new Margine(n3, 3);
            m37 = new Margine(n7, 3);
            m76 = new Margine(n6, 3);
            m65 = new Margine(n5, 65);
            m51 = new Margine(n1, 16);
            m24 = new Margine(n4, 5);
            m26 = new Margine(n6, 9);

            n1.margini = new List<Margine>() { m12 };
            n2.margini = new List<Margine>() { m23, m24, m26 };
            n3.margini = new List<Margine>() { m37 };
            n4.margini = new List<Margine>();
            n5.margini = new List<Margine>() { m51 };
            n6.margini = new List<Margine>() { m65 };
            n7.margini = new List<Margine>() { m76 };

            List<Nod> graf2 = new List<Nod>() { n1, n2, n3, n4, n5, n6, n7 };

            

            m26.lungime = 10;


            CaleaCeaMaiScurta2 calea2 = new CaleaCeaMaiScurta2(graf2);

            DistantaCuNrMinMargini dist2 = calea2.CalculeazaCaleaCeaMaiScurta(n2, n6);

            Assert.AreNotEqual(dist2, new DistantaCuNrMinMargini(0,0));

            Assert.AreEqual(dist2.nr_min_margini, 3);
            Assert.AreEqual(dist2.distanta, 9);
            
        }

    }
}
