using IrmaProject.Repository.AzureStorage.Interfaces;
using IrmaProject.Repository.AzureStorage.Model;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IrmaProject.Repository.AzureStorage.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private CloudStorageAccount storageAccount;

        public ImageRepository(string storageConnString)
        {
            storageAccount = CloudStorageAccount.Parse(storageConnString);
        }

        public async Task<ImageUploadResult> UploadImage(byte[] imageBytes)
        {
            // TODO: error handling
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("pictures");
            await container.CreateIfNotExistsAsync();
            var fileId = Guid.NewGuid();
            var blob = container.GetBlockBlobReference(fileId.ToString());
            await blob.UploadFromByteArrayAsync(imageBytes, 0, imageBytes.Length);

            return new ImageUploadResult
            {
                ImageId = fileId,
                ImageUri = blob.Uri
            };
        }

        public async Task EnqueueWorkItem(Guid imageId)
        {
            // TODO: error handling + retry policy
            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference("imageprocess");
            await queue.CreateIfNotExistsAsync();
            var message = new CloudQueueMessage(imageId.ToString());
            await queue.AddMessageAsync(message);
        }

    }
}
