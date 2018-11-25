using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg.DP
{
    [TestClass]
    public class Fibonacci
    {
        int SolveClasic(int n)
        {
            if (n < 2)
                return 1;
            else
                return SolveClasic(n - 1) + SolveClasic(n - 2);
        }

        int SolveDPHelper(int n)
        {
            int[] cache = new int[n + 1];
            cache[0] = 1;
            cache[1] = 1;
            return SolveDP(n, cache);
        }

        int SolveDP(int n, int[] cache)
        {
            if (cache[n] == 0)
            {
                int result = SolveDP(n - 1, cache) + SolveDP(n - 2, cache);
                cache[n] = result;
                return result;
            }
            else
            {
                return cache[n];
            }
        }

        int SolveDPButtomUp(int n)
        {
            if (n < 2)
                return 1;
            else
            {
                int min_one = 1;
                int min_two = 1;
                for (int i = 2; i < n + 1; i++)
                {
                    int temp = min_one;
                    min_one = min_one + min_two;
                    min_two = temp;
                }
                return min_one;
            }
        }


        [TestMethod]

        public void FibonacciTest()
        {
            int n = 5;
            int test1 = this.SolveClasic(n);
            int test2 = this.SolveDPHelper(n);
            int test3 = this.SolveDPButtomUp(n);
            Assert.AreEqual(test1, test2);
            Assert.AreEqual(test3, test2);

        }


    }
}
