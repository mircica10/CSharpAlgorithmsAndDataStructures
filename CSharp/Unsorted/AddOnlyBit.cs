using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest
{
    public class InmultireDoarBit
    {


        public bool IsPaliandrom(string test)
        {
            int size = test.Length;
            for (int i = 0; i < size / 2; i++)
            {
                if ( (test[i]) != (test[size - 1 - i])  )
                    return false;
            }
            return true;
        }

        public int ClearLeastSignificantBit(int test)
        {
            return test & (test - 1);

        }

        public int GetLeastSegnificantBit(int test)
        {
            return test & (~(test - 1));
        }

        public int GetMostSignigicatBit(int test)
        {
            int rezultat = test;
            while (test != 0)
            {
                rezultat = GetLeastSegnificantBit(test);
                test = ClearLeastSignificantBit(test);
            }

            return rezultat;
        }

        public int RidicareLaPutere(int baza, int putere)
        {
            int rezultat = 1;
            while (putere != 0)
            {
                rezultat = Inmultire(rezultat, baza);
                putere = ScadereDoarBiti(putere, 1);
            }
            return rezultat;
        }

        public bool CheckIfPozitive(int x)
        {
            int bitMaskSize = 31;
            return (((x >> bitMaskSize) & 1) == 0);
        }

        public int CatImpartire(int x, int y)
        {
            int cat = 0;
            x = ScadereDoarBiti(x, y); 

            while (CheckIfPozitive(x))
            {
                cat++;
                x = ScadereDoarBiti(x, y);                
            }
            return cat;
        }

        public int AdunareDoarBiti(int x, int y)
        {
            int rezultat = x ^ y;
            int carry = x & y;

            while (carry != 0)
            {
                int shiftedcarry = carry << 1;
                carry = rezultat & shiftedcarry;
                rezultat = rezultat ^ shiftedcarry;                
            }

            return rezultat;
        }


        public int ScadereDoarBiti(int x, int y)
        {
            int z = (~y) + 1;
            return AdunareDoarBiti(x, z);
        }

        public int Inmultire(int x, int y)
        {
            int rezultat = 0;

            while (y != 0)
            {                
                if ( (y & 1) == 1)
                { 
                    rezultat = AdunareDoarBiti(rezultat, x);                    
                }

                x = x << 1;
                y = y >> 1;
            }
            return rezultat;
        }



    }

    [TestClass]
    public class InmultireDoarBitTest
    {
        [TestMethod]
        public void TesteazaAdunarea()
        {
            //Arrange 
            InmultireDoarBit inmultire = new InmultireDoarBit();
            string paliandromPozitiv = "asddsa";
            string paliandromNegativ = "asdf";
            int integerPaliandromPozitiv = 1234321;
            int integetPaliandromNegativ = 1234;
            //Act
            int x = 64;
            int y = 50;
            int testAdunare = inmultire.AdunareDoarBiti(x, y);
            int testInmultire = inmultire.Inmultire(x, y);
            int testScadere = inmultire.ScadereDoarBiti(x, y);
            bool testPozitive = inmultire.CheckIfPozitive(43);
            bool testNegative = inmultire.CheckIfPozitive(-53);
            int testCatImpartire = inmultire.CatImpartire(93, 31);
            int testRidicareLaPutere = inmultire.RidicareLaPutere(5, 3);
            int testGetMostSignificantBit = inmultire.GetMostSignigicatBit(69);
            bool testPaliandromPozitiv = inmultire.IsPaliandrom(paliandromPozitiv);
            bool testPaliangromNegativ = inmultire.IsPaliandrom(paliandromNegativ);
            bool testIntegerPaliandromPozitiv = inmultire.IsPaliandrom(integerPaliandromPozitiv.ToString());
            bool testIntegerPaliangromNegativ = inmultire.IsPaliandrom(integetPaliandromNegativ.ToString());
            //Assert
            Assert.AreEqual(testAdunare, 114);
            Assert.AreEqual(testInmultire, 3200);
            Assert.AreEqual(testScadere, 14);
            Assert.IsTrue(testPozitive);
            Assert.IsFalse(testNegative);
            Assert.AreEqual(testCatImpartire, 3);
            Assert.AreEqual(testRidicareLaPutere, 125);
            Assert.AreEqual(testGetMostSignificantBit, 64);
            Assert.IsTrue(testPaliandromPozitiv);
            Assert.IsFalse(testPaliangromNegativ);
            Assert.IsTrue(testIntegerPaliandromPozitiv);
            Assert.IsFalse(testIntegerPaliangromNegativ);
        }


    }

   

}
