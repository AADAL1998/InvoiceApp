using InvoiceApp.Controller;
using InvoiceApp.DataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp
{
    class Program
    {
        static ProductManager productManager = new ProductManager();
        static CategoryManager categoryManager = new CategoryManager();
        static CustomerManager customerManager = new CustomerManager();
        static InvoiceManager invoiceManager = new InvoiceManager();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Invoicing System");
            Console.WriteLine();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Choose an option between 1 to 5");
                Console.WriteLine("1. Product Management");
                Console.WriteLine("2. Category Management");
                Console.WriteLine("3. Customer Management");
                Console.WriteLine("4. Generate Invoice");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ProductManagement();
                        break;
                    case "2":
                        CategoryManagement();
                        break;
                    case "3":
                        CustomerManagement();
                        break;
                    case "4":
                        GenerateInvoice();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number again from 1 to 5.");
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Exiting the program...");
        }

        static void ProductManagement()
        {
            bool backToMainMenu = false;
            while (!backToMainMenu)
            {
                Console.WriteLine("Product Management Menu:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. View All Products");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Enter your choice (1-5): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        UpdateProduct();
                        break;
                    case "3":
                        DeleteProduct();
                        break;
                    case "4":
                        ViewAllProducts();
                        break;
                    case "5":
                        backToMainMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number again from 1 to 5.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddProduct()
        {
            try
            {
                Console.WriteLine("Adding a New Product:");

                Product product = new Product();
                Console.Write("Enter Product Name: ");
                product.Name = Console.ReadLine();

                Console.Write("Enter Product Description: ");
                product.Description = Console.ReadLine();

                Console.Write("Enter Product Price: ");
                product.Price = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter Product Quantity: ");
                product.Quantity = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Category ID: ");
                product.CategoryId = Convert.ToInt32(Console.ReadLine());

                productManager.AddProduct(product);
                Console.WriteLine("Product added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void UpdateProduct()
        {
            try
            {
                Console.WriteLine("Updating a Product:");

                Console.Write("Enter Product ID to Update: ");
                int productId = Convert.ToInt32(Console.ReadLine());

                Product product = productManager.GetProductById(productId);
                if (product != null)
                {
                    Console.Write("Enter New Product Name (leave empty to keep current): ");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newName))
                    {
                        product.Name = newName;
                    }

                    Console.Write("Enter New Product Description (leave empty to keep current): ");
                    string newDescription = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newDescription))
                    {
                        product.Description = newDescription;
                    }

                    Console.Write("Enter New Product Price (leave empty to keep current): ");
                    string newPriceStr = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newPriceStr))
                    {
                        product.Price = Convert.ToDecimal(newPriceStr);
                    }

                    Console.Write("Enter New Product Quantity (leave empty to keep current): ");
                    string newQuantityStr = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newQuantityStr))
                    {
                        product.Quantity = Convert.ToInt32(newQuantityStr);
                    }

                    Console.Write("Enter New Category ID (leave empty to keep current): ");
                    string newCategoryIdStr = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newCategoryIdStr))
                    {
                        product.CategoryId = Convert.ToInt32(newCategoryIdStr);
                    }

                    productManager.UpdateProduct(product);
                    Console.WriteLine("Product updated successfully!");
                }
                else
                {
                    Console.WriteLine($"Product with ID {productId} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void DeleteProduct()
        {
            try
            {
                Console.WriteLine("Deleting a Product:");

                Console.Write("Enter Product ID to Delete: ");
                int productId = Convert.ToInt32(Console.ReadLine());

                productManager.DeleteProduct(productId);
                Console.WriteLine("Product deleted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewAllProducts()
        {
            Console.WriteLine("List of Products:");

            foreach (var product in DataManager.Products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}, Quantity: {product.Quantity}, Category ID: {product.CategoryId}");
            }
        }

        static void CategoryManagement()
        {
            bool backToMainMenu = false;
            while (!backToMainMenu)
            {
                Console.WriteLine("Category Management Menu:");
                Console.WriteLine("1. Add Category");
                Console.WriteLine("2. Update Category");
                Console.WriteLine("3. Delete Category");
                Console.WriteLine("4. View All Categories");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Enter your choice (1-5): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddCategory();
                        break;
                    case "2":
                        UpdateCategory();
                        break;
                    case "3":
                        DeleteCategory();
                        break;
                    case "4":
                        ViewAllCategories();
                        break;
                    case "5":
                        backToMainMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddCategory()
        {
            try
            {
                Console.WriteLine("Adding a New Category:");

                Category category = new Category();
                Console.Write("Enter Category Name: ");
                category.Name = Console.ReadLine();

                Console.Write("Enter Category Description: ");
                category.Description = Console.ReadLine();

                categoryManager.AddCategory(category);
                Console.WriteLine("Category added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void UpdateCategory()
        {
            try
            {
                Console.WriteLine("Updating a Category:");

                Console.Write("Enter Category ID to Update: ");
                int categoryId = Convert.ToInt32(Console.ReadLine());

                Category category = categoryManager.GetCategoryById(categoryId);
                if (category != null)
                {
                    Console.Write("Enter New Category Name (leave empty to keep current): ");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newName))
                    {
                        category.Name = newName;
                    }

                    Console.Write("Enter New Category Description (leave empty to keep current): ");
                    string newDescription = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newDescription))
                    {
                        category.Description = newDescription;
                    }

                    categoryManager.UpdateCategory(category);
                    Console.WriteLine("Category updated successfully!");
                }
                else
                {
                    Console.WriteLine($"Category with ID {categoryId} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void DeleteCategory()
        {
            try
            {
                Console.WriteLine("Deleting a Category:");

                Console.Write("Enter Category ID to Delete: ");
                int categoryId = Convert.ToInt32(Console.ReadLine());

                categoryManager.DeleteCategory(categoryId);
                Console.WriteLine("Category deleted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewAllCategories()
        {
            Console.WriteLine("List of Categories:");

            foreach (var category in DataManager.Categories)
            {
                Console.WriteLine($"ID: {category.Id}, Name: {category.Name}, Description: {category.Description}");
            }
        }

        static void CustomerManagement()
        {
            bool backToMainMenu = false;
            while (!backToMainMenu)
            {
                Console.WriteLine("Customer Management Menu:");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Update Customer");
                Console.WriteLine("3. Delete Customer");
                Console.WriteLine("4. View All Customers");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Enter your choice (1-5): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddCustomer();
                        break;
                    case "2":
                        UpdateCustomer();
                        break;
                    case "3":
                        DeleteCustomer();
                        break;
                    case "4":
                        ViewAllCustomers();
                        break;
                    case "5":
                        backToMainMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddCustomer()
        {
            try
            {
                Console.WriteLine("Adding a New Customer:");

                Customer customer = new Customer();
                Console.Write("Enter Customer Name: ");
                customer.Name = Console.ReadLine();

                Console.Write("Enter Customer Email: ");
                customer.Email = Console.ReadLine();

                Console.Write("Enter Customer Address: ");
                customer.Address = Console.ReadLine();

                Console.Write("Enter Customer Contact Number: ");
                customer.ContactNumber = Console.ReadLine();

                customerManager.AddCustomer(customer);
                Console.WriteLine("Customer added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void UpdateCustomer()
        {
            try
            {
                Console.WriteLine("Updating a Customer:");

                Console.Write("Enter Customer ID to Update: ");
                int customerId = Convert.ToInt32(Console.ReadLine());

                Customer customer = customerManager.GetCustomerById(customerId);
                if (customer != null)
                {
                    Console.Write("Enter New Customer Name (leave empty to keep current): ");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newName))
                    {
                        customer.Name = newName;
                    }

                    Console.Write("Enter New Customer Email (leave empty to keep current): ");
                    string newEmail = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newEmail))
                    {
                        customer.Email = newEmail;
                    }

                    Console.Write("Enter New Customer Address (leave empty to keep current): ");
                    string newAddress = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newAddress))
                    {
                        customer.Address = newAddress;
                    }

                    Console.Write("Enter New Customer Contact Number (leave empty to keep current): ");
                    string newContactNumber = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newContactNumber))
                    {
                        customer.ContactNumber = newContactNumber;
                    }

                    customerManager.UpdateCustomer(customer);
                    Console.WriteLine("Customer updated successfully!");
                }
                else
                {
                    Console.WriteLine($"Customer with ID {customerId} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void DeleteCustomer()
        {
            try
            {
                Console.WriteLine("Deleting a Customer:");

                Console.Write("Enter Customer ID to Delete: ");
                int customerId = Convert.ToInt32(Console.ReadLine());

                customerManager.DeleteCustomer(customerId);
                Console.WriteLine("Customer deleted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewAllCustomers()
        {
            Console.WriteLine("List of Customers:");

            foreach (var customer in DataManager.Customers)
            {
                Console.WriteLine($"ID: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}, Address: {customer.Address}, Contact Number: {customer.ContactNumber}");
            }
        }

        static void GenerateInvoice()
        {
            try
            {
                Console.WriteLine("Generating Invoice:");

                Console.Write("Enter Customer ID: ");
                int customerId = Convert.ToInt32(Console.ReadLine());

                Customer customer = customerManager.GetCustomerById(customerId);
                if (customer == null)
                {
                    Console.WriteLine($"Customer with ID {customerId} not found.");
                    return;
                }

                List<InvoiceItem> invoiceItems = new List<InvoiceItem>();

                bool addMoreItems = true;
                while (addMoreItems)
                {
                    Console.WriteLine("Add Product to Invoice:");
                    Console.Write("Enter Product ID: ");
                    int productId = Convert.ToInt32(Console.ReadLine());

                    Product product = productManager.GetProductById(productId);
                    if (product == null)
                    {
                        Console.WriteLine($"Product with ID {productId} not found.");
                        continue;
                    }

                    Console.Write("Enter Quantity: ");
                    int quantity = Convert.ToInt32(Console.ReadLine());

                    InvoiceItem invoiceItem = new InvoiceItem
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        UnitPrice = product.Price
                    };

                    invoiceItems.Add(invoiceItem);

                    Console.Write("Add another product to invoice? (yes/no): ");
                    string addAnother = Console.ReadLine();
                    addMoreItems = addAnother.Equals("yes", StringComparison.OrdinalIgnoreCase);
                }

                Console.Write("Enter Payment Option: ");
                string paymentOption = Console.ReadLine();

                // Generate invoice
                Invoice invoice = invoiceManager.GenerateInvoice(customerId, invoiceItems, paymentOption);

                Console.WriteLine("Invoice Generated Successfully:");
                Console.WriteLine($"Invoice ID: {invoice.Id}");
                Console.WriteLine($"Customer Name: {customer.Name}");
                Console.WriteLine("Invoice Items:");
                foreach (var item in invoice.Items)
                {
                    Console.WriteLine($"Product ID: {item.ProductId}, Quantity: {item.Quantity}, Unit Price: {item.UnitPrice:C}, Total Price: {item.TotalPrice:C}");
                }
                decimal AmoutnAfterDiscount=invoiceManager.CalculateDiscount(invoice.TotalAmount);
                Console.WriteLine($"Total Amount: {AmoutnAfterDiscount:C}");
                Console.WriteLine($"Payment Option: {invoice.PaymentOption}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

}
