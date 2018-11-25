using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest.Alg.Recursion
{
    [TestClass]
    public class LitereDinCifre
    {

        Dictionary<int, string> cifre_litere = new Dictionary<int, string>() {
            { 0, "" }, { 1, "unu" }, { 2, "doi" }, { 3, "trei" }, { 4, "patru" },
            { 5, "cinci" }, { 6, "sase" }, { 7, "sapte" }, { 8, "opt" }, { 9, "noua" }
        };
               

        string CompuneNumar(string numar)
        {
            if (numar.Length == 1) //unitati
                return numar == "0" ? "" : cifre_litere[int.Parse(numar)];
            else if (numar.Length == 2) //zeci
                return CompuneNumar(numar.Substring(0, 1)) + "zeci " + ( numar.Substring(1, 1) == "0" ? "" : " si " + CompuneNumar(numar.Substring(1, 1)) );
            else if (numar.Length == 3) //sute
                return CompuneNumar(numar.Substring(0, 1)) + " sute " + ( numar.Substring(1, 2) == "00" ? "" : CompuneNumar(numar.Substring(1, 2)) );
            else if (numar.Length > 3 && numar.Length < 7) //mii
                return CompuneNumar(numar.Substring(0, numar.Length - 3)) + ( (numar.Length == 4) ? " mii " : " de mii ") + CompuneNumar(numar.Substring(numar.Length - 3));
            else if (numar.Length >= 7 && numar.Length < 10) //milioane
                return CompuneNumar(numar.Substring(0, numar.Length - 6)) + ( (numar.Length == 7) ? " milioane " : " de milioane ") + CompuneNumar(numar.Substring(numar.Length - 6));
            else // miliarde
                return CompuneNumar(numar.Substring(0, numar.Length - 9)) + ( (numar.Length == 10) ? " miliarde " : " de miliarde ") + CompuneNumar(numar.Substring(numar.Length - 9));
        }

        [TestMethod]
        public void LitereDinCifreTest()
        {
            string test = "75877695345";
            string test1 = CompuneNumar(test);


        }


    }
}
