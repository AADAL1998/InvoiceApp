using InvoiceApp.DataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Controller
{
    public class InvoiceManager
    {
        public Invoice GenerateInvoice(int customerId, List<InvoiceItem> items, string paymentOption)
        {
            Customer customer = DataManager.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                throw new ArgumentException("Customer not found.");
            }

            decimal totalAmount = CalculateTotalAmount(items);

            Invoice invoice = new Invoice
            {
                Id = DataManager.Invoices.Count + 1,
                CustomerId = customerId,
                Items = items,
                TotalAmount = totalAmount,
                PaymentOption = paymentOption
            };

            DataManager.Invoices.Add(invoice);

            return invoice;
        }

        private decimal CalculateTotalAmount(List<InvoiceItem> items)
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += item.TotalPrice;
            }
            return total;
        }

        public decimal CalculateDiscount(decimal totalamount)
        {
            if(totalamount>15000)
            {
                return totalamount - 1000;
            }
            else
                return totalamount;
        }

    }
}
