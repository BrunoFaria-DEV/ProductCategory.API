using ProductCategory.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace ProductCategory.Domain.Dto
{
    public class CategoryDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(120, ErrorMessage = "O tamanho máximo é de 120 caracteres.")]
        public string CategoryName { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
