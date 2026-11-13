namespace NCCS_Lab_MVC.Models
{
    // Q12/Q16: simple Product model used by MVC Controller and Web API Controller
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
