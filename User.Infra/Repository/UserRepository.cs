using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Data.IRepository;
using User.Domain.Entities;
using User.Infra.Context;

namespace User.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _dbContext;
        public UserRepository(UserContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddUserAsync(Users user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task DeleteUserAsync(Guid id)
        {
            Users? user = await _dbContext.Users.FindAsync(id);

            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("user not found with the specified ID.", nameof(id));
            }
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            List<Users>? data = await _dbContext.Users.ToListAsync();

            if (data.Any())
            {
                throw new ArgumentException("No users found");
            }
            else
            {
                return data;
            }
        }

        public async Task<Users> GetUserAsync(Guid id)
        {
            Users? user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            
            if (user == null)
            {
                throw new ArgumentException("user not found with the specified ID.", nameof(id));
            }

            return user;
        }

        public async Task<Users> UpdateUserAsync(Users user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user not found with the specified ID.", nameof(user));
            }

            user.UpdatedAt = DateTime.UtcNow;
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}
