using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg
{
    [TestClass]
    public class WeightedMedian
    {
        double GetweightedMedian(int[] locations, int[] persons)
        {
            int total_persons = persons.Sum();
            double raspuns = 0.0;
            for (int i = 0; i < locations.Length; i++)
                raspuns = raspuns + (locations[i] * persons[i]) * total_persons;
            return raspuns;
        }


    }
}
