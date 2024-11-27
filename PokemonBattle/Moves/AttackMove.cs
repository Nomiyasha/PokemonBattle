using PokemonBattle.Enums;

namespace PokemonBattle.Moves
{
    public class AttackMove : Move
    {
        public AttackMove(bool isSelfTarget, int change, string name, string description, Elements type) : base(isSelfTarget, change, type, name, description) { }

        public override void Use(Pokemon target)
        {
            target.UpdateAttack(Change);
        }
    }
}
