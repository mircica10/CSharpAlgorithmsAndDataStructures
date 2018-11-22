using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest
{
    [TestClass]
    public class SteagOlandez
    {

        public int[] RezolvareOptima(int[] sir, int pivotIndex)
        {
            int pivot = sir[pivotIndex];
            int lower = 0;
            int egal = 0;
            int bigger = sir.Length;
            int necunoscute = bigger - lower - egal;
            
            while (egal < bigger - 1 )
            {
                if (sir[egal] < pivot)
                {
                    Swap(ref sir[lower], ref sir[egal]);
                    lower++;
                    egal++;
                }
                else
                {
                    if (sir[egal] == pivot)
                    {
                        egal++;
                    }
                    else
                    {
                        Swap(ref sir[egal], ref sir[bigger - 1]);
                        bigger--;
                    }
                }
            }
            return sir;
        }



        void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

                
        public int[] RezolvareQuicksortLamuto(int[] sir, int indexPivot)
        {
            Swap(ref sir[indexPivot], ref sir[sir.Length - 1]);

            int lo = 0;
            int hi = sir.Length;
            int i = lo - 1;
            int pivot = sir[hi - 1];

            for (int j = lo; j < hi - 1; j++)
            {
                if (sir[j] < pivot)
                {
                    i++;
                    Swap(ref sir[i], ref sir[j]);
                }
            }
            //if (sir[i + 1] > sir[hi - 1])
            //    Swap(ref sir[i + 1], ref sir[hi - 1]);

            int newLo = i + 1;

            for (int j = newLo ; j < hi - 1; j++)
            {
                if (sir[j] == pivot)
                {
                    i++;
                    Swap(ref sir[i], ref sir[j]);
                }
            }

            if (sir[i + 1] > sir[hi - 1])
                Swap(ref sir[i + 1], ref sir[hi - 1]);

            return sir;

        }




        public int[] RezolvareQuicksort(int[] sir, int indexPivot)
        {
            Swap(ref sir[indexPivot], ref sir[sir.Length - 1]);
            int i = -1 ;
            int j = sir.Length - 1;
            int lungimeSir = sir.Length;

            while (true)
            {
                do i++;
                while (sir[i] <= sir[lungimeSir - 1] && i < lungimeSir - 1);

                do j--;
                while (sir[j] >= sir[lungimeSir - 1] && j > 0);
                
                if (i < j)
                   Swap(ref sir[i], ref sir[j]);
                else
                    break;
                //Swap(ref sir[sir.Length - 1], ref sir[i]);
                //return sir;
            }

            j = sir.Length - 1;
            i--;
            while (true)
            {
                do i++;
                while (sir[i] <= sir[lungimeSir - 1] && i < lungimeSir - 1);

                do j--;
                while (sir[j] > sir[lungimeSir - 1] && j > 0);

                if (i < j)
                    Swap(ref sir[i], ref sir[j]);
                else
                {
                    Swap(ref sir[sir.Length - 1], ref sir[i]);
                    return sir;
                }
            }
                       

        }


        public int[] RezolvareTriviala(int[] sir, int indexPivot)
        {
            List<int> mici = new List<int>();
            List<int> egale = new List<int>();
            List<int> mari = new List<int>();

            for (int i = 0; i < sir.Length; i++)
            {
                if (sir[i] < sir[indexPivot])
                {
                    mici.Add(sir[i]);
                }
                else
                {
                    if (sir[i] == sir[indexPivot])
                    {
                        egale.Add(sir[i]);
                    }
                    else
                    {
                        mari.Add(sir[i]);
                    }
                }
            }

            int[] sirSortat = new int[sir.Length];
            int index = 0;
            foreach (int i in mici)
                sirSortat[index++] = i;
            foreach (int j in egale)
                sirSortat[index++] = j;
            foreach (int k in mari)
                sirSortat[index++] = k;

            return sirSortat;
        }

        [TestMethod]
        public void TestSteagOlandez()
        {
            //Arrange
            int[] sir       = new int[] { 5, 7, 3, 8, 1, 8, 0, -5, 9, 6, 3, 6 };
            //int[] sirLamuto = new int[] { 5, 7, 3, 8, 1, 8, 0, -5, 9, 6, 3, 6 };
            int indexPivot = 2;
            //Act
            //int[] sirSortat = RezolvareTriviala(sir, indexPivot);
            //int[] sirSortatQuicksort = RezolvareQuicksort(sir, indexPivot);
            int[] sirAsteptat = new int[] { 1, 0, -5, 3, 3, 5, 7, 8, 8, 9, 6, 6 };

            //int[] sirSortatQuicksortLamuto = RezolvareQuicksortLamuto(sirLamuto, indexPivot);
            int[] sirSortatOptim = RezolvareOptima(sir, indexPivot);



            //for(int i = 0; i < sirSortatQuicksort.Length; i++)
            //    Assert.AreEqual(sirSortatQuicksort[i], sirAsteptat[i]);

            //for (int i = 0; i < sirSortatQuicksortLamuto.Length; i++)
            //    Assert.AreEqual(sirSortatQuicksortLamuto[i], sirAsteptat[i]);


        }

    }



}
