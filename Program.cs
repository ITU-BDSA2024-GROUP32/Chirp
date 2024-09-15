using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using Simpledb;



namespace Chirp.CLI
{


    class Program
    {
        IEnumerable<Cheep> cheeps;
         static void Main(string[] args)
        {
            IDataBaseepository<Cheep> database = new CsvDataBase<Cheep>();
            string user;
            bool KillProgram = false;
            string[] ConsoleInput;



            Console.WriteLine("What is you user name?");
            user = Console.ReadLine();
            Console.WriteLine("Hello " + user + " type 'help' to see commands");


            while(!KillProgram){
                ConsoleInput = Console.ReadLine().Split("-");
                
               switch(ConsoleInput[0].Replace(" ",""))
               {
                case "exit":
                    Console.WriteLine();
                    Console.WriteLine("Executing Chirp");
                    KillProgram = true;
                    break;
                case "help":
                    Console.WriteLine();
                    Console.WriteLine("exit   -- Exits Program");
                    Console.WriteLine("read -'limit'    -- read the limit amount of cheeps starting with the newest");
                    Console.WriteLine("cheep -'message'   --sends the cheep in the <> dont include '<>'");
                    break;
                case "read":
                    Console.WriteLine();
                    UserInterface.PrintCheeps(database.read(int.Parse(ConsoleInput[1].Replace(" ",""))));
                    break;
                case "cheep":
                    cheep(user,ConsoleInput[1],database);
                    break;
                }
            }
        }

        public static void cheep (string user,string input,IDataBaseepository<Cheep> database){
            database.store(new Cheep(user,input,getUnixTime()));
        }


        public static long getUnixTime(){
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
    }
}
