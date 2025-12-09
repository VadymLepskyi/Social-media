using backend.Infrastructure.Data;
using backend.Domain.Entities;
using backend.API.DTOs;
using backend.Domain.Enums;
using backend.Application.Interfaces;
namespace backend.Application.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly AppDbContext _context;
        private readonly IFileStorageService _fileService;
        private readonly IUserProfileRepository _repository;

        public UserProfileService(AppDbContext context, IFileStorageService fileService, IUserProfileRepository repository)
        {
            _context = context;
            _fileService = fileService;
            _repository= repository;
        } 
        public async Task<UserProfile?> PostAndGetUserByKeycloakIdAsync(string keycloakId)
        {
            return await _repository.GetByKeycloakIdAsync(keycloakId);
        }

        public async Task<UserProfile> UpdateProfileAsync(
            string keycloakId,
            UpdateUserProfileDto dto,
            IFormFile? avatar
        )
        {
            var user = await PostAndGetUserByKeycloakIdAsync(keycloakId);

            if (user == null)
            {
                user = new UserProfile
                {
                    Id = Guid.NewGuid(),
                    KeycloakId = keycloakId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                await _repository.AddAsync(user);
            }
            else
            {
                user.UserName = dto.Name ?? user.UserName;
                user.City = dto.City ?? user.City;
                user.Bio = dto.Bio ?? user.Bio;
                
                if (!string.IsNullOrEmpty(dto.SkillLevel))
                {
                    if (Enum.TryParse<SkillLevel>(dto.SkillLevel, true, out var level))
                    {
                        user.SkillLevel = level;
                    }
                }
                if (avatar != null)
                {
                    var url = await _fileService.UploadFileAsync(avatar);
                    user.ProfilePhotoUrl = url;
                }
                user.UpdatedAt = DateTime.UtcNow;
                 _repository.Update(user);
            }
            await _repository.SaveChangesAsync();
            return user;
        }
        public async Task<UserProfile?> FindUserByDbIdAsync(Guid userId)
        {
            return await _repository.FindUserByDbIdAsync(userId);
        }
    }

}
