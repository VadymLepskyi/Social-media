using backend.API.DTOs;
using backend.Domain.Entities;
namespace backend.Application.Interfaces
{
    public interface IUserProfileService
    {
        Task<UserProfile?> PostAndGetUserByKeycloakIdAsync(string keycloakId);
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
    public interface IUserPostInterface
    {
        Task<UserPost> CreateUserPostAsync (UpdateUserPostDto postDto,string keycloakId);
        Task<ICollection<UpdateUserPostDto>> GetUserPostAsync(string keycloakId);
    }
}