using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Application.DTOs
{
    public class ProductDto
    {
       
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }

       
        public List<int> CategoryIds { get; set; } = [];

        public int BrandId { get; set; }

        
    }
}
