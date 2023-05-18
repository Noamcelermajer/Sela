/*
Main Program:

    Creates a list to store Customer objects.
    Instantiates multiple Customer objects with different names and balances.
    Adds the Customer objects to the list.
    Iterates over the list and prints the details of each customer.
*/
using System.Text;
using System;


namespace Assignment_1
{
    class Program
    {
        private static readonly string[] names =
        {
            "John", "Paul", "Ringo", "George", "Emma", "Liam", "Olivia", "Noah", "Ava", "Isabella",
            "Sophia", "Mia", "Jackson", "Aiden", "Lucas", "Caden", "Harper", "Ethan", "James",
            "Abigail", "Benjamin", "Charlotte", "Elijah", "Michael", "Alexander", "Daniel", "Matthew",
            "Samuel", "Emily", "Amelia", "Henry", "Oliver", "William", "Sebastian", "Evelyn", "Logan",
            "David", "Andrew", "Grace", "Sophia", "Zoe", "Victoria", "Chloe", "Aria", "Grace", "Sarah",
            "Ava", "Jack", "Ella", "Leo", "Scarlett", "Lily", "Lucy", "Mason", "Gabriel", "Ryan",
            "Hannah", "Nathan", "Caleb", "Amelia", "Audrey", "Dylan", "Stella", "Nicholas", "Julia",
            "Anthony", "Max", "Christian", "Landon", "Sofia", "Maya", "Cooper", "Lincoln", "Penelope",
            "Owen", "Daniel", "Layla", "Isaiah", "Zoey"
        };

        static void Main(string[] args)
        {
            var random = new Random();
            BillingSystem billingSystem = new BillingSystem(100);
            
            for (int i = 0; i < 100; i++)
            {
                string randomName = names[random.Next(0, names.Length)];
                Customer customer = new Customer(randomName, random.Next(-1000, 1000));
                billingSystem.AddCustomer(customer);
            }
            System.Console.WriteLine(billingSystem);
        }
    }
}