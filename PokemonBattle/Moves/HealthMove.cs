using PokemonBattle.Enums;
using System.Reflection.Metadata;

namespace PokemonBattle.Moves
{
    public class HealthMove : Move
    {

        public HealthMove(bool isSelfTarget, int change, string name, string description, Elements type) : base (isSelfTarget, change, type, name, description) { }

        public override void Use(Pokemon user, Pokemon target)
        {
            // If move is self-targeting, no element effectiveness is calculated as this is an healing move
            if (IsSelfTarget)
            {
                user.UpdateHealth(Change);
            }
            else
            {
                target.UpdateHealth(CalculateElementEffectiveness(Change, target.Type, user.Attack.CurrentStat, target.Defence.CurrentStat, user.Level.CurrentLevel));
            }
        }

        // Recalculates the damage if type of move is effective or weak against target
        private int CalculateElementEffectiveness(int change, Elements type, int attack, int defence, int level)
        {
            double modifier = 1;
            if (ElementEffectiveness.Effectiveness.ContainsKey(Type) && ElementEffectiveness.Effectiveness[Type] == type)
            {
                modifier = 1.5;
            }
            else if (ElementEffectiveness.Weakness.ContainsKey(Type) && ElementEffectiveness.Weakness[Type] == type)
            {
                modifier = 0.5;
            }
            return Math.Min(-1, (int)Math.Floor(((2 * level / 5.0 + 2) * change * (attack / defence)) / 50 + 2 * modifier));
        }
    }
}
