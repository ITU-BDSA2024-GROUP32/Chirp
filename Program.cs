using System;
using System.IO;

namespace Chirp.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "read")
            {
                // Read the CSV file
                string filePath = "chirp_cli_db.csv";
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath);
                    foreach (var line in lines)
                    {
                        var columns = line.Split(',');
                        if (columns.Length >= 3)
                        {
                            string author = columns[0];
                            string dateTime = columns[1];
                            string message = columns[2];
                            Console.WriteLine($"{author} @ {dateTime}: {message}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The file chirp_cli_db.csv does not exist.");
                }
            }
            else
            {
                Console.WriteLine("Usage: Chirp.CLI read");
            }
        }
    }
}
