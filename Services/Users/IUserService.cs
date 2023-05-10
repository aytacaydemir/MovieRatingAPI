using MovieRatingAPI.Models;

namespace MovieRatingAPI.Services.Users
{
    public interface IUserService
    {
        Task<User> FindUserById(string userId);

        Task<User> FindUserByName(string userName);
    }
}
