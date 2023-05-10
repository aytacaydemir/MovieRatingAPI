using Microsoft.EntityFrameworkCore;
using MovieRatingAPI.Data;
using MovieRatingAPI.DTOs.Requests;
using MovieRatingAPI.DTOs.Responses;
using MovieRatingAPI.Models;

namespace MovieRatingAPI.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _appDbContext;

        public MovieService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public async Task<MovieResponse> CreateMovie(MovieCreateRequest request)
        {
            var movie = new Movie
            {
                Title = request.Title,
                Year = request.Year,
                ImdbRating = request.AverageRating,
            };
            _appDbContext.Movies.Add(movie);
            await _appDbContext.SaveChangesAsync();

            var movieResponse = new MovieResponse(movie.Id, movie.Title, movie.Year, movie.ImdbRating);

            return movieResponse;
        }

        public async Task<List<MovieResponse>> FindAll()
        {
            List<Movie> movies=  await _appDbContext.Movies.ToListAsync();

            List<MovieResponse> movieResponses = movies.Select(m => new MovieResponse
            (m.Id ,m.Title, m.Year, m.ImdbRating)).ToList();

            return movieResponses;
        }
        public async Task<Movie> FindMovieById(int Id)
        {
            return await _appDbContext.Movies.FindAsync(Id);
        }
    }
}
