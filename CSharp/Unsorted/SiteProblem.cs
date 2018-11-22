using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg
{
    [TestClass]
    public class SiteProblem
    {
        HashSet<string> dictionar = null;

        bool[,] deja_verifiat = null;


        string cuvant = "";

        public SiteProblem() { }
        internal SiteProblem(string cuvant, HashSet<string> dictionary)
        {
            this.dictionar = dictionary;
            this.cuvant = cuvant;
            deja_verifiat = new bool[cuvant.Length + 1, cuvant.Length + 1];
        }

        bool SePoateHelper()
        {
            for (int i = 0; i < cuvant.Length; i++)
                for (int j = 0; j < cuvant.Length; j++)
                    deja_verifiat[i, j] = false;
            return SePoate(this.cuvant, 0);
        }

        bool SePoate(string cuvant, int index)
        {
            if (index == (cuvant.Length))
                return true;
            else
            {
                for (int i = index + 1; i <= cuvant.Length; i++)
                {
                    string sir_de_verificat = cuvant.Substring(index, i - index);
                    if (!deja_verifiat[i, index] && dictionar.Contains(sir_de_verificat))
                    {
                        //cache
                        deja_verifiat[index, i] = true;
                        if (SePoate(cuvant, i))
                            return true;
                    }
                }
                return false;
            }
        }

        [TestMethod]

        public void SiteURLproblemTest()
        {
            HashSet<string> dictionar = new HashSet<string>() { "baieti", "gata", "bani", "de"};
            string cuvant = "baietidebanigata";
            string cuvant2 = "baietidefemei";
            SiteProblem site1 = new SiteProblem(cuvant, dictionar);
            Assert.IsTrue(site1.SePoateHelper());
            SiteProblem site2 = new SiteProblem(cuvant2, dictionar);
            Assert.IsFalse(site2.SePoateHelper());

        }
            


    }
}
