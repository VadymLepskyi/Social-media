using Microsoft.AspNetCore.Http;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;
using backend.Application.Interfaces;
namespace backend.Application.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IMinioClient _minioClient;
        private readonly string _bucketName = "user-profile-images";

        public FileStorageService()
        {
            _minioClient = new MinioClient()
                .WithEndpoint("localhost:9000")
                .WithCredentials("minioadmin", "minioadmin")
                .Build();

            // Ensure bucket exists
            CreateBucketIfNotExistsAsync().Wait();
        }

        private async Task CreateBucketIfNotExistsAsync()
        {
            bool found = await _minioClient.BucketExistsAsync(
                new BucketExistsArgs().WithBucket(_bucketName)
            );

            if (!found)
            {
                await _minioClient.MakeBucketAsync(
                    new MakeBucketArgs().WithBucket(_bucketName)
                );
            }
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            using var stream = file.OpenReadStream();

            await _minioClient.PutObjectAsync(
                new PutObjectArgs()
                    .WithBucket(_bucketName)
                    .WithObject(fileName)
                    .WithStreamData(stream)
                    .WithObjectSize(file.Length)
                    .WithContentType(file.ContentType)
            );

            return $"http://localhost:9000/{_bucketName}/{fileName}";
        }
    }
}

