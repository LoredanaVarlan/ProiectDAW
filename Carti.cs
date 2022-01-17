using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Proiect_DAW
{
    public class Carti
    {
        public int IdCarte { get; set; }
        public String Titlu { get { return Titlu; } set { Titlu = value; } }
        public virtual Autori Autor{ get; set; } 
        public int An_publicare { get; set; }
        public int Nr_pagini { get; set; }
        public String Editura { get { return Editura; } set { Editura = value; } }
        public virtual Gen Gen { get; set; }

        public virtual Utilizator Cititor { get; set; }

        public virtual ICollection<Utilizator> Cititori { get; set; }

        
    }







   

}
