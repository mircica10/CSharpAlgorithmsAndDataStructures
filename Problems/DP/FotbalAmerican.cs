using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg.DP
{
    [TestClass]
    public class FotbalAmerican
    {
        int[] mutari = new int[] { 2, 3, 7 };
        //calculam cate posibilitati sunt sa facem un anume scor cu 

        public FotbalAmerican() { }


        int SolveBruteForce(int n)
        {
            int raspuns = 0;
            for (int i = 0; i < (n / mutari[0]) + 1; i = i + mutari[0])
                for (int j = 0; j < (n / mutari[1]) + 1; j = j + mutari[1])
                    for (int k = 0; k < (n / mutari[2]) + 1; k = k + mutari[2])
                        if ( (i + j + k) == n)
                            raspuns++;
            return raspuns;
        }

        int SolveButtomUp(int n)
        {
            int[] numar_combinatii = new int[n + 1];

            for (int i = 0; i < (n + 1); i++)
            {
                int numar = 0;
                for (int j = 0; j < mutari.Length; j++)
                {
                    if (i == mutari[j]) // se incremeanteaza in 2 situatii: 1. index egal cu posibilitatea 
                        numar++;
                    // si 2.index - valoarea posibilitatii mai mare ca 0, respectiv s-a ajuns la valoarea anterioara 
                    if (i >= mutari[j] && numar_combinatii[i - mutari[j]] > 0 )
                        numar = numar + numar_combinatii[i - mutari[j]];
                }
                numar_combinatii[i] = numar;
            }
            return numar_combinatii[n];
        }

        int SolveRecursive(int index, int n)
        {
            if (index < 0)
                return 0;
            else
            {
                int raspuns = 0;
                if ( (index == mutari[0]) || (index == mutari[1]) || (index == mutari[2]) )
                    raspuns++;
                int v1 = SolveRecursive(index - 2, n); //safe
                int v2 = SolveRecursive(index - 3, n); //field
                int v3 = SolveRecursive(index - 7, n); //touchdown

                if (v1 > 0)
                    raspuns = raspuns + v1;
                if (v2 > 0)
                    raspuns = raspuns + v2;
                if (v3 > 0)
                    raspuns = raspuns + v3;

                return raspuns;
            }
        }

        int SolveRecursiveWithCacheHelper(int n)
        {
            int[] sir = new int[n + 1];
            return SolveRecursiveWithCache(n, n, sir);
        }

        int SolveRecursiveWithCache(int index, int n, int[] sir)
        {
            if (index < 0)
                return 0;
            else
            {
                if (sir[index] == 0)
                {
                    int raspuns = 0;
                    if ( index == mutari[0] || index == mutari[1] || index == mutari[2])
                        raspuns++;
                    int v1 = SolveRecursiveWithCache(index - 2, n, sir); //safe
                    int v2 = SolveRecursiveWithCache(index - 3, n, sir); //field
                    int v3 = SolveRecursiveWithCache(index - 7, n, sir); //touchdown

                    if (v1 > 0)
                        raspuns = raspuns + v1;
                    if (v2 > 0)
                        raspuns = raspuns + v2;
                    if (v3 > 0)
                        raspuns = raspuns + v3;

                    sir[index] = raspuns;
                    return sir[index];
                }
                else
                {
                    return sir[index];
                }
            }
        }


        [TestMethod]
        public void FotbalAmericanTest()
        {
            int n = 10;
            int raspuns = 9; //cu repetitie

            int test1 = this.SolveButtomUp(n);
            int test2 = this.SolveRecursive(n, n);
            int test3 = this.SolveRecursiveWithCacheHelper(n);
            Assert.AreEqual(test1, raspuns);
            Assert.AreEqual(test1, test2);
            Assert.AreEqual(test2, test3);
        }

    }
}
