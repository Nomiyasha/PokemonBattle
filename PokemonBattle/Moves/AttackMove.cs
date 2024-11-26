using PokemonBattle.Enums;

namespace PokemonBattle.Moves
{
    public class AttacKMove
    {
        public bool IsSelfTarget { get; }
        public int Change { get; }
        public Elements Type { get; }
        public string Name { get; }
        public string Description { get; }

        public AttacKMove(bool isSelfTarget, int change, string name, string description, Elements type)
        {
            IsSelfTarget = isSelfTarget;
            Change = change;
            Type = type;
            Name = name;
            Description = description;
        }

        public void Use(Pokemon target)
        {
            target.UpdateAttack(Change);
        }
    }
}
