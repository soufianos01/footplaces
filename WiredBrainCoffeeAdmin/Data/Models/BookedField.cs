using System.ComponentModel.DataAnnotations.Schema;

namespace FootballField.Data.Models
{
    public class BookedField
    {
        public BookedField(string id, decimal price)
        {
            Id = id;
            Price = price;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageFile { get; set; }

        [NotMapped]
        public IFormFile Upload { get; set; }

        public DateTime Edited { get; set; }
    }
}
