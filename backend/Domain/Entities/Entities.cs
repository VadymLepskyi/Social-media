using backend.Domain.Enums;
using backend.API.DTOs;
namespace backend.Domain.Entities
{
    public class UserProfile
    {
        public Guid Id { get; set; }
        public string KeycloakId  { get; set; } = string.Empty;
        public string? UserName { get; set; }
        public string? City {get;set;}
        public string? Bio {get;set;}
        public SkillLevel SkillLevel { get; set; } 
        public Guid? SkillCommunityId{get;set;}
        public SkillCommunity? SkillCommunity{get;set;}
        public ICollection<CommunityPost>? CommunityPosts {get;set;}=new List<CommunityPost>();

        public ICollection<UserPost> Posts {get;set;}= new List<UserPost>();
        public string? ProfilePhotoUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    } 
    public class UserPost
    {
        public Guid PostId { get; set; }
        public Guid UserProfileId{get;set;}
        public UserProfile ? UserProfile { get; set; }
        public string? PostContent {get; set;}
        public string? PostMediaUrl{ get;set;}
        public DateTime  CreatedAt {get;set;}= DateTime.UtcNow;
        public DateTime  UpdatedAt {get;set;}= DateTime.UtcNow;
    }
    public class SkillCommunity
    {
        public Guid Id {get;set;}
        public string? Name{get;set;}
        public SkillLevel Level{get;set;}
        public ICollection<CommunityPost> CommunityPosts {get;set;}= new List<CommunityPost>();
        public ICollection<UserProfile> Members {get;set;} = new List<UserProfile>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
    }
    public class CommunityPost
    {
         public Guid Id { get; set; }

        public Guid UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }

        public Guid? SkillCommunityId { get; set; }
        public SkillCommunity? SkillCommunity { get; set; }

        public string? Content { get; set; }
        public string? MediaUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
            
    }
}