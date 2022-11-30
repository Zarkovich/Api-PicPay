using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost("register")]
        public IActionResult UserRegister(User user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();

                return StatusCode(201, "Usuário Registrado!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        public IActionResult GetAllUsers()
        {
            var allUsers = _context.Users;

            return Ok(allUsers);
        }
    }
}