﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static List<Utilizator> utilizatori = new List<Utilizator>();
        public static List<Locatie> locatie = new List<Locatie>();
        public static List<Carti> carti = new List<Carti>();
        public static List<Autori> autori = new List<Autori>();
        public static List<Gen> genuri = new List<Gen>();

        [HttpGet]
        public IEnumerable<Utilizator> GetUtilizator()
        {
            return utilizatori;
        }

        public IEnumerable<Locatie> GetLocatie()
        {
            return locatie;
        }

        public IEnumerable<Carti> GetCarte()
        {
            return carti;
        }

        public IEnumerable<Autori> GetAutor()
        {
            return autori;
        }

        public IEnumerable<Gen> GetGen()
        {
            return genuri;
        }

        [HttpGet("{id}")]
        public IEnumerable<Utilizator> GetWithIdUtilizator(int id)
        {
            return utilizatori.Where(s => s.Id == id);
        }

        public IEnumerable<Locatie> GetWithIdLocatie(int id)
        {
            return locatie.Where(s => s.IdLoc == id);
        }

        public IEnumerable<Carti> GetWithIdCarte(int id)
        {
            return carti.Where(s => s.IdCarte == id);
        }

        public IEnumerable<Autori> GetWithIdAutor(int id)
        {
            return autori.Where(s => s.IdAutor == id);
        }

        public IEnumerable<Gen> GetWithIdGen(int id)
        {
            return genuri.Where(s => s.IdGen == id);
        }


        [HttpPost("FromBody")]
        public IEnumerable<Utilizator> AddFromBodyUtilizator([FromBody] Utilizator obUtil)
        {
            utilizatori.Add(obUtil);
            return utilizatori;
        }

        public IEnumerable<Locatie> AddFromBodyLocatie([FromBody] Locatie obLocatie)
        {
            locatie.Add(obLocatie);
            return locatie;
        }

        public IEnumerable<Carti> AddFromBodyCarti([FromBody] Carti obCarte)
        {
            carti.Add(obCarte);
            return carti;
        }

        public IEnumerable<Autori> AddFromBodyAutori([FromBody] Autori obAutor)
        {
            autori.Add(obAutor);
            return autori;
        }

        public IEnumerable<Gen> AddFromBodyGen([FromBody] Gen obGen)
        {
            genuri.Add(obGen);
            return genuri;
        }

        [HttpPut]

        public async Task<IActionResult> UpdateUtil([FromBody] Utilizator obUtil)
        {
            var UtilIndex = utilizatori.FindIndex((Utilizator _utilizator) => _utilizator.Id.Equals(obUtil.Id));
            utilizatori[UtilIndex] = obUtil;

            return Ok(utilizatori);
        }

        public async Task<IActionResult> UpdateLocatie([FromBody] Locatie obLoc)
        {
            var LocIndex = locatie.FindIndex((Locatie _locatie) => _locatie.IdLoc.Equals(obLoc.IdLoc));
            locatie[LocIndex] = obLoc;

            return Ok(locatie);
        }

        public async Task<IActionResult> UpdateCarti([FromBody] Carti obCarte)
        {
            var CarteIndex = carti.FindIndex((Carti _carte) => _carte.IdCarte.Equals(obCarte.IdCarte));
            carti[CarteIndex] = obCarte;

            return Ok(carti);
        }

        public async Task<IActionResult> UpdateAutori([FromBody] Autori obAu)
        {
            var AutorIndex = autori.FindIndex((Autori _autor) => _autor.IdAutor.Equals(obAu.IdAutor));
            autori[AutorIndex] = obAu;

            return Ok(autori);
        }

        public async Task<IActionResult> UpdateGen([FromBody] Gen obGen)
        {
            var GenIndex = genuri.FindIndex((Gen _gen) => _gen.IdGen.Equals(obGen.IdGen));
            genuri[GenIndex] = obGen;

            return Ok(genuri);
        }







    }

}
