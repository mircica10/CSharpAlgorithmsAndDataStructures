using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest
{
    public class OverlappingRectangle
    {


        public struct Punct
        {
            public decimal x;
            public decimal y;
            public Punct(decimal _x, decimal _y)
            {
                this.x = _x;
                this.y = _y;
            }
        }


        public struct Line
        {
            public decimal a;
            public decimal b;
            public Punct p1;
            public Punct p2;

            public Line(Punct p1, Punct p2)
            {
                //corner case
                if (p1.y == p2.y && p1.x == p2.x)
                {
                    throw new Exception();
                }
                a = (p1.y - p2.y) / (p1.x - p2.x);
                b = p1.y - a * p1.x;
                this.p1 = p1;
                this.p2 = p2;
            }
        }

        public Punct PunctDeIntersectie(Line l1, Line l2)
        {
            decimal x = (l2.b - l1.b) / (l1.a - l2.a);
            decimal y = l1.a * x + l1.b;
            return new Punct(x, y);
        }


        public bool SegmenteleSeIntersecteaza(Line l1, Line l2)
        {
            Punct punctDeIntersectie = PunctDeIntersectie(l1, l2);
            bool eIntreXl1 = punctDeIntersectie.x > Math.Min(l1.p1.x, l1.p2.x) && punctDeIntersectie.x < Math.Max(l1.p1.x, l1.p2.x);
            bool eIntreXl2 = punctDeIntersectie.y > Math.Min(l2.p1.x, l2.p2.x) && punctDeIntersectie.x < Math.Max(l2.p1.x, l2.p2.x);
            return eIntreXl1 && eIntreXl2;
        }


        public struct Rectangle
        {
            public int x;
            public int y;
            public int length;
            public int height;

            public Rectangle(int _x, int _y, int _length, int _height)
            {
                this.x = _x;
                this.y = _y;
                this.length = _length;
                this.height = _height;
            }

        }
            public static bool AreOverlappingRectangles(Rectangle r1, Rectangle r2)
            {
                return ((r1.x + r1.length) >= r2.x) && ((r2.x + r2.length) >= r1.x) && ((r2.y + r2.height) >= r1.y) && ((r2.y + r2.height) >= r1.y);
            }

            public static Rectangle OverlappingRectangleNew(Rectangle r1, Rectangle r2)
            {
                if (!AreOverlappingRectangles(r1, r2))
                {
                    return new Rectangle(0, 0, -1, -1);
                }

                int x = Math.Max(r1.x, r2.x);
                int y = Math.Max(r1.y, r2.y);
                int length = Math.Min(r1.x + r1.length, r2.x + r2.length) - Math.Max(r1.x, r2.x);
                int height = Math.Min(r1.y + r1.height, r2.y + r2.height) - Math.Max(r1.y, r2.y); 

                return new Rectangle(x, y, length, height);
            }



        }

        [TestClass]
    public class OverlappingRectangleTest
    {
        
            [TestMethod]
        public void TestRectangle()
        {
            //Arrange
            OverlappingRectangle.Rectangle r1 = new OverlappingRectangle.Rectangle(2, 3, 5, 6);
            OverlappingRectangle.Rectangle r2 = new OverlappingRectangle.Rectangle(4, 5, 3, 4);
            OverlappingRectangle.Rectangle r3 = new OverlappingRectangle.Rectangle(14, 16, 4, 6);

            OverlappingRectangle.Rectangle r4 = new OverlappingRectangle.Rectangle(1, 1, 5, 3);
            OverlappingRectangle.Rectangle r5 = new OverlappingRectangle.Rectangle(4, 2, 5, 5);
            OverlappingRectangle.Rectangle r6 = new OverlappingRectangle.Rectangle(4, 2, 2, 2);

            //
            OverlappingRectangle o1 = new OverlappingRectangle();
            OverlappingRectangle.Punct punct1 = new OverlappingRectangle.Punct(2, 2);
            OverlappingRectangle.Punct punct2= new OverlappingRectangle.Punct(8, 6);
            OverlappingRectangle.Punct punct3 = new OverlappingRectangle.Punct(10, 9);
            OverlappingRectangle.Punct punct4 = new OverlappingRectangle.Punct(1, 10);

            OverlappingRectangle.Line l1 = new OverlappingRectangle.Line(punct1, punct2);
            OverlappingRectangle.Line l2 = new OverlappingRectangle.Line(punct3, punct4);
                    

            

            //Act
            bool areOverlapping = OverlappingRectangle.AreOverlappingRectangles(r1, r2);
            bool areNotOverlapping = OverlappingRectangle.AreOverlappingRectangles(r1, r3);
            OverlappingRectangle.Rectangle rectangleOverlap = OverlappingRectangle.OverlappingRectangleNew(r4, r5);
            bool seIntersecteaza = o1.SegmenteleSeIntersecteaza(l1, l2);
            //Assert
            Assert.IsTrue(areOverlapping);
            Assert.IsFalse(areNotOverlapping);
            Assert.AreEqual(rectangleOverlap, r6);
            Assert.IsFalse(seIntersecteaza);
        }


    }


    
}
