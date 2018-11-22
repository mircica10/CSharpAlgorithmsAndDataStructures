using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg
{
    [TestClass]
    class Lista
    {
        internal int valoare;
        internal Lista next = null;

        internal Lista(Lista _next, int _valoare)
        {
            this.valoare = _valoare;
            this.next = _next;
        }
        internal void Insert(Lista l)
        {            
            l.next = this.next;
            this.next = l;            
        }
        internal void DeleteAfter(Lista l)
        {
            l.next = l.next.next;
        }
    }


    [TestClass]
    public class MergeSortLists
    {
        Lista MergeSortedLists(Lista lista1, Lista lista2)
        {
            Lista raspuns = null;
            Lista root = null;
            while (lista1 != null && lista2 != null)
            {
                if (lista1.valoare <= lista2.valoare)
                {
                    if (raspuns == null)
                    {
                        raspuns = lista1;
                        root = raspuns;
                    }
                    else
                    {
                        raspuns.next = lista1;
                        raspuns = raspuns.next;
                    }
                    lista1 = lista1.next;
                }
                else
                {
                    if (raspuns == null)
                    {
                        raspuns = lista2;
                        root = raspuns;
                    }
                    else
                    {
                        raspuns.next = lista2;
                        raspuns = raspuns.next;
                    }
                    lista2 = lista2.next;
                }
            }
            if (lista1 != null)
                raspuns.next = lista1;
            else if (lista2 != null)
                raspuns.next = lista2;
            return root;
        }

        Lista MergeSort(Lista list)
        {            
            if ( (list != null) && (list.next != null) )
            {
                Lista mijloc = AflaJumatateaListei(list);

                Lista l2 = mijloc;
                Lista l1 = list;
                Lista l1_iterator = list;
                Lista previous = null;
                while (l1_iterator != mijloc)
                {
                    previous = l1_iterator;
                    l1_iterator = l1_iterator.next;
                }
                previous.next = null;

                l1 = MergeSort(l1);
                l2 = MergeSort(l2);
                Lista result = MergeSortedLists(l1, l2);
                return result;
            }
            return list;
        }

        Lista AflaJumatateaListei(Lista lista)
        {
            if (lista == null || lista.next == null)
                return lista;
            
            Lista iterator1 = lista;
            Lista iterator2 = lista.next;
            while (iterator2 != null)
            {
                iterator1 = iterator1.next;
                iterator2 = iterator2.next;
                if (iterator2 != null)
                    iterator2 = iterator2.next;
            }
            return iterator1;
        }

        [TestMethod]
        public void MergeSortListTest()
        {
            Lista l1 = new Lista(null, 9);
            Lista l2 = new Lista(l1, 6);
            Lista l3 = new Lista(l2, 5);
            Lista l4 = new Lista(l3, 8);
            Lista l5 = new Lista(l4, 4);


            Lista l = MergeSort(l5);
            int count = 1;
            while (l.next != null)
            {
                Assert.IsTrue(l.next.valoare - l.valoare >= 0);
                l = l.next;
                ++count;
            }
            Assert.AreEqual(count, 5);
            
        }


    }
}
