using Microsoft.AspNetCore.Identity;

namespace iNeedTickets.Models
{
    public class User : IdentityUser
    {
        public double Credit { get; set; }

        public void Deposit(double amount)
        {
            Credit += amount;
        }

        public void Pay(double amount)
        {
            Credit -= amount;
        }
    }
}