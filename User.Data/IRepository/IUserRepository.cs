using User.Domain.Entities;

namespace User.Data.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Guid> AddUserAsync(Users due);
        Task<Users> GetUserAsync(Guid id);
        Task<Users> UpdateUserAsync(Users due);
        Task DeleteUserAsync(Guid id);
    }
}
