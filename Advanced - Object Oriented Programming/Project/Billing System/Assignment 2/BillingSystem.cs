
using System;
using System.Text;

namespace   Assignment_1
{

    class BillingSystem
    {
        private Customer[] _customers;
        private int _customerCount;

        //Properties
        public Customer[] Customers
        {
            get { return _customers; }
        }

        public BillingSystem(int customerCount)
        {
            _customers = new Customer[customerCount];
            _customerCount = 0;
        }
        public BillingSystem()
        {
            _customers = new Customer[100];
            _customerCount = 0;
        }
        //add Customer function 
        public void AddCustomer(Customer customer)
        {
            //check if array is full
            if (_customerCount == _customers.Length)
            {
                Array.Resize(ref _customers, _customers.Length * 2);
            }
            _customers[_customerCount] = customer;
            _customerCount++;
        }
        //override 
        public override string ToString()
        {
            StringBuilder output =  new StringBuilder("");
            foreach (Customer customer in _customers)
            {
                output.AppendLine(customer.ToString());
            }
            return output.ToString();
        }

    }

}