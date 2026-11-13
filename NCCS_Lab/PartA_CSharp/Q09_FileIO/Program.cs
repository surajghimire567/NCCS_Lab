using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputFile = "input.txt";
        string outputFile = "output.txt";

        // Create a sample input file first (so the program is runnable standalone)
        File.WriteAllText(inputFile, "hello\nworld\ncsharp\nfile io demo");

        StreamReader? reader = null;
        StreamWriter? writer = null;

        try
        {
            reader = new StreamReader(inputFile);
            writer = new StreamWriter(outputFile);

            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                // Processing: convert each line to uppercase
                string processed = line.ToUpper();
                writer.WriteLine(processed);
            }

            Console.WriteLine("File processed successfully. Check output.txt");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Error: Input file not found. " + ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine("I/O Error: " + ex.Message);
        }
        finally
        {
            reader?.Close();
            writer?.Close();
            Console.WriteLine("Streams closed (finally block executed).");
        }
    }
}
