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
    public class AutoriController : ControllerBase
    {

        public static List<Autori> autori = new List<Autori>();

        [HttpGet]
        public IEnumerable<Autori> GetAutor()
        {
            return autori;
        }

        [HttpGet("{id}")]
        public IEnumerable<Autori> GetWithIdAutor(int id)
        {
            return autori.Where(s => s.IdAutor == id);
        }


        [HttpPost("FromBody")]
        public IEnumerable<Autori> AddFromBodyAutori([FromBody] Autori obAutor)
        {
            autori.Add(obAutor);
            return autori;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAutori([FromBody] Autori obAu)
        {
            var AutorIndex = autori.FindIndex((Autori _autor) => _autor.IdAutor.Equals(obAu.IdAutor));
            autori[AutorIndex] = obAu;

            return Ok(autori);
        }

        [HttpDelete]
        public IActionResult DeleteAutori(Autori obAu)
        {
            autori.Remove(obAu);
            return Ok(autori);
        }


    }
}
