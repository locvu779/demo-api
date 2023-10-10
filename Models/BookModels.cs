using System.ComponentModel.DataAnnotations;

namespace API1.Models
{
    public class BookModels
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Title { get; set; }
        public string? Descriptions { get; set; }
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Range(0, 100)]
        public int Quantity { get; set; }
    }
}
