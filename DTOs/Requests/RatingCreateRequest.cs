namespace MovieRatingAPI.DTOs.Requests
{
    public record RatingCreateRequest(
        int Value,
        int MovieId
        );
}
