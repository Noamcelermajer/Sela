/*
Data members:

    name (string): Represents the customer's name.
    balance (double): Indicates the due amount for the customer.
    id (integer): A unique identifier assigned to each customer.

Static variables:

    lastCreatedId (integer): Tracks the last created id to ensure uniqueness.


*/

namespace Assignment_1
{
    public class Customer
    {
        private string _name { get; set; }
        private double _balance { get; set; }
        private int _id { get; set; }
        private static int _lastCreatedId { get; set; }
        
        //Properties
        public string Name { get => _name; set => _name = value; }
        public double Balance { get => _balance; set => _balance = value; }
        public int Id { get => _id; set => _id = value; }

        //2 constructors
        public Customer(string name)
        {
            _name = name;
            _balance = 0;
            _id = ++_lastCreatedId;
        }
        public Customer(string name , double balance)
        {
            _name = name;
            _balance = balance;
            _id = ++_lastCreatedId;
        }

        //Methods 
        //PrintDetails(): Prints the customer's name, balance, and id.
        public void PrintDetails()
        {
            System.Console.WriteLine($"Name: {_name}, Balance: {_balance}, Id: {_id}");
        }
    }
}