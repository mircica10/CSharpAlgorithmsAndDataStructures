using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ConsoleAppTest.Alg
{
    [TestClass]
    public class SearchOrderedMatrix
    {
        public static bool IsElementInMatrix(int[,] matrix, int element)
        {
            int i = 0;
            int max_i = matrix.GetLength(0);
                        
           
            while (i < max_i)
            {
                int left = 0;
                int right = max_i - 1;
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    if (element == matrix[i, mid])
                        return true;
                    if (element < matrix[i, mid])
                        right = mid - 1;
                    else
                        left = mid + 1;                        
                }               
                i++;
            }
            return false; 
        }


        [TestMethod]
        public void ElementInMatrixTest()
        {
            int[,] matrix = new int[,] { {-1, 1, 3, 5, 7 },
                                         { 2, 4, 6, 7, 9 },
                                         { 4, 7, 9,12,15 },
                                         { 8,12,16,20,24 },
                                         {10,15,18,28,29 }
                                        };
            bool test1 = SearchOrderedMatrix.IsElementInMatrix(matrix, 12);
            bool test2 = SearchOrderedMatrix.IsElementInMatrix(matrix, 13);
            Assert.IsTrue(test1);
            Assert.IsFalse(test2);


        }



    }
}
