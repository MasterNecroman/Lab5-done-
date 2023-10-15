using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1
{
    class Shop : ISearchable
    {
        private List<User> users;
        private List<Product> products;
        private List<Order> orders;
        private int nextUserId;
        private int nextOrderId;

        public Shop()
        {
            users = new List<User>();
            products = new List<Product>();
            orders = new List<Order>();
            nextUserId = 1;
            nextOrderId = 1;
        }

        public void AddUser(User user)
        {
            user.UserId = nextUserId++;
            users.Add(user);
        }

        public User GetUser(string login)
        {
            return users.Find(u => u.Login == login);
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public Product GetProduct(string name)
        {
            return products.Find(p => p.Name == name);
        }

        public void PlaceOrder(Order order)
        {
            order.OrderId = GetNextOrderId();
            orders.Add(order);
        }

        public Order GetOrder(int orderId)
        {
            return orders.Find(o => o.OrderId == orderId);
        }

        public List<Product> SearchByPrice(double maxPrice)
        {
            return products.FindAll(p => p.Price <= maxPrice);
        }

        public List<Product> SearchByCategory(string category)
        {
            return products.FindAll(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }

        public List<Product> SearchByRating(int rating)
        {
            return products.FindAll(p => p.Rating >= rating);
        }

        public User AuthenticateUser(string login, string password)
        {
            return users.FirstOrDefault(user => user.Login == login && user.Password == password);
        }

        public int GetNextOrderId()
        {
            return nextOrderId++;
        }
    }
}