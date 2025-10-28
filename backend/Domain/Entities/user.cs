using backend.Domain.Enums;
namespace backend.Domain.Entities
{
    public class User
    {
        public string Id { get; set; } = string.Empty;
        public string? Username { get; set; }
        public SkillLevel SkillLevel { get; set; } = SkillLevel.Beginner;
        public string? ProfilePhotoUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}