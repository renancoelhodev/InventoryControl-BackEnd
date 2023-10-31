using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryControl.Domain.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "O campo produto é obrigatório")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo nome produto deve ter no mínimo 3 caracteres e no máximo 30")]
        public string ProductName { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category {get; set; }


    }
}