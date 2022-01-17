using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LINQController : ControllerBase
    {
        public static List<Carti> carti = new List<Carti>();
        public static List<Gen> genuri = new List<Gen>();

        public static void Main()
        {

            ///////////////////////////////////////////////////////group by
            var GrupareGen = carti.GroupBy(x => x.Gen);
            GrupareGen.ToList().ForEach(x => Console.WriteLine($"Avem disponibile {x.Count()} carti in sectiunea {x.Key}."));



            /////////////////////////////////////////////////////////join
            var joined = carti.Join(genuri, c => c.Gen.IdGen, g => g.IdGen, (c, g) => new
            {
                c.IdCarte,
                c.Titlu,
                c.Autor,
                c.Gen.IdGen
            });
            joined.ToList().ForEach(x => Console.WriteLine($"Cartea cu titlul {x.Titlu} face partea din categoria de carti {x.IdGen}"));
        }

        
    }
}
