using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg.Paralel
{

    public class ProducerConsumer
    {

        //un thread are produce, unul care consuma
        Queue<int> coada = new Queue<int>();

        private readonly object _lock = new object();

        internal void Produce(int i)
        {
            lock (_lock)
            {
                coada.Enqueue(i);
                Monitor.Pulse(_lock);
            }
        }


        internal int Consume()
        {
            lock (_lock)
            {
                while (coada.Count == 0)
                {
                    Monitor.Wait(_lock);
                }
                return coada.Dequeue();               
            }

        }


    } 

    [TestClass]
    public class ProducerConsumerHelper
    {
        static string result = "";

        static readonly object obj2 = new object();

        static ProducerConsumer pc = new ProducerConsumer();

        static void ConsumerJob()
        {
            for (int i = 1; i <= 5; i++)
            {
                int j = pc.Consume();
                lock (obj2) result = result + "C" + j;
                Thread.Sleep(100);
                
            }
        }

        static void ProducerJob()
        {
            for (int i = 1; i <= 5; i++)
            {
                    pc.Produce(i);
                    lock (obj2) result = result + "P" + i;
                    Thread.Sleep(100);
                
            }

        }


        static void Testeaza()
        {
            
            Thread thread_consuma = new Thread(ConsumerJob);
            thread_consuma.Start();

            Thread thread_produce = new Thread(ProducerJob);
            thread_produce.Start();


            thread_produce.Join();

            thread_consuma.Join();
           
            

        }

        [TestMethod]
        public void ProducerConsumerTest()
        {
            Testeaza();

        }


    }
}
