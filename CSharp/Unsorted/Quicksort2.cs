using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg
{
    [TestClass]
    public class Quicksort2
    {

        int QuickPartition(int[] sir, int a, int b)
        {
            int i = a - 1;
            int j = b + 1;
            int pivot = sir[a];

            while (true)
            {
                do i++;
                while (sir[i] < pivot);

                do j--;
                while (sir[j] > pivot);

                if (i >= j)
                    return j;

                Swap(ref sir[i], ref sir[j]);
            }
        }

        void PartitionHoare(int[] a, int start, int end)
        {
            if (start < end)
            {
                int mijloc = QuickPartition(a, start, end);
                PartitionHoare(a, start, mijloc);
                PartitionHoare(a, mijloc + 1, end);
            }

            
        }

        void AranjatSirOptim(int[] sir)
        {
            for (int i = 1; i < sir.Length; i++)
            {
                if ((i % 2) == 0)
                {
                    if (sir[i] > sir[i - 1])
                        Swap(ref sir[i], ref sir[i - 1]);
                }
                else
                {
                    if( sir[i] < sir[i - 1])
                        Swap(ref sir[i], ref sir[i - 1]);
                }
            }
        }

        private void Swap(ref int v1, ref int v2)
        {
            int temp = v1;
            v1 = v2;
            v2 = temp;
        }

        [TestMethod]
        public void TestAranjatSir()
        {
            int[] sir = new int[] { 2 ,5, 4 ,3 ,6 ,7 ,8 , 9, 1 };
            PartitionHoare(sir, 0, sir.Length - 1);

            for (int i = 0; i < sir.Length; i++)
                Assert.AreEqual((1 + i), sir[i]);
            
            AranjatSirOptim(sir);            
        }
    }
}
