using System;
using System.Threading.Tasks;

class Program
{
    // Simulated async download method
    static async Task DownloadFileAsync(string fileName, int seconds)
    {
        Console.WriteLine($"Started downloading {fileName}...");
        await Task.Delay(seconds * 1000); // simulate network delay
        Console.WriteLine($"Finished downloading {fileName}.");
    }

    static async Task Main()
    {
        Console.WriteLine("Download started at: " + DateTime.Now.ToLongTimeString());

        // Start both downloads concurrently
        Task file1 = DownloadFileAsync("report.pdf", 3);
        Task file2 = DownloadFileAsync("photos.zip", 2);

        // Wait for both to complete concurrently
        await Task.WhenAll(file1, file2);

        Console.WriteLine("Both downloads are complete!");
        Console.WriteLine("Finished at: " + DateTime.Now.ToLongTimeString());
    }
}
