using DataBaseLayer.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
       /* var rep = new StoneRepository();
        var value = rep.Retrieve();
        value.ForEach(x => Console.WriteLine(x.Value));*/

        var rep1 = new LevelRepository();
        var value1 = rep1.Retrieve();
        value1.ForEach(x => Console.WriteLine(x.Name));
/*
        var rep2 = new UserRepository();
        var value2 = rep2.Retrieve();
        value2.ForEach(x => Console.WriteLine(x.Name));*/


    }
}