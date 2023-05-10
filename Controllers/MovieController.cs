using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRatingAPI.DTOs.Requests;
using MovieRatingAPI.DTOs.Responses;
using MovieRatingAPI.Services.Movies;

namespace MovieRatingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieResponse>>> GetMovies()
        {
            return await _movieService.FindAll();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<MovieResponse>> PostMovie(MovieCreateRequest request)
        {
            return await _movieService.CreateMovie(request);
        }
       
    }
}

