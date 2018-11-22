using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest
{
    [TestClass]
    public class SortWithOrderPreserving
    {
        [TestMethod]
        public void TestSortarePAstrareRand()
        {
            bool[] sir = new bool[] { true, false, false, true, true, false, true, false};
            bool[] sirAranjat = SirAranjat(sir);
            Assert.IsTrue(sir[7]);
            Assert.IsTrue(sir[5]);
            Assert.IsFalse(sir[0]);
            Assert.IsFalse(sir[3]);
        }


        void Swap(ref bool a, ref bool b)
        {
            bool temp = a;
            a = b;
            b = temp;
        }

        

        bool[] SirAranjat(bool[] sir)
        {
            int indexTrue  = UrmatorulTrue(sir, sir.Length - 1);
            int indexFalse = UrmatorulFalse(sir, sir.Length - 1);
            while (indexTrue != -1 && indexFalse != -1)
            {
                if (indexTrue < indexFalse)
                {
                    Swap(ref sir[indexFalse], ref sir[indexTrue]);
                    indexFalse = UrmatorulFalse(sir, indexFalse - 1);
                    indexTrue = UrmatorulTrue(sir, indexFalse - 1);
                }
                else
                    indexTrue = UrmatorulTrue(sir, indexTrue - 1);

            }
            return sir;
        }


        int UrmatorulTrue(bool[] sir, int startIndex)
        {
            for (int i = startIndex; i >= 0; i--)
            {
                if (sir[i] == true)
                    return i;
            }
            return -1;
        }

        int UrmatorulFalse(bool[] sir, int endIndex)
        {
            for (int i = endIndex; i >= 0; i--)
            {
                if (sir[i] == false)
                    return i;
            }
            return -1;
        }



    }
}
