using DataBaseLayer.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataBaseLayer.Models.Models;

namespace DataBaseLayer.Servises
{
    public class GetLevelInfoServise
    {
        public IEnumerable<ExerciseWithAnswers> GetExercisesWithAnswers(string levelId)
        {
            var exerciseRepository = new ExerciseRepository();
            var exAnswerRepository = new ExAnswerRepository();
            var answerRepository = new AnswerRepository();
            // Отримуємо всі вправи для заданого рівня

            var exercises = exerciseRepository.RetrieveByLevelId(levelId);
            var exerciseIds = exercises.Select(e => e.ExerciseId).ToArray();

            var exAnswers = exAnswerRepository.RetrieveByExerciseіId(exerciseIds);
            var answerIds = exAnswers.Select(ea => ea.AnswerId).ToArray();

            var answers = answerRepository.RetrieveByAnswerIds(answerIds);
                var result = exercises.Select(ex => new ExerciseWithAnswers
                {
                    Text = ex.Text,
                    Point = ex.Point,
                    Answers = exAnswers.Where(ea => ea.ExerciseId == ex.ExerciseId)
                                        .Join(answers, ea => ea.AnswerId, a => a.AnswerId, (ea, a) => a.Value)
                                        .ToArray()
                });

                return result;
        }
    }
}
