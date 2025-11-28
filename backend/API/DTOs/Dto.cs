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
        public string? PostContent {get; set;}
    }
}