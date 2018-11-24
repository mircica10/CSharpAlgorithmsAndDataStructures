using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg.Grafuri
{
    [TestClass]
    public class AlbNegru
    {
        
        //DS
        internal struct Coordonate : IEquatable<Coordonate>
        {
            internal int x;
            internal int y;
            internal Coordonate(int _x, int _y)
            {
                this.x = _x;
                this.y = _y;
            }

            public bool Equals(Coordonate other)
            {
                return x == other.x && y == other.y;
            }
        }

        internal enum Bloc { alb, negru };

        int[,] coordonate_vecini = new int[4, 2] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };


        Bloc[,] poza = null;
        Coordonate bloc_initial = new Coordonate(0, 0);
        //Constructori
        public AlbNegru() { }

        internal AlbNegru(Bloc[,] _poza, Coordonate bloc_initial)
        {
            this.poza = _poza;
            this.bloc_initial = bloc_initial;
        }

        internal Bloc[,] ConstruiestePozaNouaNonrec()
        {
            return ConstruiestePozaNouaHelper(ref this.poza, this.bloc_initial);
        }
        
        private Bloc[,] ConstruiestePozaNouaHelper(ref Bloc[,] graf, Coordonate bloc_initial)
        {
            //nu mai avem nevoie de lista cu elementele vizitate, deoarece modificam culoarea elementelor noi inainte de a le introduce in stiva, deci elementele noi nu mai sunt luate in calcul
            //facem BFS sa identificam toata suprafata
            Queue<Coordonate> coada = new Queue<Coordonate>();
            //culoare bloc initial
            Bloc culoare = graf[bloc_initial.x, bloc_initial.y];
            //adaugam primul elment in coada
            coada.Enqueue(bloc_initial);
            graf[bloc_initial.x, bloc_initial.y] = (culoare == Bloc.alb) ? Bloc.negru : Bloc.alb;
                        
            while (coada.Count > 0)
            {
                Coordonate coordonate_curent = coada.Dequeue();
                for (int i = 0; i < coordonate_vecini.GetLength(0); i++)
                {
                    int x = coordonate_curent.x + coordonate_vecini[i, 0];
                    int y = coordonate_curent.y + coordonate_vecini[i, 1];
                    Coordonate c = new Coordonate(x, y);
                    if (x >= 0 && x < graf.GetLength(0) && y >= 0 && y < graf.GetLength(1) && graf[x, y] == culoare )
                    {
                        graf[x, y] = (graf[x, y] == Bloc.alb) ? Bloc.negru : Bloc.alb;                        
                        coada.Enqueue(c);
                    }
                }
            }
            return graf;
        }

        private void ConstruiestePozaNouaRecursivHelper(Coordonate coordonate, Bloc bloc_cautat, ref Bloc[,] graf)
        {
            graf[coordonate.x, coordonate.y] = bloc_cautat == Bloc.alb ? Bloc.negru : Bloc.alb;

            for (int i = 0; i < coordonate_vecini.GetLength(0); i++)
            {
                int x = coordonate.x + coordonate_vecini[i, 0];
                int y = coordonate.y + coordonate_vecini[i, 1];
                Coordonate c = new Coordonate(x, y);              
                if (x >= 0 && x < graf.GetLength(0) 
                    && y >= 0 && y < graf.GetLength(1) 
                    && graf[x, y] == bloc_cautat)
                {
                    ConstruiestePozaNouaRecursivHelper(c, bloc_cautat, ref graf);
                }
            }            
        }

        internal void ConstruiestePozaNouaRecursiv()
        {
            Bloc bloc_initial = this.poza[this.bloc_initial.x, this.bloc_initial.y];
            ConstruiestePozaNouaRecursivHelper(this.bloc_initial, bloc_initial, ref this.poza);
        }
               

        [TestMethod]
        public void AlbNegruTest()
        {            
            Bloc[,] poza = new Bloc[,] 
            {
                { Bloc.alb, Bloc.negru, Bloc.alb, Bloc.alb },
                { Bloc.negru, Bloc.alb, Bloc.alb, Bloc.alb },
                { Bloc.alb, Bloc.alb, Bloc.alb, Bloc.negru},
                { Bloc.alb, Bloc.alb, Bloc.negru, Bloc.alb}
            };

            Bloc[,] poza2 = new Bloc[,]
         {
                { Bloc.alb, Bloc.negru, Bloc.alb, Bloc.alb },
                { Bloc.negru, Bloc.alb, Bloc.alb, Bloc.alb },
                { Bloc.alb, Bloc.alb, Bloc.alb, Bloc.negru},
                { Bloc.alb, Bloc.alb, Bloc.negru, Bloc.alb}
         };

            AlbNegru alb_negru = new AlbNegru(poza, new Coordonate(2,2));
            alb_negru.ConstruiestePozaNouaRecursiv();
            Bloc[,] raspuns1 = alb_negru.poza;


            AlbNegru alb_negru_non_rec = new AlbNegru(poza2, new Coordonate(2, 2));
            alb_negru_non_rec.ConstruiestePozaNouaNonrec();
            Bloc[,] raspuns2 = alb_negru_non_rec.poza;

            for (int i = 0; i < poza.GetLength(0); i++)
            {
                for (int j = 0; j < poza.GetLength(1); j++)
                {
                    Assert.AreEqual(raspuns1[i, j], raspuns2[i, j]);
                }
            }

        }


    }
}
