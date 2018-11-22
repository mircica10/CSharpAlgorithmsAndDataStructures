using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg
{
    [TestClass]
    public class PermutareaUrmatoare
    {

        void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        int[] UrmatoareaPermutare(int[] sir)
        {
            int pivot = -1;
            for (int i = sir.Length - 2; i >= 0; i--)
            {
                if (sir[i] < sir[i + 1])
                {
                    pivot = i;
                    break;
                }
            }
            if (pivot == -1)
                return new int[] { };
            //find out minim in remaining from pivot + 1 index onwards, bigger than sir[pivot]
            int minim = pivot + 1;
            for (int i = pivot + 2; i < sir.Length; i++)
            {
                if (sir[minim] > sir[i] && sir[i] > sir[pivot])
                    minim = i;
            }
            
            Swap(ref sir[pivot], ref sir[minim]);


            //de la minim la pivot il ducem pe minim pana cand intalneste un element mai mic decat el - eronat
            //swap la toate elementele de la pivot + 1 spre final, deoarece sunt in ordine descrescatoarea
            int mijlocInterval = (sir.Length + (pivot + 1)) / 2;
            int indexDeSus = sir.Length - 1;
            for (int j = pivot + 1; j < mijlocInterval ; j++)
            {
                Swap(ref sir[j], ref sir[indexDeSus]);
                indexDeSus--;
            }
            return sir;
        }

        [TestMethod]
        public void TestPermutareaUrmatoare()
        {
            int[] test = new int[] { 1,2,3,4 };
            UrmatoareaPermutare(test);
            UrmatoareaPermutare(test);
            UrmatoareaPermutare(test);
        }


    }
}
