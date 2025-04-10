using ProductCategory.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategory.Domain.Dto
{
    public class CategoryDto
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(120, ErrorMessage = "O tamanho máximo é de 120 caracteres.")]
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
