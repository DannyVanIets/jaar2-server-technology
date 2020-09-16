using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheaterReservering.DAL;
using TheaterReservering.Models;

namespace APIcontroller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetController : ControllerBase
    {
        private readonly TheaterContext _context;

        public GetController(TheaterContext context) => _context = context;

        // GET: api/Get
        [HttpGet]
        public int BerekenPrijs(int id)
        {
            KlantModel klant = _context.Klant.Find(k => k.Id);
            var totalePrijs = 0;
            if (klant.Reservingen.Count <= 0)
            {
                return 0;
            }
            else
            {
                foreach (var reservering in klant.Reservingen)
                {

                }
            }
            return lijst;
        }
    }
}
