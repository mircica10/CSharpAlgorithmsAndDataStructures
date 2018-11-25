using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg.DP
{
    [TestClass]
    public class UrcatScari
    {
        //f[n, k] = suma f[n-i, k], i intre 1 si k

        public UrcatScari() { }        

        int CalculateDP(int index, int n, int k, int[] cache)
        {
            if (index <= 1)
                return 1;
            if (cache[index] == 0)
            {
                int suma = 0;
                for (int i = 1; i <= k && (index - i) >= 0; i++)
                    suma = suma + CalculateDP(index - i, n, k, cache);
                cache[index] = suma;
            }
            return cache[index];
        }

        int CalculateDPhelper(int n, int k)
        {
            int[] cache = new int[n + 1];
            return CalculateDP(n, n, k, cache);
        }

        int numar_solutii = 0;

        int CalculateBruteForceHelper(int n, int k)
        {
            CalculateBruteForce(0, n, k);
            return numar_solutii;
        }

        void CalculateBruteForce(int index, int n, int k)
        {
            if (index == n)
                numar_solutii++;
            else if (index < n)
            {
                for (int i = 1; i <= k; i++)
                    CalculateBruteForce(index + i, n, k);
            }
        }

        [TestMethod]
        public void UrcatScariTest()
        {
            int n = 4;
            int k = 2;
            int test1 = CalculateDPhelper(n, k);
            Assert.AreEqual(test1, 5);
            int test2 = CalculateBruteForceHelper(n, k);
            Assert.AreEqual(test2, test1);
        }

    }
}
