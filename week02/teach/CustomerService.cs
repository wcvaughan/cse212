﻿/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases
        // Test 1
        // Scenario: Does the max size of customers default to 10 if the input is an invalid value?

        // Expected Result: Max size should display 10
        Console.WriteLine("Test 1");
        var service = new CustomerService(0);
        Console.WriteLine($"Size should be 10: {service}");

        // Defect(s) Found: None, _maxSize defaults to 10

        Console.WriteLine("=================");


        // Test 2
        // Scenario: Can I add more customers than the max number of customers specified?

        // Expected Result: 
        Console.WriteLine("Test 2");
        service = new CustomerService(5);
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine($"Service Queue: {service}");
        // Defect(s) Found:

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Can a customer be added then served?
        // Expected Result: Should should a customer has been added
        Console.WriteLine("Test 3");
        service = new CustomerService(5);
        service.AddNewCustomer();
        service.ServeCustomer();
        // Defect(s) Found: 

        Console.WriteLine("=================");
        // Add more Test Cases As Needed Below

        // Test 4
        // Scenario: What happens when I serve a customer and there are none?

        // Expected Result: Should display a message indicating no customers
        Console.WriteLine("Test 4");
        service = new CustomerService(5);
        service.ServeCustomer();
        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Can we add more than one customer and then serve the customers in the correct order?

        // Expected Result: Should display the customers in the same order they were entered
        Console.WriteLine("Test 5");
        service = new CustomerService(5);
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine($"Before serving customers: {service}");
        service.ServeCustomer();
        service.ServeCustomer();
        Console.WriteLine($"After serving customers: {service}");
        // Defect(s) Found: 

        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count > _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        _queue.RemoveAt(0);
        var customer = _queue[0];
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}