using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ConsoleAppTest.Alg
{

    [TestClass]
    public class TurnHanoi
    {
        Stack<int>[] turnuri = null; 
        int numar_pasi = 0;
        int numar_elemente_ramase;

        public TurnHanoi() { }

        public TurnHanoi(int k)
        {
            this.numar_elemente_ramase = k;
            Init(k);
        }

        void Init(int k)
        {
            turnuri = new Stack<int>[3];
            numar_pasi = 0;
            //init stacks
            for (int i = 0; i < 3; i++)
                turnuri[i] = new Stack<int>();
            //init source stack
            for (int i = 0; i < k; i++)
                turnuri[0].Push(i);
        }

        internal void RezolvaHanoiHelper()
        {
            RezolvaHanoi(this.numar_elemente_ramase, turnuri, 0, 1, 2);
        }

        internal void RezolvaHanoi(int k, Stack<int>[] turnuri, int source, int dest, int spare)
        {
            if (k > 0)
            {
                //mutam de la 0 la 2 prin 1 
                RezolvaHanoi(k - 1, turnuri, source, spare, dest);
                numar_pasi++;
                turnuri[dest].Push(turnuri[source].Pop());
                //mutam ultimul element de la 0 la 1 prin 2
                RezolvaHanoi(k - 1, turnuri, spare, dest, source);
            }            
        }

        [TestMethod]
        public void HanoiTest()
        {
            TurnHanoi test1 = new TurnHanoi(4);
            test1.RezolvaHanoiHelper();
            Assert.AreEqual(test1.numar_pasi, 15);

            TurnHanoi test2 = new TurnHanoi(1);
            test2.RezolvaHanoiHelper();
            Assert.AreEqual(test2.numar_pasi, 1);

            TurnHanoi test3 = new TurnHanoi(0);
            test3.RezolvaHanoiHelper();
            Assert.AreEqual(test3.numar_pasi, 0);

            TurnHanoi test4 = new TurnHanoi(10);
            test4.RezolvaHanoiHelper();
            Assert.AreEqual(test4.numar_pasi, 1023);
        }

    }
}
