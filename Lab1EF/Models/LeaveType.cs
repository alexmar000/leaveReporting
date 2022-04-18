using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1EntityFramework.Models
{
    public class LeaveType
    {
        [Key]
        public int Id { get; set; }
        public string LeaveTypeName { get; set; }
    }
}
