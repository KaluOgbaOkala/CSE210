using System;

class Program
{
    static void Main(string[] args)
    {
        // ORDER 1 - USA CUSTOMER

        Address address1 = new Address(
            "123 Main Street",
            "Salt Lake City",
            "Utah",
            "USA"
        );

        Customer customer1 = new Customer(
            "John Smith",
            address1
        );

        Product product1 = new Product(
            "Laptop",
            "P001",
            800.00,
            1
        );

        Product product2 = new Product(
            "Wireless Mouse",
            "P002",
            25.00,
            2
        );

        Product product3 = new Product(
            "Keyboard",
            "P003",
            45.00,
            1
        );

        Order order1 = new Order(customer1);

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}");

        Console.WriteLine();
        Console.WriteLine("--------------------------------");
        Console.WriteLine();


        // ORDER 2 - INTERNATIONAL CUSTOMER

        Address address2 = new Address(
            "15 Market Road",
            "Ohafia",
            "Abia State",
            "Nigeria"
        );

        Customer customer2 = new Customer(
            "Kalu Ogba",
            address2
        );

        Product product4 = new Product(
            "Smartphone",
            "P004",
            500.00,
            1
        );

        Product product5 = new Product(
            "Phone Case",
            "P005",
            15.00,
            2
        );

        Product product6 = new Product(
            "Power Bank",
            "P006",
            30.00,
            1
        );

        Order order2 = new Order(customer2);

        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product6);

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
    }
}