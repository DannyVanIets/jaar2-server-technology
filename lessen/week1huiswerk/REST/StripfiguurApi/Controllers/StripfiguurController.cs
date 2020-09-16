using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StripfiguurApi.Model;
using Microsoft.Extensions.Logging;

namespace StripfiguurApi.Controllers
{
    [Route("api/Stripfiguur")]
    [ApiController]
    public class StripfiguurController : ControllerBase
    {
        private static List<Stripfiguur> lijst = new List<Stripfiguur>()
        {
            new Stripfiguur { Id = 1, Naam = "Ycho", Omschrijving = "Een erg grappig en leuk karakter dat totaal niet vreemd of eng is." },
            new Stripfiguur { Id = 2, Naam = "Donald Duck", Omschrijving = "Een eend." },
            new Stripfiguur { Id = 3, Naam = "Goofy", Omschrijving = "Een grappig." },
        };

        // GET: api/Stripfiguur
        [HttpGet]
        public ActionResult<IEnumerable<Stripfiguur>> Get()
        {
            return lijst;
        }

        //GET: api/Stripfiguur/5
        [HttpGet("{id}")]
        public ActionResult<Stripfiguur> Get(int id)
        {
            var result = lijst.Find(items => items.Id == id);
            if(result != null)
            {
                return result;
            }
            else
            {
                return new Stripfiguur { Id = 0, Naam = "Invalid ID!", Omschrijving = "Helaas, niet goed!"};
            }
        }

        // POST: api/Stripfiguur
        [HttpPost]
        public void Post([FromBody] Stripfiguur stripfiguur)
        {
            lijst.Add(stripfiguur);
        }

        // PUT: api/Stripfiguur/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Stripfiguur stripfiguur)
        {
            var obj = lijst.FirstOrDefault(x => x.Id == stripfiguur.Id);
            if(obj != null)
            {
                obj.Naam = stripfiguur.Naam;
                obj.Omschrijving = stripfiguur.Omschrijving;
            }
        }

        // DELETE: api/Stripfiguur/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var itemToRemove = lijst.FirstOrDefault(r => r.Id == id);
            if(itemToRemove != null)
            {
                lijst.Remove(itemToRemove);
            }
        }
    }
}
