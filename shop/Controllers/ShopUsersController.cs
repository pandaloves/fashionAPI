using shop.Data;
using shop.models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace shop.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("ShopOrigins")]
    [ApiController]
    public class ShopUsersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserDetailsService _userDetailsService;
        private readonly JwtHandler _jwtHandler;

        public ShopUsersController(DataContext context, IConfiguration configuration, UserDetailsService userDetailsService, JwtHandler jwtHandler)
        {
            _context = context;
            _configuration = configuration;
            _userDetailsService = userDetailsService;
            _jwtHandler = jwtHandler;
        }


        [HttpGet]
        public async Task<ActionResult<List<ShopUser>>> GetShopUsers()
        {
            List<ShopUser> users = await _context.ShopUsers.ToListAsync();

            return Ok(users);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserSignupRequestDto registrationDto)
        {
            var user = new ShopUser
            {
                FirstName = registrationDto.FirstName,
                LastName = registrationDto.LastName,
                Email = registrationDto.Email,
            };

            var passwordHasher = new PasswordHasher<ShopUser>();
            user.Password = passwordHasher.HashPassword(user, registrationDto.Password);

            _context.ShopUsers.Add(user);
            _context.SaveChanges();

            return Ok(new { Success = true, Message = "Registered successfully" });
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserLoginRequestDto request)
        {
            ShopUser user = _context.ShopUsers.SingleOrDefault(u => u.Email == request.Email);

            if (user == null)
            {
                return Unauthorized(new { Success = false, Message = "Invalid credentials" });
            }

            var passwordHasher = new PasswordHasher<ShopUser>();
            var verificationResult = passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);

            if (verificationResult == PasswordVerificationResult.Failed)
            {
                return Unauthorized(new { Success = false, Message = "Invalid credentials" });
            }

            var token = _jwtHandler.GenerateToken(user);

            return Ok(new { Success = true, Token = token });
        }


        [HttpDelete("{userId}")]
        public async Task<ActionResult<List<ShopUser>>> DeleteUsers(int userId)
        {
            var dbUser = await _context.ShopUsers.FindAsync(userId);
            if (dbUser == null)
            {
                return BadRequest("User not found.");
            }

            _context.ShopUsers.Remove(dbUser);
            await _context.SaveChangesAsync();

            return Ok(new { Success = true, Message = "Delete user successfully" });
        }
    }
}
