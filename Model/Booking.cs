using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ticket_Booking_system.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        
        public int TicketID { get; set; }
        [ForeignKey("TicketID")]
        public Tickets TicketId { get; set; }
        public int BookingCount { get; set; }

    }
}
