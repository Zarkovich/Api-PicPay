using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransactionController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Transaction(Transaction transaction)
        {
            var payer = _context.Users.Find(transaction.Payer);
            var payee = _context.Users.Find(transaction.Payee);

            if (payer == null) return NotFound();

            if (payer.TypeUser == EnumTypeUser.Logista) return BadRequest("Logista não pode fazer transferência");

            if (payer.Balance < transaction.Value) return BadRequest("Não há saldo suficiente");

            payer.Balance -= transaction.Value;
            payee.Balance += transaction.Value;

            _context.Add(transaction);

            var authAuthorization = await RequestMocks.GetAuth();

            if (!authAuthorization) return BadRequest("Transação não autorizada!");

            _context.SaveChanges();

            return StatusCode(201, transaction);
        }

    }
}