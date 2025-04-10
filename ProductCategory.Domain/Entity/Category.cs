using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductCategory.Domain.Entity
{
    public class Category
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(120)]
        public string CategoryName { get; set; }

        [JsonIgnore]
        public ICollection<Product>? Products { get; set; }
    }
}
