using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue shall add an item to the back of the queue.
    // Expected Result: Bob, Tim, Sue,
    // Defect(s) Found: 
    public void TestPriorityQueue_Enqueue()
    {
        var priorityQueue = new PriorityQueue();

        // expectedResult = ["Bob", "Tim", "Sue"];

        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Tim", 4);
        priorityQueue.Enqueue("Sue", 3);

        // Debug.WriteLine(priorityQueue.ToString());
        Assert.AreEqual("[Bob (Pri:1), Tim (Pri:4), Sue (Pri:3)]", priorityQueue.ToString());
        // Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: Dequeue shall remove and return the item with the highest priority;
    // Expected Result: Tim, Sue, Bob
    // Defect(s) Found: 
    public void TestPriorityQueue_Dequeue()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Tim", 4);
        priorityQueue.Enqueue("Sue", 3);

        string[] expectedResult = ["Tim", "Sue", "Bob"];

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            var person = priorityQueue.Dequeue();
            // Debug.WriteLine(person);
            Assert.AreEqual(expectedResult[i], person);
            i++;
        }
        // Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: Dequeue shall remove and return the item with the highest priority
    // closest to the front of the queue;
    // Expected Result: Tim, Ann, Finn, Sue, Bob
    // Defect(s) Found: 
    public void TestPriorityQueue_MultipleHighestPriority()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Finn", 3);
        priorityQueue.Enqueue("Tim", 4);
        priorityQueue.Enqueue("Sue", 3);
        priorityQueue.Enqueue("Ann", 4);

        string[] expectedResult = ["Tim", "Ann", "Finn", "Sue", "Bob"];
        int i = 0;
        while (priorityQueue.Length > 0)
        {
            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], person);
            i++;
        }
    }

    [TestMethod]
    // Scenario: The queue is empty; Throw invalid operation exception message.
    // Expected Result: "The queue is empty."

    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            var person = priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
    // Add more test cases as needed below.
}