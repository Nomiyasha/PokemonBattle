using PokemonBattle.Enums;

namespace PokemonBattle.Moves
{
    public abstract class Move : IMove
    {
        public bool IsSelfTarget { get; }
        public int Change { get; }
        public Elements Type { get; }
        public string Name { get; }
        public string Description { get; }

        public Move(bool isSelfTarget, int change, Elements type, string name, string description)
        {
            IsSelfTarget = isSelfTarget;
            Change = change; 
            Type = type; 
            Name = name; 
            Description = description;
        }

        public virtual void Use(Pokemon target) { }
        public virtual void Use(Pokemon user, Pokemon target) { }
    }
}
