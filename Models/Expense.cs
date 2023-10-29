using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace netmvc.Models
{
    public class Expense
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Imageurl { get; set; }
        [Required]
        public int Type { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public string UserId { get; set; }
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
    }
}