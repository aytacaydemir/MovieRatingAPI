using Microsoft.AspNetCore.Mvc;
using MovieRatingAPI.DTOs.Requests;
using MovieRatingAPI.DTOs.Responses;
using MovieRatingAPI.Models;

namespace MovieRatingAPI.Services.Movies
{
    public interface IMovieService
    {
        Task<Movie> FindMovieById(int Id);
        Task<List<MovieResponse>> FindAll();
        Task<MovieResponse> CreateMovie(MovieCreateRequest request);
    }
}
