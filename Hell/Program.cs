using DataBaseLayer.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        var rep = new LevelRepository();
        var value = rep.Retrieve();
        value.ForEach(x => Console.WriteLine(x.Name));
    }
}