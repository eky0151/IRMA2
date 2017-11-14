using IrmaProject.ApplicationService.Interfaces;
using IrmaProject.Repository.AzureStorage.Interfaces;
using IrmaProject.Repository.AzureStorage.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IrmaProject.ApplicationService
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        public async Task<Uri> UploadImage(byte[] imageBytes)
        {
            ImageUploadResult result = await imageRepository.UploadImage(imageBytes);
            await imageRepository.EnqueueWorkItem(result.ImageId);
            return result.ImageUri;
        }
    }
}
