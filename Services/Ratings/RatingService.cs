using Microsoft.EntityFrameworkCore;
using MovieRatingAPI.Data;
using MovieRatingAPI.DTOs.Requests;
using MovieRatingAPI.Models;
using MovieRatingAPI.Services.Movies;
using MovieRatingAPI.Services.Users;

namespace MovieRatingAPI.Services.Ratings
{
    public class RatingService : IRatingService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;

        public RatingService(AppDbContext appDbContext, IMovieService movieService, IUserService userService)
        {
            _appDbContext = appDbContext;
            _movieService = movieService;
            _userService = userService;
        }
        public async Task CreateRating(RatingCreateRequest request, string userId)
        {
            var movie = await _movieService.FindMovieById(request.MovieId);
            var user = await _userService.FindUserById(userId);

            var rating = new Rating
            {
                Value = request.Value,
                UserId = userId,
                MovieId = request.MovieId,
                Movie = movie,
                User = user
            };

            _appDbContext.Add<Rating>(rating);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task UpdateRating(Rating rating, int value)
        {
            rating.Value = value;
            await _appDbContext.SaveChangesAsync();
        }
        
        public async Task<Rating> FindRatingByUserIdAndMovieId(string userId, int movieId)
        {
            return await _appDbContext.Ratings.FirstOrDefaultAsync(
                r => r.MovieId == movieId && r.UserId == userId);
        }
    }
}
