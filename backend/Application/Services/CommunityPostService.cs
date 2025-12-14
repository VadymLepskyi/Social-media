using backend.Application.Interfaces;
using backend.Domain.Entities;
using backend.Infrastructure.Data;
using backend.API.DTOs;


namespace backend.Application.Services
{
    public class CommunityPostService: ICommunityPostInterface
    {
        private readonly ICommunityPostRepository _repository;
        private readonly IUserProfileRepository _profileRepo;
        public CommunityPostService (ICommunityPostRepository repository,IUserProfileRepository profileRepo)
        {
            _repository= repository;
            _profileRepo=profileRepo;
        }
        public async Task<CommunityPostDto> CreateUserPostAsync(CommunityPostDto communityPostDto, string keycloakId)
        {
            var user = await _profileRepo.GetByKeycloakIdAsync(keycloakId);
            if (user == null)
                throw new Exception("User not found");
            if (string.IsNullOrWhiteSpace(communityPostDto.Content))
                throw new Exception("Post content is required");

            var post = new CommunityPost
            {
                Id = Guid.NewGuid(),
                UserProfileId = user.Id,
                Content = communityPostDto.Content,
                CreatedAt = DateTime.UtcNow,
            };

            await _repository.AddUserPostAsync(post);

            // Return a DTO to avoid cycles
            var postDto = new CommunityPostDto
            {
                SkillCommunityId=post.SkillCommunityId,
                Content = post.Content,
                MediaUrl = post.MediaUrl,
            };

            return postDto;
        }
    }
}