using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW
{
    public class Autori
    {
        public int IdAutor { get; set; }
        public String Nume { get { return Nume; } set { Nume = value; } }
        public String Prenume { get { return Prenume; } set { Prenume = value; } }
        public String Sex { get { return Sex; } set { Sex = value; } }
        public virtual ICollection<Carti> CartiScrise { get; set; }

    }
}
