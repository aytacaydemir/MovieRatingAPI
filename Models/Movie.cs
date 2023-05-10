namespace MovieRatingAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Year { get; set; }
        public string? ImdbRating { get; set; }
        public List<Rating>? Ratings { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
