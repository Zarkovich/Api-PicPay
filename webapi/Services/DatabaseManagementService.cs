using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialize(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (serviceDb == null) throw new Exception("Não foi possível criar uma Migration");

                var haveMigrations = serviceDb.Database.GetAppliedMigrations();
                if (haveMigrations.Count() > 0) return;

                serviceDb.Database.Migrate();
            }
        }
    }
}