using System;
using System.Collections.Generic;
using BangazonFinancials.Factories;
using BangazonFinancials.Entities;

namespace BangazonFinancials.Actions
{
    public class QuarterlyReport
    {
        public static void ReadInput()
        {
            ReportsFactory reportFactory = new ReportsFactory();

            Console.WriteLine("\r\n$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("Quartlerly Revenue");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$");

            List<Report> QuarterlyReports = new List<Report>();
            QuarterlyReports = reportFactory.GetQuarterlyReports();

            if (QuarterlyReports.Count == 0)
            {
                Console.WriteLine("No sales.");
            }
            else if (QuarterlyReports.Count > 0)
            {
                Console.WriteLine("Product                Revenue");
                foreach (Report report in QuarterlyReports)
                {
                    Console.WriteLine($"{report.Name}                   ${report.Price}");
                }
            }

            Console.WriteLine("\r\nPress any key to return to main menu");
            Console.ReadLine();
        }
    }
}