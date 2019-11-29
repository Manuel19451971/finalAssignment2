using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayersProfile.Models;

namespace PlayersProfile.API
{
    [Route("api/Carstabs")]
    [ApiController]
    public class V1Controller : Controller
    {

        private readonly playersdb1Context _context;

        public V1Controller(playersdb1Context context)
        {
            _context = context;
        }
        // GET: api/V1
        [HttpGet]
        public IActionResult Get()
        {
            var mystuff = _context.Carstab.ToList();
            return Json(mystuff);
        }

        // GET: api/V1/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var mystuff = _context.Carstab.Where(s => s.CarId == id).SingleOrDefault();
            return Json(mystuff);
        }

        // POST: api/V1
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/V1/5
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
