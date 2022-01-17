using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW
{
    public class Utilizator
    {
       
        public int Id { get; set; }
        public String Nume { get { return Nume; } set { Nume = value; } }
        public String Prenume { get { return Prenume; } set { Prenume = value; } }
        public int Varsta { get; set; }
        public String Email { get { return Email; } set { Email = value; } }
        public String Sex { get { return Sex; } set { Sex = value; } }


        }




}
