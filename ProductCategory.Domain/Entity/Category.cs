using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProductCategory.Domain.Entity
{
    public class Category
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(120)]
        public string CategoryName { get; private set; }

        [JsonIgnore]
        public ICollection<Product>? Products { get; set; }

        public Category(int id, string categoryName)
        {
            Id = id;
            CategoryName = categoryName;
        }

        public Category(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
                throw new ArgumentNullException(nameof(categoryName), "informe o nome da categoria.");

            if (categoryName.Length > 120)
                throw new ArgumentNullException(nameof(categoryName), "O tamanho máximo é de 120 caracteres.");

            CategoryName = categoryName;
        }

        public void Update(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
                throw new ArgumentNullException(nameof(categoryName), "informe o nome da categoria.");

            if (categoryName.Length > 120)
                throw new ArgumentNullException(nameof(categoryName), "O tamanho máximo é de 120 caracteres.");

            this.CategoryName = categoryName;
        }
    }
}
