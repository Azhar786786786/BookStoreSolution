namespace BookStoreWebApi.DTOs
{
    public class BookRequestDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
    }
}
