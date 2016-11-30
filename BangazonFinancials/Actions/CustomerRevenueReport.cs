using System;
using System.Collections.Generic;
using BangazonFinancials.Factories;
using BangazonFinancials.Entities;
namespace BangazonFinancials.Actions
{
    public class CustomerRevenueReport
    {
        public static void ReadInput()
        {
            ReportsFactory revenueReportFactory = new ReportsFactory();

            Console.WriteLine("\r\n$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("REVENUE BY CUSTOMER");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$");

            List<Report> CustomerRevenueReports = new List<Report>();

            CustomerRevenueReports = revenueReportFactory.GetRevenueByCustomer();

            Console.WriteLine($"Customer          Revenue");

            foreach (Report report in CustomerRevenueReports)
            {
                Console.WriteLine($"{report.Name,-10}                  ${report.Price,-30}");
            }

            Console.WriteLine("\r\nPress any key to return to main menu");
            Console.ReadLine();
        }
    }
}