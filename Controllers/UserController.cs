using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Ticket_Booking_system.Data;
using Ticket_Booking_system.DTO;
using Ticket_Booking_system.Model;
using Ticket_Booking_system.Repository.IRepository;

namespace Ticket_Booking_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMailService mailService;
        private readonly IMapper _mapper;


        public UserController(ApplicationDbContext context, IMailService mailService)
        {
            _context = context;
            this.mailService = mailService;

        }

        

        [HttpGet]
        public IActionResult GetAll()
        {
            var user = _context.users.Include(u => u.Department).Include(r => r.Role).ToList();
            var admincolumn = user.FirstOrDefault(AdminRole => AdminRole.RoleId == 1);
            user.Remove(admincolumn);
            var df = user.Select(a => new
            {
                Id = a.Id,
                RoleName = a.Role.RolesName,
                RoleId = a.Role.Id,
                DepartName = a.Department.DepartmentName,
                DepartmentId = a.DepartmentId,
                Name = a.Name,
                Address = a.Address,
                Email = a.Email,
                RegistrationDate = a.RegistrationDate.ToString("dd-MM-yyyy"),
                ExpireDate = a.ExpireDate.ToString("dd-MM-yyyy"),

            }).ToList();
            return Ok(df);
        }

        [HttpPost]

        public async Task<IActionResult> DepSave([FromBody] User user)
        {
            if (user == null) return BadRequest();

            if (user.RoleId == 0 && user.RoleId != 1)
            {
                user.RoleId = 2;
                user.DepartmentId = 7;
            }


            DateTime date1 = new DateTime();
            date1 = DateTime.Now;
            DateTime date2 = date1.AddDays(7);

            user.RegistrationDate = date1;
            user.ExpireDate = date2;
            _context.users.Add(user);
            _context.SaveChanges();


            if (user.Email != null)
            {
                var WelcomeRequest = new WelcomeRequest()
                {
                    ToEmail = user.Email,
                    UserName = user.Name,
                    Id = user.Id
                };


                await mailService.SendWelcomeEmailAsync(WelcomeRequest);


            }
            return Ok();
        }


        [HttpPut]
        

        public IActionResult UserUpdate([FromBody] UserDTO userDto)
        {

            if (userDto == null || userDto.Id == 0 ) return BadRequest();
           
            var tab = _context.users.Find(userDto.Id);

            tab.RoleId = userDto.RoleId;
            tab.Address = userDto.Address;
            tab.DepartmentId = userDto.DepartmentId;
            tab.Id = userDto.Id;
            tab.Name = userDto.Name;
            tab.Email = userDto.Email;

            //var user = _mapper.Map<User>(userDto);

            _context.users.Update(tab);
            _context.SaveChanges();
            return Ok();

        }

        [HttpPatch]

        public IActionResult DepPatch([FromBody] User user)
        {
            var pass = _context.users.FirstOrDefault(p => p.Id == user.Id);

            pass.Password = user.Password;

            _context.users.Update(pass);
            _context.SaveChanges();


            return Ok();

        }


        [HttpDelete("{id:int}")]
        public IActionResult DelDelete(int id)
        {
            var userfromdb = _context.users.Find(id);
            _context.users.Remove(userfromdb);
            _context.SaveChanges();
            return Ok();

        }

        [HttpPost]
        [Route("login")]  
        public IActionResult Login(Login login)
        {

            var loginCredential = _context.users.
                Where(log => log.Email == login.Email && log.Password == login.Password).FirstOrDefault();
            if (loginCredential == null)
            {
                return BadRequest();
            }
            else
            {                                               
        

                return Ok(loginCredential);

            }
        }


    }
}
