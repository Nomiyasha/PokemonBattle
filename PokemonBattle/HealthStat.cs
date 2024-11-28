using PokemonBattle.Interfaces;

namespace PokemonBattle
{
    public class HealthStat : IStat
    {
        public int DefaultStat { get; }
        public Level Level { get; }
        public int CalculatedStat
        {
            get
            {
                return (int)((2 * DefaultStat * (Level.CurrentLevel / 100)) + Level.CurrentLevel + 10);
            }
        }
        public int CurrentStat { get; private set; }

        public HealthStat(int stat, Level level)
        {
            DefaultStat = stat;
            Level = level;
            CurrentStat = CalculatedStat;
        }

        // Updates health and makes sure it go below 0 or the default (max) value
        public void UpdateStat(int change)
        {
            CurrentStat = change > 0 ? Math.Min(CalculatedStat, CurrentStat + change) : Math.Max(0, CurrentStat + change);
        }

        // Resets to default value
        public void ResetStat()
        {
            CurrentStat = CalculatedStat;
        }
    }
}