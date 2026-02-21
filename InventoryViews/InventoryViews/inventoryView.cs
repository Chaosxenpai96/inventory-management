using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Services;

namespace Inventoryview
{
    public class InventoryView
    {
        private InventoryService inventoryService;

        public InventoryView()
        {
            inventoryService = new InventoryService();
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== Inventory Management ===");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. Reset Inventory");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayInventory();
                        break;

                    case "2":
                        UpdateStock();
                        break;

                    case "3":
                        inventoryService.ResetInventory();
                        Console.WriteLine("Inventory has been reset.");
                        break;

                    case "4":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        private void DisplayInventory()
        {
            string[,] inventory = inventoryService.GetInventory();

            Console.WriteLine("\nCurrent Inventory:");
            for (int i = 0; i < inventory.GetLength(1); i++)
            {
                Console.WriteLine($"{i + 1}. {inventory[0, i]} - Stock: {inventory[1, i]}");
            }
        }

        private void UpdateStock()
        {
            DisplayInventory();

            Console.Write("Select product number to update: ");
            int productNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter new stock quantity: ");
            string newStock = Console.ReadLine();

            inventoryService.UpdateStock(productNumber - 1, newStock);

            Console.WriteLine("Stock updated successfully.");
        }
    }
}
