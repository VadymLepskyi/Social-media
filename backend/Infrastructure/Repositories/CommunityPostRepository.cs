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
        public async Task<List<CommunityPostDto>> GetUserCommunityPostsAsync(Guid userId)
        {
            // Get the user's community ID
            var userCommunityId = await _context.UserProfiles
                .Where(u => u.Id == userId)
                .Select(u => u.SkillCommunityId)
                .FirstOrDefaultAsync();

            if (userCommunityId == null)
                return new List<CommunityPostDto>();

            // Get posts from that community
            var posts = await _context.CommunityPosts
                .Where(p => p.SkillCommunityId == userCommunityId)
                .Include(p => p.UserProfile)
                .OrderByDescending(p => p.CreatedAt)
                .Select(p => new CommunityPostDto
                {
                    UserId = p.UserProfile!.Id.ToString(),
                    UserName = p.UserProfile!.UserName ?? "Unknown",
                    SkillLevel=p.UserProfile!.SkillLevel,
                    PostId = p.Id.ToString(),
                    PostContent = p.Content,
                    CreatedAt = p.CreatedAt
                })
                .ToListAsync();
            return posts;
        }
    }
    
}