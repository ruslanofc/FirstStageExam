using System;
using System.ComponentModel.DataAnnotations;

namespace LinkScalpel.Models
{
    public class TimeLink : Link
    {
        public DateTime Time { get; set; }
    }
}
