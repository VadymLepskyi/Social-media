using backend.Domain.Entities;
using backend.API.DTOs;
using backend.Application.Interfaces;
namespace backend.Application.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserSkillCommunity _UserSkillCommunity;
        private readonly IFileStorageService _fileService;
        private readonly IUserProfileRepository _repository;

        public UserProfileService( IFileStorageService fileService, IUserProfileRepository repository, IUserSkillCommunity UserSkillCommunity)
        {
            _UserSkillCommunity = UserSkillCommunity;
            _fileService = fileService;
            _repository= repository;
        } 
        public async Task<UserProfile?> PostAndGetUserByKeycloakIdAsync(string keycloakId)
        {
            return await _repository.GetByKeycloakIdAsync(keycloakId);
        }

        public async Task<UserProfileResponseDto> UpdateProfileAsync(
            string keycloakId,
            UserProfileResponseDto dto,
            IFormFile? avatar)
        {
            var user = await PostAndGetUserByKeycloakIdAsync(keycloakId);

            if (user == null)
            {
                user = new UserProfile
                {
                    Id = Guid.NewGuid(),
                    KeycloakId = keycloakId,
                    CreatedAt = DateTime.UtcNow
                };

                await _repository.AddAsync(user);
            }

            user.UserName = dto.Name ?? user.UserName;
            user.City = dto.City ?? user.City;
            user.Bio = dto.Bio ?? user.Bio;

            user.SkillLevel = dto.SkillLevel;
            await _UserSkillCommunity.AssignCommunityAsync(user);

            if (avatar != null)
            {
                user.ProfilePhotoUrl =
                    await _fileService.UploadFileAsync(avatar);
            }

            user.UpdatedAt = DateTime.UtcNow;
            _repository.Update(user);
            await _repository.SaveChangesAsync();

            // 🔴 MAP TO DTO (critical)
            return new UserProfileResponseDto
            {
                Id = user.Id,
                Name = user.UserName,
                City = user.City,
                Bio = user.Bio,
                SkillLevel = user.SkillLevel,
                Community = user.SkillCommunity == null ? null : new SkillCommunityDto
                {
                    Id = user.SkillCommunity.Id,
                    Name = user.SkillCommunity.Name,
                    Level = user.SkillCommunity.Level,
                    CreatedAt = user.SkillCommunity.CreatedAt
                }
            };
        }


        public async Task<UserProfile?> FindUserByDbIdAsync(Guid userId)
        {
            return await _repository.FindUserByDbIdAsync(userId);
        }
    }

}
