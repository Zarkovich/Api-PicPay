using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace webapi.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Cpf), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public EnumTypeUser TypeUser { get; set; }

        [Precision(14, 2)]
        public decimal Balance { get; set; }
    }
}