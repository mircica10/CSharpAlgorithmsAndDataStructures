using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg
{
    [TestClass]
    public class GeneratePermutation
    {

        //genereaza permutari ale caracterelor unui string
        List<string> Permutari(string s)
        {
            if (s.Length == 1)
                return new List<string> { s };
            else
            {
                List<string> raspuns = new List<string>();
                char c = s[0];
                List<string> perm = Permutari(s.Substring(1));
                foreach (string temp in perm)
                {
                    for (int i = 0; i <= temp.Length; i++)
                    {
                        raspuns.Add(temp.Insert(i, c.ToString()));
                    }
                }
                return raspuns;
            }
        }

        [TestMethod]
        public void TestPermutari()
        {
            string test = "1234";
            List<string> testPermutari = Permutari(test);

            Console.WriteLine("");

        }


    }
}
