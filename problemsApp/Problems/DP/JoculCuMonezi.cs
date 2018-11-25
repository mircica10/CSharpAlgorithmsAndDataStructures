using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg.Recursion
{
    [TestClass]
    public class JoculCuMonezi
    {        
        int CalculeazaDPhelper(int[] C)
        {
            //max min strategie
            //R[i,j] = max { c[i] + min{ R[i + 2, j], R[i + 1, j - 1]  }, c[j] + min{R[i, j - 2], R[i + 1, j - 1] } }

            int[,] R = new int[C.Length, C.Length];
            return CalculeazaDP(0, C.Length - 1, C, R);
        }

        int CalculeazaDP(int i, int j, int[] C, int[,] R)
        {
            if (i >= j)//base case
                return 0;
            else
            {
                if (R[i, j] == 0)
                {
                    int take_left = C[i] + Math.Min(CalculeazaDP(i + 2, j, C, R), CalculeazaDP(i + 1, j - 1, C, R));
                    int take_right = C[j] + Math.Min(CalculeazaDP(i, j - 2, C, R), CalculeazaDP(i + 1, j - 1, C, R));
                    R[i, j] = Math.Max(take_left, take_right);
                }
                return R[i, j];
            }
        }
    }
}
