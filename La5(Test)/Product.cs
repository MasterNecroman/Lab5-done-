using System;
using System.Collections.Generic;

namespace Task_1
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Rating { get; set; }

        public Product(string name, double price, string description, string category, int rating)
        {
            Name = name;
            Price = price;
            Description = description;
            Category = category;
            Rating = rating;
        }

        
        public static Product Pistol => new Product("Pistol", 499.99, "Compact 9mm pistol", "Firearms", 5);
        public static Product Shotgun => new Product("Shotgun", 799.99, "12-gauge shotgun", "Firearms", 5);
        public static Product Rifle => new Product("Rifle", 1499.99, "5.56mm rifle", "Firearms", 5);

        
        public static Product Milk => new Product("Milk", 2.99, "Pasteurized milk", "Groceries", 2);
        public static Product CannedFood => new Product("Canned Food", 1.99, "Canned vegetables", "Groceries", 3);
        public static Product Water => new Product("Water", 0.99, "Bottled drinking water", "Groceries", 3);

        
        public static Product Medicine => new Product("Medicine", 9.99, "Pain reliever", "Medicines", 5);

        
        public static Product Ammo9mm => new Product("9mm Ammo", 19.99, "9mm ammunition", "Ammunition", 4);
        public static Product Ammo12gauge => new Product("12 Gauge Ammo", 24.99, "12-gauge shotgun shells", "Ammunition", 4);

        
        public static Product Tools => new Product("Tools", 29.99, "Basic toolkit", "Tools", 2);
    }
}