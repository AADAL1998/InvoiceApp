using InvoiceApp.DataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Controller
{
    public class CategoryManager
    {
        public void AddCategory(Category category)
        {
            if (string.IsNullOrEmpty(category.Name))
            {
                throw new ArgumentException("Category name cannot be empty.");
            }

            category.Id = DataManager.Categories.Count + 1;

            DataManager.Categories.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            Category existingCategory = DataManager.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
            }
            else
            {
                throw new ArgumentException("Category not found.");
            }
        }

        public void DeleteCategory(int categoryId)
        {
            Category category = DataManager.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category != null)
            {
                DataManager.Categories.Remove(category);
            }
            else
            {
                throw new ArgumentException("Category not found.");
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            return DataManager.Categories.FirstOrDefault(c => c.Id == categoryId);
        }

    }
}
