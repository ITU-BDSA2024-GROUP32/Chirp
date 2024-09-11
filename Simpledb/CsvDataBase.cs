using Simpledb;
using CsvHelper;
using System.Globalization;

public record Cheep(String Author, String Message, long TimeStamp);
public class CsvDataBase<T> : IDataBaseepository<T>
{
    public CsvDataBase(){

    }
     public IEnumerable<T> read(int? limit){
        Cheep cheep;
        using (var reader = new StreamReader("cheeps.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var cheeps = csv.GetRecords<Cheep>();
            for(int i = 0 ; i < limit ; i++){
                cheep = cheeps.ElementAt(i);
                Console.WriteLine(cheep.Author + "@ " + cheep.Message + ": " + DateTimeOffset.FromUnixTimeSeconds(cheep.TimeStamp).DateTime);
            }
        }
        return null;
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
