using System;
using System.Collections.Generic;

namespace Task_1
{
    class Program
    {
        static Shop shop = new Shop();
        static User currentUser = null;

        static void Main(string[] args)
        {
            InitializeShop();

            while (true)
            {
                if (currentUser == null)
                {
                    DisplayMainMenu();
                }
                else
                {
                    DisplayUserMenu();
                }
            }
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Log in");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        LogIn();
                        break;
                    case 2:
                        Register();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number for your choice.");
            }
        }

        static void LogIn()
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            currentUser = shop.AuthenticateUser(username, password);

            if (currentUser != null)
            {
                Console.WriteLine($"Welcome, {currentUser.Login}!");
            }
            else
            {
                Console.WriteLine("Authentication failed. Please check your username and password.");
            }
        }

        static void Register()
        {
            Console.Write("Enter a new username: ");
            string newUsername = Console.ReadLine();
            Console.Write("Enter a new password: ");
            string newPassword = Console.ReadLine();

            User newUser = new User(newUsername, newPassword);
            shop.AddUser(newUser);
            Console.WriteLine("Registration successful. You can now log in with your new account.");
        }

        static void InitializeShop()
        {
          
            shop.AddProduct(Product.Pistol);
            shop.AddProduct(Product.Shotgun);
            shop.AddProduct(Product.Rifle);
            shop.AddProduct(Product.Milk);
            shop.AddProduct(Product.CannedFood);
            shop.AddProduct(Product.Water);
            shop.AddProduct(Product.Medicine);
            shop.AddProduct(Product.Ammo9mm);
            shop.AddProduct(Product.Ammo12gauge);
            shop.AddProduct(Product.Tools);

          
            User user1 = new User("user1", "password1");
            User user2 = new User("user2", "password2");
            shop.AddUser(user1);
            shop.AddUser(user2);
        }

        static void DisplayUserMenu()
        {
            Console.WriteLine("\nUser Menu:");
            Console.WriteLine("1. Display cheap products");
            Console.WriteLine("2. Display products by category");
            Console.WriteLine("3. Display highly rated products (by rating)");
            Console.WriteLine("4. Show purchase history");
            Console.WriteLine("5. Create Order");
            Console.WriteLine("6. Log out");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        List<Product> cheapProducts = shop.SearchByPrice(12.0);
                        DisplayProducts(cheapProducts);
                        break;
                    case 2:
                        Console.Write("Enter a category: ");
                        string category = Console.ReadLine();
                        List<Product> categoryProducts = shop.SearchByCategory(category);
                        DisplayProducts(categoryProducts);
                        break;
                    case 3:
                        DisplayHighlyRatedProducts();
                        break;
                    case 4:
                        DisplayPurchaseHistory();
                        break;
                    case 5:
                        CreateOrder();
                        break;
                    case 6:
                        currentUser = null;
                        DisplayMainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number for your choice.");
            }
        }

        static void DisplayHighlyRatedProducts()
        {
            Console.Write("Enter the minimum rating to search for: ");
            if (int.TryParse(Console.ReadLine(), out int rating))
            {
                List<Product> highlyRatedProducts = shop.SearchByRating(rating);
                DisplayProducts(highlyRatedProducts);
            }
            else
            {
                Console.WriteLine("Invalid rating. Please enter a valid number.");
            }
        }

        static void DisplayPurchaseHistory()
        {
            if (currentUser != null)
            {
                List<Product> purchaseHistory = currentUser.PurchaseHistory;
                Console.WriteLine("\nPurchase History:");
                DisplayProducts(purchaseHistory);
            }
            else
            {
                Console.WriteLine("You need to log in to view your purchase history.");
            }
        }

        static void DisplayProducts(List<Product> products)
        {
            Console.WriteLine("\nProducts:");
            if (products.Count == 0)
            {
                Console.WriteLine("No products found.");
            }
            foreach (Product product in products)
            {
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: ${product.Price}");
                Console.WriteLine($"Description: {product.Description}");
                Console.WriteLine($"Category: {product.Category}");
                Console.WriteLine($"Rating: {product.Rating}");
                Console.WriteLine();
            }
        }

        static void CreateOrder()
        {
            if (currentUser != null)
            {
                List<Product> cart = new List<Product>();
                Console.WriteLine("Add products to your cart (enter product name, one per line). Enter 'done' to complete the order.");
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input.ToLower() == "done")
                    {
                        break;
                    }
                    Product product = shop.GetProduct(input);
                    if (product != null)
                    {
                        cart.Add(product);
                    }
                    else
                    {
                        Console.WriteLine("Product not found. Please enter a valid product name.");
                    }
                }

                if (cart.Count > 0)
                {
                    Console.Write("Enter the delivery address: ");
                    string address = Console.ReadLine();

                    
                    Order newOrder = CreateOrderRecursively(currentUser.UserId, cart, 0, 0, address);
                    shop.PlaceOrder(newOrder);
                    currentUser.PurchaseHistory.AddRange(cart);
                    Console.WriteLine("Order placed successfully.");
                }
                else
                {
                    Console.WriteLine("No products in your cart. Order not placed.");
                }
            }
            else
            {
                Console.WriteLine("You need to log in to create an order.");
            }
        }

        static Order CreateOrderRecursively(int userId, List<Product> cart, int index, double totalPrice, string address)
        {
            if (index == cart.Count)
            {
                return new Order(userId, cart, cart.Count, totalPrice, address);
            }
            else
            {
                totalPrice += cart[index].Price;
                return CreateOrderRecursively(userId, cart, index + 1, totalPrice, address);
            }
        }
    }
}