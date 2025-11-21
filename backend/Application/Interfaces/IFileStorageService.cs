public interface IFileStorageService
{
    Task<string> UploadFileAsync(IFormFile file);
}
