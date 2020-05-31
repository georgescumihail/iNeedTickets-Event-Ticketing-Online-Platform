using iNeedTickets.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;

namespace iNeedTickets.Services
{
    public class TicketImageService : ITicketImageService
    {
        private IQRCreatorService _qrCreatorService;

        public TicketImageService(IQRCreatorService qrCreatorService)
        {
            _qrCreatorService = qrCreatorService;
        }

        public void DrawImage(Ticket ticket)
        {
            var ticketImage = new Bitmap(595, 842);

            var qrImage = _qrCreatorService.Generate(ticket);

            using (var graphics = Graphics.FromImage(ticketImage))
            {
                graphics.Clear(Color.White);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

                graphics.DrawString("iNeedTickets", new Font("Calibri", 25, FontStyle.Italic), Brushes.Teal, new PointF(30, 50));
                graphics.DrawLine(new Pen(Brushes.Teal, 10), new PointF(10, 110), new PointF(585, 110));
                graphics.DrawString($"Event: {ticket.TicketArea.Event.Name}", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new PointF(30, 130));
                graphics.DrawString($"Category: {ticket.TicketArea.AreaName}", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new PointF(30, 180));
                graphics.DrawString($"Price: {ticket.TicketArea.Price.ToString()} lei", new Font("Arial", 14), Brushes.Black, new PointF(30, 220));
                graphics.DrawString($"{ticket.TicketArea.Event.Date} - {ticket.TicketArea.Event.Location.Name}", new Font("Arial", 14), Brushes.Black, new PointF(30, 260));
                if (ticket.TicketArea.Event.IsSeated)
                {
                    graphics.DrawString($"Seat: {ticket.SeatNumber}", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new PointF(30, 290));
                }
                graphics.DrawImage(qrImage, 120, 320, 350, 350);
            }

            var filePath = "./Images/Tickets/" + ticket.FileName;

            ticketImage.Save(filePath, ImageFormat.Jpeg);
        }
    }
}
