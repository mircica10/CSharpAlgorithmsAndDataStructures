using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg.DP
{
    [TestClass]
    public class PrintatFrumos
    {
        int[] cuvinte = null;
        int[] mizeria = null;
        int[,] f = null;
        int lungime_maxima = 0;

        public PrintatFrumos() { }
        public PrintatFrumos(int _lungime_maxima, int[] cuvinte)
        {
            this.lungime_maxima = _lungime_maxima;
            this.cuvinte = cuvinte;
            mizeria = new int[cuvinte.Length];
            f = new int[cuvinte.Length, cuvinte.Length];
        }

        void CalculatF()
        {
            for (int i = 0; i < cuvinte.Length; i++)
            {
                for (int j = i; j < cuvinte.Length; j++)
                {
                    int f_temp = 0;
                    f[i, j] = int.MaxValue;
                    for (int k = i; k <= j; k++)
                        f_temp = f_temp + cuvinte[k];
                    //adaugam spatiile libere
                    f_temp = f_temp + ( (j - i) > 0 ? j - i : 0 );
                    //updatam f[i, j] daor daca e mai mic sau egal cu Lungime Maxima
                    if (f_temp <= this.lungime_maxima)
                        f[i, j] = (this.lungime_maxima - f_temp) * (this.lungime_maxima - f_temp); //functia este patratica
                }
            }
        }

        
        int CalculeazaMizeria()
        {
            //calculam matricea
            CalculatF();

            //o facem buttom up
            for (int i = 0; i < cuvinte.Length; i++)
            {
                int mizerie_temp = int.MaxValue;
                for (int j = 0; j <= i; j++)
                {
                    int mizerie_precedenta = (j - 1) < 0 ? 0 : mizeria[j - 1];
                    if (f[j, i] == int.MaxValue) //nu luam in seama daca cuvintele de la j la i nu pot fi scrise pe o linie
                        continue;
                    int mizerie_j_i = mizerie_precedenta + f[j, i];
                    mizerie_temp = Math.Min(mizerie_temp, mizerie_j_i);
                }
                mizeria[i] = mizerie_temp;
            }
            return mizeria[cuvinte.Length - 1];
        }

        [TestMethod]
        public void PrintatFrumosTest()
        {
            PrintatFrumos printat_frumos = new PrintatFrumos(5, new int[] { 1, 1, 1, 1 });
            Assert.AreEqual(8, printat_frumos.CalculeazaMizeria());

            PrintatFrumos printat_frumos2 = new PrintatFrumos(11, new int[] { 3, 3, 1, 1, 2, 2, 6 });
            Assert.AreEqual(45, printat_frumos2.CalculeazaMizeria());


        }

    }
}
