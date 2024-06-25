using InvoiceApp.DataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Controller
{
    public class ProductManager
    {
        public void AddProduct(Product product)
        {
            if (string.IsNullOrEmpty(product.Name) || product.Price <= 0 || product.Quantity < 0)
            {
                throw new ArgumentException("Product attributes are not valid.");
            }

            product.Id = DataManager.Products.Count + 1;

            DataManager.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            Product existingProduct = DataManager.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;
                existingProduct.CategoryId = product.CategoryId;
            }
            else
            {
                throw new ArgumentException("Product not found.");
            }
        }

        public void DeleteProduct(int productId)
        {
            Product product = DataManager.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                DataManager.Products.Remove(product);
            }
            else
            {
                throw new ArgumentException("Product not found.");
            }
        }

        public Product GetProductById(int productId)
        {
            return DataManager.Products.FirstOrDefault(p => p.Id == productId);
        }

    }
}
