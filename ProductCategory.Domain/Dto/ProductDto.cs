using ProductCategory.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace ProductCategory.Domain.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "informe o nome do produto.")]
        [MaxLength(120, ErrorMessage = "O tamanho máximo é de 120 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "informe a descrição do produto.")]
        [MaxLength(500, ErrorMessage = "O tamanho máximo é de 500 caracteres.")]
        public string Description { get; set; }

        public int? CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
