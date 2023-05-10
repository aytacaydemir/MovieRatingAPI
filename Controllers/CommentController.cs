using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRatingAPI.DTOs.Requests;
using MovieRatingAPI.DTOs.Responses;
using MovieRatingAPI.Services.Comments;
using System.Security.Claims;

namespace MovieRatingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<CommentResponse>> CreateComment(CommentCreateRequest request)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await _commentService.CreateComment(request, userId);
        }
    }
}
