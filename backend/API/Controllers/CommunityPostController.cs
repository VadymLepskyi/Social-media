using backend.API.DTOs;
using backend.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using backend.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
namespace backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommunityPostController : ControllerBase
    {
        private readonly ICommunityPostInterface _service;
        private readonly IUserProfileRepository _repository;
        private string? KeycloakId => User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        public CommunityPostController( ICommunityPostInterface service, IUserProfileRepository repository)
        {
            _service = service;
            _repository= repository;
        }
    [Authorize]
    [HttpPost("createPost")]
        public async Task<IActionResult> CreatePost([FromBody] CommunityPostDto dto)
        {
            if (KeycloakId == null)
                return Unauthorized("Keycloak Id not found");

            if (dto == null)
                return BadRequest("Invalid post data");

            try
            {
                var post = await _service.CreateUserPostAsync(dto,KeycloakId);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Authorize]
        [HttpGet("retrieveUsersPosts")]
        public async Task<IActionResult> RetrieveUsersPosts()
        {
            var keycloakId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (keycloakId == null) return Unauthorized();

            var user = await _repository.GetByKeycloakIdAsync(keycloakId);
            if (user == null)
                return NotFound("User profile not found");
            var posts = await _service.GetAllUsersPostsAsync(user.Id);
            return Ok(posts);
        }
    }
}