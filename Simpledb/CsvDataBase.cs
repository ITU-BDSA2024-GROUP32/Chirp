using Simpledb;
using CsvHelper;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

public record Cheep(String Author, String Message, long TimeStamp);
public class CsvDataBase<T> : IDataBaseepository<T>
{
    public CsvDataBase(){

    }
     public IEnumerable<T> read(int? limit){
        List<Cheep> ListCheep = new List<Cheep>();
        int i = 0;
        using (var reader = new StreamReader("cheeps.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var cheeps = csv.GetRecords<Cheep>();
            cheeps = cheeps.Reverse();
            foreach(Cheep cheep in cheeps){
                ListCheep.Add(cheep);
                i++;
                if(i == limit){
                    break;
                }
            }
        }
        return ListCheep.Cast<T>();
     }
    public void store(T record){
        using (var Stream = File.Open("cheeps.csv",FileMode.Append))
        using (var writer = new StreamWriter(Stream))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecord(record);
            writer.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine("Cheep was succesfully sent!");
    }

}
