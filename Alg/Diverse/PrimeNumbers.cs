using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg
{
    [TestClass]
    public class NumerePrime
    {

        List<int> GenereazaNumerePrime(int n)
        {
            List<int> prime = new List<int>();
            bool[] verificate = new bool[n];
            for (int i = 0; i < verificate.Length; i++)
            {
                verificate[i] = false;
            }
            verificate[0] = verificate[1] = true;
            bool prim = true;
            for (int i = 2; i < n && verificate[i] == false; i++)
            {
                prim = true;

                for (int j = 2; i <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        prim = false;
                        break;
                    }
                }

                if (prim)
                {
                    prime.Add(i);
                    for (int k = i; k < n; k = k + i)
                    {
                        verificate[k] = true;
                    }
                }
            }
            return prime;
        }


        [TestMethod]
        public void TestPrime()
        {
            int n = 100;
            List<int> prime = this.GenereazaNumerePrime(n);
        }

    }
}
