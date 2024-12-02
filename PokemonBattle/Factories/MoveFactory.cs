using PokemonBattle.Enums;
using PokemonBattle.Interfaces;
using PokemonBattle.Moves;

namespace PokemonBattle.Factories;

public class MoveFactory
{
    /// <summary>
    /// Returns a IMove object based on inputed string.
    /// </summary>
    /// <param name="moveName">Accepted Entries:
    /// scratch, tackle, vinewhip, ember, watergun, growl, growth, withdraw, tailwhip</param>
    /// <returns>A IMove object</returns>
    /// <exception cref="ArgumentException">Invalid name entered.</exception>
    public IMove Create(string moveName)
    {
        return moveName.ToLower() switch
        {
            "scratch" => new HealthMove(false, -40, "Scratch", "Scratches with sharp claws.", Elements.Normal), 
            "tackle" => new HealthMove(false, -40, "Tackle", "A full-body charge attack.", Elements.Normal),
            "vinewhip" => new HealthMove(false, -40, "Vine Whip", "Whips the foe with vines.", Elements.Grass),
            "ember" => new HealthMove(false, -40, "Ember", "A weak fire attack.", Elements.Fire),
            "watergun" => new HealthMove(false, -40, "Watergun", "Squirts water to attack.", Elements.Water),
            "growl" => new AttackMove(false, -1, "Growl", "Reduces the foe's Attack.", Elements.Normal),
            "growth" => new AttackMove(true, 1, "Growth", "The user's body grows.", Elements.Normal),
            "withdraw" => new DefenceMove(false, 1, "Withdraw", "Withdraws the body into shell.", Elements.Water),
            "tailwhip" => new DefenceMove(true, -1, "Tail Whip", "Lowers the foe's Defense.", Elements.Normal),
            _ => throw new ArgumentException("Invalid moveName")
        };
    }
}