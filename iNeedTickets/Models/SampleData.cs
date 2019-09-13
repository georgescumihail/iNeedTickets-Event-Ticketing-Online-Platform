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
                    new Event() {name = "Metallica Concert", location = "Arena Nationala", description = "Metallica se intorc in Romania pentru prima data in ultimii 10 ani, pentru un show de proportii", price = 450, category = "Music", date = DateTime.Now, photoLink= "metallica.jpeg" },
                    new Event() {name = "Rammstein Concert", location = "Piata Constitutiei", description = "Rammstein va asteapta la un show incendiar in Piata Constitutiei, cu ocazia landarii noului material discografic", price = 300, category = "Music", date = DateTime.Now.AddDays(25), photoLink = "rammstein.jpg" },
                    new Event() {name = "Quantic Fest", location = "Quantic", description = "Un nou festival", price = 100, category = "Music", date = DateTime.Now.AddDays(15), photoLink = "quantic.jpg" },
                    new Event() {name = "Stand Up Night", location = "Club 99", description = "Seara funny cu cei mai buni artisti de stand-up", price = 20, category = "Comedy", date = DateTime.Now.AddDays(3), photoLink = "standup1.jpg" },
                    new Event() {name = "Subcarpati Concert", location = "Arenele Romane", description = "Lansare subcarpati", price = 100, category = "Music", date = DateTime.Now.AddDays(70), photoLink = "subcarpati.jpg" },
                    new Event() {name = "Teatru Comedie", location = "Teatrul Notara", description = "Teatru de comedie romanesc clasic", price = 450, category = "Theatre", date = DateTime.Now.AddDays(12), photoLink = "teatru1.jpg" },
                    new Event() { name = "Teatru de Copii", location = "Teatrul Celalalt", description = "O noua piesa de teatru", price = 20, category = "Theatre", date = DateTime.Now.AddDays(15), photoLink = "teatru2.jpg" },
                    new Event() { name = "Stand Up Night 2", location = "Club 99", description = "Seara funny cu cei mai buni artisti de stand-up, partea a doua", price = 20, category = "Comedy", date = DateTime.Now.AddDays(12), photoLink = "standup2.jpg" },
                    new Event() { name = "Fotbal - Romania vs Brazilia", location = "Arena Nationala", description = "Cel mai asteptat meci din acest an", price = 100, category = "Sports", date = DateTime.Now.AddDays(30), photoLink = "fotbal.jpg" },
                    new Event() { name = "Finala Handbal", location = "Club Sportiv Steaua", description = "Finala campionatului de handbal", price = 30, category = "Sports", date = DateTime.Now.AddDays(15), photoLink = "handbal.png" },
                    new Event() { name = "Painting Expo", location = "Galeria de Arta", description = "Expozitie de pictura la galeria de arta", price = 30, category = "Art", date = DateTime.Now.AddDays(15), photoLink = "painting.jpg" }

                    );
                context.SaveChanges();
            }
        }
    }
}
