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
        public SkillLevel SkillLevel { get; set; } 

        public string? ProfilePhotoUrl { get; set; }
        public ICollection<UserPost> Posts {get;set;}= new List<UserPost>();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public UserProfile()
        {
            SkillLevel=SkillLevel.Beginner;
        }

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
}