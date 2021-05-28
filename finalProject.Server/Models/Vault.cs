using System;
using System.ComponentModel.DataAnnotations;

namespace finalProject.Models
{
    public class Vault
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Description { get; set; }
        [Required]
        public string CreatorId { get; set; }
        public string Name { get; set; }
        public bool? IsPrivate { get; set; }
        public Profile Creator { get; set; }
    }
}