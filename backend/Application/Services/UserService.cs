using backend.Application.Interfaces;
using backend.Infrastructure.Data;
using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Applications.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context) => _context = context;
        public async Task<User?> GetUserByIdAsync(string id) => await _context.Users.FindAsync(id);
        public async Task<List<User>> GetAllUsersAsync() => await _context.Users.ToListAsync();
        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }


    }
}
