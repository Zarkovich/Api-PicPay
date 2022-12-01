using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace webapi.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Precision(14, 2)]
        public decimal Value { get; set; }
        public int Payer { get; set; }
        public int Payee { get; set; }
    }
}