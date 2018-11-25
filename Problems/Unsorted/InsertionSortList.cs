using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg
{
       
    [TestClass]
    public class InsertionSortList
    {
        Lista SorteazaLista(Lista lista)
        {
            //facem insertion sort pentru liste
            Lista iter = lista;
            Lista dummy = new Lista(iter, 0);
            

            while (iter != null && iter.next != null)
            {
                if (iter.valoare > iter.next.valoare)
                {
                    //avem element mai mare decat precedentul
                    //il introducem la locul lui
                    Lista temp = dummy;
                    while (temp.next.valoare < iter.next.valoare)
                    {
                        temp = temp.next;
                    }
                    Lista element_de_inserat = iter.next;
                    iter.next = iter.next.next;
                    element_de_inserat.next = temp.next;
                    temp.next = element_de_inserat;
                }
                else
                {
                    iter = iter.next;
                }
            }
            return dummy.next;
        }

        [TestMethod]
        public void InsertionSortListTest()
        {
            Lista l = new Lista(new Lista(new Lista(new Lista(new Lista(new Lista(null, 4),1),6),2),3),5);
            Lista sorted_list = SorteazaLista(l);
            while (sorted_list.next != null)
            {
                Assert.IsTrue(sorted_list.valoare <= sorted_list.next.valoare);
                sorted_list = sorted_list.next;
            }


        }

    }
}
