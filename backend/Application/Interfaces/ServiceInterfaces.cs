using backend.Application.DTOs;
using backend.Domain.Entities;
namespace backend.Application.Interfaces
{
    public interface IUserProfileService
    {
        Task<UserProfile?> PostUserByKeycloakIdAsync(string keycloakId);
        Task<UserProfile> UpdateProfileAsync(
            string keycloakId,
            UpdateUserProfileDto dto,
            IFormFile? avatar
        );

    }
    public interface IFileStorageService
    {
        Task<string> UploadFileAsync(IFormFile file);
    }
}