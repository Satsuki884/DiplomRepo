using DataBaseLayer.Repositories;
using DataBaseLayer.Servises;
using static DataBaseLayer.Models.Models;
using static Mysqlx.Notice.Warning.Types;

//cntr shift b

internal class Program
{
    private static void Main(string[] args)
    {
        //var rep1 = new LevelRepository();
        //var value1 = rep1.Retrieve("Level 1");

        /* var servis = new LevelServise();
         var stoneServis = new StoneServise();
         var nameLevel = "Level 3";

         if (servis.IsLevelAvailable(nameLevel) )
         {
             Console.WriteLine(servis.IsLevelComplitedSuccessible(nameLevel, 8));
             //Console.WriteLine(stoneServis.SetStoneToLevel(nameLevel));
         }*/

        var levelRepository = new LevelRepository();
        var level = levelRepository.Retrieve("Level 37");

        var dataService = new GetLevelInfoServise();

        var exercisesWithAnswers = dataService.GetExercisesWithAnswers(level.Name);

        foreach (var exercise in exercisesWithAnswers)
        {
            Console.WriteLine($"Text: {exercise.Text}");
            Console.WriteLine($"Point: {exercise.Point}");
            Console.WriteLine($"Answers: {string.Join(", ", exercise.Answers)}\n");
        }








    }
}