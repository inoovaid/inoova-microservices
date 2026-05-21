using OrderFlow.DTOs;
using OrderFlow.Interfaces;
using OrderFlow.Models;

namespace OrderFlow.Services
{
    public class UserService : IUserService
    {
        private readonly IUserReadRepository _readRepository;

        private readonly IUserWriteRepository _writeRepository;

        public UserService(
        IUserReadRepository readRepository,
        IUserWriteRepository writeRepository)
            {
                _readRepository = readRepository;
                _writeRepository = writeRepository;
            }

        public async Task<List<UserResponseDto>> GetAll()
        {
            var users = await _readRepository.GetAll();

            return users.Select(user => new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            }).ToList();
        }

        public async Task<UserResponseDto> GetById(int id)
        {
            var user = await _readRepository.GetById(id);

            if (user == null)
                return null;

            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public async Task<UserResponseDto> Create(CreateUserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email
            };

            var createdUser = await _writeRepository.Add(user);

            return new UserResponseDto
            {
                Id = createdUser.Id,
                Name = createdUser.Name,
                Email = createdUser.Email
            };
        }

        public async Task<bool> Delete(int id)
        {
            return await _writeRepository.Delete(id);
        }
    }
}