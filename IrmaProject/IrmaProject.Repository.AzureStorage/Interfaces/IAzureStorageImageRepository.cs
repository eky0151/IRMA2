using IrmaProject.Dto.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IrmaProject.Repository.AzureStorage.Interfaces
{
    public interface IAzureStorageImageRepository
    {
        Task<ImageUploadResult> UploadImage(byte[] imageBytes);
        Task EnqueueWorkItem(Guid imageId);
    }
}
