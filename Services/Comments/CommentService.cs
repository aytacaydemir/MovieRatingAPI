using MovieRatingAPI.Data;
using MovieRatingAPI.DTOs.Requests;
using MovieRatingAPI.DTOs.Responses;
using MovieRatingAPI.Models;
using MovieRatingAPI.Services.Movies;
using MovieRatingAPI.Services.Users;

namespace MovieRatingAPI.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;

        public CommentService(AppDbContext appDbContext, IMovieService movieService, IUserService userService) 
        {
            _appDbContext = appDbContext;
            _movieService = movieService;
            _userService = userService;
        }

        public async Task<CommentResponse> CreateComment(CommentCreateRequest request, string userId)
        {

            var movie = await _movieService.FindMovieById(request.MovieId);
            var user = await _userService.FindUserById(userId);

            if (user == null || movie == null) 
            {
                return null;
            }

            var comment = new Comment
            {
                Description = request.Description,
                CreatedAt = DateTime.Now,
                MovieId = request.MovieId,
                UserId = userId,
                Movie = movie,
                User = user
            };

            _appDbContext.Add<Comment>(comment);
            await _appDbContext.SaveChangesAsync();

            var commentResponse = new CommentResponse(comment.Id, comment.Description, comment.CreatedAt, comment.UserId, comment.MovieId);
            return commentResponse;
        }
    }
}

