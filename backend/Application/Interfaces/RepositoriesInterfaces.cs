using backend.Domain.Entities;
namespace backend.Application.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<UserProfile?>GetByKeycloakIdAsync(string keycloakId);
        Task<UserProfile?>AddAsync (UserProfile userProfile);
        UserProfile Update(UserProfile userProfile);
        Task SaveChangesAsync();
        
    }
}