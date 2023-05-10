namespace MovieRatingAPI.DTOs.Requests
{
    public record MovieCreateRequest(
        string Title,
        int Year,
        string AverageRating
        );
}
