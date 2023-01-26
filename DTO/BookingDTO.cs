using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Ticket_Booking_system.Model;

namespace Ticket_Booking_system.DTO
{
    public class BookingDTO 
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int TicketID { get; set; } 
        public int BookingCount { get; set; }

    }
}
