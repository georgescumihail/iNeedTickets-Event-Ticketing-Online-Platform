using iNeedTickets.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace iNeedTickets.Services
{
    public class EmailService : IEmailService
    {
        private IOptions<ServiceCredentials> _config;

        public EmailService(IOptions<ServiceCredentials> config)
        {
            _config = config;
        }

        public void SendEmail(User user, TicketArea area, PurchaseModel purchaseData, List<string> imagePaths)
        {
            var emailMessage = new MailMessage();
            var credentials = new NetworkCredential(_config.Value.ServiceEmail, _config.Value.ServicePassword);

            emailMessage.To.Add(user.Email);
            emailMessage.Subject = "iNeedTickets purchase confirmation";
            emailMessage.From = new MailAddress(_config.Value.ServiceEmail);
            emailMessage.IsBodyHtml = true;
            emailMessage.Body = $"<p>You purchased <b>{purchaseData.TicketsCount}</b> tickets "
                + $"for <b>{area.Event.Name} - {area.AreaName}</b>. "
                + $"See you at <b>{area.Event.Location.Name}</b> on <b>{area.Event.Date.ToString()}.</b> We hope you will enjoy the show!</p>";

            foreach(var path in imagePaths)
            {
                emailMessage.Attachments.Add(new Attachment("./Images/Tickets/" + path));
            }

            var smtp = new SmtpClient("smtp.office365.com");
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = credentials;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(emailMessage);
        }
    }
}
