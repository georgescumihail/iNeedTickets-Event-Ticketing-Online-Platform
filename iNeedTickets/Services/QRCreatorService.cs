using iNeedTickets.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace iNeedTickets.Services
{
    public class QRCreatorService : IQRCreatorService
    {
        public Bitmap Generate(Ticket ticket)
        {
            var qrGenerator = new QRCodeGenerator();

            var qrText = $"{ ticket.TicketArea.Event.Name}" +
                $"-{ticket.TicketArea.Event.Location.Name}" +
                $"-{ticket.EncryptionCode.ToString()}".Replace(" ", "-");

            var qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);

            return qrCodeImage;
        }
    }
}
