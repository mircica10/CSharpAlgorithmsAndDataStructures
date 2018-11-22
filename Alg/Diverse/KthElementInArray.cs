using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ConsoleAppTest.Alg
{

    struct IndexValue
    {
        public int index;
        public int value;
        public IndexValue(int _index, int _value)
        {
            this.index = _index;
            this.value = _value;
        }
    }

    [TestClass]
    public class KthElementInArray
    {
        //facem cam ca la quicksort

        IndexValue PartitionQuicksort(int[] array, int k, int left, int right)
        {
            int random = new Random().Next(left, right + 1);
            
            Swap(ref array[random], ref array[right]);

            int i = left - 1;
            for (int j = left; j <= (right - 1); j++)
            {
                if (array[j] <= array[right])
                {
                    i = i + 1;
                    Swap(ref array[i], ref array[j]);
                }
            }
            Swap(ref array[i + 1], ref array[right]);
            return new IndexValue(i + 1, array[i + 1]);
        }

        int ElementKHelper(int[] a, int k)
        {
            return k > a.Length ? -1 : ElementK(a, k - 1, 0, a.Length - 1);
        }

        int ElementK(int[] array, int k, int left, int right)
        {
            IndexValue element = PartitionQuicksort(array, k, left, right);
            if (element.index == k )
                return element.value;
            else if ( k > element.index )
            {
                return ElementK(array, k, element.index + 1, right);
            }
            else //(element.index  k)// > k
            {                
                return ElementK(array, k, left, element.index - 1);
            }
        }


        void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        [TestMethod]
        public void ElementKTest()
        {
            int[] a = new int[] { 54, 6, 32, 7, 87, 536, 9, 10, 0, 24, 765, 982, 12};
            int test1 = 4;
            int test2 = 6;

            int r1 = this.ElementKHelper(a, test1);
            int r2 = this.ElementKHelper(a, test2);

            Assert.AreEqual(r1, 9);
            Assert.AreEqual(r2, 12);

        }


    }
}
