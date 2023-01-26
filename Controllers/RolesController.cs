using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket_Booking_system.Data;
using Ticket_Booking_system.Model;

namespace Ticket_Booking_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RolesController(ApplicationDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dep = _context.roles.ToList();
            //var adminRole = dep.FirstOrDefault(x => x.Id == 1);
            //dep.Remove(adminRole);
            return Ok(dep);
        }

        [HttpPost]

        public IActionResult DepSave([FromBody] Role  role)
        {
            if (role == null) return BadRequest();
            _context.roles.Add(role);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult DepUpdate([FromBody] Role role)
        {

            if (role == null) return BadRequest();
            _context.roles.Update(role);
            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public IActionResult DelDelete(int id)
        {
            var rolefromdb = _context.roles.Find(id);
            _context.roles.Remove(rolefromdb);
            _context.SaveChanges();
            return Ok();

        }



    }
}
