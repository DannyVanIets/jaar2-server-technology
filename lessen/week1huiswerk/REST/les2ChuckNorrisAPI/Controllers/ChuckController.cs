using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using les2ChuckNorrisAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace les2ChuckNorrisAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChuckController : ControllerBase
    {
        private static List<ChuckFacts> facts = new List<ChuckFacts>()
        {
            new ChuckFacts{ Id=1, Rating=4, Text="Chuck Norris doesn't call the wrong number." },
            new ChuckFacts{ Id=2, Rating=3, Text="Chuck Norris counted to infinity twice." },
            new ChuckFacts{ Id=3, Rating=5, Text="Chuck Norris threw a grenade and killed 50 people, then it exploded." }
        };

        // GET: api/Chuck
        [HttpGet]
        public ActionResult<IEnumerable<ChuckFacts>> Get()
        {
            return facts;
        }

        // GET: api/Chuck/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<ChuckFacts> Get(int id)
        {
            var result = facts.FirstOrDefault(item => item.Id == id);
            if (result != null)
            {
                return result;
            }
            return new ChuckFacts { Id = 0, Rating = 0, Text = "Invalid ID was given." };
        }

        // POST: api/Chuck
        [HttpPost]
        public void Post([FromBody] ChuckFacts chuckfact)
        {
            facts.Add(chuckfact);
        }

        // PUT: api/Chuck/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ChuckFacts chuckfact)
        {
            var result = facts.FirstOrDefault(chuckfact => chuckfact.Id == id);
            if (result != null)
            {
                result.Rating = chuckfact.Rating;
                result.Text = chuckfact.Text;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var itemToRemove = facts.FirstOrDefault(chuckfact => chuckfact.Id == id);
            if (itemToRemove != null)
            {
                facts.Remove(itemToRemove);
            }
        }
    }
}
