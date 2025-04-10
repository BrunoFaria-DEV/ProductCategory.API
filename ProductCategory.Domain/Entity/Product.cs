using System.ComponentModel.DataAnnotations;

namespace ProductCategory.Domain.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(120)]
        public string Name { get; private set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; private set; }

        public int? CategoryId { get; private set; }
        public Category? Category { get; private set; }

        public Product(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Product(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "informe o nome do produto.");

            if (name.Length > 120)
                throw new ArgumentNullException(nameof(name), "O tamanho máximo é de 120 caracteres.");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException(nameof(description), "informe a descrição do produto.");

            if (description.Length > 500)
                throw new ArgumentNullException(nameof(description), "O tamanho máximo é de 500 caracteres.");

            Name = name;
            Description = description;
        }

        public void Update(string name, string description) 
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "informe o nome do produto.");

            if (name.Length > 120)
                throw new ArgumentNullException(nameof(name), "O tamanho máximo é de 120 caracteres.");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException(nameof(description), "informe a descrição do produto.");

            if (description.Length > 500)
                throw new ArgumentNullException(nameof(description), "O tamanho máximo é de 500 caracteres.");

            this.Name = name;
            this.Description = description;
        }

    }
}
