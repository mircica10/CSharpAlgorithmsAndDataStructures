using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ConsoleAppTest.Alg
{
    [TestClass]
    public class SellStockTwice
    {
        int ProfitMaxim(int[] sir)
        {
            int minim = sir[0];
            int[] castigMaxim = new int[sir.Length];
            castigMaxim[0] = 0;

            //a -> b
            for (int i = 1; i < sir.Length; i++)
            {
                minim = Math.Min(minim, sir[i]);
                castigMaxim[i] = sir[i] - minim;
            }

            //a <- b
            int maxim = sir[sir.Length - 1];
            int castigMaxim2Vanzari = castigMaxim[castigMaxim.Length - 1];
            for (int i = sir.Length - 1; i > 0; i--)
            {
                maxim = Math.Max(maxim, sir[i]);
                castigMaxim2Vanzari = Math.Max(castigMaxim[i - 1] + maxim - sir[i], castigMaxim2Vanzari);
            }

            return castigMaxim2Vanzari;
        }

        [TestMethod]
        public void TestVanzareActiuneDe2Ori()
        {
            int[] sir = new int[] { 12,11,13,9,12,8,14,13,15};
            Assert.AreEqual(10, ProfitMaxim(sir));

        }

    }
}
