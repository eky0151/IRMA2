using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IrmaProject.ApplicationService.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Security.Claims;

namespace IrmaProject.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        private readonly IImageService imageService;
        private readonly IUserService userService;

        public ImageController(IImageService imageService, IUserService userService)
        {
            this.imageService = imageService;
            this.userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            Uri uploadedImageUri = null;
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        formFile.CopyTo(ms);
                        uploadedImageUri = await imageService.UploadImage(ms.ToArray());
                    }
                }
            }

            return Ok(new { count = files.Count, size, uploadedImageUri });
        }

        [HttpPost("CreateAlbum")]
        public async Task<IActionResult> CreateAlbum(Guid userId)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbum(int id)
        {
            //ImageService where AlbumId == id
            return View();
        }
    }
}