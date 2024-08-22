namespace BookStore.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public string Publish { get; set; }
        public string Category { get; set; }
        public int Edition { get; set; }
    }
}
