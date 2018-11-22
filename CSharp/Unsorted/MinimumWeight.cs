using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    class MinimimWeight
    {
                
        public int SchimbaBiti(int cuvant, int i, int j)
        {
            if (((cuvant >> i) & 1) == ((cuvant >> j) & 1))
                return cuvant;
            int mascaDeBiti = (1 << i) | (1 << j);
            return cuvant = cuvant ^ mascaDeBiti;

        }

        public int GreutateMinimaCalculeaza(int cuvant)
        {
            if (cuvant == 0 || cuvant == int.MaxValue)
                return cuvant;


            int firstbit = cuvant & 1;
            int i = 1;

            while (true)
            {
                if (firstbit != ((cuvant >> i) & 1))
                {
                    break;
                }
                else
                {
                    i++;
                }
            }

            return SchimbaBiti(cuvant, i - 1, i);
        }

        



    }
}
