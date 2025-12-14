using backend.Application.Interfaces;
using backend.Domain.Entities;
using backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using backend.API.DTOs;
namespace backend.Infrastructure.Repositories
{
      public class SkillCommunityPostRepository: IUserSkillCommunityRepository
    {
        private readonly AppDbContext _context;
        public SkillCommunityPostRepository(AppDbContext contetx)
        {
            _context=contetx;
        }
        public async Task<CommunityPost> AddUserPostAsync(CommunityPost communityPost)
        {
           await _context.CommunityPosts.AddAsync(communityPost);
           await _context.SaveChangesAsync();
            return communityPost;
        }
    }
}