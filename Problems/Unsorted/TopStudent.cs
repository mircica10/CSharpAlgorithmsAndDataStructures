using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg
{

    class MinPriorityQueue
    {
        List<int> lista = new List<int>();

        public MinPriorityQueue()
        { }


        public double Average
        {
            get
            {
                return lista.Average();
            }
        }
                
        public int GetSize()
        {
            return lista.Count;
        }

        public int Dequeue()
        {
            if (GetSize() == 0)
                throw new Exception("Dequeue(): Empty Queue");
            int min = lista.Min();
            lista.Remove(min);
            return min;
        }
        public void Enqueue(int val)
        {
            lista.Add(val);
        }

        public int Peek()
        {
            return lista.Min();
        }

    }



    internal class ExamResult
    {
        internal int StudentId { get; private set; }
        internal int Grade { get; private set; }

        public ExamResult(int _studentID, int _grade)
        {
            this.StudentId = _studentID;
            this.Grade = _grade;
        }
    }



    [TestClass]
    public class TopStudent
    {
        int GetStudentTopGrades(List<ExamResult> lista, int k)
        {
            Dictionary<int, MinPriorityQueue> students_grades = new Dictionary<int, MinPriorityQueue>();

            //create dictionary
            foreach (ExamResult result in lista)
            {
                if (students_grades.ContainsKey(result.StudentId))
                {
                    if (students_grades[result.StudentId].GetSize() <= k)
                        students_grades[result.StudentId].Enqueue(result.Grade);
                    else
                    {
                        if (result.Grade > students_grades[result.StudentId].Peek())
                        {
                            students_grades[result.StudentId].Dequeue();
                            students_grades[result.StudentId].Enqueue(result.Grade);
                        }
                    }
                }
                else
                {
                    MinPriorityQueue queue = new MinPriorityQueue();
                    queue.Enqueue(result.Grade);
                    students_grades.Add(result.StudentId, queue);
                }
            }

            //find maximum average
            double average = 0;
            int id = 0;

            foreach (KeyValuePair<int, MinPriorityQueue> pair in students_grades)
            {
                if (pair.Value.GetSize() >= k && (pair.Value.Average > average) )
                {
                    id = pair.Key;
                    average = pair.Value.Average;
                }
            }
            return id;
        }

        [TestMethod]
        public void TopStudentTest()
        {
            List<ExamResult> lista = new List<ExamResult>();
            lista.Add(new ExamResult(1, 97));
            lista.Add(new ExamResult(1, 99));

            lista.Add(new ExamResult(2, 90));
            lista.Add(new ExamResult(2, 92));
            lista.Add(new ExamResult(2, 94));
            lista.Add(new ExamResult(2, 94));

            lista.Add(new ExamResult(3, 90));
            lista.Add(new ExamResult(3, 92));
            lista.Add(new ExamResult(3, 90));

            int test = this.GetStudentTopGrades(lista, 3);

            Assert.AreEqual(test, 2);

        }


    }
}
