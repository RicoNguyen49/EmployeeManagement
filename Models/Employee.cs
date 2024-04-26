using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [StringLength(100)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Department{ get; set; } = string.Empty;

        [Range(0, 500000)]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

    }
}
