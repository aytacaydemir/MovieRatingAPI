using MovieRatingAPI.DTOs.Requests;
using MovieRatingAPI.DTOs.Responses;
using MovieRatingAPI.Models;

namespace MovieRatingAPI.Services.Comments
{
    public interface ICommentService
    {
        Task<CommentResponse> CreateComment(CommentCreateRequest request, string userId);
    }
}
