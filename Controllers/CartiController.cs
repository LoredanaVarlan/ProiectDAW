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
    public class CartiController : ControllerBase
    {

        public static List<Carti> carti = new List<Carti>();

        [HttpGet]
        public IEnumerable<Carti> GetCarte()
        {
            return carti;
        }

        [HttpGet("{id}")]
        public IEnumerable<Carti> GetWithIdCarte(int id)
        {
            return carti.Where(s => s.IdCarte == id);
        }

        [HttpPost("FromBody")]
        public IEnumerable<Carti> AddFromBodyCarti([FromBody] Carti obCarte)
        {
            carti.Add(obCarte);
            return carti;
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCarti([FromBody] Carti obCarte)
        {
            var CarteIndex = carti.FindIndex((Carti _carte) => _carte.IdCarte.Equals(obCarte.IdCarte));
            carti[CarteIndex] = obCarte;

            return Ok(carti);
        }


        [HttpDelete]
        public IActionResult DeleteCarti(Carti obCarte)
        {
            carti.Remove(obCarte);
            return Ok(carti);
        }



    }
}
