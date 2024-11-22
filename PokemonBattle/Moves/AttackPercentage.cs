namespace PokemonBattle
{
    public class AttackPercentage : Move
    {
        public AttackPercentage(int damage) : base (damage)
        {}

        public override int CalculateDamage(int damage, Pokemon user, Pokemon target)
        {
            // Calculates damage as percentage of targets hp.
            return target.Hp / damage;
        }
    }
}