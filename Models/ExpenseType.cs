using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace netmvc.Models
{
    public class ExpenseType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public float Min { get; set; }
        public float Max { get; set; }
        public string UserId { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}