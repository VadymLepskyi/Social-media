using backend.Infrastructure.Data;
using backend.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
                var keycloakUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var username = User.FindFirst("preferred_username")?.Value;

                if (keycloakUserId == null)
                    return BadRequest("Missing Keycloak user ID.");
                // It represents the whole collection (table) of users in the database.
                var user = await _context.Users.FindAsync(keycloakUserId);

                if (user == null)
                {
                    user = new User
                    {
                        Id = keycloakUserId,
                        Username = username,
                        CreatedAt = DateTime.UtcNow
                    };

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                }

                return Ok(user);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"SyncUser:{ex}");
                return BadRequest($"Error: {ex.Message}");
            }
            
        }
    }
}