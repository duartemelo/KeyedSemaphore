using KeyedSemaphoreImplementation.DTOs;

namespace KeyedSemaphoreImplementation.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserCreateResponseDTO> Create(UserCreateDTO model);
    }
}