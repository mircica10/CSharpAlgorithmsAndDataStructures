using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg
{

  

    [TestClass]
    public class SquareRoot
    {
        static double GetPrecision(int x)
        {
            double numar = 1;
            while (x-- > 0)
                numar *= 0.1d;

            return numar;
        }

        public static double GetSquareRoot(double target, int precision)
        {
           
            double distanta = GetPrecision(precision);
            double left = 0;
            double right = target;
            double mid = left + ((right - left) / 2);

            while (Math.Abs(target - (mid * mid) ) > distanta)
            {
                if ( (mid * mid) > target)
                    right = mid;
                else
                    left = mid;
                mid = left + ((right - left) / 2);
               
            }
            return mid;
        }

        [TestMethod]
        public void SquareRootTest()
        {
            double target1 = 8;
            double result1 = SquareRoot.GetSquareRoot(target1, 1);

            Assert.IsTrue((result1 * result1 - 0.001) < target1);

        }

    }
}
