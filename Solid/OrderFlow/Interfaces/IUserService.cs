using OrderFlow.DTOs;

namespace OrderFlow.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponseDto>> GetAll();

        Task<UserResponseDto> GetById(int id);

        Task<UserResponseDto> Create(CreateUserDto dto);

        Task<bool> Delete(int id);
    }
}