using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Products
    {
        
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public double? Price { get; set; }
        public string? Image { get; set; }   
        public string? Description { get; set; }
        public double? Rating { get; set; }
    }
}
