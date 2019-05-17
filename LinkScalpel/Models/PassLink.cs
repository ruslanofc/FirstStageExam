using System.ComponentModel.DataAnnotations;

namespace LinkScalpel.Models
{
    public class PassLink : Link
    {
        public string Password { get; set; }
    }
}
