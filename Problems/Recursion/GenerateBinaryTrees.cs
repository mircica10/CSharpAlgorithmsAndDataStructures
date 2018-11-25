using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting; 


namespace ConsoleAppTest.Alg.Recursion
{

    
    [TestClass]
    public class GenerateBinaryTrees
    {
        internal class BinaryTree
        {
            internal BinaryTree left;
            internal BinaryTree right;
            internal int value;

            public BinaryTree() { }

            internal BinaryTree CopyTree(BinaryTree copac, BinaryTree copie)
            {
                if (copac == null)
                    return null;
                else
                {
                    if (copac.left != null)
                    {
                        copie.left = new BinaryTree(copac.left.value, null, null);
                        CopyTree(copac.left, copie.left);
                    }
                    else
                        copie.left = null;

                    if (copac.right != null)
                    {
                        copie.right = new BinaryTree(copac.right.value, null, null);
                        CopyTree(copac.right, copie.right);
                    }
                    else
                        copie.right = null;
                    return copie;
                }
            }



            internal BinaryTree(int _value, BinaryTree _left, BinaryTree _right)
            {
                this.value = _value;
                this.left = _left;
                this.right = _right;
            }

            private bool AreEqual(BinaryTree tree1, BinaryTree tree2)
            {
                if (tree1 != null && tree2 != null)
                {
                    bool left = AreEqual(tree1.left, tree2.left);
                    bool right = AreEqual(tree1.right, tree2.right);
                    return left && right;
                }
                else if (tree2 == null && tree1 == null)
                {
                    return true;
                }
                else
                    return false;
            }

            public override bool Equals(object obj)
            {
                return AreEqual(this, (BinaryTree)obj);
            }

            public override int GetHashCode()
            {
                var hashCode = 1890787815;
                hashCode = hashCode * -1521134295 + EqualityComparer<BinaryTree>.Default.GetHashCode(left);
                hashCode = hashCode * -1521134295 + EqualityComparer<BinaryTree>.Default.GetHashCode(right);
                hashCode = hashCode * -1521134295 + value.GetHashCode();
                return hashCode;
            }
        }

        int n;

        List<BinaryTree> solutie = new List<BinaryTree>();

        void GenerateBinaryTreeRecursively(int k, BinaryTree root, BinaryTree copac)
        {
            if (k >= n)
            {
                BinaryTree _copie_copac = new BinaryTree(root.value, null, null);
                root.CopyTree(root, _copie_copac);
                if(!solutie.Contains(_copie_copac))
                    solutie.Add(_copie_copac);
            }
            else
            {
                if (copac.left == null)
                {
                    copac.left = new BinaryTree(1, null, null);
                    GenerateBinaryTreeRecursively(k + 1, root, copac);
                    copac.left = null;
                }
                else
                    GenerateBinaryTreeRecursively(k, root, copac.left);

                if (copac.right == null)
                {
                    copac.right = new BinaryTree(1, null, null);
                    GenerateBinaryTreeRecursively(k + 1, root, copac);
                    copac.right = null;
                }
                else
                    GenerateBinaryTreeRecursively(k, root, copac.right);
            }
        }

        List<BinaryTree> solutii2 = new List<BinaryTree>();

        internal List<BinaryTree> BTgenerierenPerfect(int n)
        {
            List<BinaryTree> rezultat = new List<BinaryTree>();
            if (n == 0)
            {
                rezultat.Add(null);
                return rezultat;
            }
            else
            {
                for (int left_trees = 0; left_trees < n; left_trees++)
                {
                    List<BinaryTree> stanga_copaci = BTgenerierenPerfect(left_trees);
                    int right_trees = n - left_trees - 1;
                    List<BinaryTree> dreapta_copaci = BTgenerierenPerfect(right_trees);
                    foreach (var i in stanga_copaci)
                        foreach (var j in dreapta_copaci)
                            rezultat.Add(new BinaryTree(1, i, j));
                }
            }
            return rezultat;
        }



        [TestMethod]
        public void GenerateCopaciBinariTest()
        {
            
            BinaryTree n1 = new BinaryTree(1, null, null);
       
            this.n = 3;

            this.GenerateBinaryTreeRecursively(1 ,n1, n1);
            Assert.AreEqual(this.solutie.Count, 5);

            List<BinaryTree> solutie =  this.BTgenerierenPerfect(3);
            Assert.AreEqual(solutie.Count, 5);
        }


    }
}
