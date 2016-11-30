using System.Collections.Generic;
using BangazonFinancials.Data;
using Microsoft.Data.Sqlite;
using BangazonFinancials.Entities;

namespace BangazonFinancials.Factories
{

    public class ReportsFactory
    {
        public List<Report> GetWeeklyReports()
        {
            BangazonWebConnection Conn = new BangazonWebConnection();
            List<Report> ReportList = new List<Report>();

            string query = $@"
            SELECT Product.Name, Product.Price*COUNT(OrderProduct.ProductId)
            FROM Product
            JOIN OrderProduct ON Product.ProductId = OrderProduct.ProductId
            JOIN 'Order' O ON OrderProduct.OrderId = O.OrderId
            WHERE O.DateCompleted >= datetime('now', '-7 days') AND O.DateCompleted <= datetime('now', 'localtime')
            GROUP BY Product.Name";
            Conn.execute(query, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    ReportList.Add(new Report
                    {
                        Name = reader[0].ToString(),
                        Price = reader.GetDouble(1)
                    });
                }
                //reader.Close();
            });
            return ReportList;
        }

        public List<Report> GetMonthlyReports()
        {
            BangazonWebConnection Conn = new BangazonWebConnection();
            List<Report> ReportList = new List<Report>();

            string query = $@"
            SELECT Product.Name, Product.Price*COUNT(OrderProduct.ProductId)
            FROM Product
            JOIN OrderProduct ON Product.ProductId = OrderProduct.ProductId
            JOIN 'Order' O ON OrderProduct.OrderId = O.OrderId
            WHERE O.DateCompleted >= datetime('now', '-30 days') AND O.DateCompleted <= datetime('now', 'localtime')
            GROUP BY Product.Name";
            Conn.execute(query, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    ReportList.Add(new Report
                    {
                        Name = reader[0].ToString(),
                        Price = reader.GetDouble(1)
                    });
                }
                //reader.Close();
            });
            return ReportList;
        }

        public List<Report> GetQuarterlyReports()
        {
            BangazonWebConnection Conn = new BangazonWebConnection();
            List<Report> ReportList = new List<Report>();

            string query = $@"
            SELECT Product.Name, Product.Price*COUNT(LineItem.ProductId)
            FROM Product
            JOIN LineItem ON Product.ProductId = LineItem.ProductId
            JOIN 'Order' O ON LineItem.OrderId = O.OrderId
            WHERE O.DateCompleted >= datetime('now', '-90 days') AND O.DateCompleted <= datetime('now', 'localtime')
            GROUP BY Product.Name";
            Conn.execute(query, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    ReportList.Add(new Report
                    {
                        Name = reader[0].ToString(),
                        Price = reader.GetDouble(1)
                    });
                }
                //reader.Close();
            });
            return ReportList;
        }
        public List<Report> GetRevenueByCustomer()
        {
            BangazonWebConnection Conn = new BangazonWebConnection();

            List<Report> ReportList = new List<Report>();

            string query = $@"
            SELECT User.FirstName || ' ' || User.LastName AS ""Full Name"", SUM(Product.Price)
            FROM User
            JOIN 'Order' O ON User.UserId = O.UserId
            JOIN OrderProduct ON O.OrderId = OrderProduct.OrderId
            JOIN Product ON OrderProduct.ProductId = Product.ProductId
            GROUP BY ""Full Name""";
            Conn.execute(query, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    ReportList.Add(new Report
                    {
                        Name = reader[0].ToString(),
                        Price = reader.GetDouble(1)
                    });
                }
                //reader.Close();
            });
            return ReportList;
        }

        public List<Report> GetRevenueByProduct()
        {
            BangazonWebConnection Conn = new BangazonWebConnection();

            List<Report> ReportList = new List<Report>();

            string query = $@"
            SELECT Product.Name, SUM(Product.Price)
            FROM Product
            JOIN OrderProduct ON Product.ProductId = OrderProduct.ProductId
            GROUP BY Product.Name";
            Conn.execute(query, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    ReportList.Add(new Report
                    {
                        Name = reader[0].ToString(),
                        Price = reader.GetDouble(1)
                    });
                }
                //reader.Close();
            });
            return ReportList;
        }
    }
}