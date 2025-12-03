using backend.Application.Interfaces;
using backend.Domain.Entities;
using backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using backend.API.DTOs;
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
        public async Task<ICollection<UpdateUserPostDto>> GetUserPostAsync(string keycloak)
        {
           var user= await _context.UserProfiles.Include(u=>u.Posts).FirstOrDefaultAsync(u=>u.KeycloakId==keycloak)
            ?? throw new Exception("User not found");
           return user.Posts.Select(p => new UpdateUserPostDto
            {
                PostId = p.PostId,
                UserName = user.UserName, 
                PostContent = p.PostContent,
                PostMediaUrl = p.PostMediaUrl,
                CreatedAt = p.CreatedAt
            }).ToList();
        }
    }          
}