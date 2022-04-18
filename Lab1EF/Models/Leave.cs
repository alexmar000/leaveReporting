using System.ComponentModel.DataAnnotations;

namespace Lab1EntityFramework.Models
{
    public class Leave
    {
        public Leave()
        {
            CreatedDate = DateTime.Now;
        }

        [Key]
        public int LeaveId { get; set; }
        public Employee Employee { get; set; }
        [Required]
        public LeaveType LeaveType { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
