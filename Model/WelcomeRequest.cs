using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticket_Booking_system.Model
{
    public class WelcomeRequest
    {
        public int Id { get; set; }

        public string ToEmail { get; set; }
        public string UserName { get; set; }

    }
}
