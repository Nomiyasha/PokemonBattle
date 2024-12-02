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
        // KRAV 1
        // 1: Inkapsling / Informationsgömning
        // 2: Hur: Fältet är privat.
        // 3: Motivering: Fältet används inte utanför klassen. Shorthanden för properties vi använder här har ett 
        //    fält i bakgrunden.
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
                CurrentStat = (int)Math.Round(CalculatedStat * (1.0 + (CurrentModifierStage / 2.0)), 0);
            } 
            else if (CurrentModifierStage < 0)
            {
                CurrentStat = (int)Math.Round(CalculatedStat * (2.0 / (2.0 - CurrentModifierStage)), 0);
                if (CurrentStat < 1) CurrentStat = 1;
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