using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg
{
    class Interval
    {
        internal int start { get; set; }
        internal int end { get; set; }
        internal  Interval(int _s, int _e)
        {
            this.start = _s;
            this.end = _e;
        }
    }







    [TestClass]
    public class OverlappingSchedule
    {
        List<Interval> AccomodateIntervalBetter(List<Interval> intervals, Interval interval_nou)
        {
            List<Interval> raspuns = new List<Interval>();
            int i = 0;

            while (i < intervals.Count() && intervals[i].end < interval_nou.start)
            {
                raspuns.Add(intervals[i]);
                ++i;
            }

            while( i < intervals.Count && intervals[i].start <= interval_nou.end)
            {
                interval_nou = new Interval(Math.Min(intervals[i].start, interval_nou.start),
                                                       Math.Max(intervals[i].end, interval_nou.end) );                
                ++i;
            }
            raspuns.Add(interval_nou);
            //add the rest of the elements
            while (i < intervals.Count)
            {
                raspuns.Add(intervals[i]);
                ++i;
            }
            return raspuns;
        }

        List<Interval> AccomodateInterval(List<Interval> intervals, Interval interval_nou)
        {
            List<Interval> raspuns = new List<Interval>();
            int i = 0;
            while (i  < intervals.Count && intervals[i].end < interval_nou.start)
            {
                raspuns.Add(intervals[i++]);                
            }
            //adauga element
            //1. corner cases
            if (i == ( intervals.Count - 1 ) || i == 0)
            {
                raspuns.Add(interval_nou);
                return raspuns;
            }
            else //2. no corner cases
                raspuns.Add(new Interval(intervals[i++].start, interval_nou.end));
            
            //skip la ce e in interval
            while ((i < intervals.Count && interval_nou.end > intervals[i].end))
            {
                ++i;
            }
            if (i == (intervals.Count - 1) )
                return raspuns;
            raspuns[raspuns.Count - 1].end = intervals[i++].end;
            //get the rest of the elements, if exists
            while (i < intervals.Count)
            {
                raspuns.Add(intervals[i++]);                
            }
            return raspuns;
        }

        [TestMethod]
        public void OverlappingScheduleTest()
        {
            List<Interval> lista = new List<Interval>();
            lista.Add(new Interval(-4, -2));
            lista.Add(new Interval(0, 2));
            lista.Add(new Interval(4, 6));
            lista.Add(new Interval(7, 9));
            lista.Add(new Interval(11, 12));
            lista.Add(new Interval(14, 17));

            Interval element_cou = new Interval(1, 8);
            List<Interval> test = this.AccomodateInterval(lista, element_cou);
            Assert.AreEqual(test.Count, 4);

            Interval element_nou = new Interval(1, 8);
            List<Interval> test2 = this.AccomodateIntervalBetter(lista, element_nou);
            Assert.AreEqual(test.Count, 4);
            for (int i = 0; i < test.Count; i++)
            {
                Assert.AreEqual(test[i].start, test2[i].start);
                Assert.AreEqual(test[i].end, test2[i].end);
            }
        }


    }
}
