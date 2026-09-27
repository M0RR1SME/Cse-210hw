namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Order 1: USA Customer 
            Address address1 = new Address("123 Main Street", "Seattle", "WA", "USA");
            Customer customer1 = new Customer("Alice Johnson", address1);
            Order order1 = new Order(customer1);

            order1.AddProduct(new Product("Wireless Ergonomic Mouse", "M-100", 29.99m, 2));
            order1.AddProduct(new Product("Mechanical Keyboard", "K-200", 89.99m, 1));
            order1.AddProduct(new Product("XL Desk Pad", "P-300", 15.50m, 1));

            //  Order 2: International Customer 
            Address address2 = new Address("456 Yonge Street", "Toronto", "ON", "Canada");
            Customer customer2 = new Customer("Carlos Silva", address2);
            Order order2 = new Order(customer2);

            order2.AddProduct(new Product("27-Inch 4K Monitor", "MON-400", 299.99m, 1));
            order2.AddProduct(new Product("High-Speed HDMI Cable", "CBL-500", 12.00m, 2));

            //  Display Results 
            DisplayOrderDetails(order1, 1);
            DisplayOrderDetails(order2, 2);
        }

        static void DisplayOrderDetails(Order order, int orderNumber)
        {
            Console.WriteLine("======================================== ORDER #" + orderNumber + " ========================================");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("Total Price (including shipping): $" + order.CalculateTotalCost().ToString("F2"));
            Console.WriteLine();
        }
    }
}