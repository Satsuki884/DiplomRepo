using DataBaseLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataBaseLayer.Models.Models;

namespace DataBaseLayer.Servises
{
    internal class StoneServise
    {
        private readonly LevelRepository _levelRepository;
        private readonly StoneRepository _stoneRepository;
        private readonly StoneLevelRepository _stoneLevelRepository;

        public StoneServise()
        {
            _levelRepository = new LevelRepository();
            _stoneRepository = new StoneRepository();
            _stoneLevelRepository = new StoneLevelRepository();
        }

        public bool SetStoneToLevel(string name)
        {
            var level = _levelRepository.Retrieve(name);
            var stoneLevel = _stoneLevelRepository.Retrieve(int.Parse(name.Split(' ')[1]));

            var result = Math.Round((double)level.Grade * 4 / level.MaxRate);

            var stone = _stoneRepository.Retrieve((StoneValue)result);

            stoneLevel.StoneId = stone.StoneId;

            return _stoneLevelRepository.Update(stoneLevel);
        }
    }
}
