using System;
using System.ComponentModel.DataAnnotations;

namespace finalProject.Models
{
    public class Vault
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsPrivate { get; set; }
        // Virtual
        public Profile Creator { get; set; }
    }
}