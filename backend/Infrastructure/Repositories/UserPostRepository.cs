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
        public async Task<ICollection<UserPostDto>> GetUserPostAsync(string keycloak)
        {
           var user= await _context.UserProfiles.Include(u=>u.Posts).FirstOrDefaultAsync(u=>u.KeycloakId==keycloak)
            ?? throw new Exception("User not found");
           return user.Posts.Select(p => new UserPostDto
            {
                PostId = p.PostId.ToString(),
                UserId = p.UserProfileId.ToString(),
                UserName = p.UserProfile?.UserName,
                PostContent = p.PostContent,
                 SkillLevel=p.UserProfile?.SkillLevel,
                MediaUrl = p.PostMediaUrl,
                CreatedAt = p.CreatedAt
            }).ToList();
        }
        public async Task<List<UserPostDto>> GetAllUsersPostsAsync()
        {
            var posts = await _context.UserPosts
                .Include(p => p.UserProfile)
                .ToListAsync(); 
            return posts.Select(p => new UserPostDto
            {
                UserId = p.UserProfile?.Id.ToString() ?? Guid.Empty.ToString(),
                UserName = p.UserProfile?.UserName ?? "Unknown",
                PostId = p.PostId.ToString(),
                SkillLevel=p.UserProfile?.SkillLevel,
                PostContent = p.PostContent,
                CreatedAt = p.CreatedAt
            }).ToList();
        }
        public async Task<ICollection<UserPostDto>>GetPostByUserId(Guid id)
        {
            var user= await _context.UserProfiles.Include(u=>u.Posts).FirstOrDefaultAsync(u=>u.Id==id)
            ?? throw new Exception("User not found");
            return user.Posts.Select(p=> new UserPostDto
            {
                PostId = p.PostId.ToString(),
                UserId = p.UserProfileId.ToString(),
                UserName = p.UserProfile?.UserName,
                SkillLevel=p.UserProfile?.SkillLevel,
                PostContent = p.PostContent,
                MediaUrl = p.PostMediaUrl,
                CreatedAt = p.CreatedAt
                
            }).ToList();
        }


    }          
}