using backend.Domain.Entities;
using backend.API.DTOs;
namespace backend.Application.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<UserProfile?>GetByKeycloakIdAsync(string keycloakId);
        Task<UserProfile?>AddAsync (UserProfile userProfile);
        UserProfile Update(UserProfile userProfile);
        Task SaveChangesAsync();
        
    }
      public interface IUserPostRepository
    {
        Task<UserPost>AddUserPostAsync (UserPost userPost);
        Task<ICollection<UpdateUserPostDto>> GetUserPostAsync(string keycloak);
        Task<List<UpdateUserPostDto>> GetAllUsersPostsAsync();
    }

}