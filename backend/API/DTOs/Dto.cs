namespace backend.API.DTOs
{
    public class UpdateUserProfileDto
    {
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Bio { get; set; }
        public string? SkillLevel { get; set; }
       
    }
    public class UpdateUserPostDto
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public string? UserName { get; set; } = string.Empty;
        public string? PostContent { get; set; }
        public string? PostMediaUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}