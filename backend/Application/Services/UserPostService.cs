using backend.Application.Interfaces;
using backend.Domain.Entities;
using backend.Infrastructure.Data;
using backend.API.DTOs;


namespace backend.Application.Services
{
    public class UserPostService: IUserPostInterface
    {
        private readonly IUserPostRepository _repository;
        private readonly IUserProfileRepository _profileRepo;
        public UserPostService (IUserPostRepository repository,IUserProfileRepository profileRepo)
        {
            _repository= repository;
            _profileRepo=profileRepo;
        }
        public async Task<UserPost> CreateUserPostAsync(UpdateUserPostDto userPostDto, string keycloakId)
        {  
            var user = await _profileRepo.GetByKeycloakIdAsync(keycloakId);
            if (user == null)
                throw new Exception("User not found");
            if (string.IsNullOrWhiteSpace(userPostDto.PostContent))
                throw new Exception("Post content is required");
            var post= new UserPost
            {
                PostId=Guid.NewGuid(),
                UserProfileId=user.Id,
                PostContent=userPostDto.PostContent,
                CreatedAt=DateTime.UtcNow,
                UpdatedAt=DateTime.UtcNow
            };
            await _repository.AddUserPostAsync(post);
                return post;
        }
        public async Task<ICollection<UserPost>> GetUserPostAsync(string keycloakId)
        {
            return await _repository.GetUserPostAsync(keycloakId);
        }
       
    }
}