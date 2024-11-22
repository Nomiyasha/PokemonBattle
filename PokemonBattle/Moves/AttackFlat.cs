namespace PokemonBattle
{
    public class AttackFlat : Move
    {
        public AttackFlat(int damage) : base (damage)
        {}
        public override int CalculateDamage(int damage, Pokemon user, Pokemon target)
        {
            // Returns the flat damage (implement attack defence stat later?)
            return damage;
        }
    }
}