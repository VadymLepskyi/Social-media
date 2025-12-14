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
        private string? KeycloakId => User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        public CommunityPostController( ICommunityPostInterface service)
        {
            _service = service;
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
    }
}