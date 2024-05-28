﻿using DataBaseLayer.Repositories;
using DataBaseLayer.Servises;

internal class Program
{
    private static void Main(string[] args)
    {
        var rep1 = new LevelRepository();
        var value1 = rep1.Retrieve("Level 1");
        /*foreach(var item in value1)
        {
            Console.WriteLine("Name "+value1.Name);
            Console.WriteLine("Grade " + value1.Grade);
            Console.WriteLine("Max_rate " + value1.Max_rate);
            Console.WriteLine("IsAvailable " + value1.IsAvailable);
            Console.WriteLine("IsBoss " + value1.IsBoss);
            Console.WriteLine("IsCompleted " + value1.IsCompleted);
            Console.WriteLine("StoneId " + value1.StoneId);*/
        //}

        var servis = new LevelServise();
        var stoneServis = new StoneServise();

        Console.WriteLine(servis.IsLevelComplitedSuccessible(value1.Name, 8));
        Console.WriteLine(stoneServis.SetStoneToLevel(value1.Name));
        Console.WriteLine("StoneId " + value1.StoneId + "\n\n\n");

        var value2 = rep1.Retrieve("Level 2");
        /*foreach(var item in value1)
        {*/
        Console.WriteLine(value2.Name);
        Console.WriteLine(value2.LevelId);
        Console.WriteLine(value2.Grade);
        Console.WriteLine(value2.Max_rate);
        Console.WriteLine(value2.IsAvailable);
        Console.WriteLine(value2.IsBoss);
        Console.WriteLine(value2.IsCompleted);
        Console.WriteLine(value2.StoneId);
        //}



    }
}