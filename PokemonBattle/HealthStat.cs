using PokemonBattle.Interfaces;

namespace PokemonBattle
{
    public class HealthStat : IStat
    {
        public int DefaultStat { get; private set; }
        public int CurrentStat { get; private set; }

        public HealthStat(int stat)
        {
            DefaultStat = stat;
            CurrentStat = stat;
        }

        // Updates health and makes sure it go below 0 or the default (max) value
        public void UpdateStat(int change)
        {
            CurrentStat = change > 0 ? Math.Min(DefaultStat, CurrentStat + change) : Math.Max(0, CurrentStat + change);
        }

        // Resets to default value
        public void ResetStat()
        {
            CurrentStat = DefaultStat;
        }
    }
}