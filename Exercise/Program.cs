using System;
using System.Globalization;
using Exercise.Entities;
using Exercise.Entities.Enums;

namespace Exercise
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDate);

            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Order order = new Order(status, client);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            OrderItem orderItem;
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                name = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(name, price);

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                orderItem = new OrderItem(quantity, price, product);
                order.AddItem(orderItem);
            }

            Console.WriteLine(order);
        }
    }
}
