using OrderFlow.Models;

namespace OrderFlow.Interfaces
{
    // Interface responsável apenas por leitura
    public interface IUserReadRepository
    {
        Task<List<User>> GetAll();

        Task<User> GetById(int id);
    }
}