using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.DataManagement
{
    public static class DataManager
    {
        public static List<Product> Products { get; set; } = new List<Product>();
        public static List<Category> Categories { get; set; } = new List<Category>();
        public static List<Customer> Customers { get; set; } = new List<Customer>();
        public static List<Invoice> Invoices { get; set; } = new List<Invoice>();

    }
}
