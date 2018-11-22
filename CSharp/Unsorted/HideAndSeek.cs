using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg
{
    [TestClass]
    public class HideAndSeek
    {

        string GetNextIterationVersion2(string s)
        {
            string raspuns = "";
            int repetitions;

            for (int i = 0; i < s.Length; i++)
            {
                repetitions = 1;

                while (s[i] == s[i + 1])  
                {
                    repetitions++;
                    i++;
                }                
                raspuns = raspuns + repetitions + s[i - 1];
            }
            
            return raspuns;
        }



        string GetNextIteration(string s)
        {
            string raspuns = "";
            int repetitions = 1;

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                {
                    repetitions++;
                    continue;
                }
                if (repetitions > 1)
                {
                    raspuns = raspuns + repetitions + s[i - 1];
                    repetitions = 1;
                    continue;
                }
                raspuns = raspuns + repetitions + s[i - 1];
            }
            //ultima cifra
            raspuns = raspuns + repetitions + s[s.Length - 1];
            return raspuns;
        }


        char CiftaNMetoda2(int n)
        {
            string s = "1";

            while (s.Length < n)
            {
                s = GetNextIterationVersion2(s);
            }
            return s[n - 1];
        }


        char CiftaN(int n)
        {
            string s = "1";

            while (s.Length < n)
            {
                s = GetNextIteration(s);
            }
            return s[n - 1];
        }

        [TestMethod]
        public void TestHideAndSeek()
        {
            //1113213211
            char c = CiftaN(9);
            Assert.AreEqual(c, '1');
            char d = CiftaN(9);
            Assert.AreEqual(d, '1');

        }


    }
}
