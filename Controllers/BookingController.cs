using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket_Booking_system.Data;
using Ticket_Booking_system.DTO;
using Ticket_Booking_system.DTOMapping;
using Ticket_Booking_system.Model;

namespace Ticket_Booking_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public BookingController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult BookingTicketGetAll()
        {
            //var y = _context.bookings.Include(UserTbale => UserTbale.User).Include(TicketTable => TicketTable.TicketId).GroupBy(item => item.UserId).Select(group => group.ToList()).ToList();

     //  var Grp = _context.bookings.Include(UserTbale => UserTbale.User).Include(TicketTable => TicketTable.TicketId).GroupBy(item => item.UserId).Select(group => new {
     //    BookingCount = group.ToList().Sum(a=>a.BookingCount),
     //    UserName = group.FirstOrDefault().UserId,
     //    TicketName = group.FirstOrDefault().TicketID,
     //    img = group.FirstOrDefault().TicketId.img
     //}).ToList();


           var bookking = _context.bookings.Include(UserTbale => UserTbale.User).
                Include(TicketTable => TicketTable.TicketId).ToList();
            var bk = bookking.Select(b => new
            {
                UserName = b.User.Name,
                TicketName = b.TicketId.TicketName,
                BookingCount = b.BookingCount,
                img = b.TicketId.img
            });
            return Ok(bk);
        }

        //[HttpGet("{id:int}")]

        //public IActionResult GetTicketByBookingId(int id )
        //{
        //    var ticket = _context.bookings.Include(booking => booking.TicketId).
        //        Where(ticket => ticket.TicketID == id).Select(b => new
        //        {
        //            id = b.TicketID,
        //            TicketName = b.TicketId.TicketName,
        //            TicketCount = b.TicketId.TicketCount,
        //            img = b.TicketId.img,
        //            BookingCount = b.BookingCount
        //        });

        //    return Ok(ticket);
        //} 




        [HttpPost]

        //public IActionResult DepSave([FromBody] BookingDTO bookingDto)

        public IActionResult BookingTicketSave([FromBody] BookingDTO  bookingDto)
        {
            if (bookingDto == null ) return BadRequest();
            var obj = new Booking();
            obj.UserId = bookingDto.UserId;
            obj.TicketID = bookingDto.TicketID;
            obj.BookingCount = bookingDto.BookingCount;
            _context.bookings.Add(obj);
            _context.SaveChanges();
            //obj.User.Email = bookingDto.Email;
            //obj.TicketID = bookingDto.TicketID;
            //obj.BookingCount = bookingDto.BookingCount;
            return Ok();
;            
        }


        [HttpPut]

        public IActionResult BookingTicktUpdate([FromBody] Booking booking)
        {

            if (booking == null) return BadRequest();

            //var bokkingdto = _mapper.Map<BookingDTO, Booking>(bookingDto);

            _context.bookings.Update(booking);
            _context.SaveChanges();
            return Ok();

        }


        [HttpDelete("{id:int}")]
        public IActionResult BookingTicketDelete(int id)
        {
            var bookingfromdb = _context.bookings.Find(id);
            _context.bookings.Remove(bookingfromdb);
            _context.SaveChanges();
            return Ok();

        }
    }
}
