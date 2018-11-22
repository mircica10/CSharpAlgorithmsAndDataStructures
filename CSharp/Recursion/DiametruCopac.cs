using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg.Recursion
{
    class BT
    {
        internal BT left;
        internal BT right;
        public BT(BT _left, BT _right)
        {
            this.left = _left;
            this.right = _right;
        }

        public BT()
        {
            this.left = null;
            this.right = null;
        }
    }
        

    [TestClass]
    public class DiametruCopac
    {

        int diameter = int.MinValue;

        int CalculeazaAdancimeMaximaCopac(BT root)
        {
            if (root == null)//base case, returnam 0
                return 0;
            else
            {
                int left = CalculeazaAdancimeMaximaCopac(root.left);
                int right = CalculeazaAdancimeMaximaCopac(root.right);
                diameter = Math.Max(left + right + 1, diameter);
                int height_noua = Math.Max(left, right) + 1;
                return height_noua;
            }
        }

        public DiametruCopac() { }

        int CalculeazaDiametru(BT root)
        {
            return CalculeazaAdancimeMaximaCopac(root.left) + CalculeazaAdancimeMaximaCopac(root.right);
        }

        [TestMethod]
        public void DiametruCopacTest()
        {
            BT n9 = new BT();
            BT n8 = new BT(null, n9);
            BT n7 = new BT(null, n8);
            BT n6 = new BT();
            BT n5 = new BT();
            BT n4 = new BT(n6, n5);
            BT n3 = new BT(n4, n7);
            BT n2 = new BT();
            BT n1 = new BT(n2, n3);

            CalculeazaAdancimeMaximaCopac(n1);
            Assert.AreEqual(this.diameter, 6);
        }

    }
}
