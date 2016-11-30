using System;
using System.Collections.Generic;
using BangazonFinancials.Factories;
using BangazonFinancials.Entities;
namespace BangazonFinancials.Actions
{
    public class WeeklyReport
    {
        public static void ReadInput()
        {
            ReportsFactory reportFactory = new ReportsFactory();

            Console.WriteLine("\r\n$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("Weekly Revenue");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$");

            List<Report> WeeklyReports = new List<Report>();
            WeeklyReports = reportFactory.GetWeeklyReports();

            if (WeeklyReports.Count == 0)
            {
                Console.WriteLine("No sales to report.");
            }
            else if (WeeklyReports.Count > 0)
            {
                Console.WriteLine("Product                Revenue");
                foreach (Report report in WeeklyReports)
                {
                    Console.WriteLine($"{report.Name} ${report.Price}");
                }
            }

            Console.WriteLine("\r\nPress any key to return to main menu");
            Console.ReadLine();
        }
    }
}