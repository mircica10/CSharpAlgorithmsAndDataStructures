using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest
{
    public class BitOperations
    {

        public int[] arrayInvers = new int[65536];

        public OperatiiCuBiti()
        {
            //populate array
            
            /*for (int i = 0; i < arrayInvers.Length; i++)
            {
                arrayInvers[i] = CalculeazaInvers(i);
            }*/            
        }




        public int CalculeazaInversLookup(int calc)
        {
            int bitMask = 0xFFFF;
            int bitMaskSize = 16;


            return arrayInvers[(calc >> (3 * bitMaskSize)) & bitMask] |
                   arrayInvers[(calc >> (2 * bitMaskSize)) & bitMask] |
                   arrayInvers[(calc >> bitMaskSize) & bitMask] |
                   arrayInvers[calc & bitMask];

        }

        public int CalculeazaInvers(int temp)
        {
            int bitMask = 0xFFFF;
            for (int i = 0; i < bitMask / 2; i++)
            {
                temp = InverseazaBiti(temp, i, bitMask/2 + i);
            }
            return temp;
        }


      


        public int InverseazaBiti(int test, int i, int j)
        {
            if ( (  (test >> i) & 1 ) == ( (test >> j) & 1 ) )
            {
                return test;
            }
            int mask = 1 << i | 1 << j;
            return test ^ mask;
        }





    }

    

    [TestClass]
    public class OperatiiCuBitiTest
    {
        [TestMethod]
        public void TestOperatiiCuBit()
        {
            //Arrage
            OperatiiCuBiti ob = new OperatiiCuBiti();
            int inverseazaBitiInput = 50;
            int inverseazaBitiOutput = 52;
            int inversInput = 3;
            int inversOutput = int.MaxValue - inversInput;
            //Act
            int inverseazaBitiTest = ob.InverseazaBiti(inverseazaBitiInput, 1, 2);
            int inversTest = ob.CalculeazaInvers(inversInput);
            //int inversTestLokkup = ob.CalculeazaInversLookup(inversInput);


            //Assert
            Assert.AreEqual(inverseazaBitiTest, inverseazaBitiOutput);
            //Assert.AreEqual(inversTestLokkup, inversTest);
        }
    }

}
