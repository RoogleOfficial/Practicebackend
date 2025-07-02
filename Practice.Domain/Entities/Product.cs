using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Domain.Entities
{
    public class Product
    {
        [Key]

        public int Id { get; set; } 


        public required string Name { get; set; }

        public required string Type { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }


        public List<Category> Categories { get; set; } = [];


        public int BrandId { get; set; }

        [ForeignKey("BrandId")]
        public required Brand Brand { get; set; }

        public required DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public required DateTime UpdatedOn { get; set; }
    }
}
