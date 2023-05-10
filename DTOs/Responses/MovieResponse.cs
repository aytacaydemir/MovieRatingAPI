namespace MovieRatingAPI.DTOs.Responses
{
    public record MovieResponse(
        int Id,
        string Title,
        int Year,
        string ImdbRating
        );
}
