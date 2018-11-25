using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg.Grafuri
{
    [TestClass]
    public class DAGCaleaCeaMaiLunga
    {
        class Nod
        {
            internal int max_distanta = 0;
            internal List<Nod> margini = null;
            internal Nod(int _max_dist, List<Nod> margini)
            {
                this.margini = margini;
                this.max_distanta = _max_dist;
            }
        }

    
        List<Nod> graf = new List<Nod>();

        public DAGCaleaCeaMaiLunga() { }

        DAGCaleaCeaMaiLunga(List<Nod> graf)
        {
            this.graf = graf;            
        }

        void InitGraf()
        {
            foreach (Nod n in this.graf)
                n.max_distanta = -1;
        }

        Stack<Nod> DFS()
        {
            Stack<Nod> ordine_topologica = new Stack<Nod>();
            foreach (Nod n in this.graf)
                if (n.max_distanta == -1)
                    DFSHelper(n, ordine_topologica);
            return ordine_topologica;
        }

        private void DFSHelper(Nod n, Stack<Nod> ordine_topologica)
        {
            n.max_distanta = 0;//il marcam vizitat
            foreach (Nod descendent in n.margini)
                if (descendent.max_distanta == -1)  //daca e nevizitat, coboara
                    DFSHelper(descendent, ordine_topologica);
            ordine_topologica.Push(n);              //parcurgere postordine
        }

        int CalculeazaCeaMaiLungaCale(Stack<Nod> ordine_topologica)
        {
            int max_distanta = 0;

            while (ordine_topologica.Count > 0)
            {
                Nod nod_curent = ordine_topologica.Pop();
                max_distanta = Math.Max(nod_curent.max_distanta, max_distanta);
                foreach (Nod descendent in nod_curent.margini)
                {
                    descendent.max_distanta = Math.Max(descendent.max_distanta, nod_curent.max_distanta + 1);
                }
            }
            return max_distanta;
        }

        //init graf
        //sorteaza topologic
        //calculeaza cale maxima
        int RezolvaTopologic()
        {
            Stack<Nod> sortare_topologica = null;
            int cale_maxima = -1;

            this.InitGraf();
            sortare_topologica = DFS();
            cale_maxima = CalculeazaCeaMaiLungaCale(sortare_topologica);

            return cale_maxima;
        }

        [TestMethod]
        public void DGAcaleaceamailungaTest()
        {
            Nod n1 = new Nod(1, null);
            Nod n2 = new Nod(2, null);
            Nod n3 = new Nod(3, null);
            Nod n4 = new Nod(4, null);
            Nod n5 = new Nod(5, null);
            Nod n6 = new Nod(6, null);
            Nod n7 = new Nod(7, null);


            n1.margini = new List<Nod>() { n2 };
            n2.margini = new List<Nod>() { n3, n4, n6 };
            n3.margini = new List<Nod>() { n7 };
            n4.margini = new List<Nod>();
            n5.margini = new List<Nod>() {  };
            n6.margini = new List<Nod>() { n7, n5 };
            n7.margini = new List<Nod>();

            List<Nod> graf = new List<Nod>() { n1, n2, n3, n4, n5, n6, n7 };

            DAGCaleaCeaMaiLunga dag = new DAGCaleaCeaMaiLunga(graf);

            int test1 = dag.RezolvaTopologic();

            Assert.AreEqual(test1, 3);

        }



    }
}
