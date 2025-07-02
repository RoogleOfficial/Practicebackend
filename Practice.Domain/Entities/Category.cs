using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Domain.Entities
{
    public class Category
    {
        [Key]

        public int Id { get; set; } 
        public required string Name { get; set; }

        public string? Description { get; set; }

        public List<Product> products { get; set; } = [];
        public required DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public required DateTime UpdatedOn { get; set; }
    }
}
