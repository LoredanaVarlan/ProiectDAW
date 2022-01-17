using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW
{
    public class Carti
    {
        public int IdCarte { get; set; }
        public String Titlu { get { return Titlu; } set { Titlu = value; } }
        public String Autor { get { return Autor; } set { Autor = value; } }
        public int An_publicare { get; set; }
        public int Nr_pagini { get; set; }
        public String Editura { get { return Editura; } set { Editura = value; } }
    }
}
