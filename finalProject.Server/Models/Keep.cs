using System;
using System.ComponentModel.DataAnnotations;

namespace finalProject.Models
{
    public class Keep
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Img { get; set; }
        public int Views { get; set; }
        public int Shares { get; set; }
        public int Keeps { get; set; }
        // Virtual
        public Profile Creator { get; set; }
    }
}