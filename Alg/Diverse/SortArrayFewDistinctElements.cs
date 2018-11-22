using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg
{
    [TestClass]
    public class SortArrayFewDistinctElements
    {
       
        class Student
        {
            internal string prenume;
            internal string nume;
            //internal int age;

            internal Student(string _prenume, string _nume)
            {
                this.nume = _nume;
                this.prenume = _prenume;
                
            }
        }

                
        Student[] SortArray(Student[] sir_studenti)
        {
            //
            Dictionary<string, Tuple<int, int>> hash_prenume_indecsi = new Dictionary<string, Tuple<int, int>>();
            foreach (Student student in sir_studenti)
            {
                if (hash_prenume_indecsi.ContainsKey(student.prenume))
                {
                    hash_prenume_indecsi[student.prenume] = new Tuple<int, int>(hash_prenume_indecsi[student.prenume].Item1 + 1, hash_prenume_indecsi[student.prenume].Item2);
                }
                else
                {
                    hash_prenume_indecsi[student.prenume] = new Tuple<int, int>(1, 0);
                }
            }
            //stabileste offset
            int offset = 0;
            string[] chei = hash_prenume_indecsi.Keys.ToArray(); 
            foreach (string s in chei)
            {
                Tuple<int, int> tuple = new Tuple<int, int>(hash_prenume_indecsi[s].Item1, offset);
                hash_prenume_indecsi.Remove(s);
                hash_prenume_indecsi.Add(s, tuple);

                offset = hash_prenume_indecsi[s].Item1 + offset;
            }

            Student[] studenti = new Student[sir_studenti.Length];
            foreach (Student student in sir_studenti)
            {
                int index = hash_prenume_indecsi[student.prenume].Item1 + hash_prenume_indecsi[student.prenume].Item2 - 1;
                Tuple<int, int> tupla_noua = new Tuple<int, int>(hash_prenume_indecsi[student.prenume].Item1 - 1, hash_prenume_indecsi[student.prenume].Item2);
                hash_prenume_indecsi.Remove(student.prenume);
                hash_prenume_indecsi.Add(student.prenume, tupla_noua);

                studenti[index] = student;
            }
            //
            return studenti;
        }

        void SortArrayInPlace(Student[] sir_studenti)
        {
            //
            Dictionary<string, int> prenume_count = new Dictionary<string, int>();
            foreach (Student student in sir_studenti)
            {
                if (prenume_count.ContainsKey(student.prenume))
                {
                    prenume_count[student.prenume] = prenume_count[student.prenume] + 1; 
                }
                else
                {
                    prenume_count.Add(student.prenume, 1);
                }
            }
            //stabileste offset
            int offset = 0;
            Dictionary<string, int> prenume_offset = new Dictionary<string, int>();
            foreach (string s in prenume_count.Keys)
            {
                prenume_offset.Add(s, offset);
                offset = prenume_count[s] + offset;
            }
                       
            while (prenume_offset.Count > 0)
            {
                KeyValuePair<string, int> from = prenume_offset.ElementAt(0);
                string toPrenume = sir_studenti[from.Value].prenume;
                int toValue = prenume_offset[toPrenume];
                Interchange(sir_studenti, from.Value, toValue);

                int count = prenume_count[toPrenume] - 1;
                prenume_count.Remove(toPrenume);
                prenume_count.Add(toPrenume, count);
                if(count > 0)
                {
                    prenume_offset[toPrenume] = toValue + 1;
                }
                else
                {
                    prenume_offset.Remove(toPrenume);
                }
            }
            
        }

        void Interchange(Student[] sir, int i, int j)
        {
            Student temp = sir[i];
            sir[i] = sir[j];
            sir[j] = temp;
        }


        void SortArrayBetter(Student[] sir_studenti)
        {
            List<Student> lista = sir_studenti.ToList();
            lista.Sort(Comparer<Student>.Create((x, y) => x.prenume.Equals(y.prenume) ? 0 : 1));
            lista.Sort();
        }

        [TestMethod]
        public void SortFewDistinct()
        {
            List<Student> lista = new List<Student>();
            lista.Add(new Student("Gigi", "Becali"));
            lista.Add(new Student("Fred", "Astaire"));
            lista.Add(new Student("Mike", "Powels"));
            lista.Add(new Student("Gigi", "Sulla"));
            lista.Add(new Student("Mike", "Douglass"));
            lista.Add(new Student("Fred", "Dirk"));

            Student[] sir = lista.ToArray();

            SortArrayInPlace(sir);          

        }

    }

    

}
