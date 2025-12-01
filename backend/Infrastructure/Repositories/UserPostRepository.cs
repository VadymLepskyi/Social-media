using backend.Application.Interfaces;
using backend.Domain.Entities;
using backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace backend.Infrastructure.Repositories
{
    public class UserPostRepository: IUserPostRepository
    {
        private readonly AppDbContext _context;
        public UserPostRepository(AppDbContext contetx)
        {
            _context=contetx;
        }
        public async Task<UserPost> AddUserPostAsync(UserPost userPost)
        {
           await _context.UserPosts.AddAsync(userPost);
           await _context.SaveChangesAsync();
            return userPost;
        }
        public async Task<UserPost>  GetUserPostAsync(string keycloak)
        {
            // await _context.UserPosts.
            return userPost:
        }
    }
}