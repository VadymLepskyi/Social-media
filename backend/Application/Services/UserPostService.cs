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
        public async Task<UserPostDto> CreateUserPostAsync(UserPostDto userPostDto, string keycloakId)
        {
            var user = await _profileRepo.GetByKeycloakIdAsync(keycloakId);
            if (user == null)
                throw new Exception("User not found");
            if (string.IsNullOrWhiteSpace(userPostDto.PostContent))
                throw new Exception("Post content is required");

            var post = new UserPost
            {
                PostId = Guid.NewGuid(),
                UserProfileId = user.Id,
                PostContent = userPostDto.PostContent,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _repository.AddUserPostAsync(post);

            // Return a DTO to avoid cycles
            var postDto = new UserPostDto
            {
                PostId = post.PostId.ToString(),
                UserId = user.Id.ToString(),
                UserName = user.UserName,
                PostContent = post.PostContent,
                MediaUrl = post.PostMediaUrl,
                CreatedAt = post.CreatedAt
            };

            return postDto;
        }

        public async Task<ICollection<UserPostDto>> GetUserPostAsync(string keycloakId)
        {
            return await _repository.GetUserPostAsync(keycloakId);
        }
        public async Task<List<UserPostDto>> GetAllUsersPostsAsync()
        {
            return await _repository.GetAllUsersPostsAsync();
        }
         public async Task<ICollection<UserPostDto>>GetPostByUserId(Guid id)
        {
            return await _repository.GetPostByUserId(id);
        }
       
    }
}