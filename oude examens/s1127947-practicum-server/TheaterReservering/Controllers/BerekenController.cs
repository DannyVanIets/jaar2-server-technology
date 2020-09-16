using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheaterReservering.DAL;
using TheaterReservering.Models;

namespace TheaterReservering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BerekenController : ControllerBase
    {
        private readonly TheaterContext _context;

        public BerekenController(TheaterContext context) => _context = context;

        // GET: api/Get
        [HttpGet("{id}")]
        public int BerekenPrijs(int id)
        {
            KlantModel klant = _context.Klant.Include(k => k.Reservingen).FirstOrDefault(k => k.KlantId == id);
            var totalePrijs = 0;
            if (klant.Reservingen == null || klant.Reservingen.Count <= 0)
            {
                return 0;
            }
            else
            {
                foreach (var reservering in klant.Reservingen)
                {
                    if (reservering.Naam[0].ToString() == "E")
                    {
                        totalePrijs += 20;
                    }
                    else if (reservering.Naam[0].ToString() == "D")
                    {
                        totalePrijs += 25;
                    }
                    else if (reservering.Naam[0].ToString() == "C")
                    {
                        totalePrijs += 30;
                    }
                    else if (reservering.Naam[0].ToString() == "B")
                    {
                        totalePrijs += 35;
                    }
                    else if (reservering.Naam[0].ToString() == "A")
                    {
                        totalePrijs += 40;
                    }

                    if(reservering.Naam[1].ToString() == "3" || reservering.Naam[1].ToString() == "4")
                    {
                        totalePrijs += 5;
                    }
                }
            }
            return totalePrijs;
        }

        // POST: api/Api
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Api/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
