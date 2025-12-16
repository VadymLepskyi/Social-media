using backend.Application.Interfaces;
using backend.Domain.Entities;
using backend.Infrastructure.Data;
using backend.API.DTOs;
using Microsoft.EntityFrameworkCore;


namespace backend.Application.Services
{
    public class CommunityPostService: ICommunityPostInterface
    {
        private readonly ICommunityPostRepository _repository;
        private readonly IUserProfileRepository _profileRepo;
        private readonly AppDbContext _context;
        public CommunityPostService (ICommunityPostRepository repository,IUserProfileRepository profileRepo,AppDbContext context)
        {
            _repository= repository;
            _profileRepo=profileRepo;
            _context = context;
        }
        public async Task<CommunityPostDto> CreateUserPostAsync(CommunityPostDto communityPostDto, string keycloakId)
        {
            var user = await _profileRepo.GetByKeycloakIdAsync(keycloakId);
            if (user == null)
                throw new Exception("User not found");
            if (string.IsNullOrWhiteSpace(communityPostDto.PostContent))
                throw new Exception("Post content is required");

            // Get the community the user belongs to
            var community = await _context.SkillCommunities
                .Where(sc => sc.Members.Any(m => m.Id == user.Id))
                .FirstOrDefaultAsync();

            if (community == null)
                throw new Exception("User does not belong to any community");

            var post = new CommunityPost
            {
                Id = Guid.NewGuid(),
                UserProfileId = user.Id,
                Content = communityPostDto.PostContent,
                SkillCommunityId = community.Id, // assign automatically
                CreatedAt = DateTime.UtcNow,
            };

            await _repository.AddUserPostAsync(post);

            return new CommunityPostDto
            {
                SkillCommunityId = post.SkillCommunityId,
                SkillLevel=user.SkillLevel,
                PostContent = post.Content,
                MediaUrl = post.MediaUrl,
                PostId = post.Id.ToString(),
                UserId = user.Id.ToString(),
                UserName = user.UserName
            };
        }
        public async Task<List<CommunityPostDto>> GetAllUsersPostsAsync(Guid id)
        {
            return await _repository.GetUserCommunityPostsAsync( id);
        }
    }
}