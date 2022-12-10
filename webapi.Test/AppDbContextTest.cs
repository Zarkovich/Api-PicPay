using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Test
{
    public static class AppDbContextTest
    {
        public static AppDbContext StartDb(string database)
        {
            List<User> users = new();
            users.Add(new User
            {
                Id = 1,
                Name = "Teste",
                Email = "Teste@email.com",
                Cpf = "000000000",
                Password = "Teste",
                Balance = 50,
                TypeUser = EnumTypeUser.Comum
            });
            users.Add(new User
            {
                Id = 2,
                Name = "Teste",
                Email = "teste2@email.com",
                Cpf = "11111111",
                Password = "Teste",
                Balance = 100,
                TypeUser = EnumTypeUser.Logista
            });
            users.Add(new User
            {
                Id = 3,
                Name = "Teste",
                Email = "teste3@email.com",
                Cpf = "222222222",
                Password = "Teste",
                Balance = 100,
                TypeUser = EnumTypeUser.Logista
            });

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(database);

            var context = new AppDbContext(options.Options);

            context.Users.AddRange(users);

            context.SaveChanges();



            return context;
        }
    }
}