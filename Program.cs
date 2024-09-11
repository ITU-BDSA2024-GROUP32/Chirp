using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using CsvHelper;



namespace Chirp.CLI
{

    public record Cheep(String Author, String Message, long TimeStamp);

    class Program
    {
        IEnumerable<Cheep> cheeps;
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
            using (var reader = new StreamReader("cheeps.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
             var cheeps = csv.GetRecords<Cheep>();
             foreach (Cheep cheep in cheeps){
                Console.WriteLine(cheep.Author + "@ " + cheep.Message + ": " + DateTimeOffset.FromUnixTimeSeconds(cheep.TimeStamp).DateTime);
             }
            }
        }

        public static void cheep (string user){
        string input = Console.ReadLine();

        Cheep cheep = new Cheep(user,input,getUnixTime());
        
        using (var Stream = File.Open("cheeps.csv",FileMode.Append))
        using (var writer = new StreamWriter(Stream))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecord(cheep);
            writer.WriteLine();
        } 
        }


        public static long getUnixTime(){
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
    }
}
