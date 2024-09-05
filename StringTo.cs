using System;
using System.IO;

class  StringTo{
    static void Main(){
        Console.WriteLine("John,Doe,30,New York");
        string input = Console.ReadLine();
        
        string[] values = input.Split(',');

        string csvLine = string.Join(",",values);

        string filePath = "output.csv";

        File.WriteAllText(filePath, csvLine);
    
        Console.WriteLine("CSV line: " + csvLine);
        Console.WriteLine("CSV file saved to: " + filePath);
    }
}