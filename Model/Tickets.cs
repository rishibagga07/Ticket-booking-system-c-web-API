﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticket_Booking_system.Model
{
    public class Tickets
    {
        public int Id { get; set; }
        public string TicketName { get; set; }
        public int TicketCount { get; set; }
        public string img { get; set; }
      
        public bool IsDeleted { get; set; }
    }
}
