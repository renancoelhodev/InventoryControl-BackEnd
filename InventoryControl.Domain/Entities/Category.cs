using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryControl.Domain.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "O campo nome da categoria é obrigatório")]
        public string CategoryName { get; set; }

        public ICollection<Product> Products {get; set;}

        
    }
}