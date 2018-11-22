using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg.Grafuri
{

    [TestClass]
    public class Labirint
    {
        struct Bloc
        {
            internal bool _e_intrare;
            internal bool _e_iesire;
            internal bool _e_alb;

            internal Bloc(bool e_alb, bool e_intrare, bool e_iesire)
            {
                this._e_alb = e_alb;
                this._e_intrare = e_intrare;
                this._e_iesire = e_iesire;
            }
        }

        struct mutare_posibile
        {
            internal int x;
            internal int y;
            internal mutare_posibile(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        mutare_posibile[] mutari_posibile = new mutare_posibile[] {new mutare_posibile(1,0),
                                                                   new mutare_posibile(-1,0),
                                                                   new mutare_posibile(0,1),
                                                                   new mutare_posibile(0,-1)
                                                                    }; 

        Bloc[,] matrice_labirint = null;
        
        public Labirint() { }
        Labirint(Bloc[,] _labirint)
        {
            this.matrice_labirint = _labirint;
        }

        bool ExistaCaleHelper()
        {
            List<Tuple<int, int>> calea = new List<Tuple<int, int>>();
            List<Tuple<int, int>> vizitate = new List<Tuple<int, int>>();

            return ExistaCale(0, 0, this.matrice_labirint, calea, vizitate);
        }

        bool ExistaCale(int i, int j, Bloc[,] labirint, List<Tuple<int, int>> calea, List<Tuple<int, int>> vizitate)
        {
            if (i < 0 || i >= labirint.GetLength(0) || j < 0 || j >= labirint.GetLength(0))//index overflow
                return false;
            if (calea.Contains(new Tuple<int, int>(i, j))) //deja vizitata
                return false;
            if (!labirint[i, j]._e_alb)//e blocata
                return false;
            if (labirint[i, j]._e_iesire)//am ajuns la final
            {
                calea.Add(new Tuple<int, int>(i, j));
                return true;
            }
            calea.Add(new Tuple<int, int>(i, j));
            vizitate.Add(new Tuple<int, int>(i, j));
            foreach (var mutare in mutari_posibile)
            {
                if (ExistaCale(i + mutare.x, j + mutare.y, labirint, calea, vizitate))
                {
                    return true;
                }                
            }
            calea.Remove(new Tuple<int, int>(i, j));
            //calea.RemoveAt(calea.Count - 1);
            return false;
        }

        [TestMethod]
        public void LabirintTest()
        {
            Bloc[,] labirint_adevarat = new Bloc[,] {
                                            { new Bloc(true, true, false), new Bloc(true, false, false), new Bloc(true, false, false), new Bloc(true, false, false), new Bloc(true, false, true) },
                                            { new Bloc(true, false, false), new Bloc(false, false, false), new Bloc(true, false, false), new Bloc(false, false, false), new Bloc(true, false, false)},
                                            { new Bloc(false, false, false), new Bloc(true, false, false), new Bloc(true, false, false), new Bloc(true, false, false), new Bloc(true, false, false)},
                                            { new Bloc(false, false, false), new Bloc(true, false, false), new Bloc(false, false, false), new Bloc(true, false, false), new Bloc(true, false, false)},
                                            { new Bloc(false, false, false), new Bloc(true, false, false), new Bloc(true, false, false), new Bloc(true, false, false), new Bloc(false, false, false) }
                                            };
            Bloc[,] labirint_fals = new Bloc[,] {
                                            { new Bloc(true, true, false), new Bloc(true, false, false), new Bloc(true, false, false), new Bloc(true, false, false), new Bloc(true, false, true) },
                                            { new Bloc(true, false, false), new Bloc(false, false, false), new Bloc(true, false, false), new Bloc(false, false, false), new Bloc(false, false, false)},
                                            { new Bloc(false, false, false), new Bloc(true, false, false), new Bloc(true, false, false), new Bloc(true, false, false), new Bloc(true, false, false)},
                                            { new Bloc(false, false, false), new Bloc(true, false, false), new Bloc(false, false, false), new Bloc(true, false, false), new Bloc(true, false, false)},
                                            { new Bloc(false, false, false), new Bloc(true, false, false), new Bloc(true, false, false), new Bloc(true, false, false), new Bloc(false, false, false) }
                                            };
            Labirint lab = new Labirint(labirint_adevarat);
            Assert.IsTrue(lab.ExistaCaleHelper());

            Labirint lab_fals = new Labirint(labirint_fals);
            Assert.IsTrue(lab_fals.ExistaCaleHelper());
        }


    }
}
