using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        try
        {
            // Call the async demo method
            await DemonstrateExceptions();
        }
        catch (AggregateException ex)
        {
            // NOTE:
            // In your screenshot you had this catch in Main.
            // With the fixed code below, normally HttpRequestException is
            // already handled inside DemonstrateExceptions, so this may not run.
            Console.WriteLine($"Aggregate Exception caught in Main: {ex.Message}");
            foreach (var inner in ex.InnerExceptions)
            {
                Console.WriteLine(" - " + inner.Message);
            }
        }
    }

    static async Task DemonstrateExceptions()
    {
        using var _client = new HttpClient();

        var urls = new[]
        {
            "https://jsonplaceholder.typicode.com/posts/1",   // valid
            "https://this-does-not-exist.invalid/post1",      // invalid
            "https://this-does-not-exist.invalid/post2",      // invalid
            "https://jsonplaceholder.typicode.com/posts/3"    // valid
        };

        // Create HTTP GET tasks for each URL
        var tasks = urls.Select(url => _client.GetStringAsync(url)).ToList();

        try
        {
            Console.WriteLine($"Count: {tasks.Count}");

        //  string[] results = await Task.WaitAll(tasks.ToArray()); // synchronous method returns void  not string 

           string[] results = await Task.WhenAll(tasks.ToArray());

            Console.WriteLine($"All {results.Length} succeeded.");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"At least one task failed (first exception): {ex.Message}");

            // Show ALL failed tasks (not just the first)
            foreach (var task in tasks.Where(t => t.IsFaulted))
            {
                Console.WriteLine(" - " + task.Exception?.InnerException?.Message);
            }
        }
    }
}