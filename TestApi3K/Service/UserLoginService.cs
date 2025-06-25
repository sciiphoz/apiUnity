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
            var users = await _context.Users.OrderByDescending(x => x.level1score + x.level2score + x.level3score).Take(10).ToListAsync();

            return new OkObjectResult(new
            {
                users,
                status = true
            });
        }

        public async Task<IActionResult> GetUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            return new OkObjectResult(new
            {
                user,
                status = true
            });
        }
        public async Task<IActionResult> CreateNewUserAsync(CreateNewUser newUser)
        {
            var user = new Users()
            {
                Login = newUser.Login,
                Password = newUser.Password,
            };

            if (user == null)
            {
                return new ConflictObjectResult(new { status = false });
            }
            else
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return new OkObjectResult(new { user, status = true });
            }
        }

        public async Task<IActionResult> LoginAsync(LoginModel user)
        {
            Users currentUser = await _context.Users.Where(x => x.Login == user.Login && x.Password == user.Password).SingleAsync();

            if (currentUser == null) return new ConflictObjectResult(new { status = false });

            return new OkObjectResult(new { user = currentUser, status = true });
        }

        public async Task<IActionResult> AddScoreAsync(int userId, int value, int lvl)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user != null)
            {
                switch (lvl)
                {
                    case 1:
                        if (user.level1score < value)
                        {
                            user.level1score = value;
                            break;
                        }
                        else break;
                    case 2:
                        if (user.level2score < value)
                        {
                            user.level2score = value;
                            break;
                        }
                        else break;
                    case 3:
                        if (user.level3score < value)
                        {
                            user.level3score = value;
                            break;
                        }
                        else break;
                    default:
                        break;
                }
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return new OkObjectResult(new { status = true });
        }

    }
}
