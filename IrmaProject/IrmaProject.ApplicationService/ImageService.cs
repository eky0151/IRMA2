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
        private readonly IAzureStorageImageRepository azureImageRepository;
        private readonly IDbImageRepository databaseImageRepository;
        private readonly IUserRepository userRepository;
        private readonly IAlbumRepository albumRepository;

        public ImageService(IAzureStorageImageRepository azureImageRepository, IUserRepository userRepository, IDbImageRepository databaseImageRepository, IAlbumRepository albumRepository)
        {
            this.azureImageRepository = azureImageRepository;
            this.userRepository = userRepository;
            this.databaseImageRepository = databaseImageRepository;
            this.albumRepository = albumRepository;
        }

        public async Task<Guid> CreateAlbumWithUserId(Guid userId, string albumName)
        {
            var account = await userRepository.FindByIdentifier(userId);
            var newAlbum = new Album
            {
                Account = account,
                Name = albumName
            };
            return await albumRepository.CreateAlbum(newAlbum);
        }

        public async Task<Album> FindAlbumById(Guid albumId)
        {
            var album = await albumRepository.GetAlbumById(albumId);
            if(album == null)
            {
                throw new ArgumentException();
            }
            return album;
        }

        public async Task<IEnumerable<Album>> GetAlbumsByUserId(Guid userId)
        {
            return await albumRepository.GetAlbumsByAccountId(userId);
        }

        public async Task<Uri> UploadImage(Guid albumId, byte[] imageBytes)
        {
            ImageUploadResult result = await azureImageRepository.UploadImage(imageBytes);

            await azureImageRepository.EnqueueWorkItem(result.ImageId);
            return result.ImageUri;
        }
    }
}
