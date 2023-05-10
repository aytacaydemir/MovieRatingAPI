namespace MovieRatingAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; } = null!;
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
    }
}
