using DataBaseLayer.Repositories;
using static DataBaseLayer.Models.Models;

namespace DataBaseLayer.Servises
{
    public class LevelServise
    {
        private readonly LevelRepository _levelRepository;
        public LevelServise()
        {
            _levelRepository = new LevelRepository();
        }

       /* bool isLevelAvailable(int level)
        {

        }*/
        
        public bool IsLevelComplitedSuccessible(string name, int grade)
        {
            if(IsComplited(name, grade))
            {
               return IsAvailable(name);
            }

            return false;
        }

        public bool IsComplited(string name, int grade)
        {
            var level = _levelRepository.Retrieve(name);
            if (grade > 0 && level != null)
            {
                level.IsCompleted = true;
                level.Grade = grade;

                return _levelRepository.Update(level);
            }

            return false;
        }

        public int SumGrade()
        {
            var levels = _levelRepository.Retrieve();
            int sumGrades = levels.Where(x => x.Grade != 0).Sum(x => x.Grade);
            return sumGrades;
        }

        public int SumMaxRate()
        {
            var levels = _levelRepository.Retrieve();
            int sumMaxRate = levels.Where(x => x.Max_rate != 0).Sum(x => x.Max_rate);
            return sumMaxRate;
        }

        public bool IsComplited(string name)
        {
            var level = _levelRepository.Retrieve(name);
            if(level.Grade > 0)
            { 
                level.IsCompleted = true;
                //_levelRepository.Update(level);
                return true;
            }
            return false;
        }

        public bool BossIsCompleted(Level level)
        {
            var userServis = new UserServise();
            level.IsAvailable = true;
            var bossCompleted = _levelRepository.Update(level);
            if (bossCompleted)
            {
                return userServis.UpdateImage(level);
            }
            return _levelRepository.Update(level);
        }

        public bool IsAvailable(string currentLevelName)
        {
            var level = _levelRepository.Retrieve(currentLevelName);
            
            var levels = _levelRepository.Retrieve();

            var currentLevelNumber = int.Parse(currentLevelName.Split(' ')[1]);
            
            var nextLevelNumber = currentLevelNumber+1;
            var nextLevelName = $"Level {nextLevelNumber}";
            
            var nextLevel = _levelRepository.Retrieve(nextLevelName);

            int sumGrades = levels.Where(x=>x.Grade != 0).Sum(x=>x.Grade);

            if (!level.IsBoss)
            {
                nextLevel.IsAvailable = true;
                return _levelRepository.Update(nextLevel);
            }
            else
            {
                Console.WriteLine("Level is boss: " + level.IsBoss);
                if (Rules.bossLevelAcssesRule.TryGetValue(currentLevelNumber, out int pointsNeed) && sumGrades >= pointsNeed)
                {
                    return BossIsCompleted(nextLevel);
                    /*nextLevel.IsAvailable = true;
                    return _levelRepository.Update(nextLevel);*/
                }
                return false;
            }
        }
    }
}
