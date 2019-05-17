using System;
using System.ComponentModel.DataAnnotations;

namespace LinkScalpel.Models
{
    public class Link
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        
    }
}
