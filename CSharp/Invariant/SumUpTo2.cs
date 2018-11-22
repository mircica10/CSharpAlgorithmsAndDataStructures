using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg.Invariant
{
    [TestClass]
    public class SumUpTo2
    {
        int[] sir = null;
        int target = 0;
        public SumUpTo2() { }
        public SumUpTo2(int[] sir, int target)
        {
            this.sir = sir;
            this.target = target;         
        }
        //ordonam sirul
        public bool ExistaHelper()
        {
            List<int> sir_ordonat = this.sir.ToList();
            sir_ordonat.Sort();
            this.sir = sir_ordonat.ToArray();
            return Exista();
        }

        public bool ExistaFaraDubluriHelper()
        {
            List<int> sir_ordonat = this.sir.ToList();
            sir_ordonat.Sort();
            this.sir = sir_ordonat.ToArray();
            return ExistaFaraDubluri();
        }

        public bool Exista()
        {
            int i = 0;
            int j = sir.Length - 1;
            while (i <= j)
            {
                if (sir[i] + sir[j] == this.target)
                    return true;
                else if (sir[i] + sir[j] < this.target)
                    i++;
                else
                    j--;
            }
            return false;
        }

        public bool ExistaFaraDubluri()
        {
            int i = 0;
            int j = sir.Length - 1;
            while (i < j)
            {
                if (sir[i] + sir[j] == this.target)
                    return true;
                else if (sir[i] + sir[j] < this.target)
                    i++;
                else
                    j--;
            }
            return false;
        }

        [TestMethod]
        public void SumUpTo2Test()
        {
            int[] sir = new int[] {5, 8, 7, 9, 2,-3 };
            int target1 = 18;
            SumUpTo2 sum1 = new SumUpTo2(sir, target1);
            Assert.IsTrue(sum1.ExistaHelper());

            int target2 = 54;
            SumUpTo2 sum2 = new SumUpTo2(sir, target2);
            Assert.IsFalse(sum2.ExistaHelper());
        }

    }

    
    [TestClass]
    public class SumUpTo3
    {
        int[] sir = null;
        int target = 0;

        public SumUpTo3() { }
        public SumUpTo3(int[] sir, int target)
        {
            this.sir = sir;
            this.target = target;            
        }

        public bool ExistaCuDubluri()
        {

            List<int> sir_ordonat = sir.ToList();
            sir_ordonat.Sort();
            sir = sir_ordonat.ToArray();

            //cautam daca exista SumUpTo2() cu target = target - a[i]
            for (int i = 0; i < sir.Length; i++)
            {
                SumUpTo2 sum2 = new SumUpTo2(sir, target - sir[i]);
                bool succes = sum2.Exista();
                if (succes)
                    return true;
            }
            return false;
        }

        int[] RemoveElementAtIndex(int[] sir_ordonat, int index)
        {            
            int[] sir_temp = new int[sir_ordonat.Length - 1];
            for (int j = 0; j < sir_ordonat.Length; j++)
            {
                int counter = 0;
                if (j != index)
                    sir_temp[counter++] = sir_ordonat[j];
            }
            return sir_temp;
        }

        public bool ExistaFaraDubluri()
        {
            //ordonam sirul originam
            List<int> sir_ordonat = sir.ToList();
            sir_ordonat.Sort();

            
            //procedam ca la exista, daor ca scoatem elementul a[i] din sir daca tinta este target - a[i]
            for (int i = 0; i < sir.Length; i++)
            {
                int[] sir_temp = RemoveElementAtIndex(sir_ordonat.ToArray(), i);
                SumUpTo2 sum2 = new SumUpTo2(sir_temp, target - sir_ordonat[i]);
                if (sum2.ExistaFaraDubluri())
                    return true;
            }
            return false;
        }

        [TestMethod]
        public void SumUpTo3Test()
        {
            int[] sir = new int[] { 5, 8, 7, 9, 2, -3 };
            int target1 = 20;
            SumUpTo3 sum1 = new SumUpTo3(sir, target1);
            Assert.IsTrue(sum1.ExistaCuDubluri());
            sum1.target = 130;
            Assert.IsFalse(sum1.ExistaCuDubluri());
            sum1.target = 27;
            Assert.IsFalse(sum1.ExistaFaraDubluri());
            Assert.IsTrue(sum1.ExistaCuDubluri());
        }

    }


}
