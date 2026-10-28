public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Plan:
        // 1. Create a new array of doubles that can hold 'length' values.
        // 2. Loop from 0 up to length - 1 using an index i.
        // 3. For each position, the multiple is number * (i + 1),
        //    because the first multiple is number * 1, not number * 0.
        // 4. Store that value in the array at position i.
        // 5. After the loop, return the array.

        var result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Plan:
        // 1. Rotating right by 'amount' means the last 'amount' items move to the front.
        // 2. Find the split point: data.Count - amount. Everything from that
        //    index to the end is the part that moves to the front.
        // 3. Use GetRange to copy that last section into a new list.
        // 4. Use RemoveRange to delete that section from the end of the original list.
        // 5. Use InsertRange at index 0 to put the copied section at the front.
        // 6. The original list is now rotated, so there's nothing to return.

        int splitIndex = data.Count - amount;

        List<int> lastPart = data.GetRange(splitIndex, amount);
        data.RemoveRange(splitIndex, amount);
        data.InsertRange(0, lastPart);
    }
}