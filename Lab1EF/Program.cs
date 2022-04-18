using Lab1EntityFramework.Models;
using Lab1EF;
using System.Globalization;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        public enum MenuItems
        {
            CreateReport = 1,
            ReadReports = 2,
            ReportsByMonth = 3
        }


        static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose option:");
            Console.WriteLine("1. Create leave report");
            Console.WriteLine("2. Find leave reports by name");
            Console.WriteLine("3. Find leave reports by month");
            switch ((MenuItems)int.Parse(Console.ReadLine()))
            {
                case MenuItems.CreateReport:
                    CreateLeaveReport();
                    return true;
                case MenuItems.ReadReports:
                    FindPersonLeaveReports();
                    return true;
                case MenuItems.ReportsByMonth:
                    FindReportsByMonth();
                    return true;
                default:
                    return true;
            }
        }
        static void CreateLeaveReport()
        {
            var leaveTypeNames = DataHandler.GetLeaveTypeNames();

            Console.Clear();
            Console.WriteLine("Enter employee id: ");
            var employeeID = Int32.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Enter leave start date with format YYYYMMDD:");
            var startDate = DateTime.ParseExact(Console.ReadLine(), "yyyyMMdd", CultureInfo.InvariantCulture);
            Console.Clear();
            Console.WriteLine("Enter leave end date with format YYYYMMDD:");
            var endDate = DateTime.ParseExact(Console.ReadLine(), "yyyyMMdd", CultureInfo.InvariantCulture);
            Console.Clear();

            Console.WriteLine("Choose leave category:");
            for (int i = 1; i < leaveTypeNames.Count + 1 ; i++)
            {
                Console.WriteLine($"{i}. {leaveTypeNames[i-1]}");
            }
            var leaveCategory = (Int32.Parse(Console.ReadLine())-1);

            DataHandler.CreateLeaveReport(startDate, endDate, employeeID, leaveCategory);
            Console.Clear();
        }
        static void FindPersonLeaveReports()
        {
            Console.Clear();
            Console.WriteLine("Search for user:");
            var searchInput = Console.ReadLine();
            var results = DataHandler.GetLeaveReports(searchInput);
            Console.Clear();
            results.ForEach(r => Console.WriteLine(r));
            Console.WriteLine("Press any key to return");
            Console.ReadKey();
        }
        static void FindReportsByMonth()
        {
            Console.Clear();
            Console.WriteLine("Enter month:");
            var searchInput = Int32.Parse(Console.ReadLine());
            var results = DataHandler.GetLeaveReportsByMonth(searchInput);
            foreach (var r in results)
                Console.WriteLine(r);
            Console.WriteLine("Press any key to return");
            Console.ReadKey();
        }
    }
}

