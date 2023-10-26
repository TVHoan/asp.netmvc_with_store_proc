using System;
using System.ComponentModel.DataAnnotations;

namespace netmvc.Dto.Post
{
    public class PostInputUpdate
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
    }
}