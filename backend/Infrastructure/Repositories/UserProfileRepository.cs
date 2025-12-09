using backend.Application.Interfaces;
using backend.Domain.Entities;
using backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace backend.Infrastructure.Repositories
{
    public class UserProfileRepository :IUserProfileRepository
    {
        private readonly AppDbContext _context;

        public UserProfileRepository(AppDbContext context)
        {
            _context=context;
        }

        public async Task<UserProfile?>GetByKeycloakIdAsync(string KeycloakId)
        {
            return await _context.UserProfiles.FirstOrDefaultAsync(u=>u.KeycloakId==KeycloakId);   
        }
        public async Task<UserProfile?> AddAsync( UserProfile userProfile)
        {
             await _context.UserProfiles.AddAsync(userProfile);
             return userProfile;
        }
        public UserProfile Update(UserProfile userProfile)
        {
            _context.UserProfiles.Update(userProfile);
            return userProfile;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<UserProfile?> FindUserByDbIdAsync(Guid userId)
        {
            var user= await _context.UserProfiles.FindAsync(userId);
            return user;
        }
    }

}