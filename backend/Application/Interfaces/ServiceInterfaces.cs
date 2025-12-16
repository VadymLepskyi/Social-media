using backend.API.DTOs;
using backend.Domain.Entities;
namespace backend.Application.Interfaces
{
    public interface IUserProfileService
    {
        Task<UserProfile?> PostAndGetUserByKeycloakIdAsync(string keycloakId);
        Task<UserProfileResponseDto> UpdateProfileAsync(
            string keycloakId,
            UserProfileResponseDto dto,
            IFormFile? avatar
        );
        Task<UserProfile?> FindUserByDbIdAsync(Guid userId);

    }
    public interface IFileStorageService
    {
        Task<string> UploadFileAsync(IFormFile file);
    }
    public interface IUserPostInterface
    {
        Task<UserPostDto> CreateUserPostAsync (UserPostDto postDto,string keycloakId);
        Task<ICollection<UserPostDto>> GetUserPostAsync(string keycloakId);
        Task<List<UserPostDto>> GetAllUsersPostsAsync();
         Task<ICollection<UserPostDto>>GetPostByUserId(Guid id);
    }
    public interface IUserSkillCommunity
    {
        Task AssignCommunityAsync(UserProfile userProfile );
    }
    public interface ICommunityPostInterface
    {
        Task<CommunityPostDto> CreateUserPostAsync (CommunityPostDto postDto,string keycloakId);
        Task<List<CommunityPostDto>> GetAllUsersPostsAsync(Guid id);
    }
}