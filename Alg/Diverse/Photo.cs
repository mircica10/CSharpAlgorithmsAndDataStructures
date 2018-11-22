using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg
{

    [TestClass]
    public class Fotografie
    {
        bool Merge(int[] echipa1, int[] echipa2)
        {
            if (echipa1.Length != echipa2.Length)
                return false;
            echipa1.ToList().Sort();
            echipa2.ToList().Sort();

            int[] e1 = echipa1.ToArray();
            int[] e2 = echipa2.ToArray();

            bool echipa1_in_fata = true;

            for (int i = 0; i < e1.Length; i++)
            {
                if (e1[i] > e2[i])
                {
                    echipa1_in_fata = false;
                    break;
                }
            }
            if (echipa1_in_fata)
                return true;

            bool echipa2_in_fata = true;

            for (int i = 0; i < e1.Length; i++)
            {
                if (e1[i] < e2[i])
                {
                    echipa2_in_fata = false;
                    break;
                }
            }
            if (echipa2_in_fata)
                return true;

            return false;
        }

        [TestMethod]
        public void PhotoDayTest()
        {
            int[] test1 = new int[] { 4, 2, 6 };
            int[] test2 = new int[] { 2, 1, 4 };
            Assert.IsTrue(this.Merge(test1, test2));


        }


    }
}
