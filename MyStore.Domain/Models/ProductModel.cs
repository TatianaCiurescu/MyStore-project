using System.ComponentModel.DataAnnotations;

namespace MyStore.Domain.Models
{
    public class ProductModel
    {
        public int Productid { get; set; }
        [Required]
        [MinLength(4)]
        public string Productname { get; set; }
        public int Supplierid { get; set; }
        public int Categoryid { get; set; }
        [Required]
        public decimal Unitprice { get; set; }
        public bool Discontinued { get; set; }
    }
}
