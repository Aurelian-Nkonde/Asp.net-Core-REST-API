using System;
using System.ComponentModel.DataAnnotations;

namespace CommandsAPI.Dtos
{
    public class CommandCreateDto
    {

        [Required]
        [MaxLength(200)]        
        public string HowTo { get;set; }
        [Required]
        public string Platform { get;set; }
        [Required]
        public string CommandLine { get;set; }
    }
}