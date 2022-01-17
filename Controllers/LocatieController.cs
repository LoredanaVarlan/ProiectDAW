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
    public class LocatieController : ControllerBase
    {

        public static List<Locatie> locatie = new List<Locatie>();

        [HttpGet]


        public IEnumerable<Locatie> GetLocatie()
        {
            return locatie;
        }

        [HttpGet("{id}")]


        public IEnumerable<Locatie> GetWithIdLocatie(int id)
        {
            return locatie.Where(s => s.IdLoc == id);
        }

        [HttpPost("FromBody")]

        public IEnumerable<Locatie> AddFromBodyLocatie([FromBody] Locatie obLocatie)
        {
            locatie.Add(obLocatie);
            return locatie;
        }


        [HttpPut]
        public async Task<IActionResult> UpdateLocatie([FromBody] Locatie obLoc)
        {
            var LocIndex = locatie.FindIndex((Locatie _locatie) => _locatie.IdLoc.Equals(obLoc.IdLoc));
            locatie[LocIndex] = obLoc;

            return Ok(locatie);
        }

        [HttpDelete]

        public IActionResult DeleteLoactie(Locatie obLoc)
        {
            locatie.Remove(obLoc);
            return Ok(locatie);
        }



    }
}
