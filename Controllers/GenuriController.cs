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
    public class GenuriController : ControllerBase
    {
           
        public static List<Gen> genuri = new List<Gen>();
   

        [HttpGet]
        public IEnumerable<Gen> GetGen()
        {
            return genuri;
        }

       
        [HttpGet("{id}")]
        public IEnumerable<Gen> GetWithIdGen(int id)
        {
            return genuri.Where(s => s.IdGen == id);
        } 
       

        [HttpPost("FromBody")]
        public IEnumerable<Gen> AddFromBodyGen([FromBody] Gen obGen)
        {
            genuri.Add(obGen);
            return genuri;
        }
 

        [HttpPut]
        public async Task<IActionResult> UpdateGen([FromBody] Gen obGen)
        {
            var GenIndex = genuri.FindIndex((Gen _gen) => _gen.IdGen.Equals(obGen.IdGen));
            genuri[GenIndex] = obGen;

            return Ok(genuri);
        }


        [HttpDelete]
        public IActionResult DeleteGen(Gen obGen)
        {
            genuri.Remove(obGen);
            return Ok(genuri);
        }


    }

}
