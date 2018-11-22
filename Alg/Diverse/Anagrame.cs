using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest
{
    [TestClass]
    public class Anagrame
    {


        bool SuntAnagrameFaraHash(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            int[] lookupTable = new int[256];
            int numarElementeUnice = 0;
            //construim tabelul 
            foreach (char c in s1)
            {
                int element = c - 'a';
                if (lookupTable[element] == 0)
                {
                    lookupTable[element] = 1;
                    numarElementeUnice++;
                }
                else
                {
                    lookupTable[element] = lookupTable[element] + 1;
                }
            }

            //testam
            int numarElementeUniceRamase = numarElementeUnice;
            foreach (char c in s2)
            {
                int element = c - 'a';
                
                if (lookupTable[element] == 0)
                {
                    return false;
                }
                else
                {
                    lookupTable[element] = lookupTable[element] - 1;

                    if (lookupTable[element] == 0)
                    {
                        numarElementeUniceRamase = numarElementeUniceRamase - 1;
                        if (numarElementeUniceRamase == 0)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;

        }


        bool SuntAnagrame(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            Dictionary<char, int> lookupTable = new Dictionary<char, int>();
            
            //construim tabelul 
            foreach (char c in s1)
            {
                if (lookupTable.ContainsKey(c))
                {
                    lookupTable[c] = lookupTable[c] + 1;
                }
                else
                {
                    lookupTable.Add(c, 1);                    
                }
            }

            foreach (char c in s2)
            {
                if (!lookupTable.ContainsKey(c))
                {
                    return false;
                }
                else
                {
                    lookupTable[c] = lookupTable[c] - 1;
                    if (lookupTable[c] < 0)
                    {
                        return false;
                    }
                }
            }

            return true;

        }

        [TestMethod]
        public void TestAnagrame()
        {
            //Arrange
            string s1 = "asdfggh";
            string s1_anagrama = "agshdfg";
            string s1_neanagrama = "agshdfa";
            //Act
            bool eAnagrama = this.SuntAnagrameFaraHash(s1, s1_anagrama);
            bool nueAnagrama = this.SuntAnagrameFaraHash(s1, s1_neanagrama);
            //Assert
            Assert.IsTrue(eAnagrama);
            Assert.IsFalse(nueAnagrama);
        }

    }
}
