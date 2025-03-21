using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TestApi3K.DataBaseContext;
using TestApi3K.Interfaces;
using TestApi3K.Model;
using TestApi3K.Requests;

namespace TestApi3K.Service
{
    public class UserLoginService : IUsersLoginsService
    {
        private readonly ContextDb _context;

        public UserLoginService(ContextDb context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            return new OkObjectResult(new
            {
                data = new { users = users },
                status = true
            });
        }

        public async Task<IActionResult> GetUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            return new OkObjectResult(new
            {
                data = new { user = user },
                status = true
            });
        }

        public async Task<IActionResult> GetAllSkinsAsync()
        {
            var skins = await _context.Skins.ToListAsync();

            return new OkObjectResult(new
            {
                data = new { skins = skins },
                status = true
            });
        }

        public async Task<IActionResult> GetUsersSkinsAsync(int userId)
        {
            var userskin = await _context.UsersSkins.Where(x => x.id_User == userId).ToListAsync();

            return new OkObjectResult(new
            {
                data = new { userskin = userskin },
                status = true
            });
        }

        public async Task<IActionResult> CreateNewUserAsync(CreateNewUser newUser)
        {
            var user = new Users()
            {
                Login = newUser.Login,
                Password = newUser.Password,
                Currency = 50
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new OkObjectResult(new { status = true });
        }

        public async Task<IActionResult> LoginAsync(LoginModel user)
        {
            Users currentUser = await _context.Users.Where(x => x.Login == user.Login && x.Password == user.Password).SingleAsync();

            if (currentUser == null) return new ConflictObjectResult(new { status = true });

            return new OkObjectResult(new { user = currentUser, status = true });
        }

        public async Task<IActionResult> AddCurrencyAsync(int userId, int value)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user != null)
            {
                user.Currency += value;
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return new OkObjectResult(new { status = true });
        }
        public async Task<IActionResult> DepleteCurrencyAsync(int userId, int value)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user != null)
            {
                user.Currency -= value;
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return new OkObjectResult(new { status = true });
        }
        public async Task<IActionResult> BuySkinAsync(int userId, int skinId) { 
            UsersSkins userskin;
            var user = await _context.Users.FindAsync(userId);
            var skin = await _context.Skins.FindAsync(skinId);

            if (user.Currency >= skin.Price)
            {
                if (!_context.UsersSkins.Where(x => x.id_Skin == skinId && x.id_User == userId).Any())
                {
                    userskin = new UsersSkins
                    {
                        id_User = userId,
                        id_Skin = skinId,
                    };

                    await DepleteCurrencyAsync(userId, skin.Price);

                    await _context.UsersSkins.AddAsync(userskin);
                    await _context.SaveChangesAsync();

                    return new OkObjectResult(new { status = true });
                }
            }

            return new ConflictObjectResult(new { status = false });
        }
    }
}
