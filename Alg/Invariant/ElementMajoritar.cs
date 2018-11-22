using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg.Invariant
{
    [TestClass]
    public class ElementMajoritar
    {
        private string sir;

        public ElementMajoritar() { }

        internal ElementMajoritar(string sir)
        {
            this.sir = sir;
        }

        char GetElementMajoritar()
        {
            Dictionary<char, int> caractere_numar = new Dictionary<char, int>();
            foreach (char c in this.sir)
            {
                if (caractere_numar.ContainsKey(c))
                    caractere_numar[c] = caractere_numar[c] + 1;
                else
                    caractere_numar.Add(c, 1);
            }
            int min = 0;
            char element_majoritar = 'a';
            foreach (var pair in caractere_numar)
            {
                if (min < pair.Value)
                {
                    min = pair.Value;
                    element_majoritar = pair.Key;
                }
            }
            return element_majoritar;
        }

        char GetElementMajoritatInvariant()
        {
            char candidate = '0';
            int candidate_count = 0;
            foreach (char c in this.sir)
            {
                if (candidate_count == 0)
                    candidate = c;
                else if (candidate == c)
                    ++candidate_count;
                else
                    --candidate_count;
            }
            return candidate;
        }

        [TestMethod]
        public void ElementMajoritarTest()
        {
            ElementMajoritar _elem = new ElementMajoritar("asdfnshdnrrnndsrrrrnnrerrrrrrr");
            Assert.AreEqual('r', _elem.GetElementMajoritar());
            Assert.AreNotEqual('t', _elem.GetElementMajoritar());

            Assert.AreEqual('r', _elem.GetElementMajoritatInvariant());

        }


    }
}
