using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Alg.DP
{
    class CeaMaiLungaSecventaCrescatoare
    {
        int[] sir = null;

        int CalculeazaCeaMaiLungaSecventaCreascatoare()
        {
            int max = 0;
            int[] values = new int[sir.Length];

            for (int i = 0; i < sir.Length; i++)
            {
                int max = 0;
                for (int j = 0; j < i; j++)
                {
                    if (sir[j] < sir[i])
                        max = Math.Max(max, values[j] + 1);
                }
                values[i] = max;
            }


        }



    }
}
