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
            var exImagesRepository = new ExImageRepository();
            var answerRepository = new AnswerRepository();
            var imageRepository = new ImageRepository();

            var exercises = exerciseRepository.RetrieveByLevelId(levelId);
            var exerciseIds = exercises.Select(e => e.ExerciseId).ToArray();

            var exAnswers = exAnswerRepository.RetrieveByExerciseіId(exerciseIds);
            var answerIds = exAnswers.Select(ea => ea.AnswerId).ToArray();

            var answers = answerRepository.RetrieveByAnswerIds(answerIds);

            var exImages = exImagesRepository.RetrieveByExerciseіId(exerciseIds);
            var imageIds = exAnswers.Select(ea => ea.AnswerId).ToArray();

            var images = imageRepository.RetrieveByAnswerIds(imageIds);

            var result = exercises.Select(ex => new ExerciseWithAnswers
                {
                    Text = ex.Text,
                    Point = ex.Point,
                    Answers = exAnswers.Where(ea => ea.ExerciseId == ex.ExerciseId)
                                        .Join(answers, ea => ea.AnswerId, a => a.AnswerId, (ea, a) => a.Value)
                                        .ToArray(),
                Images = exImages.Where(ei => ei.ExerciseId == ex.ExerciseId)
                                 .Join(images, ei => ei.ImageId, i => i.ImageId, (ei, i) => i)
                                 .ToArray()
            });

                return result;
        }
    }
}
