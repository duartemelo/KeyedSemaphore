using KeyedSemaphoreImplementation.Data;
using KeyedSemaphoreImplementation.DTOs;
using KeyedSemaphoreImplementation.Entities;
using KeyedSemaphoreImplementation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KeyedSemaphoreImplementation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        public UserController(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserCreateResponseDTO>> Register(UserCreateDTO request)
        {
            var userDto = await _userService.Create(request);
            return Ok(userDto);
        }
    }
}
