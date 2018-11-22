using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ConsoleAppTest.Alg.Grafuri
{
    [TestClass]
    public class CaleaCeaMaiScurta 
    {
        class Nod : IComparable<Nod>
        {
            internal List<Margine> margini = null;
            internal int id;
            internal Nod() { }
            internal Nod(int id,List<Margine> margini)
            {
                this.id= id;
                this.margini = margini;
            }

            public int CompareTo(Nod other)
            {
                return id - other.id;
            }
        }

        class Margine
        {
            internal Nod destinatie;
            internal int atribut;
            internal Margine() { }
            internal Margine(int att, Nod dest)
            {
                this.destinatie = dest;
                this.atribut = att;
            }
        }

        public CaleaCeaMaiScurta() { }

        List<Nod> graf = null;

        CaleaCeaMaiScurta(List<Nod> graf)
        {
            this.graf = graf;
        }


        KeyValuePair<Nod, int> NodCuDistMinima(Dictionary<Nod, int> nod_dist)
        {
            int min = int.MaxValue;
            Nod n = null;
            KeyValuePair<Nod, int> raspuns = new KeyValuePair<Nod, int>(n, min);
            foreach (KeyValuePair<Nod, int> var in nod_dist)
            {
                if (var.Value < raspuns.Value)
                {
                    raspuns = var;
                }
            }
            return raspuns;
        }



        int CaleaCeaMaiScurtaDjistra(Nod sursa, Nod dest)
        {
            Dictionary<Nod, int> nod_distanta = new Dictionary<Nod, int>();
            foreach (Nod n in graf)
                nod_distanta.Add(n, int.MaxValue);
            nod_distanta[sursa] = 0;
                        
            while (nod_distanta.Count > 0)
            {
                KeyValuePair<Nod, int> current = NodCuDistMinima(nod_distanta);
                int distanta_cur = current.Value;
                Nod nod_cur = current.Key;
                nod_distanta.Remove(nod_cur);

                if (nod_cur == dest)
                    return distanta_cur;
                foreach (Margine margine in nod_cur.margini)
                {                  
                    if (nod_distanta[margine.destinatie] > distanta_cur + margine.atribut)
                    {
                        nod_distanta[margine.destinatie] = distanta_cur + margine.atribut;
                    }                                        
                }
            }
            return -1;
        }

        [TestMethod]
        public void CaleaCeaMaiScurtaTest()
        {
            //construim arbore de test
            Nod n1 = new Nod(1,null);
            Nod n2 = new Nod(2,null);
            Nod n3 = new Nod(3,null);
            Nod n4 = new Nod(4,null);
            Nod n5 = new Nod(5,null);
            Nod n6 = new Nod(6,null);
            Nod n7 = new Nod(7,null);

            Margine m12 = new Margine(2, n2);
            Margine m23 = new Margine(34, n3);
            Margine m37 = new Margine(7, n7);
            Margine m67 = new Margine(1, n7);
            Margine m65 = new Margine(65, n5);
            Margine m51 = new Margine(16, n1);
            Margine m24 = new Margine(5, n4);
            Margine m26 = new Margine(3, n6);

            n1.margini = new List<Margine>() { m12 };
            n2.margini = new List<Margine>() { m23, m24, m26 };
            n3.margini = new List<Margine>() { m37 };
            n4.margini = new List<Margine>();
            n5.margini = new List<Margine>() { m51 };
            n6.margini = new List<Margine>() { m67, m65 };
            n7.margini = new List<Margine>();

            List<Nod> graf = new List<Nod>() { n1, n2, n3, n4, n5, n6, n7 };

            CaleaCeaMaiScurta calea = new CaleaCeaMaiScurta(graf);

            int raspuns = calea.CaleaCeaMaiScurtaDjistra(n2, n7);

            Assert.AreEqual(raspuns, 4);

        }

       
    }
}
