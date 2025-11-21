using backend.Infrastructure.Data;
using backend.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
        _context = context;
        }
        [HttpPost("sync")]
        public async Task<IActionResult> SyncUser()
        {
            try
            {
                 // User refers to the currently authenticated user provided by ASP.NET Core.
                var keycloakUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (keycloakUserId == null)
                    return BadRequest("Missing Keycloak user ID");
                // Sync user in UserProfiles table
                var existingProfile = await _context.UserProfiles
                    .FirstOrDefaultAsync(u => u.KeycloakId == keycloakUserId);
                if (existingProfile == null)
                {
                    var newProfile = new UserProfile
                    {
                        KeycloakId = keycloakUserId,
                    };
                    _context.UserProfiles.Add(newProfile);
                    await _context.SaveChangesAsync();
                }
                return Ok();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"SyncUser:{ex}");
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}   