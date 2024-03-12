using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3Test3A
{
    public class Pytanie
    {
        public string Tresc {get;set;}
        public bool Odpowiedz { get;set;}
         //public bool UdzielonaOdpowiedz { get;set;}
        public Pytanie(string tresc, bool odpowiedz)
        {
            Tresc = tresc;
            Odpowiedz = odpowiedz;
        }
       

    }
}
