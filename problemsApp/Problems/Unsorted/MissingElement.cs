using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg
{
    [TestClass]
    public class MissingElement
    {
        int DoubleElement(int[] array)
        {
            HashSet<int> hash = new HashSet<int>();

            for (int i = 0; i < array.Length; i++) {
                if (hash.Contains(array[i]))
                    return array[i];
                else
                    hash.Add(array[i]);
            }
            return -1;
        }

        int GetMissingElement(int[] array)
        {
            int doubled = this.DoubleElement(array);

            int sumCorrect = ( (array.Length - 1) * array.Length ) / 2;
            int sum = array.Sum();
            return doubled + (sumCorrect - sum);
        }
        [TestMethod]
        public void MissingElementTest()
        {
            int[] a = new int[] { 0, 0, 2, 3, 4, 5, 6 };
            int[] b = new int[] { 0, 1, 2, 3, 4, 5, 7, 7};

            int test1 = GetMissingElement(a);
            int test2 = GetMissingElement(b);

            Assert.AreEqual(test1, 1);
            Assert.AreEqual(test2, 6);
        }

    }
}
