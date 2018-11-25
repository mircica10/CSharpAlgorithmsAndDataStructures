using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg.Recursion
{
    [TestClass]
    public class CMMDC
    {
        int CMMDCsolve(int x, int y)
        {
            return x % y == 0 ? y : CMMDCsolve(y, x / y);
        }

        public CMMDC() { }


        [TestMethod]
        public void CMMDCTest()
        {
            Assert.AreEqual(CMMDCsolve(34, 14), 2);
            Assert.AreEqual(CMMDCsolve(48, 12), 12);



        }
    }
}
