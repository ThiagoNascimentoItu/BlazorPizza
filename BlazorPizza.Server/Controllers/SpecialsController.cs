using BlazorPizza.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPizza.Server.Controllers
{
    [Route("specials")]
    [ApiController]
    public class SpecialsController: Controller
    {
        private readonly PizzaStoreContext _db;
        public SpecialsController(PizzaStoreContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<ActionResult<List<PizzaSpecial>>> GetSpecial()
        {
            return await _db.Specials.OrderByDescending(s => s.BasePrice).ToListAsync();
        }
    }
}
