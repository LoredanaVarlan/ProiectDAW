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
    
    
        [HttpPost]
         public IEnumerable<Utilizator> AddFromBodyUtilizator([FromBody] Utilizator obUtil)
        {
            utilizatori.Add(obUtil);
            return utilizatori;
        }
    
    
    
    
    
    }





}
