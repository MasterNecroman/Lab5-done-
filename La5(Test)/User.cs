using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1
{
    class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Product> PurchaseHistory { get; set; }
        public int UserId { get; internal set; }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
            PurchaseHistory = new List<Product>();
        }

        public void AddToPurchaseHistory(Product product)
        {
            PurchaseHistory.Add(product);
        }

       
        public List<Product> SearchByPrice(double maxPrice)
        {
            return PurchaseHistory
                .Where(product => product.Price <= maxPrice)
                .ToList();
        }

        public List<Product> SearchByCategory(string category)
        {
            return PurchaseHistory
                .Where(product => product.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Product> SearchByRating(int minRating)
        {
            return PurchaseHistory
                .Where(product => product.Rating >= minRating)
                .ToList();
        }
    }
}