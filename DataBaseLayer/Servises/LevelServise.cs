using DataBaseLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataBaseLayer.Models.Models;

namespace DataBaseLayer.Servises
{
    public class LevelServise
    {
        private readonly StoneRepository _stoneRepository;
        private readonly LevelRepository _levelRepository;
        public LevelServise()
        {
            _stoneRepository = new StoneRepository();
            _levelRepository = new LevelRepository();
        }
        
        public bool IsCompleated(string name)
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

        public bool IsAvailable(string name)
        {
            var level = _levelRepository.Retrieve(name);
            

            string newString;
            string[] parts = name.Split(' ');
            int.TryParse(parts[1], out int number);
            newString = $"Level {number}";
            var next_level = _levelRepository.Retrieve(newString);

            var levels = _levelRepository.Retrieve();
            int sumGrades = 0;
            foreach(var Qlevel  in levels) 
            {
                sumGrades += Qlevel.Grade;
            }

            if (level.IsCompleted && !level.IsBoss)
            {
                level.IsAvailable = true;
                _levelRepository.Update(next_level);
                return true;
            }else if(level.IsCompleted && level.IsBoss && sumGrades == Rules.bossLevelAcssesRule)
            {
                level.IsAvailable = true;
                _levelRepository.Update(next_level);
                return true;
            }

            return false;
        }

    }
}
