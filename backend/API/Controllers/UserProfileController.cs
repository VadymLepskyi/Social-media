using backend.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

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
            // You probably extract Keycloak ID from JWT:
            var keycloakId = User.FindFirst("preferred_username")?.Value;

            if (keycloakId == null)
                return Unauthorized();

            var user = await _service.UpdateProfileAsync(keycloakId, dto, avatar);

            return Ok(user);
        }
    }
}
