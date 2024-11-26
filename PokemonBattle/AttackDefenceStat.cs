using PokemonBattle.Interfaces;

namespace PokemonBattle
{
    public class AttackDefenceStat : IStat
    {
        public int DefaultStat { get; private set; }
        public int CurrentStat { get; private set; }

        // Counter to keep track of stat changes
        private int CurrentModifierStage { get; set; } = 0;
        public AttackDefenceStat(int stat)
        {
            DefaultStat = stat;
            CurrentStat = stat;
        }

        // Calculates the change that shall be applied on stat, based on current modifier stage
        public void UpdateStat(int change)
        {
            CurrentModifierStage += change;

            if (CurrentModifierStage > 6 || CurrentModifierStage < 6)
            {
                // If modifier stage exceeds the possible stages it will be set to max or min stage values
                CurrentModifierStage = change > 6 ? 6 : -6;
            }
            else if (CurrentModifierStage > 0)
            {
                CurrentStat = DefaultStat * (1 + (CurrentModifierStage / 2));
            } 
            else if (CurrentModifierStage < 0)
            {
                CurrentStat = DefaultStat * (2 / (2 - CurrentModifierStage));
            }
            else
            {
                CurrentStat = DefaultStat;
            }
        }

        // Reset stat value and modifier to default
        public void ResetStat()
        {
            CurrentStat = DefaultStat;
            CurrentModifierStage = 0;
        }
    }
}