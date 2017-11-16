using IrmaProject.ApplicationService.Interfaces;
using IrmaProject.Domain.Entities;
using IrmaProject.Dto.Model;
using IrmaProject.Repository.AzureStorage.Interfaces;
using IrmaProject.Repository.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public async Task<Guid> AddImage(Image image)
        {
            image.Deleted = false;
            image.UrlFriendlyName = Regex.Replace(image.Name, "[^a-zA-Z0-9_]+", "", RegexOptions.Compiled).Replace(" ", String.Empty);
            var guid = await databaseImageRepository.AddImage(image);
            await albumRepository.UpdateAlbumModifiedDate(image.Album.Id);
            return guid;
        }

        public async Task<Guid> CreateAlbumWithUserId(Guid userId, string albumName)
        {
            var account = await userRepository.FindByIdentifier(userId);
            var newAlbum = new Album
            {
                Account = account,
                Name = albumName,
                Deleted = false,
                UrlFriendlyName = Regex.Replace(albumName, "[^a-zA-Z0-9_]+", "", RegexOptions.Compiled).Replace(" ", String.Empty)
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

        public async Task<Album> FindAlbumByName(string albumName)
        {
            return await albumRepository.GetAlbumByName(albumName.Replace(" ",String.Empty));
        }

        public async Task<int> GetAlbumFilesCountById(Guid albumId)
        {
            return (await databaseImageRepository.GetImageIdsByAlbumId(albumId)).Count();
        }

        public async Task<IEnumerable<Album>> GetAlbumsByUserId(Guid userId)
        {
            return await albumRepository.GetAlbumsByAccountId(userId);
        }

        public async Task<IEnumerable<Album>> GetAlbumsByUsername(string username)
        {
            var user = await userRepository.FindByUserName(username);
            var albums = await albumRepository.GetAlbumsByAccountId(user.Id);
            return albums;
        }

        public async Task<Dictionary<Guid, int>> GetAlbumsFilesCountByIds(IEnumerable<Guid> ids)
        {
            var resultDictionary = new Dictionary<Guid, int>();
            for(int i = 0; i< ids.Count(); i++)
            {
                var imageIds = await databaseImageRepository.GetImageIdsByAlbumId(ids.ElementAt(i));

                resultDictionary.Add(ids.ElementAt(i), imageIds.Count());
            }
            return resultDictionary;
        }

        public async Task<IEnumerable<Image>> GetImagesByAlbumId(Guid albumId)
        {
            return await databaseImageRepository.GetImagesByAlbumId(albumId);
        }

        public async Task<IEnumerable<Image>> GetImagesByAlbumName(string albumName)
        {
            var friendlyAlbumName = Regex.Replace(albumName, "[^a-zA-Z0-9_]+", "", RegexOptions.Compiled).Replace(" ", String.Empty);
            var album = (await albumRepository.GetAlbumByName(friendlyAlbumName));
            var result = await databaseImageRepository.GetImagesByAlbumId(album.Id);
            return result;
        }

        public async Task<ImageUploadResult> UploadImage(Guid albumId, byte[] imageBytes)
        {
            ImageUploadResult result = await azureImageRepository.UploadImage(imageBytes);

           // await azureImageRepository.EnqueueWorkItem(result.ImageId);
            return result;
        }
    }
}
