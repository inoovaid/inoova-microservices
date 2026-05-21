using OrderFlow.Models;

namespace OrderFlow.Interfaces
{
    // Interface responsável apenas por escrita
    public interface IUserWriteRepository
    {
        Task<User> Add(User user);

        Task<User> Update(User user);

        Task<bool> Delete(int id);
    }
}