namespace DataBaseLayer.Models
{
    public class Models
    {
        public class Image
        {
            public int ImageId { get; set; }
            public string ImagePath { get; set; }
        }

        public class Exercise
        {
            public int ExerciseId { get; set; }
            public int ImageId { get; set; }
            public string Text { get; set; }
            public int Point { get; set; }
            public string Answer { get; set; }
            public Image Image { get; set; }
        }

        public class Level
        {
            public int LevelId { get; set; }
            public int ImageId { get; set; }
            public string Name { get; set; }
            public int MaxRate { get; set; }
            public int Grade { get; set; }
            public bool IsBoss { get; set; }
            public bool IsCompleted { get; set; }
            public bool IsAvailable { get; set; }
            public Image Image { get; set; }
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
            public Image Image { get; set; }
        }

        public class ExLevel
        {
            public int ExLevelId { get; set; }
            public int LevelId { get; set; }
            public int ExerciseId { get; set; }
            public Level Level { get; set; }
            public Exercise Exercise { get; set; }
        }

        public class StoneLevel
        {
            public int StoneLevelId { get; set; }
            public int LevelId { get; set; }
            public int StoneId { get; set; }
            public Level Level { get; set; }
            public Stone Stone { get; set; }
        }

        public class BossLevel
        {
            public int BossLevelId { get; set; }
            public int MinGrade { get; set; }
            public int LevelId { get; set; }
            public Level Level { get; set; }
        }
    }
}
