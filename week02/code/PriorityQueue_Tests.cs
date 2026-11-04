using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue A (priority 1), B (priority 5), C (priority 3). Dequeue three times.
    // Expected Result: B, C, A (highest priority first, and each item is removed once dequeued).
    // Defect(s) Found: Failed on the second Dequeue (returned B again instead of C).
    //   Dequeue returned the value but never removed the item from the list.
    //   Fixed by adding _queue.RemoveAt(highPriorityIndex).
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A (priority 1), B (priority 2), C (priority 9). The highest priority item is last.
    // Expected Result: C
    // Defect(s) Found: Failed (returned B instead of C). The for loop condition was
    //   index < _queue.Count - 1, so the last item was never checked.
    //   Fixed by changing it to index < _queue.Count.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 9);

        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Enqueue A (priority 5), B (priority 5), C (priority 1). Dequeue twice.
    // Expected Result: A, then B (ties are broken first-in, first-out).
    // Defect(s) Found: Failed (returned B first instead of A). The comparison used >=,
    //   so a later item with equal priority replaced the earlier one.
    //   Fixed by changing >= to >.
    public void TestPriorityQueue_TieUsesFifo()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 1);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue a single item, A (priority 3), and dequeue it.
    // Expected Result: A
    // Defect(s) Found: No defect found. Passed before and after the fixes.
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);

        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: No defect found. The empty check was already correct.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}