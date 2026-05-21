using Microsoft.EntityFrameworkCore;
using OrderFlow.Data;
using OrderFlow.Interfaces;
using OrderFlow.Models;

namespace OrderFlow.Repositories
{
    public class UserRepository : IUserReadRepository, IUserWriteRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> Add(User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> Update(User user)
        {
            _context.Users.Update(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return false;

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}