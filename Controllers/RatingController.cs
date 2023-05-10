using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRatingAPI.DTOs.Requests;
using MovieRatingAPI.Models;
using MovieRatingAPI.Services.Ratings;
using System.Security.Claims;

namespace MovieRatingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }
 
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Rating>> PostRating(RatingCreateRequest request)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var existingRating = await _ratingService.FindRatingByUserIdAndMovieId(userId, request.MovieId);

            if (existingRating != null)
            {
                await _ratingService.UpdateRating(existingRating, request.Value);
                return Ok();
            }
            else
            {
                await _ratingService.CreateRating(request, userId);
                return Ok(); 
            }
        }
    }
}
