using backend.Domain.Enums;
namespace backend.Domain.Entities
{
    public class UserProfile
    {
        public Guid Id { get; set; }
        public string KeycloakId  { get; set; } = string.Empty;
        public string? UserName { get; set; }
        public string? City {get;set;}
        public string? Bio {get;set;}
        public SkillLevel SkillLevel { get; set; } = SkillLevel.Beginner;

        public string? ProfilePhotoUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}