using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker1.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        [Column(TypeName = "decimal(18,2)")] // Specifies SQL column type
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }
        public DateTime Date { get; set; }
    }

}
