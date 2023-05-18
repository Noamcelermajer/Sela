
using System;
using System.Text;

namespace   Assignment_1
{

    class BillingSystem
    {
        private Customer[] _customers;
        private int _customerCount;

        public BillingSystem(int customerCount)
        {
            if (customerCount < null)
            {
                _customerCount = 100;
            }
            _customers = new Customer[customerCount];
            _customerCount = customerCount;
        }
        //add Customer function 
        public void AddCustomer(Customer customer)
        {
            //check if array is full
            if (_customerCount == _customers.Count() - 1 )
            {
                //create  new array bigger by 1 than current array
                 _customers = new Customer[_customers.Count() + 1];
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