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
        public void DrawImage(Ticket ticket, Bitmap qrCodeImage)
        {
            var ticketImage = new Bitmap(595, 842);

            using (var graphics = Graphics.FromImage(ticketImage))
            {
                graphics.Clear(Color.White);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

                graphics.DrawString("iNeedTickets", new Font("Calibri", 25, FontStyle.Italic), Brushes.Teal, new PointF(30, 50));
                graphics.DrawLine(new Pen(Brushes.Teal, 10), new PointF(10, 110), new PointF(585, 110));
                graphics.DrawString($"Eveniment: {ticket.TicketClassRef.EventRef.Name}", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new PointF(30, 130));
                graphics.DrawString($"Categorie: {ticket.TicketClassRef.AreaName}", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new PointF(30, 180));
                graphics.DrawString($"Pret: {ticket.TicketClassRef.Price.ToString()} lei", new Font("Arial", 14), Brushes.Black, new PointF(30, 220));
                graphics.DrawString($"{ticket.TicketClassRef.EventRef.Date} - {ticket.TicketClassRef.EventRef.Location.Name}", new Font("Arial", 14), Brushes.Black, new PointF(30, 260));

                graphics.DrawImage(qrCodeImage, 120, 320, 350, 350);
            }

            var filePath = "./Images/Tickets/" + ticket.FileName;

            ticketImage.Save(filePath, ImageFormat.Jpeg);
        }
    }
}
