using System.Diagnostics;
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
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Iterate from 1 to length and multiply number to loop index and add each result to the list. 
        double[] multiples = new double[length];

        for (int i = 1; i <= length; i++)
        {
            multiples[i-1] = number * i;
        }

        return multiples;
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
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // First I'll getRange from beginnig to amount, then List slice data from amount to data.Count 
        // minus amount. Finally add the list slice to the end of the list getRange created.

        List<int> newArrayEndingPart = data.GetRange(0, data.Count - amount);
        List<int> newArrayBeginning = data.GetRange(data.Count - amount, amount);

        newArrayBeginning.AddRange(newArrayEndingPart);

        data.Clear();
        data.AddRange(newArrayBeginning);

    }
}

