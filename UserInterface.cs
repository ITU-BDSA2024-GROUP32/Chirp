
public static class UserInterface{

    public static void PrintCheeps(IEnumerable<Cheep> cheeps){
        foreach(Cheep cheep in cheeps){
            Console.WriteLine(cheep.Author + "@ " + cheep.Message + ": " + DateTimeOffset.FromUnixTimeSeconds(cheep.TimeStamp).DateTime); 
        }
    }

}