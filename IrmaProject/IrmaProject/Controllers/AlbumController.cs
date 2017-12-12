using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IrmaProject.Models;
using IrmaProject.ApplicationService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using IrmaProject.Dto.Model;
using System.IO;
using Microsoft.ProjectOxford.Vision.Contract;

namespace IrmaProject.Controllers
{
    [Produces("application/json")]
    [Route("api/Album")]
    public class AlbumController : Controller
    {
        private readonly IImageService imageService;
        private readonly IUserService userService;

        public AlbumController(IImageService imageService, IUserService userService)
        {
            this.imageService = imageService;
            this.userService = userService;
        }

        [HttpGet("get")]
        public async Task<IEnumerable<AlbumViewModel>> Get()
        {
            var account = userService.GetAccountByClaimsPrincipal(User);
            var albums = await imageService.GetAlbumsByUsername(account.Username);
            var albumsFilesCount = await imageService.GetAlbumsFilesCountByIds(albums.Select(x => x.Id));
            List<AlbumViewModel> viewModel = new List<AlbumViewModel>();
            viewModel = albums.Select(x => new AlbumViewModel()
            {
                UrlFriendlyAlbumName = x.UrlFriendlyName,
                CreatedAt = x.CreatedAt.DateTime.ToLongDateString(),
                Description = x.Description,
                ModifiedAt = x.UpdatedAt == null ? "" : x.UpdatedAt.Value.DateTime.ToLongDateString(),
                Name = x.Name,
                FilesCount = albumsFilesCount.FirstOrDefault(y => y.Key.Equals(x.Id)).Value,
                Images = x.Image.Select(i => new ImageViewModel()
                {
                    Height = i.Height == null ? 0 : (int)i.Height,
                    Width = i.Width == null ? 0 : (int)i.Width,
                    Name = i.Name,
                    UploadedAt = i.CreatedAt.DateTime.ToLongDateString(),
                    Url = i.WebSizeUrl,
                    UrlFriendlyImageName = i.UrlFriendlyName,
                    Tags = i.Tags != null ? i.Tags.Split(',').ToList() : new List<string>()
                }).ToList()
            }).ToList();

            return viewModel;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAlbum(string albumName)
        {
            var user = userService.GetAccountByClaimsPrincipal(User);
            await imageService.CreateAlbumWithUserId(user.Id, albumName);
            return RedirectToAction("Albums", "Image");
        }

        [HttpPost("uploadimage")]
        public async Task<IActionResult> UploadImage(string albumname, IFormFile file, string imageName)
        {
            var user = userService.GetAccountByClaimsPrincipal(User);
            var albums = await imageService.GetAlbumsByUserId(user.Id);
            var album = albums.FirstOrDefault(x => x.Name.Equals(albumname));
            if (album == null)
                return RedirectToAction("Albums", "Image");
            ImageUploadResult uploadedImage = null;
            long size = file.Length;
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    uploadedImage = await imageService.UploadImage(album.Id, ms.ToArray());
                }
                var newImage = new Domain.Entities.Image()
                {
                    Album = await imageService.FindAlbumById(album.Id),
                    BlobImageId = uploadedImage.ImageId,
                    Height = 100,
                    Width = 100,
                    MobileSizeUrl = uploadedImage.ImageUri.ToString(),
                    Name = imageName,
                    WebSizeUrl = uploadedImage.ImageUri.ToString()
                };
                IEnumerable<Tag> tags = await imageService.GetVisionData(newImage.WebSizeUrl);
                newImage.Tags = String.Join(",", tags.Select(x => x.Name));
                await imageService.AddImage(newImage);
            }
            var userNameClaim = User.Claims.FirstOrDefault(c => c.Type.Contains("email"));
            //return Ok(new { count = files.Count, size, uploadedImageUri });
            return RedirectToAction("Albums", "Image");
        }
    }
}