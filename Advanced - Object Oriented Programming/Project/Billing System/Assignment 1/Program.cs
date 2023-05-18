/*
Main Program:

    Creates a list to store Customer objects.
    Instantiates multiple Customer objects with different names and balances.
    Adds the Customer objects to the list.
    Iterates over the list and prints the details of each customer.
*/



namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer[] customers = new Customer[5];
            for (int i = 0; i < customers.Length; i++)
            {
                customers[i] = new Customer("Customer " + i);
            }
            foreach (Customer customer in customers)
            {
                customer.PrintDetails();
            }
        }
    }
}