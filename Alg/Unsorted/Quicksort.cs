using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest
{
    [TestClass]
    public class Quicksort
    {

        void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

       
        int PartitionLamuto(int[] array, int start, int stop)
        {
            int pivot = array[stop];
            int i = start - 1;
            for (int j = start; j < stop - 1; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(ref array[i], ref array[j]);
                }
            }
            if (array[stop] < array[i + 1])
                Swap(ref array[i + 1], ref array[stop]);
            return i + 1;
        }


        void SolveQuicksortLamuto(int[] array, int start, int stop)
        {
            if (start < stop)
            {
                int p = PartitionLamuto(array, start, stop);
                SolveQuicksortLamuto(array, start, p - 1);
                SolveQuicksortLamuto(array, p + 1, stop);
            }
        }

        int PartitionHoare(int[] array, int start, int stop)
        {
            int pivot = array[start];
            int i = start - 1;
            int j = stop + 1;

            while (true)
            {
                do i++;
                while (array[i] < pivot);
                do j--;
                while (array[j] > pivot);

                if (i >= j)
                    return j;
                
                Swap(ref array[i], ref array[j]);                
            }
        }


        void SolveQuicksortHoare(int[] array, int start, int stop)
        {
            if (start < stop)
            {
                int p = PartitionHoare(array, start, stop);
                SolveQuicksortHoare(array, start, p);
                SolveQuicksortHoare(array, p + 1, stop);
            }
        }

        [TestMethod]
        public void TestQuicksort()
        {
            int[] sirDeSortatHoare = new int[] { 8, 6, 1, 3, 5, 7, 9, 10, 4, 11, 2 };
            int[] sirDeSortatLamuto = new int[] { 8, 6, 1, 3, 5, 7, 9, 10, 4, 11, 2 };


            int[] sirAsteptat = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            SolveQuicksortHoare(sirDeSortatHoare, 0, sirDeSortatHoare.Length - 1);
            SolveQuicksortLamuto(sirDeSortatLamuto, 0, sirDeSortatLamuto.Length - 1);

            for (int i = 0; i < sirDeSortatHoare.Length; i++)
                Assert.AreEqual(sirAsteptat[i], sirDeSortatHoare[i]);

            for (int i = 0; i < sirDeSortatLamuto.Length; i++)
                Assert.AreEqual(sirAsteptat[i], sirDeSortatLamuto[i]);


        }



    }
}
