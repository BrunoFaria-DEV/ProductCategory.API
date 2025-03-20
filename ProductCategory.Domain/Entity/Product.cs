using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategory.Domain.Entity
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Product(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Product(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void SetName( string name, string description ) 
        {
            this.Name = name;
        }

        public void SetDescription(string name, string description)
        {
            this.Description = description;
        }
    }
}
