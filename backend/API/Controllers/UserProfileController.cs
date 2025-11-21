using backend.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using backend.Application.Interfaces;

namespace backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _service;

        public UserProfileController(IUserProfileService service)
        {
            _service = service;
        }

        [HttpPost("updateProfile")]
        public async Task<IActionResult> UpdateProfile(
            [FromForm] UpdateUserProfileDto dto,
            [FromForm] IFormFile? avatar
        )
        {
            try
            {
                var keycloakId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                Console.WriteLine($"KeycloakId: {keycloakId}");
                Console.WriteLine($"DTO Name: {dto?.Name}, City: {dto?.City}, Bio: {dto?.Bio}, Skill: {dto?.SkillLevel}");
                Console.WriteLine($"Avatar file: {avatar?.FileName}");

                if (keycloakId == null) return Unauthorized();
                
                if (dto == null)
                    return BadRequest("Missing profile data");
                var user = await _service.UpdateProfileAsync(keycloakId, dto, avatar);

                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateProfile Error: {ex}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
