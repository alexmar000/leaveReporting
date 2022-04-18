using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1EntityFramework.Models
{
    public class EmployeeLeaveContext : DbContext
    { 
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-IGUCUFA\SQLEXPRESS;Initial Catalog=EmployeeLeaveDb;Integrated Security=true");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Employee erik = new Employee { Name = "Erik Johansson", Id = 1 };
            Employee sofie = new Employee { Name = "Sofie Silvstedt", Id = 2 };
            Employee mikael = new Employee { Name = "Mikael Forsgren", Id = 3 };

            LeaveType sickness = new LeaveType { LeaveTypeName = "Sickness", Id = 1 };
            LeaveType parental = new LeaveType { LeaveTypeName = "Parental", Id = 2 };
            LeaveType vacation = new LeaveType { LeaveTypeName = "Vacation", Id = 3 };
            LeaveType other = new LeaveType { LeaveTypeName = "Other", Id = 4 };


            modelBuilder.Entity<Employee>().HasData(
            erik,
            sofie,
            mikael
            );

            modelBuilder.Entity<LeaveType>().HasData(
                sickness,
                parental,
                vacation,
                other
                );

            modelBuilder.Entity<Leave>().HasData(
                new  { EmployeeId = erik.Id, LeaveId = 1, LeaveTypeId = sickness.Id, StartDate = new DateTime(2020, 11, 23), EndDate = new DateTime(2020, 11, 30), CreatedDate = new DateTime(2018, 3, 24) },
                new  { EmployeeId = erik.Id, LeaveId = 2, LeaveTypeId = vacation.Id, StartDate = new DateTime(2020, 06, 11), EndDate = new DateTime(2020, 07, 11), CreatedDate = new DateTime(2018, 3, 24) },
                new  { EmployeeId = mikael.Id, LeaveId = 3, LeaveTypeId = parental.Id, StartDate = new DateTime(2021, 2, 3), EndDate = new DateTime(2021, 2, 5), CreatedDate = new DateTime(2018, 6, 22) },
                new  { EmployeeId = sofie.Id, LeaveId = 4, LeaveTypeId = vacation.Id, StartDate = new DateTime(2022, 7, 14), EndDate = new DateTime(2022, 8, 16), CreatedDate = new DateTime(2018, 1, 12) }
                );
        }
    }
}
