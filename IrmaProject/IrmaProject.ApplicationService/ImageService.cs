using IrmaProject.ApplicationService.Interfaces;
using IrmaProject.Domain.Entities;
using IrmaProject.Repository.AzureStorage.Interfaces;
using IrmaProject.Repository.AzureStorage.Model;
using IrmaProject.Repository.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IrmaProject.ApplicationService
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository imageRepository;
        private readonly IUserRepository userRepository;

        public ImageService(IImageRepository imageRepository, IUserRepository userRepository)
        {
            this.imageRepository = imageRepository;
            this.userRepository = userRepository;
        }

        public async Task<Guid> CreateAlbumWithUserId(Guid userId, string albumName)
        {
            var account = await userRepository.FindByIdentifier(userId);
            var newAlbum = new Album
            {
                Account = account,
                Name = albumName
            };
            imageRepository.cre
        }

        public async Task<Uri> UploadImage(byte[] imageBytes)
        {
            ImageUploadResult result = await imageRepository.UploadImage(imageBytes);
            await imageRepository.EnqueueWorkItem(result.ImageId);
            return result.ImageUri;
        }
    }
}
