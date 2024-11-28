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

        public void CheckIfLevelUp()
        {
            if (Xp >= 100 * (Math.Pow(CurrentLevel, 3)))
            {
                CurrentLevel++;
                Xp -= (int)Math.Pow(CurrentLevel, 3);
            }
        }
    }
}
