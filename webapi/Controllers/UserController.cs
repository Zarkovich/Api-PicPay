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
                var userContainsCpf = _context.Users.Where(x => x.Cpf == user.Cpf);
                var userContainsEmail = _context.Users.Where(x => x.Email == user.Email);

                if (userContainsCpf.Count() != 0 || userContainsEmail.Count() != 0) return BadRequest("Error: Usuário existente");

                _context.Add(user);
                _context.SaveChanges();

                return StatusCode(201, "Usuário Registrado!");
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex);
            }

        }

        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            var allUsers = _context.Users;

            return Ok(allUsers);
        }
    }
}