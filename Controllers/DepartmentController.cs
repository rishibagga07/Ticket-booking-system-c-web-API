using Microsoft.AspNetCore.Authorization;
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
   // [Authorize]
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;

        }

        
        [HttpGet]
        public IActionResult GetAll ()
        {
            
            var dep = _context.departments.Where(dep=>dep.IsDeleted==false ).ToList();


            return Ok(dep);
        }

        [HttpPost]

        public IActionResult DepSave([FromBody] Department department)
        {
            if (department == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            _context.departments.Add(department);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult DepUpdate ([FromBody] Department department )
        {

            if (department == null) return BadRequest();
            _context.departments.Update(department);
            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public IActionResult DepDelete (int id )
        {
            var depfromdb = _context.departments.Find(id);
            depfromdb.IsDeleted = true;
            _context.SaveChanges();
            return Ok();

        }
    }
}
