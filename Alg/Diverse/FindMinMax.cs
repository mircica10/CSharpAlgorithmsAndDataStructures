using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg
{
    [TestClass]
    public class FindMinMax
    {
        int min = int.MaxValue;
        int max = int.MinValue;

        void GetValues(int[] a)
        {
            for (int i = 1; i < a.Length; i = i + 1) {
                if (a[i - 1] >= a[i])
                {
                    max = Math.Max(max, a[i - 1]);
                    min = Math.Min(min, a[i]);
                }
                else
                {
                    max = Math.Max(max, a[i]);
                    min = Math.Min(min, a[i - 1]);
                }
            }
            if (a.Length % 2 == 1)
            {
                max = Math.Max(max, a[a.Length - 1]);
                min = Math.Min(min, a[a.Length - 1]);
            }
        }


        [TestMethod]
        public void MinMaxTest()
        {
            int[] a = new int[] { 37, 62, 91, 82, 54, 87, 101 };
            GetValues(a);
            Assert.AreEqual(min, a.Min());
            Assert.AreEqual(max, a.Max());
        }

    }
}
