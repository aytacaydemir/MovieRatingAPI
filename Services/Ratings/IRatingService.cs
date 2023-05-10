using MovieRatingAPI.DTOs.Requests;
using MovieRatingAPI.Models;

namespace MovieRatingAPI.Services.Ratings
{
    public interface IRatingService
    {
        Task CreateRating(RatingCreateRequest request, string userId);
        Task UpdateRating(Rating rating, int value);
        Task<Rating> FindRatingByUserIdAndMovieId(string userId, int movieId);
    
}
}
