using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg
{
    [TestClass]
    public class ApplyPermutationToAnArray
    {

        void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        int[] AplicaPermutareaMetodaBruta(int[] sir, int[] permutare)
        {
            int[] sirNou = new int[sir.Length];

            for (int i = 0; i < permutare.Length; i++)
            {
                sirNou[i] = sir[permutare[i]];
            }

            return sirNou;
        }

        int[] AplicaPermutareaInplace(int[] sir, int[] permutare)
        {
            for (int i = 0; i < permutare.Length; i++)
            {
                if (i != permutare[i])
                {
                    int indexViitor = -1;
                    for (int j = i; j < sir.Length; j++)
                    {
                        if (i == permutare[j])
                        {
                            indexViitor = j;
                            break;
                        }
                    }
                    //swap la permutare
                    Swap(ref sir[i], ref sir[permutare[i]]);
                    Swap(ref permutare[i], ref permutare[indexViitor]);                   
                }
            }


            return sir;
        }

        [TestMethod]
        public void TestAplicaPermutareaUnuiSir()
        {
            int[] sirInitial = { 1, 2, 3, 4, 5 };
            int[] permutarea = { 3, 0, 1, 4, 2 };
            int[] sirDupaPermutare = { 4, 1, 2, 5, 3 };
            int[] permutareAplicataMetodaBruta = AplicaPermutareaMetodaBruta(sirInitial, permutarea);
            int[] sirInitialInplace = { 1, 2, 3, 4, 5 };
            int[] permutareaAplicataInplace = AplicaPermutareaInplace(sirInitialInplace, permutarea);

            for (int i = 0; i < permutareAplicataMetodaBruta.Length; i++)
                Assert.AreEqual(permutareAplicataMetodaBruta[i], sirDupaPermutare[i]);

            for (int i = 0; i < permutareaAplicataInplace.Length; i++)
                Assert.AreEqual(permutareaAplicataInplace[i], sirDupaPermutare[i]);

        }
    }
}
