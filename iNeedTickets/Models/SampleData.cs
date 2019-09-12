using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace iNeedTickets.Models
{
    public static class SampleData
    {
        public static void Populate(IApplicationBuilder app) {

            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.events.Any())
            {
                context.events.AddRange(
                    new Event() {name = "Metallica Concert", location = "Arena Nationala", description = "Metallica se intorc in Romania pentru prima data in ultimii 10 ani, pentru un show de proportii", price = 450, category = "Music" },
                    new Event() {name = "Rammstein Concert", location = "Piata Constitutiei", description = "Rammstein va asteapta la un show incendiar in Piata Constitutiei, cu ocazia landarii noului material discografic", price = 300, category = "Music" },
                    new Event() {name = "Quantic Fest", location = "Quantic", description = "Un nou festival", price = 100, category = "Music" },
                    new Event() {name = "Stand Up Night", location = "Club 99", description = "Seara funny cu cei mai buni artisti de stand-up", price = 20, category = "Comedy" },
                    new Event() {name = "Subcarpati Concert", location = "Arenele Romane", description = "Lansare subcarpati", price = 100, category = "Music" },
                    new Event() {name = "Teatru Comedie", location = "Teatrul Notara", description = "Teatru de comedie romanesc clasic", price = 450, category = "Theatre" }
                    );
                context.SaveChanges();
            }
        }
    }
}
