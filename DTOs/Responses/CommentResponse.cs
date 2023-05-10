namespace MovieRatingAPI.DTOs.Responses
{
    public record CommentResponse(
        int Id,
        string Description,
        DateTime CreatedAt,
        string UserId,
        int MovieId
        );
   
}
