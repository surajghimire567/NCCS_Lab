namespace NCCS_Lab_MVC.Models
{
    // Q17: Entity used with EF Core for CRUD operations
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
