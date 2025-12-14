using backend.Infrastructure.Data;
using backend.Domain.Entities;
using backend.API.DTOs;
using backend.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using backend.Application.Interfaces;
namespace backend.Application.Services
{
    public class UserSkillCommunity: IUserSkillCommunity
    {
        private readonly AppDbContext _context;
       
        public UserSkillCommunity(AppDbContext context)
        {
            _context=context;
            
        }
        public async Task AssignCommunityAsync(UserProfile user)
        {
            var community = await _context.SkillCommunities
                .FirstOrDefaultAsync(c => c.Level == user.SkillLevel);

            if (community == null)
            {
                community = new SkillCommunity
                {
                    Id = Guid.NewGuid(),
                    Level = user.SkillLevel,
                    Name = user.SkillLevel.ToString(),
                    CreatedAt = DateTime.UtcNow
                };

                _context.SkillCommunities.Add(community);
                await _context.SaveChangesAsync();
            }

            // Assign FK
            user.SkillCommunityId = community.Id;

            // Assign navigation (important for EF tracking)
            user.SkillCommunity = community;
        }

    }
}