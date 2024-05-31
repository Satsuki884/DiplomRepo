using DataBaseLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataBaseLayer.Models.Models;

namespace DataBaseLayer.Servises
{
    public class ExerciseServise
    {
        private readonly ExerciseRepository _exerciseRepository;
        private readonly ExImageRepository _exImageRepository;
        private readonly ExAnswerRepository _exAnswerRepository;
        private readonly AnswerRepository _answerRepository;
        //private readonly StoneLevelRepository _stoneLevelRepository;

        public ExerciseServise()
        {
            _exerciseRepository = new ExerciseRepository();
            _exImageRepository = new ExImageRepository();
            _exAnswerRepository = new ExAnswerRepository();
            _answerRepository = new AnswerRepository();
        }


    }
}
