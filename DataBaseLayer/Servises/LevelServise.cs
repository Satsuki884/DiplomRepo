using DataBaseLayer.Repositories;
using System.Diagnostics;
using System.Xml.Linq;
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

        public bool IsLevelAvailable(string levelName)
        {
            var level = _levelRepository.Retrieve(levelName);
            if (level.IsAvailable)
            {
                return true;
            }
            return false;
        }
        
        public bool IsLevelComplitedSuccessible(string name, int grade)
        {
            if(IsComplited(name, grade))
            {
               return IsAvailable(name);
            }

            return false;
        }

        public bool MakeLevelAccessible(Level nextLevel)
        {
            var levels = _levelRepository.Retrieve();
            int lastAccsesLevel = levels
                                        .Where(level => level.IsCompleted)
                                        .Select(level => int.Parse(level.Name.Split(' ')[1]))
                                        .DefaultIfEmpty(0)
                                        .Max();
            var levelNumber = lastAccsesLevel + 1;
            var updateLevel = _levelRepository.Retrieve("Level " + levelNumber);

            if (Rules.bossLevelAcssesRule.TryGetValue(lastAccsesLevel, out int pointsNeed) && SumGrade() >= pointsNeed)
            {
                updateLevel.IsAvailable = true;
                if(_levelRepository.Update(nextLevel) && _levelRepository.Update(updateLevel))
                {
                    return true;
                }
                return false;
            }
            return _levelRepository.Update(nextLevel);
        }

        public bool SetStone(Level level)
        {
            var stoneServis = new StoneServise();
            var levelComp = _levelRepository.Update(level);
            if (levelComp)
            {
                return stoneServis.SetStoneToLevel(level.Name);
            }
            return false;
        }

        public bool IsComplited(string name, int grade)
        {
            var level = _levelRepository.Retrieve(name);
            if (grade > 0 && level != null)
            {
                level.IsCompleted = true;
                //Console.WriteLine("level.Grade = " + level.Grade);
                //Console.WriteLine("grade = " + grade);

                if (grade >= level.Grade)
                {
                    //Console.WriteLine("level.Grade = " + level.Grade);
                    level.Grade = grade;
                    //Console.WriteLine("level.Grade = " + level.Grade);
                }

                // Console.WriteLine(level.Name + "isCompleted");

                //var stoneServis = new StoneServise();
                //stoneServis.SetStoneToLevel(name);

                return SetStone(level);
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

        

        public bool BossIsCompleted(Level level)
        {
            var userServis = new UserServise();
            level.IsAvailable = true;
            var bossCompleted = _levelRepository.Update(level);
            if (bossCompleted)
            {
                return userServis.UpdateImage(level);
            }
            return false;
        }

        public bool IsAvailable(string currentLevelName)
        {
            var level = _levelRepository.Retrieve(currentLevelName);

            var currentLevelNumber = int.Parse(currentLevelName.Split(' ')[1]);
            
            var nextLevelNumber = currentLevelNumber+1;
            var nextLevelName = $"Level {nextLevelNumber}";
            
            var nextLevel = _levelRepository.Retrieve(nextLevelName);

            int sumGrades = SumGrade();

            if (!level.IsBoss)
            {
                nextLevel.IsAvailable = true;
                return MakeLevelAccessible(nextLevel);
                //return _levelRepository.Update(nextLevel);
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
