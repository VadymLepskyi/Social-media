using Microsoft.EntityFrameworkCore;
using backend.Infrastructure.Data;
using backend.Domain.Entities;
using backend.Application.DTOs;
using backend.Domain.Enums;
public class UserProfileService : IUserProfileService
{
    private readonly AppDbContext _context;
    private readonly IFileStorageService _fileService;

    public UserProfileService(AppDbContext context, IFileStorageService fileService)
    {
        _context = context;
        _fileService = fileService;
    }

    public async Task<UserProfile?> GetByKeycloakIdAsync(string keycloakId)
    {
        return await _context.UserProfiles
            .FirstOrDefaultAsync(u => u.KeycloakId == keycloakId);
    }

    public async Task<UserProfile> UpdateProfileAsync(
        string keycloakId,
        UpdateUserProfileDto dto,
        IFormFile? avatar
    )
    {
        var user = await GetByKeycloakIdAsync(keycloakId);

        if (user == null)
        {
            user = new UserProfile
            {
                Id = Guid.NewGuid(),
                KeycloakId = keycloakId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            _context.UserProfiles.Add(user);
        }

        user.UserName = dto.Name ?? user.UserName;
        user.City = dto.City ?? user.City;
        user.Bio = dto.Bio ?? user.Bio;
        if (!string.IsNullOrEmpty(dto.SkillLevel) &&
            Enum.TryParse<SkillLevel>(dto.SkillLevel, true, out var skill))
                {
                    user.SkillLevel = skill;
                }

        if (avatar != null)
        {
            var url = await _fileService.UploadFileAsync(avatar);
            user.ProfilePhotoUrl = url;
        }

        user.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        return user;
    }
}
