namespace asp_mvc_hello_bookrental.Models
{
    public class BookModel
    {
        // Books class is used to build database schema
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public bool IsRented { get; set; }
    }
}
