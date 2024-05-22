using DataBaseLayer.Repositories;

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

        public bool IsComplited(string name)
        {
            var level = _levelRepository.Retrieve(name);
            if(level.Grade > 0)
            { 
                level.IsCompleted = true;
                _levelRepository.Update(level);
                return true;
            }
            return false;
        }

        public bool IsAvailable(string currentLevelName)
        {
            var level = _levelRepository.Retrieve(currentLevelName);
            
            if(!level.IsCompleted)
            {
                return false;
            }
            var levels = _levelRepository.Retrieve();

            var currentLevelNumber = int.Parse(currentLevelName.Split(' ')[1]);
            
            var nextLevelNumber = currentLevelNumber++;
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
                if (Rules.bossLevelAcssesRule.TryGetValue(currentLevelNumber, out int pointsNeed) && sumGrades == pointsNeed)
                {
                    nextLevel.IsAvailable = true;
                    return _levelRepository.Update(nextLevel);
                }
                return false;
            }
        }
    }
}
