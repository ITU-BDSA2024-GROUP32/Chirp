using System;
using System.Diagnostics;
using System.IO;


namespace Chirp.CLI
{
    class Program
    {
      
        static void Main(string[] args)
        {
            bool KillProgram = false;
            String ConsoleInput;

            while(!KillProgram){
                ConsoleInput = Console.ReadLine(); 
               switch(ConsoleInput)
               {
                case "exit":
                    Console.WriteLine();
                    Console.WriteLine("Executing Chirp");
                    KillProgram = true;
                    break;
                case "help":
                    Console.WriteLine();
                    Console.WriteLine("exit   -- Exits Program");
                    Console.WriteLine("read   -- Reads current cheep feed");
                    Console.WriteLine("cheep -- Next input is your cheep");

                    break;
                case "read":
                    Console.WriteLine();
                    read();
                    break;
                case "cheep":
                    Console.WriteLine("hej1");
                    cheep();
                    Console.WriteLine("hej2");
                    break;
                }
            }
        }

        public static void read(){
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
        }

        public static void cheep (){
        string input = Console.ReadLine();
        
        string[] values = input.Split(',');

        string csvLine = string.Join(",",values);

        string filePath = "chirp_cli_db.csv";

        File.AppendAllText(filePath, csvLine + Environment.NewLine);
        //File.AppendAllText(filePath, );
        }
    }
}
