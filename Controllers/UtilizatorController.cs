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
    public class UtilizatorController : ControllerBase
    {

        public static List<Utilizator> utilizatori = new List<Utilizator>();

        [HttpGet]
        public IEnumerable<Utilizator> GetUtilizator()
        {
            return utilizatori;
        }

        [HttpGet("{id}")]
        public IEnumerable<Utilizator> GetWithIdUtilizator(int id)
        {
            return utilizatori.Where(s => s.Id == id);
        }


        [HttpPost("FromBody")]
        public IEnumerable<Utilizator> AddFromBodyUtilizator([FromBody] Utilizator obUtil)
        {
            utilizatori.Add(obUtil);
            return utilizatori;
        }

        [HttpPut]

        public async Task<IActionResult> UpdateUtil([FromBody] Utilizator obUtil)
        {
            var UtilIndex = utilizatori.FindIndex((Utilizator _utilizator) => _utilizator.Id.Equals(obUtil.Id));
            utilizatori[UtilIndex] = obUtil;

            return Ok(utilizatori);
        }


        /*
        [HttpPatch("{id}")]
        public IActionResult Patch ([FromRoute] int id, [FromBody] JsonPatchDocument<Utilizator> obUtil)
        {
            if(obUtil != null)
            {
                var utilToUpdate = utilizatori.FirstOrDefault(_util => _util.Id.Equals(id));
                obUtil.ApplyTo(utilToUpdate, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                return Ok(utilizatori);
            }
            else
            {
                return BadRequest();
            }

        }

        */

        [HttpDelete]

        public IActionResult DeleteUtil(Utilizator obUtil)
        {
            utilizatori.Remove(obUtil);
            return Ok(utilizatori);
        }
    }
}
