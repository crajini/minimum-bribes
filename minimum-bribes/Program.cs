// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Result.minimumBribes(new List<int> { 1, 2, 5, 3, 4, 7, 8, 6 });

class Result
{

    /*
     * Complete the 'minimumBribes' function below.
     *
     * The function accepts INTEGER_ARRAY q as parameter.
     */

    public static void minimumBribes(List<int> q)
    {
        int[] originalQueue = new int[q.Count];
        Array.Copy(q.ToArray(), originalQueue, q.Count);

        // Sort the original queue (to get the positions they started with)
        Array.Sort(originalQueue);

        int bribes = 0;

        // Check the current state of the queue compared to the sorted one
        for (int i = 0; i < q.Count; i++)
        {
            // Find the original position of the current person in the sorted queue
            int originalPosition = Array.IndexOf(originalQueue, q[i]);

            // Check if the person has moved more than 2 positions ahead
            if (originalPosition - i > 2)
            {
                Console.WriteLine("Too chaotic");
                return;
            }

            // Count how many people have passed the current person (bribed them)
            for (int j = Math.Max(0, originalPosition - 2); j < i; j++)
            {
                if (q[j] > q[i])
                {
                    bribes++;
                }
            }
        }

        Console.WriteLine(bribes);
    }
}
