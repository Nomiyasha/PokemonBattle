using PokemonBattle.Enums;

namespace PokemonBattle.Moves
{
    public class HealthMove : IMove
    {
        public bool IsSelfTarget { get; }
        public int Change { get; }
        public Elements Type { get; }
        public string Name { get; }
        public string Description { get; }

        public HealthMove(bool isSelfTarget, int change, string name, string description, Elements type)
        {
            IsSelfTarget = isSelfTarget;
            Change = change;
            Type = type;
            Name = name;
            Description = description;
        }

        public void Use(Pokemon pokemon)
        {
            // If move is self-targeting, no element effectiveness is calculated as this is an healing move
            if (IsSelfTarget)
            {
                pokemon.UpdateHealth(Change);
            }
            else
            {
                pokemon.UpdateHealth(CalculateElementEffectiveness(Change, pokemon.Type));
            }
        }

        // Recalculates the damage if type of move is effective or weak against target
        private int CalculateElementEffectiveness(int change, Elements type)
        {
            if (ElementEffectiveness.Effectiveness.ContainsKey(Type) && ElementEffectiveness.Effectiveness[Type] == type)
            {
                return change * 2;
            }
            else if (ElementEffectiveness.Weakness.ContainsKey(Type) && ElementEffectiveness.Weakness[Type] == type)
            {
                // Rounds the change to not include any decimals and explicitly converts to int
                return (int)Math.Round((change * 0.5), 0); 
            }
            else return Change;
        }
    }
}
