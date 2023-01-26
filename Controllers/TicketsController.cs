using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket_Booking_system.Data;
using Ticket_Booking_system.DTO;
using Ticket_Booking_system.Model;

namespace Ticket_Booking_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var ticketss = _context.tickets.Where(del => del.IsDeleted == false).ToList();
            var t = ticketss.Select(a => new
            {
                
                PendingTicket = a.TicketCount - _context.bookings.
                Where(del => del.TicketID == a.Id && a.IsDeleted == false).
                Sum(a => a.BookingCount),
                Id = a.Id,
                TicketName = a.TicketName,
                TicketCount = a.TicketCount,
                img = a.img
            });
            return Ok(t);
        }

       



        [HttpPost]

        public IActionResult DepSave([FromBody] Tickets tickets)
        {
            if (tickets == null) return BadRequest();


            _context.tickets.Add(tickets);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult DepUpdate([FromBody] TicketsDTO ticketsDTO)
        {

            if (ticketsDTO == null) return BadRequest();

            if (ticketsDTO.img == null)
            {


                Tickets tickets = new Tickets();
                tickets.TicketName = ticketsDTO.TicketName;
                tickets.TicketCount = ticketsDTO.TicketCount;



                _context.tickets.Update(tickets);
            }

            else
            {


                Tickets tickets = new Tickets();
                tickets.TicketName = ticketsDTO.TicketName;
                tickets.TicketCount = ticketsDTO.TicketCount;
                tickets.img = ticketsDTO.img;


                _context.tickets.Update(tickets);
            }

//            _context.tickets.Update(tickets);

            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public IActionResult DelDelete(int id)
        {
            var tickestfromdb = _context.tickets.Find(id);
            tickestfromdb.IsDeleted = true;
            _context.SaveChanges();
            return Ok();

        }


    }
}
