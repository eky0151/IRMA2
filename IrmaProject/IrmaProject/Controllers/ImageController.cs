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
using IrmaProject.Common.Constant;
using IrmaProject.Models;
using IrmaProject.Dto.Model;

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

        [HttpPost("UploadMore")]
        public async Task<IActionResult> UploadMore(Guid albumId, List<IFormFile> files, string imageName)
        {
            var album = await imageService.FindAlbumById(albumId);
            ImageUploadResult uploadedImageUri = null;
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        formFile.CopyTo(ms);
                        uploadedImageUri = await imageService.UploadImage(album.Id, ms.ToArray());
                    }
                }
            }

            return Ok(new { count = files.Count, size, uploadedImageUri });
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> Upload(Guid albumId, IFormFile file, string imageName)
        {
            var album = await imageService.FindAlbumById(albumId);
            ImageUploadResult uploadedImage = null;
            long size = file.Length;
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    uploadedImage = await imageService.UploadImage(album.Id, ms.ToArray());
                }
                await imageService.AddImage(new Domain.Entities.Image()
                {
                    Album = await imageService.FindAlbumById(albumId),
                    BlobImageId = uploadedImage.ImageId,
                    Height = 100,
                    Width = 100,
                    MobileSizeUrl = uploadedImage.ImageUri.ToString(),
                    Name = imageName,
                    WebSizeUrl = uploadedImage.ImageUri.ToString()
                });
            }
            var userNameClaim = User.Claims.FirstOrDefault(c => c.Type.Contains("email"));
            //return Ok(new { count = files.Count, size, uploadedImageUri });
            return RedirectToAction("Album", new { username = userNameClaim.Value, albumname = album.Name });
        }

        [HttpGet]
        [Route("{username}/Album/{albumname}")]
        public async Task<IActionResult> Album(string username, string albumname)
        {
            var images = await imageService.GetImagesByAlbumName(albumname);
            ShowImagesViewModel viewModel = new ShowImagesViewModel();
            viewModel.Images = images.Select(x => new ImageViewModel()
            {
                Name = x.Name,
                UploadedAt = x.CreatedAt.DateTime.ToLongDateString() + " " + x.CreatedAt.DateTime.ToShortTimeString(),
                Url = x.WebSizeUrl,
                Width = "50",
                Height = "50"
            });
            var album = (await imageService.FindAlbumByName(albumname));
            viewModel.AlbumId = album.Id.ToString();
            return View(viewModel);
        }

        [HttpGet]
        [Route("{username}/Albums")]
        public async Task<IActionResult> Albums(string username)
        {
            var albums = await imageService.GetAlbumsByUsername(username);
            var albumsFilesCount = await imageService.GetAlbumsFilesCountByIds(albums.Select(x => x.Id));
            ShowAlbumsViewModel viewModel = new ShowAlbumsViewModel();
            viewModel.Albums = albums.Select(x => new AlbumViewModel()
            {
                UrlFriendlyAlbumName = x.UrlFriendlyName,
                CreatedAt = x.CreatedAt.DateTime.ToLongDateString(),
                Description = x.Description,
                ModifiedAt = x.UpdatedAt == null ? "" : x.UpdatedAt.Value.DateTime.ToLongDateString(),
                Name = x.Name,
                FilesCount = albumsFilesCount.FirstOrDefault(y => y.Key.Equals(x.Id)).Value
            });
            var account = userService.GetAccountByClaimsPrincipal(User);
            viewModel.Userid = account.Id;
            return View(viewModel);
        }

        [HttpPost("CreateAlbum")]
        public async Task<IActionResult> CreateAlbum(Guid userId, string albumName)
        {
            await imageService.CreateAlbumWithUserId(userId, albumName);
            return RedirectToAction("Albums", new { username = userService.GetAccountByClaimsPrincipal(User).Username });
        }
    }
}