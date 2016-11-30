using System;
using System.Collections.Generic;
using BangazonFinancials.Factories;
using BangazonFinancials.Entities;

namespace BangazonFinancials.Actions
{
    public class ProductRevenueReport
    {
        public static void ReadInput()
        {
            ReportsFactory revenueReportFactory = new ReportsFactory();

            Console.WriteLine("\r\n$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("Product Revenue");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$");

            List<Report> ProductRevenueReports = new List<Report>();

            ProductRevenueReports = revenueReportFactory.GetRevenueByProduct();

            Console.WriteLine("Product               Revenue");

            foreach (Report report in ProductRevenueReports)
            {
                Console.WriteLine($"{report.Name}                ${report.Price}");
            }

            Console.WriteLine("\r\nPress any key to return to main menu");
            Console.ReadLine();
        }
    }
}