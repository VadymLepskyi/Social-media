using backend.Application.DTOs;
using backend.Domain.Entities;
public interface IUserProfileService
{
    Task<UserProfile?> GetByKeycloakIdAsync(string keycloakId);

    Task<UserProfile> UpdateProfileAsync(
        string keycloakId,
        UpdateUserProfileDto dto,
        IFormFile? avatar
    );
}
