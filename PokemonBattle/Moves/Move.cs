namespace PokemonBattle
{
    public abstract class Move
    {
        protected int Damage { get; }

        public Move(int damage)
        {
            Damage = damage;
        }
        public void UseMove(Pokemon user, Pokemon target)
        {
            int damage = CalculateDamage(Damage, user, target);
            target.UpdateHealth(damage);
        }

        public abstract int CalculateDamage(int damage, Pokemon user, Pokemon target);
    }
}