namespace MovieRatingAPI.DTOs.Requests
{
    public record CommentCreateRequest(
        string Description,
        int MovieId);
}
