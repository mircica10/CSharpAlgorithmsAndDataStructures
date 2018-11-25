using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg.Grafuri
{
    enum Culoare { alb, gri, negru};

    class Nod
    {
        internal int id;
        internal Culoare culoare;
        internal List<Margine> margini;
        internal Nod(int id, List<Margine> margini, Culoare culoare = Culoare.alb)
        {
            this.id = id;
            this.culoare = culoare;
            this.margini = margini;
        }
    }

    class Margine
    {
        internal int atribut;
        internal Nod destinatie;
        internal Margine(int atribut, Nod dest)
        {
            this.atribut = atribut;
            this.destinatie = dest;
        }
    }

    [TestClass]
    public class Parcurgeri
    {
        //un graf e o lista de noduri, fiecare nod avand 
        List<Nod> graf = null;

        public Parcurgeri() { }
        internal Parcurgeri(List<Nod> _graf)
        {
            this.graf = _graf;
        }


        string ParcurgereAdancimePostorder()
        {
            string raspuns = "";
            this.ResetNoduri();
            foreach (Nod nod in graf)
            {
                if (nod.culoare == Culoare.alb)
                {
                    string s = ParcurgereAdancimeHelperPostorder(nod);
                    raspuns = s + raspuns;
                }
            }
            return raspuns;
        }

        string ParcurgereAdancimeHelperPostorder(Nod nod)
        {
            string s = "";
            nod.culoare = Culoare.gri;
            foreach (Margine m in nod.margini)
            {
                if (m.destinatie.culoare == Culoare.alb)
                {
                    s = s + ParcurgereAdancimeHelperPostorder(m.destinatie);
                }
            }
            nod.culoare = Culoare.negru;
            s = s + nod.id;
            return s;
        }


        string ParcurgereAdancimePreorder()
        {
            string raspuns = "";
            this.ResetNoduri();
            foreach (Nod nod in graf)
            {
                if (nod.culoare == Culoare.alb)
                {
                    string s = ParcurgereAdancimeHelperPreorder(nod);
                    raspuns = raspuns + s;
                }
            }
            return raspuns;
        }

        string ParcurgereAdancimeHelperPreorder(Nod nod)
        {
            string s = "";
            nod.culoare = Culoare.gri;
            foreach (Margine m in nod.margini)
            {
                if (m.destinatie.culoare == Culoare.alb)
                {
                    s = ParcurgereAdancimeHelperPreorder(m.destinatie) + s;                    
                }
            }
            nod.culoare = Culoare.negru;
            s = nod.id + s;
            return s;
        }

        void ResetNoduri()
        {
            foreach (Nod n in this.graf)
                n.culoare = Culoare.alb;
        }

        string ParcurgereLatime()
        {
            string ordine = "";
            this.ResetNoduri();
            Nod nod_initial = this.graf[0];

            Queue<Nod> coada = new Queue<Nod>();
            coada.Enqueue(nod_initial);
            nod_initial.culoare = Culoare.negru;

            while (coada.Count > 0)
            {
                Nod nod_curent = coada.Dequeue();
                ordine = ordine + nod_curent.id;
                foreach (Margine m in nod_curent.margini)
                {
                    if (m.destinatie.culoare == Culoare.alb)
                    {
                        m.destinatie.culoare = Culoare.negru;
                        coada.Enqueue(m.destinatie);
                    }
                }
            }
            return ordine;
        }

        [TestMethod]
        public void ParcurgeriArboriTest()
        {
            //construim arbore de test
            Nod n1 = new Nod(1, null);
            Nod n2 = new Nod(2, null);
            Nod n3 = new Nod(3, null);
            Nod n4 = new Nod(4, null);
            Nod n5 = new Nod(5, null);
            Nod n6 = new Nod(6, null);
            Nod n7 = new Nod(7, null);

            Margine m12 = new Margine(1, n2);
            Margine m23 = new Margine(1, n3);
            Margine m37 = new Margine(1, n7);
            Margine m67 = new Margine(1, n7);
            Margine m65 = new Margine(1, n5);
            Margine m51 = new Margine(1, n1);
            Margine m24 = new Margine(1, n4);
            Margine m26 = new Margine(1, n6);

            n1.margini = new List<Margine>() { m12 };
            n2.margini = new List<Margine>() { m23, m24, m26 };
            n3.margini = new List<Margine>() { m37 };
            n4.margini = new List<Margine>();
            n5.margini = new List<Margine>() { m51 };
            n6.margini = new List<Margine>() { m67, m65};
            n7.margini = new List<Margine>();

            List<Nod> graf = new List<Nod>() { n1, n2, n3, n4, n5, n6, n7 };

            Parcurgeri parcurgeri = new Parcurgeri(graf);


            string  preordine_adancime = parcurgeri.ParcurgereAdancimePreorder();
            string ordine_latime = parcurgeri.ParcurgereLatime();
            string postordine_adancime = parcurgeri.ParcurgereAdancimePostorder();
            char[] postordine_adancime_char_array = postordine_adancime.ToCharArray();
            Array.Reverse(postordine_adancime_char_array);
            string reverse_postordering = new string(postordine_adancime_char_array);

        }


    }
}
