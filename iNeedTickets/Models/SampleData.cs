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

            var event1 = new Event() { Name = "Metallica Concert", Location = "Arena Nationala", Description = "Metallica se intorc in Romania pentru prima data in ultimii 10 ani, pentru un show de proportii", Category = "Music", Date = DateTime.Now, PhotoLink = "metallica.jpeg" };
            var event2 = new Event() { Name = "Rammstein Concert", Location = "Piata Constitutiei", Description = "Rammstein va asteapta la un show incendiar in Piata Constitutiei, cu ocazia landarii noului material discografic", Category = "Music", Date = DateTime.Now.AddDays(25), PhotoLink = "rammstein.jpg" };
            var event3 = new Event() { Name = "Quantic Fest", Location = "Quantic", Description = "Un nou festival", Category = "Music", Date = DateTime.Now.AddDays(15), PhotoLink = "quantic.jpg" };
            var event4 = new Event() { Name = "Stand Up Night", Location = "Club 99", Description = "Seara funny cu cei mai buni artisti de stand-up", Category = "Comedy", Date = DateTime.Now.AddDays(3), PhotoLink = "standup1.jpg" };
            var event5 = new Event() { Name = "Subcarpati Concert", Location = "Arenele Romane", Description = "Lansare subcarpati", Category = "Music", Date = DateTime.Now.AddDays(70), PhotoLink = "subcarpati.jpg" };
            var event6 = new Event() { Name = "Teatru Comedie", Location = "Teatrul Notara", Description = "Teatru de comedie romanesc clasic", Category = "Theatre", Date = DateTime.Now.AddDays(12), PhotoLink = "teatru1.jpg" };
            var event7 = new Event() { Name = "Teatru de Copii", Location = "Teatrul Celalalt", Description = "O noua piesa de teatru", Category = "Theatre", Date = DateTime.Now.AddDays(15), PhotoLink = "teatru2.jpg" };
            var event8 = new Event() { Name = "Stand Up Night 2", Location = "Club 99", Description = "Seara funny cu cei mai buni artisti de stand-up, partea a doua", Category = "Comedy", Date = DateTime.Now.AddDays(12), PhotoLink = "standup2.jpg" };
            var event9 = new Event() { Name = "Fotbal - Romania vs Brazilia", Location = "Arena Nationala", Description = "Cel mai asteptat meci din acest an", Category = "Sports", Date = DateTime.Now.AddDays(30), PhotoLink = "fotbal.jpg" };
            var event10 = new Event() { Name = "Finala Handbal", Location = "Club Sportiv Steaua", Description = "Finala campionatului de handbal", Category = "Sports", Date = DateTime.Now.AddDays(15), PhotoLink = "handbal.png" };
            var event11 = new Event() { Name = "Painting Expo", Location = "Galeria de Arta", Description = "Expozitie de pictura la galeria de arta", Category = "Art", Date = DateTime.Now.AddDays(15), PhotoLink = "painting.jpg" };

            if (!context.Events.Any())
            {
                context.Events.AddRange(event1, event2, event3, event4, event5, event6, event7, event8, event9, event10, event11);
                context.SaveChanges();
            }
            if (!context.TicketTypes.Any())
            {
                context.TicketTypes.AddRange(
                    new TicketType() { AreaName = "Golden Circle", Capacity = 500, Price = 1400, EventRef = event1 },
                    new TicketType() { AreaName = "Silver Circle", Capacity = 500, Price = 800, EventRef = event1 },
                    new TicketType() { AreaName = "Normal Circle", Capacity = 500, Price = 400, EventRef = event1 },
                    new TicketType() { AreaName = "Normal Circle", Capacity = 500, Price = 100, EventRef = event2 },
                    new TicketType() { AreaName = "Normal Circle", Capacity = 500, Price = 200, EventRef = event3 },
                    new TicketType() { AreaName = "Normal Circle", Capacity = 500, Price = 100, EventRef = event4 },
                    new TicketType() { AreaName = "Normal Circle", Capacity = 500, Price = 200, EventRef = event5 },
                    new TicketType() { AreaName = "Normal Circle", Capacity = 500, Price = 100, EventRef = event6 },
                    new TicketType() { AreaName = "Normal Circle", Capacity = 500, Price = 200, EventRef = event7 },
                    new TicketType() { AreaName = "Normal Circle", Capacity = 500, Price = 50, EventRef = event8 },
                    new TicketType() { AreaName = "Normal Circle", Capacity = 500, Price = 100, EventRef = event9 },
                    new TicketType() { AreaName = "Normal Circle", Capacity = 500, Price = 300, EventRef = event10 },
                    new TicketType() { AreaName = "Normal Circle", Capacity = 500, Price = 100, EventRef = event11 }
                    );
                context.SaveChanges();
            }
        }
    }
}
