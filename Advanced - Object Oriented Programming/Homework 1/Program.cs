using System;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            List<Product> products = new List<Product>();
            products.Add(new Product("Iphone 2", 159.99, 360));
            products.Add(new Product("Banana", 0.49, 180));
            products.Add(new Product("Pizza", 1.99, 95));

            Console.WriteLine("Enter your name:");
            string userName = Console.ReadLine();
            Console.WriteLine("\nAvailable Products:");
            int c = 1;

            foreach(Product p in products)
            {
                Console.WriteLine($"{c++}) {p}");
            }

            Console.WriteLine("\nSelect the product you want to buy by entering its number:");
            int userChoice = int.Parse(Console.ReadLine());

            Product chosenProduct;
            chosenProduct = products[userChoice - 1];

            string invoice = GenerateInvoice(userName, chosenProduct);
            Console.WriteLine("\nInvoice details:");
            Console.WriteLine(invoice);
        }

        static string GenerateInvoice(string customerName, Product product)
        {
            string itemName = product.GetName();
            string itemPrice = product.GetPrice().ToString("C");
            string warrantyEndDate = product.GetWarrantyExpiry().ToString("F");

            return $"Customer: {customerName}\nItem: {itemName}\nPrice: {itemPrice}\nWarranty End Date: {warrantyEndDate}";
        }
    }
