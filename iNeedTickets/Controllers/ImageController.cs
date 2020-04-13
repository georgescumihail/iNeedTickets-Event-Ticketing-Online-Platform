using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iNeedTickets.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace iNeedTickets.Controllers
{
    public class ImageController : Controller
    {
        private IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public IActionResult TicketPhoto(string fileName)
        {
            var image = _imageService.GetTicketImage(fileName);

            return File(image, "image/jpeg");
        }

        public IActionResult EventPhoto(string fileName)
        {
            var image = _imageService.GetEventImage(fileName);

            return File(image, "image/jpeg");
        }
    }
}