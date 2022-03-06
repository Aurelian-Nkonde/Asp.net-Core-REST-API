using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommandsAPI.Models
{
    public class Command
    {
        [Key]
        [Required]
        public  int Id { get; set; }  
        [Required]
        [StringLength(200)]
        public string HowTo { get; set; }
        [Required]
        public string Platform { get; set; }
        [Required]
        public string CommandLine { get; set; }

    }
}
