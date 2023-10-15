using System;
using System.Collections.Generic;

namespace Task_1
{
    class Order
    {
        public int OrderId { get; set; }
        public List<Product> Products { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }

        public Order(int orderId, List<Product> products, int quantity, double totalPrice, string status)
        {
            OrderId = orderId;
            Products = products;
            Quantity = quantity;
            TotalPrice = totalPrice;
            Status = status;
        }
    }
}