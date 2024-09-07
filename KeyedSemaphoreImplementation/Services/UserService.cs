using KeyedSemaphoreImplementation.Data;
using KeyedSemaphoreImplementation.DTOs;
using KeyedSemaphoreImplementation.Entities;
using KeyedSemaphoreImplementation.Semaphore;
using KeyedSemaphoreImplementation.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KeyedSemaphoreImplementation.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private static readonly KeyedSemaphore _keyedSemaphore = new KeyedSemaphore();
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserCreateResponseDTO> Create(UserCreateDTO model)
        {
            if (!await _keyedSemaphore.WaitAsync(model.Email, 500))   
            {
                throw new Exception("Can't add user at the moment!");
            }

            try
            {
                if (await _context.Users.AnyAsync(x => x.Email == model.Email))
                {
                    throw new Exception("User already exists");
                }

                await Task.Delay(5000);

                var user = new User(model.Email, model.Password);

                _context.Users.Add(user);

                await _context.SaveChangesAsync();

                return new UserCreateResponseDTO
                {
                    Id = user.Id,
                    Email = user.Email
                };
            } finally
            {
                _keyedSemaphore.Release(model.Email);
            }
        }
    }
}
