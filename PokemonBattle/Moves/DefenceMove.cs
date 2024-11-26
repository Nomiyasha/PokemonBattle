using PokemonBattle.Enums;

namespace PokemonBattle.Moves
{
    public class DefenceMove
    {
        public bool IsSelfTarget { get; }
        public int Change { get; }
        public Elements Type { get; }
        public string Name { get; }
        public string Description { get; }

        public DefenceMove(bool isSelfTarget, int change, string name, string description, Elements type)
        {
            IsSelfTarget = isSelfTarget;
            Change = change;
            Type = type;
            Name = name;
            Description = description;
        }

        public void Use(Pokemon target)
        {
            target.UpdateDefence(Change);
        }
    }
}
