using backend.Application.Interfaces;
using backend.Domain.Entities;
using backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using backend.API.DTOs;
namespace backend.Infrastructure.Repositories
{
    public class CommunityPostRepository: ICommunityPostRepository
    {
        private readonly AppDbContext _context;
        public CommunityPostRepository(AppDbContext contetx)
        {
            _context=contetx;
        }
        public async Task<CommunityPost> AddUserPostAsync(CommunityPost communityPost)
        {
           await _context.CommunityPosts.AddAsync(communityPost);
           await _context.SaveChangesAsync();
            return communityPost;
        }
        public async Task<List<CommunityPostDto>> GetAllUsersPostsAsync()
        {
            var posts = await _context.CommunityPosts
                .Include(p => p.UserProfile)
                .ToListAsync(); 
            return posts.Select(p => new CommunityPostDto
            {
                UserId = p.UserProfile?.Id.ToString() ?? Guid.Empty.ToString(),
                UserName = p.UserProfile?.UserName ?? "Unknown",
                PostId = p.Id.ToString(),
                Content = p.Content,
                CreatedAt = p.CreatedAt
            }).ToList();
        }
        public async Task<ICollection<CommunityPostDto>>GetPostByUserId(Guid id)
        {
            var user= await _context.UserProfiles.Include(u=>u.CommunityPosts).FirstOrDefaultAsync(u=>u.Id==id)
            ?? throw new Exception("User not found");
            return user.CommunityPosts.Select(p=> new CommunityPostDto
            {
                PostId = p.Id.ToString(),
                UserId = p.UserProfileId.ToString(),
                UserName = p.UserProfile?.UserName,
                Content = p.Content,
                MediaUrl = p.MediaUrl,
                CreatedAt = p.CreatedAt
                
            }).ToList();
        }
    }
    
}