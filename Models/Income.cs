using System;
using System.ComponentModel.DataAnnotations;

namespace netmvc.Models
{
    public class Income
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal NetIncome { get; set; }
        public DateTime start { get; set; }
        public string UserId { get; set; }
    }
}