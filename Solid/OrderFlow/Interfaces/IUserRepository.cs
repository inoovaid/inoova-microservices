using OrderFlow.Models;

namespace OrderFlow.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();

        Task<User> GetById(int id);

        Task<User> Add(User user);

        Task<User> Update(User user);

        Task<bool> Delete(int id);
    }
}