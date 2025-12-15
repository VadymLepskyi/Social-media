using backend.Domain.Enums;
using backend.Domain.Entities;
namespace backend.API.DTOs
{
    public class UserProfileResponseDto
    {
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Bio { get; set; }
        public SkillLevel SkillLevel { get; set; }
        public SkillCommunityDto? Community { get; set; }       
        public Guid? Id {get;set;}

    }
   public class UserPostDto
   {
        public string? PostId { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? PostContent { get; set; }
        public string? MediaUrl { get; set; }
        public SkillLevel? SkillLevel { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class SkillCommunityDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public SkillLevel Level { get; set; }
        public DateTime CreatedAt { get; set; }
        }
        public class CommunityPostDto
    {
        public string? PostId { get; set; }
        public string? UserName { get; set; }
        public string? UserId { get; set; }
        public string? Content { get; set; } = string.Empty;
        public string? MediaUrl { get; set; }
        public Guid? SkillCommunityId { get; set; }
        public DateTime CreatedAt { get; set; }
    }


}