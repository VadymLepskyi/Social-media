namespace backend.API.DTOs
{
    public class UpdateUserProfileDto
    {
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Bio { get; set; }
        public string? SkillLevel { get; set; }
        public Guid? Id {get;set;}
       
    }
   public class UserPostDto
   {
        public string? PostId { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? PostContent { get; set; }
        public string? MediaUrl { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }

}