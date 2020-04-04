using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace iNeedTickets.Controllers
{
    public class ImageController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;

        public ImageController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult TicketPhoto(string fileName)
        {
            var path = _hostingEnvironment.ContentRootPath + "\\Images\\Tickets\\" + fileName;

            return base.PhysicalFile(path, "image/jpeg");
        }

        public IActionResult EventPhoto(string fileName)
        {
            var path = _hostingEnvironment.ContentRootPath + "\\Images\\Events\\" + fileName;

            return base.PhysicalFile(path, "image/jpeg");
        }
    }
}