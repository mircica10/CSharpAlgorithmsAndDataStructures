using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg
{
    [TestClass]
    public class RotateMatrix
    {
        int[,] RotesteDreaptaBruteForce(int n)
        {
            int[,] matrice = new int[4, 4];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrice[i, j] = i * n + j + 1;

            int[,] matriceRotitaDreapta = new int[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matriceRotitaDreapta[i, j] = matrice[n - j - 1, i];

            return matriceRotitaDreapta;
        }


        int[,] RotesteDreaptaInplace(int n)
        {
            int[,] matrice = new int[4, 4];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrice[i, j] = i * n + j + 1;

            int temp1, temp2, temp3, temp4;

            int start = 0;
            int end = n - 1;

            while ( start < end )
            {
                for (int i = start; i < end; i++)
                {
                    temp1 = matrice[start, i];
                    temp2 = matrice[i, end];
                    temp3 = matrice[end, end - i];
                    temp4 = matrice[end - i, start];
                    matrice[start, i] = temp4;
                    matrice[i, end] = temp1;
                    matrice[end, end - i] = temp2;
                    matrice[end - i, start] = temp3;
                }
                start++;
                end--;
            }
            
            return matrice;
        }

        [TestMethod]
        public void TestRotesteDreaptaBrut()
        {
            int[,] mat = RotesteDreaptaBruteForce(4);
            int[,] mat2 = RotesteDreaptaInplace(4);
        }

    }
}
