using backend.API.DTOs;
using backend.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using backend.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
namespace backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPostController : ControllerBase
    {
        private readonly IUserPostInterface _service;
        private string? KeycloakId => User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        public UserPostController( IUserPostInterface service)
        {
            _service = service;
        }
    [Authorize]
    [HttpPost("createPost")]
        public async Task<IActionResult> CreatePost([FromBody] UpdateUserPostDto dto)
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
        [HttpGet("retrievePosts")]
        public async Task<IActionResult> RetrievePosts()
        {
             if (KeycloakId == null)
                return Unauthorized("Keycloak Id not found");

            var posts= await _service.GetUserPostAsync(KeycloakId);
            return Ok(posts);
        }

         
    }
}