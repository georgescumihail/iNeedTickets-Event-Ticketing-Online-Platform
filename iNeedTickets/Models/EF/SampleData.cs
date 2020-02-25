using Microsoft.AspNetCore.Builder;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace iNeedTickets.Models
{
    public static class SampleData
    {
        public static void Populate(IApplicationBuilder app) {

            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            var location1 = new Location { Name = "Arenele Romane", Latitude = 44.412943, Longitude = 26.093381, Description = "Cea mai buna locatie pentru concerte" };
            var location2 = new Location { Name = "Teatrul National", Latitude = 44.436649, Longitude = 26.103910, Description = "Teatrul national, evident" };
            var location3 = new Location { Name = "Arena Nationala", Latitude = 44.436973, Longitude = 26.153215, Description = "Arena nationala unde se desfasoara cele mai mari meciuri" };
            var location4 = new Location { Name = "Club 99", Latitude = 44.446237, Longitude = 26.108074, Description = "Club de stand up comedy" };
            var location5 = new Location { Name = "Quantic", Latitude = 44.438029, Longitude = 26.059438, Description = "Club, pub, concert venue, restaurant" };
            var location6 = new Location { Name = "Galeria de arta", Latitude = 44.428923, Longitude = 26.096030, Description = "O minunata galerie de arta in zona Piata Unirii" };

            if (!context.Locations.Any())
            {
                context.Locations.AddRange(location1, location2, location3, location4);
                context.SaveChanges();
            }

            var event1 = new Event() { Name = "Metallica Concert", Location = location1, Description = "Metallica se intorc in Romania pentru prima data in ultimii 10 ani, pentru un show de proportii", EventType = EventType.Concerts, Date = DateTime.Now, PhotoLink = "metallica.jpeg" };
            var event2 = new Event() { Name = "Rammstein Concert", Location = location1, Description = "Rammstein va asteapta la un show incendiar in Piata Constitutiei, cu ocazia landarii noului material discografic", EventType = EventType.Concerts, Date = DateTime.Now.AddDays(25), PhotoLink = "rammstein.jpg" };
            var event3 = new Event() { Name = "Quantic Fest", Location = location5, Description = "Un nou festival", EventType = EventType.Concerts, Date = DateTime.Now.AddDays(15), PhotoLink = "quantic.jpg" };
            var event4 = new Event() { Name = "Stand Up Night", Location = location4, Description = "Seara funny cu cei mai buni artisti de stand-up", EventType = EventType.Standup, Date = DateTime.Now.AddDays(3), PhotoLink = "standup1.jpg" };
            var event5 = new Event() { Name = "Subcarpati Concert", Location = location1, Description = "Lansare subcarpati", EventType = EventType.Concerts, Date = DateTime.Now.AddDays(70), PhotoLink = "subcarpati.jpg" };
            var event6 = new Event() { Name = "Teatru Comedie", Location = location2, Description = "Teatru de comedie romanesc clasic", EventType = EventType.Theatre, Date = DateTime.Now.AddDays(12), PhotoLink = "teatru1.jpg" };
            var event7 = new Event() { Name = "O Noapte Furtunoasa", Location = location2, Description = "O noua piesa de teatru", EventType = EventType.Theatre, Date = DateTime.Now.AddDays(15), PhotoLink = "teatru2.jpg" };
            var event8 = new Event() { Name = "Stand Up Night 2", Location = location4, Description = "Seara funny cu cei mai buni artisti de stand-up, partea a doua", EventType = EventType.Standup, Date = DateTime.Now.AddDays(12), PhotoLink = "standup2.jpg" };
            var event9 = new Event() { Name = "Fotbal - Romania vs Brazilia", Location = location3, Description = "Cel mai asteptat meci din acest an", EventType = EventType.Sports, Date = DateTime.Now.AddDays(30), PhotoLink = "fotbal.jpg" };
            var event10 = new Event() { Name = "Finala Handbal", Location = location3, Description = "Finala campionatului de handbal", EventType = EventType.Sports, Date = DateTime.Now.AddDays(15), PhotoLink = "handbal.png" };
            var event11 = new Event() { Name = "Painting Expo", Location = location6, Description = "Expozitie de pictura la galeria de arta", EventType = EventType.Art, Date = DateTime.Now.AddDays(15), PhotoLink = "painting.jpg" };

            if (!context.Events.Any())
            {
                context.Events.AddRange(event1, event2, event3, event4, event5, event6, event7, event8, event9, event10, event11);
                context.SaveChanges();
            }

            if (!context.TicketTypes.Any())
            {
                context.TicketTypes.AddRange(
                    new TicketClass { AreaName = "Golden Circle", Capacity = 500, Price = 1400, EventRef = event1 },
                    new TicketClass { AreaName = "Silver Circle", Capacity = 500, Price = 800, EventRef = event1 },
                    new TicketClass { AreaName = "Normal Circle", Capacity = 500, Price = 400, EventRef = event1 },
                    new TicketClass { AreaName = "Normal Circle", Capacity = 500, Price = 100, EventRef = event2 },
                    new TicketClass { AreaName = "Normal Circle", Capacity = 500, Price = 200, EventRef = event3 },
                    new TicketClass { AreaName = "Normal Circle", Capacity = 500, Price = 100, EventRef = event4 },
                    new TicketClass { AreaName = "Normal Circle", Capacity = 500, Price = 200, EventRef = event5 },
                    new TicketClass { AreaName = "Normal Circle", Capacity = 500, Price = 100, EventRef = event6 },
                    new TicketClass { AreaName = "Normal Circle", Capacity = 500, Price = 200, EventRef = event7 },
                    new TicketClass { AreaName = "Normal Circle", Capacity = 500, Price = 50, EventRef = event8 },
                    new TicketClass { AreaName = "Normal Circle", Capacity = 500, Price = 100, EventRef = event9 },
                    new TicketClass { AreaName = "Normal Circle", Capacity = 500, Price = 300, EventRef = event10 },
                    new TicketClass { AreaName = "Normal Circle", Capacity = 500, Price = 100, EventRef = event11 }
                    );
                context.SaveChanges();
            }
        }
    }
}
