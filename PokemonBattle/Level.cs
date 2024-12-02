namespace PokemonBattle
{
    public class Level
    {
        public int CurrentLevel { get; private set; }
        public int Xp { get; private set; }

        public Level(int level = 1)
        {
            CurrentLevel = level;
            Xp = 0;
        }

        public void SetExp(int level)
        {
            Xp += level * 50;
            CheckIfLevelUp();
        }

        private void CheckIfLevelUp()
        {
            if (Xp >= (Math.Pow(CurrentLevel, 3)))
            {
                CurrentLevel++;
                Xp -= (int)Math.Pow(CurrentLevel, 3);
            }
        }
    }
}
