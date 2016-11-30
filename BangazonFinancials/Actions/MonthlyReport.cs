
using System;
using System.Collections.Generic;
using BangazonFinancials.Factories;
using BangazonFinancials.Entities;

namespace BangazonFinancials.Actions
{
    public class MonthlyReport
    {
        public static void ReadInput()
        {
            ReportsFactory reportFactory = new ReportsFactory();

            Console.WriteLine("\r\n$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("Montly Report");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$");

            List<Report> MonthlyReports = new List<Report>();
            MonthlyReports = reportFactory.GetMonthlyReports();

            if (MonthlyReports.Count == 0)
            {
                Console.WriteLine("No sales to report.");
            }
            else if (MonthlyReports.Count > 0)
            {
                Console.WriteLine("Product                       Revenue");
                foreach (Report report in MonthlyReports)
                {
                    Console.WriteLine($"{report.Name}                ${report.Price}");
                }
            }

            Console.WriteLine("\r\nPress any key to return to main menu");
            Console.ReadLine();
        }
    }
}