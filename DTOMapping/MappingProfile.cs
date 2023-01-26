using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket_Booking_system.DTO;
using Ticket_Booking_system.Model;

namespace Ticket_Booking_system.DTOMapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<BookingDTO, Booking>().ReverseMap(); 
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<TicketsDTO, Tickets>().ReverseMap();
        }
    }
}
