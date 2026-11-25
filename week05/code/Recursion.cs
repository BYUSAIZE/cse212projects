using System.Collections;

public static class Recursion
{
    /// <summary>
    /// Problem 1: sum of 1^2 + 2^2 + ... + n^2 using recursion.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case
        if (n <= 0)
            return 0;

        // Smaller problem: n^2 plus the sum for n-1
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: permutations of length 'size' from 'letters'.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: the word is long enough
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Try each remaining letter, removing it from the pool so it isn't reused
        for (int i = 0; i < letters.Length; i++)
        {
            var remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    /// <summary>
    /// Problem 3: ways to climb 's' stairs (1, 2, or 3 at a time), memoized.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // Create the cache on the first call
        remember ??= new Dictionary<int, decimal>();

        // Reuse a stored answer if we already have one
        if (remember.ContainsKey(s))
            return remember[s];

        // Solve using recursion, passing the cache along
        decimal ways = CountWaysToClimb(s - 1, remember)
                     + CountWaysToClimb(s - 2, remember)
                     + CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// Problem 4: all binary strings matching a pattern with * wildcards.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        // Base case: no wildcard left, so the pattern is a finished binary string
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Replace the first * with 0, then with 1, and recurse on each
        WildcardBinary(pattern[..index] + "0" + pattern[(index + 1)..], results);
        WildcardBinary(pattern[..index] + "1" + pattern[(index + 1)..], results);
    }

    /// <summary>
    /// Problem 5: all paths from (0,0) to the end square.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }

        // Record the square we're standing on
        currPath.Add((x, y));

        // Found the end: save this path
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            return;
        }

        // Try right, left, down, up
        var moves = new (int dx, int dy)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        foreach (var (dx, dy) in moves)
        {
            int nx = x + dx;
            int ny = y + dy;

            if (maze.IsValidMove(currPath, nx, ny))
            {
                // Give each branch its own copy of the path
                SolveMaze(results, maze, nx, ny, new List<ValueTuple<int, int>>(currPath));
            }
        }
    }
}