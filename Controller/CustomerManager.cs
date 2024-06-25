using InvoiceApp.DataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Controller
{
    public class CustomerManager
    {
        public void AddCustomer(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.Name) || string.IsNullOrEmpty(customer.Email))
            {
                throw new ArgumentException("Customer name and email are required.");
            }

            customer.Id = DataManager.Customers.Count + 1;

            DataManager.Customers.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            Customer existingCustomer = DataManager.Customers.FirstOrDefault(c => c.Id == customer.Id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
                existingCustomer.Email = customer.Email;
                existingCustomer.Address = customer.Address;
                existingCustomer.ContactNumber = customer.ContactNumber;
            }
            else
            {
                throw new ArgumentException("Customer not found.");
            }
        }

        public void DeleteCustomer(int customerId)
        {
            Customer customer = DataManager.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                DataManager.Customers.Remove(customer);
            }
            else
            {
                throw new ArgumentException("Customer not found.");
            }
        }

        public Customer GetCustomerById(int customerId)
        {
            return DataManager.Customers.FirstOrDefault(c => c.Id == customerId);
        }

    }
}
