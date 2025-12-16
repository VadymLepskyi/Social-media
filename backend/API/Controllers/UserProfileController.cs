using backend.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using backend.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _service;
        private string? KeycloakId => User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        public UserProfileController(IUserProfileService service)
        {
            _service = service;
        }
        [HttpPost("updateProfile")]
        public async Task<IActionResult> UpdateProfile(
            [FromForm] UserProfileResponseDto dto,
            [FromForm] IFormFile? avatar)
        {
            try
            {               
                Console.WriteLine($"KeycloakId: {KeycloakId}");
                Console.WriteLine($"DTO Name: {dto?.Name}, City: {dto?.City}, Bio: {dto?.Bio}, Skill: {dto?.SkillLevel}");
                Console.WriteLine($"Avatar file: {avatar?.FileName}");
                if (KeycloakId == null) return Unauthorized("Keycloak Id not found");
                if (dto == null)
                    return BadRequest("Missing profile data");
                var user = await _service.UpdateProfileAsync(KeycloakId, dto, avatar);
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateProfile Error: {ex}");
                return StatusCode(500, ex.Message);
            }
        }
        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetProfile()
        {
            if (KeycloakId == null) return Unauthorized("Keycloak Id not found");
            var user= await _service.PostAndGetUserByKeycloakIdAsync(KeycloakId);
            if(user==null) return NotFound ("User not found");
            return Ok(user);
        }
        [Authorize]
        [HttpGet("{userId}")]
        public async Task<IActionResult> FindUserByDbIdAsync(Guid userId)
        {
            if (userId == Guid.Empty)
                return BadRequest("Missing or invalid userId");

            var user = await _service.FindUserByDbIdAsync(userId);

            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }
    }
}
