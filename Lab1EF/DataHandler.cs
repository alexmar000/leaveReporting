using Lab1EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1EF
{
    public static class DataHandler
    {
        public static List<string> GetLeaveTypeNames()
        {
            using EmployeeLeaveContext context = new EmployeeLeaveContext();
            List<string> leaveTypeNames = new List<string>();

            foreach (var leaveType in context.LeaveTypes) 
                leaveTypeNames.Add(leaveType.LeaveTypeName);
            return leaveTypeNames;
        }

        public static void CreateLeaveReport(DateTime startDate, DateTime endDate, int employeeId, int leaveTypeId)
        {
            using EmployeeLeaveContext context = new EmployeeLeaveContext();

            Leave leave = new Leave()
            {
                StartDate = startDate,
                EndDate = endDate,
                LeaveType = context.LeaveTypes.First(l => l.Id == leaveTypeId),
                Employee = context.Employees.First(e => e.Id == employeeId),
            };
            context.Leaves.Add(leave);
            context.SaveChanges();
        }
        public static List<string> GetLeaveReports(string name)
        {
            using EmployeeLeaveContext context = new EmployeeLeaveContext();
            List<string> reportStrings = new();

            var employee = context.Employees.First(n => n.Name.Contains(name));
            var reports = context.Leaves.Include(p => p.LeaveType).Where(l => l.Employee == employee);

            foreach (var report in reports)
                reportStrings.Add($"{report.Employee.Name} -- {report.LeaveType.LeaveTypeName} | {report.StartDate.ToString("MM/dd/yyyy")} - {report.EndDate.ToString("MM/dd/yyyy")}");

            return reportStrings;
        }

        public static List<string> GetLeaveReportsByMonth(int month)
        {
            using EmployeeLeaveContext context = new EmployeeLeaveContext();
            List<string> reportStrings = new();
            var reports = context.Leaves.Include(e => e.Employee).Where(r => r.CreatedDate.Month == month);

            foreach (var report in reports)
                reportStrings.Add($"{report.Employee.Name} - {(report.EndDate - report.StartDate).Days} | Created: {report.CreatedDate.ToString("MM/dd/yyyy")}");
            return reportStrings;
        }
    }
}
