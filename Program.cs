using System;
using System.Diagnostics;
using System.IO;


namespace Chirp.CLI
{
    class Program
    {
      
        static void Main(string[] args)
        {
            string user;
            bool KillProgram = false;
            string ConsoleInput;


            Console.WriteLine("What is you user name?");
            user = Console.ReadLine();
            Console.WriteLine("Hello " + user + " type 'help' to see commands");


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
                    cheep(user);
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

        public static void cheep (string user){
        string input = Console.ReadLine();
        
        string csvLine = user + "," + getDateTime() + "," + input;

        string filePath = "chirp_cli_db.csv";

        File.AppendAllText(filePath, csvLine + Environment.NewLine);
      
        }


        public static String getUnixTime(){
            long time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            return time.ToString();
        }

        public static String getDateTime(){
            return DateTime.Now.ToString();
        }
    }
}
