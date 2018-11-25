using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ConsoleAppTest.Alg.Paralel
{


    [TestClass]
    public class PrintAlternativ
    {

        static int counter = 0; 

        static string raspuns = "";
        static bool ODD_TURN = true;
        static bool EVEN_TURN = false;

        bool turn_ = false;
        private object mx_ = new object();

        public PrintAlternativ() { }


        void WaitTurn(bool old_turn)
        {
            lock (mx_)
            {
                while (turn_ != old_turn)
                    Monitor.Wait(mx_);
            }
        }

        void ToggleTurn()
        {
            lock (mx_)
            {
                turn_ = !turn_;
                Monitor.PulseAll(mx_);
            }
        }

        void PrintOdd()
        {
            for (int i = 2; i < 10; i = i + 2)
            {
                WaitTurn(ODD_TURN);
                raspuns += i;//Console.Write(i);
                ToggleTurn();
            }
        }

        void PrintEven()
        {
            for (int i = 1; i < 10; i = i + 2)
            {
                WaitTurn(EVEN_TURN);
                raspuns += i; //Console.Write(i);
                ToggleTurn();
            }
        }

        static void RezolvaComplicat()
        {

            PrintAlternativ p = new PrintAlternativ();

            Thread threadEven = new Thread(p.PrintEven);
            Thread threadOdd = new Thread(p.PrintOdd);

            threadEven.Start();
            threadOdd.Start();
            threadEven.Join();
            threadOdd.Join();
            
        }

        //pare rezolvae falsa, totul e facut doar de un thread
        void Incrementeaza()
        {
            for (int i = 1; PrintAlternativ.counter < 9; ++i)
            {
                //raspuns = raspuns + Thread.CurrentThread.Name.ToString();
                PrintAlternativ.counter++;
                raspuns = raspuns + PrintAlternativ.counter;
            }
        }

        static void RezolvaSimplu()
        {
            PrintAlternativ p = new PrintAlternativ();
            Thread threadEven = new Thread(p.Incrementeaza);
            Thread threadOdd = new Thread(p.Incrementeaza);
            threadEven.Name = "Even";
            threadOdd.Name = "Odd";

            threadEven.Start();
            threadOdd.Start();
            threadEven.Join();
            threadOdd.Join();

        }


        [TestMethod]
        public void PrintatAlternativ()
        {
            PrintAlternativ.RezolvaComplicat();
            Assert.AreEqual(PrintAlternativ.raspuns, "123456789");

            //PrintAlternativ.RezolvaSimplu();
            //Assert.AreEqual(PrintAlternativ.raspuns, "123456789");
        }

    }


    [TestClass]
    public class PrintAlternativEvents
    {
        public PrintAlternativEvents() { }

        static string raspuns = "";
        AutoResetEvent event_ = new AutoResetEvent(false);
        bool Odd = true;
        bool Even = false;

        bool turn = true;
               
        
        void PrintOdd()
        {
            for (int i = 1; i < 10; i = i + 2)
            {
                WaitTurn(this.Odd);
                raspuns += i;//Console.Write(i);    
                Toggle();              
            }
        }
        
        void PrintEven()
        {
            for (int i = 2; i < 10; i = i + 2)
            {
                WaitTurn(this.Even);
                raspuns += i; //Console.Write(i);
                Toggle();
            }
          
        }

        void WaitTurn(bool current_turn)
        {
                while (current_turn != turn)
                    event_.WaitOne(500);            
        }

        void Toggle()
        {
                turn = !turn;
                event_.Set();
                //event_.Reset();            
        }

        static void RezolvaComplicat()
        {
            PrintAlternativEvents pav = new PrintAlternativEvents();

            Thread threadEven = new Thread(pav.PrintEven);
            Thread threadOdd = new Thread(pav.PrintOdd);

            threadEven.Name = "EvenThread";
            threadOdd.Name = "OddThread";
                       
            threadOdd.Start();
            threadEven.Start();

            threadEven.Join();
            threadOdd.Join();
            
           
        }
        


        [TestMethod]
        public void PrintAlternativEventsTest()
        {
            PrintAlternativEvents.RezolvaComplicat();
            Assert.AreEqual(PrintAlternativEvents.raspuns, "123456789");
            
        }


    }



}
