using backend.Domain.Entities;
using backend.API.DTOs;
namespace backend.Application.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<UserProfile?>GetByKeycloakIdAsync(string keycloakId);
        Task<UserProfile?>AddAsync (UserProfile userProfile);
        UserProfile Update(UserProfile userProfile);
        Task <UserProfile?> FindUserByDbIdAsync(Guid userId);
        Task SaveChangesAsync();
        
    }
      public interface IUserPostRepository
    {
        Task<UserPost>AddUserPostAsync (UserPost userPost);
        Task<ICollection<UserPostDto>> GetUserPostAsync(string keycloak);
        Task<List<UserPostDto>> GetAllUsersPostsAsync();
        Task<ICollection<UserPostDto>> GetPostByUserId(Guid id);

    }

}