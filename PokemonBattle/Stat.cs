namespace PokemonBattle
{
    public class Stat
    {
        public int MaxStat { get; private set; }
        public int CurrentStat { get; private set; }

        public Stat(int stat)
        {
            MaxStat = stat;
            CurrentStat = stat;
        }

        public void UpdateStat(int change)
        {
            CurrentStat += change;
        }

        public void ResetStat()
        {
            CurrentStat = MaxStat;
        }
    }
}