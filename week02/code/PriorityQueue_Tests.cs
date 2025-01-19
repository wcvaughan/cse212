using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue adds an item to the back of _queue and contains both data and priority
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("highspren", 1);
        Assert.IsNotNull(priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue removes the item with highest priority and returns its value
    // Expected Result: The value retrieved by the Dequeue method will be "tin"
    // Defect(s) Found: tin expected but bronze was returned
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("steel", 1);
        priorityQueue.Enqueue("zinc", 2);
        priorityQueue.Enqueue("bronze", 3);
        priorityQueue.Enqueue("tin", 4);
        Assert.AreEqual("tin", priorityQueue.Dequeue());

    }

    [TestMethod]
    // Scenario: Two items share the same priority, Dequeue removes the item closest to the front of the queue and its value is returned
    // Expected Result: firstItem value will be "threnody" while secondItem value will be "yolen"
    // Defect(s) Found: "threnody" is the same value returned instead of "yolen"
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("roshar", 1);
        priorityQueue.Enqueue("canticle", 2);
        priorityQueue.Enqueue("threnody", 4);
        priorityQueue.Enqueue("yolen", 4);
        string firstItem = priorityQueue.Dequeue();
        string secondItem = priorityQueue.Dequeue();
        Assert.AreEqual("yolen", firstItem);
        Assert.AreEqual("threnody", secondItem);
    }

    [TestMethod]
    // Scenario: If the queue is empty an exception error is thrown when Dequeue is called
    // Expected Result: Error is thrown
    // Defect(s) Found: none
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.
}