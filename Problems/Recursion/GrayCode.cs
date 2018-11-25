using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg.Recursion
{
    [TestClass]
    public class GrayCode
    {
        List<string> solutie = null;
        int n;
        public GrayCode(int _n)
        {
            this.n = _n;
        }
        public GrayCode() { }

        void SolveGreyCodeHelper()
        {
            List<string> lista = new List<string>();
            lista.Add("");
            SolveGreyCode(lista, 0);
        }

        void SolveGreyCode(List<string> prev, int k)
        {
            if (k >= n) //caz de baza, returnam lista
            {
                solutie = new List<string>(prev);
                return;
            }
            else
            {
                List<string> rezultat = new List<string>();
                for (int i = 0; i < prev.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        rezultat.Add(prev[i] + "0");
                        rezultat.Add(prev[i] + "1");
                    }
                    else
                    {
                        rezultat.Add(prev[i] + "1");
                        rezultat.Add(prev[i] + "0");
                    }
                }
                SolveGreyCode(rezultat, k + 1);                
            }
        }
        [TestMethod]
        public void GrayCodeTest()
        {
            GrayCode graycode = new GrayCode(4);
            graycode.SolveGreyCodeHelper();
            Assert.AreEqual(graycode.solutie.Count, 16);
        }
    }



    [TestClass]
    public class GrayCodeBacktrack
    {


        List<int> SolveBetter(int numbites)
        {
            if (numbites == 0)
                return new List<int>() { 0 };
            else
            {
                List<int> prev_list = SolveBetter(numbites - 1);
                int leadingdigit = 1 << (numbites - 1);
                List<int> lista_nou = new List<int>(prev_list);
                for (int i = prev_list.Count - 1; i >= 0; --i)
                    lista_nou.Add(leadingdigit | prev_list.ElementAt(i));
                return lista_nou;
            }

        }

        [TestMethod]
        public void SolveGreyCodesBetter()
        {
            List<int> raspuns = SolveBetter(3);
            Assert.AreEqual(raspuns.Count, 8);
        }

        public bool OneBitDiffer(int x, int y)
        {
            int z = x ^ y;
            return z != 0 && ( (z & (z - 1)) == 0 );
        }


        List<int> SolveBacktrackHelper(int n)
        {
            List<int> sol = new List<int>() { 0 };
            SolveBacktrack(n, new List<int>() { 0 }, sol);
            return sol;
        }

        bool SolveBacktrack(int numbits, List<int> history, List<int> sol)
        {
            if ( sol.Count == (1 << numbits) )
                return OneBitDiffer(sol.ElementAt(0), sol.ElementAt(sol.Count - 1));
            else
            {
                for (int i = 0; i < numbits; ++i)
                {
                    int prev = sol.ElementAt(sol.Count - 1);
                    int nou = prev ^ (1 << i);
                    //if (!history.Contains(nou))
                    if (!sol.Contains(nou))
                    {                        
                        //history.Add(nou);
                        sol.Add(nou);
                        if (SolveBacktrack(numbits, history, sol))
                            return true;
                        //history.Remove(nou);
                        sol.Remove(sol.Count - 1);
                    }
                }
                return false;
            }
        }

        [TestMethod]
        public void SolveGreyBacktrackTest()
        {
            List<int> sol = SolveBacktrackHelper(3);
            Assert.AreEqual(sol.Count, 8);
        }


    }

}
