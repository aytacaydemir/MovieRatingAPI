using Microsoft.EntityFrameworkCore;
using MovieRatingAPI.Data;
using MovieRatingAPI.Models;

namespace MovieRatingAPI.Services.Users
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<User> FindUserById(string userId)
        {
            return await _appDbContext.Users.FindAsync(userId);
        }

        public async Task<User> FindUserByName(string userName) 
        {
            return await _appDbContext.Users.SingleOrDefaultAsync(u => u.Username == userName);
        }
    }
}
