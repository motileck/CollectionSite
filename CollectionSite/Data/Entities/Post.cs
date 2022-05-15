namespace CollectionSite.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? PostContent { get; set; }
        public DateTime Created { get; set; }
        public User User { get; set; }
    }
}
