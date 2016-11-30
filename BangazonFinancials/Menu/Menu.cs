using System.Collections.Generic;
using System;
using BangazonFinancials.Actions;

namespace BangazonFinancials.Menu
{

    public class MenuSystem
    {
        private struct MenuItem
        {
            public string prompt;
            public delegate void MenuAction();
            public MenuAction Action;
        };

        private Dictionary<int, MenuItem> _MenuItems = new Dictionary<int, MenuItem>();

        private bool done = false;

        private void MarkDone()
        {
            done = true;
        }

        public MenuSystem()
        {
            _MenuItems.Add(1, new MenuItem()
            {
                prompt = "Weekly Report",
                Action = WeeklyReport.ReadInput
            });

            _MenuItems.Add(2, new MenuItem()
            {
                prompt = "Monthly Report",
                Action = MonthlyReport.ReadInput
            });

            _MenuItems.Add(3, new MenuItem()
            {
                prompt = "Quarterly Report",
                Action = QuarterlyReport.ReadInput
            });

            _MenuItems.Add(4, new MenuItem()
            {
                prompt = "Customer Revenue Report",
                Action = CustomerRevenueReport.ReadInput
            });

            _MenuItems.Add(5, new MenuItem()
            {
                prompt = "Product Revenue Report",
                Action = ProductRevenueReport.ReadInput
            });

            _MenuItems.Add(6, new MenuItem()
            {
                prompt = "Exit Application",
                Action = MarkDone
            });
        }

        public void Start()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            while (!done)
            {
                ShowMainMenu();
            }
        }

        public void ShowMainMenu()
        {
            Console.Clear();

            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("");
            Console.WriteLine("Bangazon Financial Reports");
            Console.WriteLine("");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");

            // Display each menu item
            foreach (KeyValuePair<int, MenuItem> item in _MenuItems)
            {
                Console.WriteLine($"\r\n{item.Key}. {item.Value.prompt}");
            }

            Console.Write("> ");

            // Read in the user's choice
            try
            {
                int selection;
                Int32.TryParse(Console.ReadLine(), out selection);

                // Based on their choice, execute the appropriate action
                MenuItem menuItem;
                _MenuItems.TryGetValue(selection, out menuItem);
                menuItem.Action();
            }
            catch
            {
                Console.WriteLine("Not an option, bub.");
            }
        }
    }
}