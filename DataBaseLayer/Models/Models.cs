namespace DataBaseLayer.Models
{
    public class Models
    {
        public class Image
        {
            public int ImageId { get; set; }
            public string ImagePath { get; set; }
        }

        public class Answer
        {
            public int AnswerId { get; set; }
            public string value { get; set; }
        }

        public class ExImage
        {
            public int ExImageId {  get; set; }
            public int ImageId { get; set; }
            public int ExerciseId { get; set; }
        }

        public class ExAnswer
        {
            public int AnswerId { get; set; }
            public int ExAnswerId { get; set;}
            public int ExerciseId { get; set;}
        }

        public class Exercise
        {
            public int ExerciseId { get; set; }
            public int ImageId { get; set; }
            public string Text { get; set; }
            public int Point { get; set; }
            //public string Answer { get; set; }
            public int LevelId { get; set; }
            public Image Image { get; set; }
        }

        public class Level
        {

            public int LevelId { get; set; }
            public int ImageId { get; set; }
            public string Name { get; set; }
            public int Max_rate { get; set; }
            public int Grade { get; set; }
            public bool IsBoss { get; set; }
            public bool IsCompleted { get; set; }
            public bool IsAvailable { get; set; }
            public Image Image { get; set; }
            public int StoneId { get; set; }
        }

        public enum StoneValue
        {
            None = 0,
            One = 1,
            Two = 2,
            Three = 3
        }

        public class Stone
        {
            public int StoneId { get; set; }
            public int ImageId { get; set; }
            public StoneValue Value { get; set; }
            public Image Image { get; set; }
        }

        public class User
        {
            public int UserId { get; set; }
            public int ImageId { get; set; }
            public string Name { get; set; }
            public string Sex { get; set; }
            public bool IsSword { get; set; }
            public bool IsBoots { get; set; }
            public bool IsFlashlight { get; set; }
            public bool IsArmor { get; set; }
            public bool IsAmulet { get; set; }
            public bool IsAura { get; set; }
            //public Image Image { get; set; }
        }

        public class ExLevel
        {
            public int ExLevelId { get; set; }
            public int LevelId { get; set; }
            public int ExerciseId { get; set; }
            public Level Level { get; set; }
            public Exercise Exercise { get; set; }
        }

    }
}
