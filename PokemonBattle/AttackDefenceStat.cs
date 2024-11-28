using PokemonBattle.Interfaces;

namespace PokemonBattle
{
    public class AttackDefenceStat : IStat
    {
        public int DefaultStat { get; }
        public Level Level { get; }
        public int CalculatedStat
        {
            get
            {
                return (int)((2 * DefaultStat * (Level.CurrentLevel / 100)) + 5);
            }
        }
        public int CurrentStat { get; private set; }

        // Counter to keep track of stat changes
        private int CurrentModifierStage { get; set; } = 0;
        public AttackDefenceStat(int stat, Level level)
        {
            DefaultStat = stat;
            Level = level;
            CurrentStat = CalculatedStat;
        }

        // Calculates the change that shall be applied on stat, based on current modifier stage
        public void UpdateStat(int change)
        {
            CurrentModifierStage += change;

            if (CurrentModifierStage > 6 || CurrentModifierStage < -6)
            {
                // If modifier stage exceeds the possible stages it will be set to max or min stage values
                CurrentModifierStage = CurrentModifierStage > 6 ? 6 : -6;
            }
            
            if (CurrentModifierStage > 0)
            {
                CurrentStat = CalculatedStat * (1 + (CurrentModifierStage / 2));
            } 
            else if (CurrentModifierStage < 0)
            {
                CurrentStat = CalculatedStat * (2 / (2 - CurrentModifierStage));
            }
            else
            {
                CurrentStat = CalculatedStat;
            }
        }

        // Reset stat value and modifier to default
        public void ResetStat()
        {
            CurrentStat = CalculatedStat;
            CurrentModifierStage = 0;
        }
    }
}